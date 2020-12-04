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
    public class RelationshipGraphQl : EfObjectGraphType<DatabaseContext, Relationship>
    {
        public RelationshipGraphQl(IEfGraphQLService<DatabaseContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);

            Field(x => x.FromId);
            Field(x => x.ToId);
            Field(x => x.Payload, true);
            Field(x => x.RootId);

            if (Core.Database.Config.Instance == Config.InstanceEnum.Core)
            {
                GetVulnerabilities();
            }
            GetRisks();
            GetTreatments();

            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);

        }

        public FieldType GetRisks()
        {
            return Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.AssetEdge && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
        }

        public FieldType GetVulnerabilities()
        {
            return Field<ListGraphType<VulnerabilityGraphQl>>(
                name: "vulnerabilities",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Vulnerabilitie && x.FromType == ObjectType.AssetEdge && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Vulnerability.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
        }

        public FieldType GetTreatments()
        {
            return Field<ListGraphType<TreatmentPayloadGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext)context.UserContext;

                    var payloadEntryIds = dbContext.Relationship.Where(x =>
                        x.FromType == ObjectType.AssetEdge && x.ToType == ObjectType.TreatmentPayload &&
                        x.FromId == context.Source.Id).Select(x => x.ToId);
                    return dbContext.TreatmentPayload.Where(x => !x.IsDeleted && payloadEntryIds.Contains(x.Id)).ToList();
                });
        }
    }
}
