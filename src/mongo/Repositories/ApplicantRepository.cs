using ATS.Persistence.Abstractions.Entities;
using ATS.Persistence.Abstractions.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Persistence.Mongo.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly IMongoCollection<Applicant> _applicantCollection;

        public ApplicantRepository(DbContext dbContext)
        {
            _applicantCollection = dbContext.GetCollection<Applicant>();
        }

        public void AddApplicant(Applicant applicant)
        {
            applicant.DateCreated = DateTime.UtcNow;
            applicant.DateUpdated = DateTime.UtcNow;

            _applicantCollection.InsertOne(applicant);
        }

        public async Task AddApplicantAsync(Applicant applicant)
        {
            applicant.DateCreated = DateTime.UtcNow;
            applicant.DateUpdated = DateTime.UtcNow;

            await _applicantCollection.InsertOneAsync(applicant);
        }

        public void DeleteApplicant(Guid id)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, id);
            _applicantCollection.DeleteOne(filter);
        }

        public async Task DeleteApplicantAsync(Guid id)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, id);
            await _applicantCollection.DeleteOneAsync(filter);
        }

        public Applicant GetApplicantById(Guid id)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, id);

            return _applicantCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return _applicantCollection.Find(FilterDefinition<Applicant>.Empty).ToEnumerable();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, applicant.Id);
            var update = Builders<Applicant>.Update
                .Set(x => x.FirstName, applicant.FirstName)
                .Set(x => x.LastName, applicant.LastName)
                .Set(x => x.Email, applicant.Email)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            _applicantCollection.UpdateOne(filter, update);
        }

        public async Task UpdateApplicantAsync(Applicant applicant)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, applicant.Id);
            var update = Builders<Applicant>.Update
                .Set(x => x.FirstName, applicant.FirstName)
                .Set(x => x.LastName, applicant.LastName)
                .Set(x => x.Email, applicant.Email)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            await _applicantCollection.UpdateOneAsync(filter, update);
        }

        public void UpsertApplicant(Applicant applicant)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, applicant.Id);
            var update = Builders<Applicant>.Update
                .SetOnInsert(x => x.DateCreated, DateTime.UtcNow)
                .Set(x => x.FirstName, applicant.FirstName)
                .Set(x => x.LastName, applicant.LastName)
                .Set(x => x.Email, applicant.Email)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            _applicantCollection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public async Task UpsertApplicantAsync(Applicant applicant)
        {
            var filter = Builders<Applicant>.Filter.Eq(x => x.Id, applicant.Id);
            var update = Builders<Applicant>.Update
                .SetOnInsert(x => x.DateCreated, DateTime.UtcNow)
                .Set(x => x.FirstName, applicant.FirstName)
                .Set(x => x.LastName, applicant.LastName)
                .Set(x => x.Email, applicant.Email)
                .Set(x => x.DateUpdated, DateTime.UtcNow);

            await _applicantCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
