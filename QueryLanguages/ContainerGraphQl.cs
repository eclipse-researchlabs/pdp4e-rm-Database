using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database.Enums;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class ContainerGraphQl : EfObjectGraphType<BeawreContext, Container>
    {
        public ContainerGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.RootId);
            Field(x => x.Type, true);
            Field(x => x.Payload, true);

            Field<ListGraphType<AssetGraphQl>>(
                name: "assets",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.FromType == ObjectType.Container && x.ToType == ObjectType.Asset && x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Assets.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field<ListGraphType<RelationshipGraphQl>>(
                name: "edges",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.FromType == ObjectType.Container && x.ToType == ObjectType.AssetEdge && x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Relationship.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field<ListGraphType<AssetGraphQl>>(
                name: "groups",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.FromType == ObjectType.Container && x.ToType == ObjectType.AssetGroup && x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Assets.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var assetsRelationships = dbContext.Relationship.Where(x => !x.IsDeleted && x.FromType == ObjectType.Container && x.FromId == context.Source.RootId && x.ToType == ObjectType.Asset).Select(x => x.ToId).ToArray();
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.Asset && assetsRelationships.Contains(x.FromId) && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });
            Field<ListGraphType<TreatmentsGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var assetsRelationships = dbContext.Relationship.Where(x => !x.IsDeleted && x.FromType == ObjectType.Container && x.FromId == context.Source.RootId && x.ToType == ObjectType.Asset).Select(x => x.ToId).ToArray();
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Treatment && x.FromType == ObjectType.Asset && assetsRelationships.Contains(x.FromId) && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Treatment.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);

        }
    }
}
