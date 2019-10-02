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

    public class RisksGraphQl : EfObjectGraphType<BeawreContext, Risk>
    {
        public RisksGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);

            Field<RiskPayloadModelGraphQl>(
                name: "payload",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.RiskPayload && x.FromType == ObjectType.Risk && x.FromId == context.Source.Id && !x.IsDeleted).OrderByDescending(x => x.CreatedDateTime).Select(x => x.ToId).ToArray();
                    var payload = dbContext.RiskPayload.FirstOrDefault(x => x.Id == relationships.FirstOrDefault()).Payload;
                    return string.IsNullOrEmpty(payload) ? new RiskPayloadModel() : JsonConvert.DeserializeObject<RiskPayloadModel>(payload);
                });

            Field<ListGraphType<VulnerabilityGraphQl>>(
                name: "vulnerabilities",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Vulnerabilitie && x.FromType == ObjectType.Risk && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Vulnerability.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });
            Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.Risk && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });
            Field<ListGraphType<TreatmentsGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Treatment && x.FromType == ObjectType.Risk && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Treatment.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);

        }
    }

    public class RiskPayloadGraphQl : EfObjectGraphType<BeawreContext, RiskPayload>
    {
        public RiskPayloadGraphQl(IEfGraphQLService<BeawreContext> efGraphQlService) : base(efGraphQlService)
        {
            Field(x => x.Id);
            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);
        }
    }
}
