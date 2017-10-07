using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetMany(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> All(int? limit, int? offset)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, DynamicParameters @params)
        {
            throw new NotImplementedException();
        }

        public void UpdateMany(IDictionary<Guid, DynamicParameters> @params)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}