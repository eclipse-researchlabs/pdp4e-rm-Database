using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database.Enums;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Newtonsoft.Json;

namespace Core.Database.QueryLanguages
{
    public class ContainerGraphQl : EfObjectGraphType<BeawreContext, Container>
    {
        public ContainerGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.Version);
            Field(x => x.RootId);
            Field(x => x.Type, true);
            Field(x => x.Payload, true);

            if (Config.Instance == Config.InstanceEnum.Core)
            {
                Field<ListGraphType<AssetGraphQl>>(
                    name: "assets",
                    resolve: context =>
                    {
                        var dbContext = (BeawreContext) context.UserContext;
                        var relationships = dbContext.Relationship.Where(x =>
                                x.FromType == ObjectType.Container &&
                                (x.ToType == ObjectType.Asset || x.ToType == ObjectType.AssetBpmn) &&
                                x.FromId == context.Source.RootId && !x.IsDeleted).ToList()
                            .Select(x => new
                            {
                                x.ToId, x.ToType,
                                payload = (x.ToType == ObjectType.Asset
                                    ? JsonConvert.DeserializeObject<AssetPayloadModel>(x.Payload ?? "{}")
                                    : null)
                            });
                        var assetIds = relationships.Select(x => x.ToId).ToArray();
                        var assets = dbContext.Assets.Where(x => assetIds.Contains(x.Id) && !x.IsDeleted).ToList();
                        foreach (var asset in assets)
                        {
                            var relationship = relationships.FirstOrDefault(x => x.ToId == asset.Id);
                            if (relationship.ToType == ObjectType.Asset)
                            {
                                var payload = JsonConvert.DeserializeObject<AssetPayloadModel>(asset.Payload ?? "{}");
                                if (!string.IsNullOrEmpty(relationship.payload.X)) payload.X = relationship.payload.X;
                                if (!string.IsNullOrEmpty(relationship.payload.Y)) payload.Y = relationship.payload.Y;
                                asset.Payload = JsonConvert.SerializeObject(payload);
                            }
                        }

                        return assets;
                    });

                Field<ListGraphType<AssetGraphQl>>(
                    name: "groups",
                    resolve: context =>
                    {
                        var dbContext = (BeawreContext)context.UserContext;
                        var relationships = dbContext.Relationship.Where(x => x.FromType == ObjectType.Container && (x.ToType == ObjectType.AssetGroup || x.ToType == ObjectType.AssetGroupBpmn) && x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                        return dbContext.Assets.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                    });
            }

            if (Core.Database.Config.Instance == Config.InstanceEnum.Core)
            {
                Field<ListGraphType<RelationshipGraphQl>>(
                    name: "edges",
                    resolve: context =>
                    {
                        var dbContext = (BeawreContext) context.UserContext;
                        var relationships = dbContext.Relationship.Where(x =>
                            x.FromType == ObjectType.Container &&
                            (x.ToType == ObjectType.AssetEdge || x.ToType == ObjectType.AssetEdgeBpmn) &&
                            x.FromId == context.Source.RootId && !x.IsDeleted).Select(x => x.ToId).ToArray();
                        return dbContext.Relationship.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                    });
            }

            Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var assetsRelationships = dbContext.Relationship.Where(x => !x.IsDeleted && x.FromType == ObjectType.Container && x.FromId == context.Source.RootId && x.ToType == ObjectType.Asset).Select(x => x.ToId).ToArray();
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.Asset && assetsRelationships.Contains(x.FromId) && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });
            Field<ListGraphType<TreatmentPayloadGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (BeawreContext)context.UserContext;
                    var assetsRelationships = dbContext.Relationship.Where(x => !x.IsDeleted && x.FromType == ObjectType.Container && x.FromId == context.Source.RootId && x.ToType == ObjectType.Asset).Select(x => x.ToId).ToArray();
                    var payloadIds = dbContext.Relationship.Where(x => x.ToType == ObjectType.TreatmentPayload && x.FromType == ObjectType.Asset && assetsRelationships.Contains(x.FromId) && !x.IsDeleted).Select(x => x.ToId).ToList();

                    var edgesRelationships = dbContext.Relationship.Where(x => !x.IsDeleted && x.FromType == ObjectType.Container && x.FromId == context.Source.RootId && x.ToType == ObjectType.AssetEdge).Select(x => x.ToId).ToArray();
                    payloadIds.AddRange(dbContext.Relationship.Where(x => x.ToType == ObjectType.TreatmentPayload && x.FromType == ObjectType.Asset && edgesRelationships.Contains(x.FromId) && !x.IsDeleted).Select(x => x.ToId).ToList());

                    return dbContext.TreatmentPayload.Where(x => payloadIds.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field(x => x.IsDeleted);
            Field(x => x.CreatedDateTime);

        }
    }
}
