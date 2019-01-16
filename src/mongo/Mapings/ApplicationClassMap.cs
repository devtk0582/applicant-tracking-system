using ATS.Core.Domain;
using MongoDB.Bson.Serialization;
using System;

namespace ATS.Persistence.Mongo.Mapings
{
    public class ApplicationClassMap
    {
        public static Action<BsonClassMap<Application>> Register => x =>
        {
            x.MapIdProperty(y => y.Id);
            x.AutoMap();
            x.SetIgnoreExtraElements(true);
        };
    }
}
