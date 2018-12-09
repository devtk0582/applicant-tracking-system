using ATS.Persistence.Abstractions.Entities;
using ATS.Persistence.Abstractions.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Persistence.Mongo.Repositories
{
    public class RequisitionRepository : IRequisitionRepository
    {
        private readonly IMongoCollection<Requisition> _requisitionCollection;

        public RequisitionRepository(DbContext dbContext)
        {
            _requisitionCollection = dbContext.GetCollection<Requisition>();
        }

        public void AddRequisition(Requisition requisition)
        {
            requisition.DateCreated = DateTime.UtcNow;
            requisition.DateUpdated = DateTime.UtcNow;

            _requisitionCollection.InsertOne(requisition);
        }

        public async Task AddRequisitionAsync(Requisition requisition)
        {
            requisition.DateCreated = DateTime.UtcNow;
            requisition.DateUpdated = DateTime.UtcNow;

            await _requisitionCollection.InsertOneAsync(requisition);
        }

        public void DeleteRequisition(Guid id)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, id);

            _requisitionCollection.DeleteOne(filter);
        }

        public async Task DeleteRequisitionAsync(Guid id)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, id);

            await _requisitionCollection.DeleteOneAsync(filter);
        }

        public Requisition GetRequisitionById(Guid id)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, id);

            return _requisitionCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Requisition> GetRequisitions()
        {
            return _requisitionCollection.Find(FilterDefinition<Requisition>.Empty).ToEnumerable();
        }

        public void UpdateRequisition(Requisition requisition)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, requisition.Id);
            var update = Builders<Requisition>.Update
                .Set(x => x.JobId, requisition.JobId)
                .Set(x => x.Name, requisition.Name)
                .Set(x => x.Description, requisition.Description)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            _requisitionCollection.UpdateOne(filter, update);
        }

        public async Task UpdateRequisitionAsync(Requisition requisition)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, requisition.Id);
            var update = Builders<Requisition>.Update
                .Set(x => x.JobId, requisition.JobId)
                .Set(x => x.Name, requisition.Name)
                .Set(x => x.Description, requisition.Description)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            await _requisitionCollection.UpdateOneAsync(filter, update);
        }

        public void UpsertRequisition(Requisition requisition)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, requisition.Id);
            var update = Builders<Requisition>.Update
                .SetOnInsert(x => x.DateCreated, DateTime.UtcNow)
                .Set(x => x.JobId, requisition.JobId)
                .Set(x => x.Name, requisition.Name)
                .Set(x => x.Description, requisition.Description)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            _requisitionCollection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public async Task UpsertRequisitionAsync(Requisition requisition)
        {
            var filter = Builders<Requisition>.Filter.Eq(x => x.Id, requisition.Id);
            var update = Builders<Requisition>.Update
                .SetOnInsert(x => x.DateCreated, DateTime.UtcNow)
                .Set(x => x.JobId, requisition.JobId)
                .Set(x => x.Name, requisition.Name)
                .Set(x => x.Description, requisition.Description)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            await _requisitionCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
