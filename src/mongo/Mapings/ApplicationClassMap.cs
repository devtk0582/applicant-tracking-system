using ATS.Persistence.Abstractions.Entities;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

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
