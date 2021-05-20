using MicroMachines.Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Catalog.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly IMongoCollection<T> _dbCollection;

        public BaseRepository(IMongoCollection<T> dbCollection)
        {
            _dbCollection = dbCollection;
        }

        public async Task Add(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            var deleteResult = await _dbCollection
                .DeleteOneAsync(filter: x => x.Id == entity.Id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Edit(T entity)
        {
            var updateResult = await _dbCollection
                .ReplaceOneAsync(filter: x => x.Id == entity.Id, replacement: entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbCollection.Find(x => true).ToListAsync();
        }

        public async Task<T> GetSingle(Guid id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
