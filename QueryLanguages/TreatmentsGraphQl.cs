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
    public class TreatmentsGraphQl : EfObjectGraphType<DatabaseContext, Treatment>
    {
        public TreatmentsGraphQl(IEfGraphQLService<DatabaseContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Type, true);
            Field(x => x.Name, true);
            Field(x => x.Description, true);
            Field(x => x.IsDeleted);
            Field(x => x.RootId);

            Field<TreatmentPayloadGraphQl>(
                name: "payload",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    var relationships = dbContext.Relationship
                        .Where(x => x.ToType == ObjectType.TreatmentPayload && x.FromType == ObjectType.Treatment &&
                                    x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.TreatmentPayload.FirstOrDefault(x => x.Id == relationships.FirstOrDefault());
                });

            Field<DateTimeGraphType>(
                name: "createdDateTime",
                resolve: context => context.Source.CreatedDateTime);
        }
    }
}