using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace bc.cores.repositories
{
    public interface IRepository<T>: IDisposable
        where T: class
    {
        // Factories
        bool Is<TRepository>(TRepository repo) where TRepository: class;

        T Get(Guid id);
        IEnumerable<T> GetMany(params Guid[] ids);
        IEnumerable<T> All(int? limit, int? offset);
        Guid Create(DynamicParameters @params);
        IEnumerable<Guid> CreateMany(IEnumerable<DynamicParameters> @params);
        void Delete(Guid id);
        void DeleteMany(params Guid[] ids);
        void Update(Guid id, DynamicParameters @params);
        void UpdateMany(IDictionary<Guid, DynamicParameters> @params);
        void Commit();
        void RollBack();
    }
}
