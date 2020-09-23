using Core.Database.Enums;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace Core.Database.QueryLanguages
{
    public class EvidenceGraphQl : EfObjectGraphType<BeawreContext, Evidence>
    {
        public EvidenceGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.IsDeleted);
            Field(x => x.Payload, true);
            Field(x => x.Name, true);
            Field(x => x.Version);
            Field(x => x.Branch);
            Field(x => x.RootId);

            //Field<TreatmentPayloadModel.TreatmentkPayloadGraphQl>(
            //    name: "payload",
            //    resolve: context =>
            //    {
            //        var dbContext = (BeawreContext)context.UserContext;
            //        var relationships = dbContext.Relationship
            //            .Where(x => x.ToType == ObjectType.TreatmentPayload && x.FromType == ObjectType.Treatment &&
            //                        x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
            //        return JsonConvert.DeserializeObject<TreatmentPayloadModel>(dbContext.TreatmentPayload.FirstOrDefault(x => x.Id == relationships.FirstOrDefault())?.Payload);
            //    });

            Field(x => x.CreatedDateTime);

        }
    }
}
