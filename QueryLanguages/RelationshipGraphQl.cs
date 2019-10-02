using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database;
using Core.Database.Enums;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class RelationshipGraphQl : EfObjectGraphType<BeawreContext, Relationship>
    {
        public RelationshipGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);

            Field(x => x.FromId, true);
            Field(x => x.ToId, true);
            Field(x => x.Payload, true);

            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);

        }
    }
}
