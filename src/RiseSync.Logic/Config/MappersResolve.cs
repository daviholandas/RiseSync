using Dapper.FluentMap;
using RiseSync.Logic.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiseSync.Logic.Config
{
    public static class MappersResolve
    {
        

        public static void ResolveMappers()
        {
            MongoMapping.Mapper();

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new SqlMapping());
            });
        }
    }
}
