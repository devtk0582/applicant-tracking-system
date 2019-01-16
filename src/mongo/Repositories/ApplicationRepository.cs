using ATS.Core.Domain;
using ATS.Persistence.Abstractions.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATS.Persistence.Mongo.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IMongoCollection<Application> _applicationCollection;

        public ApplicationRepository(DbContext dbContext)
        {
            _applicationCollection = dbContext.GetCollection<Application>();
        }

        public void AddApplication(Application application)
        {
            application.DateCreated = DateTime.UtcNow;
            application.DateUpdated = DateTime.UtcNow;

            _applicationCollection.InsertOne(application);
        }

        public async Task AddApplicationAsync(Application application)
        {
            application.DateCreated = DateTime.UtcNow;
            application.DateUpdated = DateTime.UtcNow;

            await _applicationCollection.InsertOneAsync(application);
        }

        public void DeleteApplication(Guid id)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, id);
            _applicationCollection.DeleteOne(filter);
        }

        public async Task DeleteApplicationAsync(Guid id)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, id);
            await _applicationCollection.DeleteOneAsync(filter);
        }

        public Application GetApplicationById(Guid id)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, id);

            return _applicationCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Application> GetApplications()
        {
            return _applicationCollection.Find(FilterDefinition<Application>.Empty).ToEnumerable();
        }

        public void UpdateApplication(Application application)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, application.Id);
            var update = Builders<Application>.Update
                .Set(x => x.ApplicantId, application.ApplicantId)
                .Set(x => x.RequisitionId, application.RequisitionId)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            _applicationCollection.UpdateOne(filter, update);
        }

        public async Task UpdateApplicationAsync(Application application)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, application.Id);
            var update = Builders<Application>.Update
                .Set(x => x.ApplicantId, application.ApplicantId)
                .Set(x => x.RequisitionId, application.RequisitionId)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            await _applicationCollection.UpdateOneAsync(filter, update);
        }

        public void UpsertApplication(Application application)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, application.Id);
            var update = Builders<Application>.Update
                .SetOnInsert(x => x.DateCreated, DateTime.UtcNow)
                .Set(x => x.ApplicantId, application.ApplicantId)
                .Set(x => x.RequisitionId, application.RequisitionId)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            _applicationCollection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public async Task UpsertApplicationAsync(Application application)
        {
            var filter = Builders<Application>.Filter.Eq(x => x.Id, application.Id);
            var update = Builders<Application>.Update
                .SetOnInsert(x => x.DateCreated, DateTime.UtcNow)
                .Set(x => x.ApplicantId, application.ApplicantId)
                .Set(x => x.RequisitionId, application.RequisitionId)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            await _applicationCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
