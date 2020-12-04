using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database;
using Core.Database.Enums;
using Core.Database.Payloads;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Newtonsoft.Json;

namespace Core.Database.QueryLanguages
{

    public class RisksGraphQl : EfObjectGraphType<DatabaseContext, Risk>
    {
        public RisksGraphQl(IEfGraphQLService<DatabaseContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.Description, true);
            Field(x => x.RootId);

            Field<RiskPayloadModelGraphQl>(
                name: "payload",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;
                    var riskPayloadId = dbContext.Relationship.FirstOrDefault(x => x.ToType == ObjectType.RiskPayload && x.FromType == ObjectType.Risk && x.FromId == context.Source.RootId && !x.IsDeleted)?.ToId;
                    if (riskPayloadId == null) return new RiskPayloadModel();
                    var payload = dbContext.RiskPayload.Where(x => x.RootId == riskPayloadId).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault()).FirstOrDefault()?.Payload;
                    return string.IsNullOrEmpty(payload) ? new RiskPayloadModel() : JsonConvert.DeserializeObject<RiskPayloadModel>(payload);
                });

            Field<ListGraphType<VulnerabilityGraphQl>>(
                name: "vulnerabilities",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Vulnerabilitie && x.FromType == ObjectType.Risk && x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Vulnerability.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
            Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.Risk && x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });

            Field<ListGraphType<TreatmentPayloadGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;

                    var payloadEntryIds = dbContext.Relationship.Where(x =>
                        x.FromType == ObjectType.Risk && x.ToType == ObjectType.TreatmentPayload &&
                        x.FromId == context.Source.RootId).Select(x => x.ToId);
                    return dbContext.TreatmentPayload.Where(x => !x.IsDeleted && payloadEntryIds.Contains(x.RootId)).ToList();
                });

            Field(x => x.IsDeleted);
            Field<DateTimeGraphType>(
                name: "createdDateTime",
                resolve: context => context.Source.CreatedDateTime);

        }
    }

    public class RiskPayloadGraphQl : EfObjectGraphType<DatabaseContext, RiskPayload>
    {
        public RiskPayloadGraphQl(IEfGraphQLService<DatabaseContext> efGraphQlService) : base(efGraphQlService)
        {
            Field(x => x.Id);
            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);
        }
    }
}
