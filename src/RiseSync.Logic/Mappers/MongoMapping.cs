using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiseSync.Logic.Mappers
{
    public static class MongoMapping 
    {
        public static void Mapper()
        {
            BsonClassMap.RegisterClassMap<Supply>( map =>
            {
                map.AutoMap();
                map.MapIdMember(s => s.Id);
                map.UnmapMember(s => s.Id);
                map.MapMember(s => s.Price).SetSerializer(new DecimalSerializer(BsonType.Decimal128));
            });
        }
    }
}
