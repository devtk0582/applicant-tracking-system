using ATS.Core.Domain;
using MongoDB.Bson.Serialization;
using System;

namespace ATS.Persistence.Mongo.Mapings
{
    public class ApplicantClassMap
    {
        public static Action<BsonClassMap<Applicant>> Register => x =>
        {
            x.MapIdProperty(y => y.Id);
            x.AutoMap();
            x.SetIgnoreExtraElements(true);
        };
    }
}
