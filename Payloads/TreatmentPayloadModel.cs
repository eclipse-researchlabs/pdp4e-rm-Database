using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database.Enums;
using Core.Database.QueryLanguages;
using Core.Database.Tables;
using GraphQL.Types;

namespace Core.Database.Payloads
{
    public class TreatmentPayloadModel
    {
        public string Description { get; set; }
        public List<Evidence> Evidences = new List<Evidence>();

        public class TreatmentkPayloadGraphQl : ObjectGraphType<TreatmentPayload>
        {
            public TreatmentkPayloadGraphQl()
            {
                Field(x => x.Id);
                Field(x => x.Payload);

                Field<ListGraphType<EvidenceGraphQl>>(
                    name: "evidences",
                    resolve: context =>
                    {
                        var dbContext = (BeawreContext)context.UserContext;
                        var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Evidence && x.FromType == ObjectType.TreatmentPayload && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                        return dbContext.Evidence.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                    });
            }
        }

    }
}
