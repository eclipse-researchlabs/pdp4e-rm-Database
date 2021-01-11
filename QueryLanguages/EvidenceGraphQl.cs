// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

using Core.Database.Enums;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace Core.Database.QueryLanguages
{
    public class EvidenceGraphQl : EfObjectGraphType<DatabaseContext, Evidence>
    {
        public EvidenceGraphQl(IEfGraphQLService<DatabaseContext> graphQlService) : base(graphQlService)
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
            //        var dbContext = (DatabaseContext)context.UserContext;
            //        var relationships = dbContext.Relationship
            //            .Where(x => x.ToType == ObjectType.TreatmentPayload && x.FromType == ObjectType.Treatment &&
            //                        x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
            //        return JsonConvert.DeserializeObject<TreatmentPayloadModel>(dbContext.TreatmentPayload.FirstOrDefault(x => x.Id == relationships.FirstOrDefault())?.Payload);
            //    });

            Field(x => x.CreatedDateTime);
        }
    }
}