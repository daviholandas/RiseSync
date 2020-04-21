using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiseSync.Logic.Mappers
{
    public class SqlMapping : EntityMap<Supply>
    {
        public SqlMapping()
        {
            Map(s => s.Id).ToColumn("IN_ID");
            Map(s => s.Code).ToColumn("IN_COD");
            Map(s => s.Name).ToColumn("IN_NOM");
            Map(s => s.Price).ToColumn("IN_VALOR");
            Map(s => s.CategoryCode).ToColumn("IN_SUBGR");
            Map(s => s.Category).ToColumn("Category");
        }
    }
}
