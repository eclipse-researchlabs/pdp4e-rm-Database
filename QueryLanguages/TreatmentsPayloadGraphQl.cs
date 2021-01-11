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
using Core.Database.Enums;
using Core.Database.Payloads;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class TreatmentPayloadGraphQl : ObjectGraphType<TreatmentPayload>
    {
        public TreatmentPayloadGraphQl()
        {
            Field(x => x.Id);
            Field(x => x.Payload, true);

            Field<ListGraphType<EvidenceGraphQl>>(
                name: "evidences",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    var relationships = dbContext.Relationship.Where(x => x.ToType == ObjectType.Evidence && x.FromType == ObjectType.TreatmentPayload && x.FromId == context.Source.Id && !x.IsDeleted).Select(x => x.ToId).ToArray();
                    return dbContext.Evidence.Where(x => relationships.Contains(x.Id) && !x.IsDeleted).ToList();
                });

            Field<TreatmentsGraphQl>(
                name: "definition",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    var treatmentId = dbContext.Relationship
                        .FirstOrDefault(x => x.ToType == ObjectType.TreatmentPayload &&
                                             x.FromType == ObjectType.Treatment &&
                                             x.ToId == context.Source.Id && !x.IsDeleted)?.FromId;
                    if (treatmentId == null) return null;
                    return dbContext.Treatment.FirstOrDefault(x => x.Id == treatmentId && !x.IsDeleted);
                });
        }
    }
}