using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database.Enums;
using Core.Database.Models;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class NotificationGraphQl : EfObjectGraphType<DatabaseContext, Relationship>
    {
        public NotificationGraphQl(IEfGraphQLService<DatabaseContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Payload, true);
            Field(x => x.CreatedDateTime);
        }
    }
}
