using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database;
using Core.Database.Enums;
using Core.Database.Payloads;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using Newtonsoft.Json;

namespace Core.Database.QueryLanguages
{

    public class TreatmentsGraphQl : EfObjectGraphType<BeawreContext, Treatment>
    {
        public TreatmentsGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Type);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.IsDeleted);

            Field<TreatmentPayloadModel.TreatmentkPayloadGraphQl>(
                name: "payload",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship
                        .Where(x => x.ToType == ObjectType.TreatmentPayload && x.FromType == ObjectType.Treatment &&
                                    x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.TreatmentPayload.FirstOrDefault(x => x.Id == relationships.FirstOrDefault());
                });

            Field(x => x.CreatedDateTime);

        }
    }
}
