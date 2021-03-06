﻿// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database;
using Core.Database.Enums;
using Core.Database.Tables;
using GraphQL.Builders;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class AssetGraphQl : EfObjectGraphType<DatabaseContext, Asset>
    {
        public AssetGraphQl(IEfGraphQLService<DatabaseContext> graphQlService, bool isEmptyLoad = false) : base(graphQlService)
        {
            if (!isEmptyLoad)
            {
                Field(x => x.Id);

                Field(x => x.Name);
                Field(x => x.Description, true);
                Field(x => x.Payload, true);
                Field(x => x.RootId);

                if (Core.Database.Config.Instance == Config.InstanceEnum.Core)
                {
                    GetVulnerabilities();
                }

                GetRisks();
                GetTreatments();
                GetGroups();
                GetEvidences();

                Field(x => x.IsDeleted);
                Field<DateTimeGraphType>(
                    name: "createdDateTime",
                    resolve: context => context.Source.CreatedDateTime);
            }
        }

        public FieldType GetRisks()
        {
            return Field<ListGraphType<RisksGraphQl>>(
                name: "risks",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Risk && x.FromType == ObjectType.Asset && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Risk.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
        }

        public FieldType GetVulnerabilities()
        {
            return Field<ListGraphType<VulnerabilityGraphQl>>(
                name: "vulnerabilities",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Vulnerabilitie && x.FromType == ObjectType.Asset && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Vulnerability.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
        }

        public FieldType GetTreatments()
        {
            return Field<ListGraphType<TreatmentPayloadGraphQl>>(
                name: "treatments",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;

                    var payloadEntryIds = dbContext.Relationship.Where(x =>
                        (x.FromType == ObjectType.Asset || x.FromType == ObjectType.AssetEdge) && x.ToType == ObjectType.TreatmentPayload &&
                        x.FromId == context.Source.Id).Select(x => x.ToId);
                    return dbContext.TreatmentPayload.Where(x => !x.IsDeleted && payloadEntryIds.Contains(x.Id)).ToList();
                });
        }

        public FieldType GetGroups()
        {
            return Field<StringGraphType>(
                name: "group",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    return dbContext.Relationship.FirstOrDefault(x => (x.ToType == ObjectType.Asset || x.ToType == ObjectType.AssetGroup) && x.FromType == ObjectType.AssetGroup && x.ToId == context.Source.Id && !x.IsDeleted)?.FromId;
                });
        }

        public FieldType GetEvidences()
        {
            return Field<ListGraphType<EvidenceGraphQl>>(
                name: "evidences",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Evidence && x.FromType == ObjectType.Asset && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Evidence.Where(x => relationships.Contains(x.RootId) && !x.IsDeleted).ToList().GroupBy(x => x.RootId).Select(x => x.OrderByDescending(y => y.Version).FirstOrDefault());
                });
        }
    }
}