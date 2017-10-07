using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace bc.cores.repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected Type DataType => typeof(T);
        protected IDbConnection Connection;
        protected IDbTransaction Transaction;
        protected string ConnectionString;

        protected BaseRepository(IConfiguration conf)
        {
            ConnectionString = conf.GetConnectionString("DefaultConnection");
            Connection = new SqlConnection(ConnectionString);
            Transaction = Connection.BeginTransaction();
        }

        public bool Is<TRepository>(TRepository repo) where TRepository : class
        {
            return typeof(TRepository).FullName == DataType.FullName;
        }

        public T Get(Guid id)
        {
            var tableName = typeof(T).Name;
            return Connection
                .Query<T>(
                    $"SELECT * FROM [{tableName}] WHERE Id = @Id",
                    @param: new { Id = id },
                    transaction: Transaction)
                .FirstOrDefault();
        }

        public IEnumerable<T> GetMany(params Guid[] ids)
        {
            var tableName = typeof(T).Name;
            return Connection
                .Query<T>(
                    $"SELECT * FROM [{tableName}] WHERE Id IN @IdS",
                    @param: new { Ids = ids },
                    transaction: Transaction);
        }

        public IEnumerable<T> All(int? limit, int? offset)
        {
            var tableName = typeof(T).Name;
            limit = limit ?? 100;
            offset = offset ?? 0;
            return Connection
                .Query<T>(
                    $@"SELECT * FROM [{tableName}]
ORDER BY [Id]
OFFSET {offset} ROWS
FETCH NEXT {limit} ROWS ONLY;",
                    transaction: Transaction);
        }

        public Guid Create(DynamicParameters @params)
        {
            var tableName = typeof(T).Name;
            var columns = string.Join(", ", @params.ParameterNames);
            var values = string.Join(", ", @params.ParameterNames.Select(p => $"@{p}"));

            var sql = $"INSERT INTO [{tableName}] ({columns}) VALUES ({values}); SELECT SCOPE_IDENTITY();";
            return Connection
                .Query<Guid>(
                    sql,
                    @param: @params,
                    transaction: Transaction)
                    .FirstOrDefault();
        }

        public IEnumerable<Guid> CreateMany(IEnumerable<DynamicParameters> @params)
        {
            return @params.Select(Create).ToList();
        }

        public void Delete(Guid id)
        {
            var tableName = typeof(T).Name;
            Connection
                .Execute(
                    $"DELETE FROM [{tableName}] WHERE Id = @Id",
                    @param: new { Id = id },
                    transaction: Transaction);
        }

        public void DeleteMany(params Guid[] ids)
        {
            var tableName = typeof(T).Name;
            Connection
                .Execute(
                    $"DELETE FROM [{tableName}] WHERE Id IN @Ids",
                    @param: new { Ids = ids },
                    transaction: Transaction);
        }

        public void Update(Guid id, DynamicParameters @params)
        {
            var tableName = typeof(T).Name;
            var setters = string.Join(", ", @params.ParameterNames.Select(param => $"{param} = @{param}"));
            var sql = $"UPDATE {tableName} SET {setters} WHERE Id = @Id";
            // make sure that @Id is included
            @params.Add("Id", id);
            Connection
                .Execute(
                    sql,
                    @param: @params,
                    transaction: Transaction);
        }

        public void UpdateMany(IDictionary<Guid, DynamicParameters> @params)
        {
            foreach (var param in @params)
            {
                Update(param.Key, param.Value);
            }
        }

        public void Commit()
        {
            Transaction?.Commit();
        }

        public void RollBack()
        {
            Transaction?.Rollback();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}