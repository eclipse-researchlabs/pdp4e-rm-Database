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
    public class AssetGraphQl : EfObjectGraphType<BeawreContext, Asset>
    {
        public AssetGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);

            Field(x => x.Name);
            Field(x => x.Description, true);
            Field(x => x.Payload, true);
            Field(x => x.RootId);

            Field<ListGraphType<VulnerabilityGraphQl>>(
                name: "vulnerabilities",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Vulnerabilitie && x.FromType == ObjectType.Asset && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Vulnerability.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
            Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.Asset && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
            Field<ListGraphType<TreatmentsGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Treatment && x.FromType == ObjectType.Asset && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Treatment.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });

            Field<StringGraphType >(
                name: "group",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    return dbContext.Relationship.FirstOrDefault(x => x.ToType == ObjectType.Asset && x.FromType == ObjectType.AssetGroup && x.ToId == context.Source.Id && !x.IsDeleted)?.FromId;
                });

            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);

        }
    }
}
