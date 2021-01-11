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
using Core.Database.Models;
using Core.Database.QueryLanguages;
using Core.Database.Tables;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Users.Implementation.QueryLanguages
{
    public class UserGraphQl : EfObjectGraphType<DatabaseContext, User>
    {
        public UserGraphQl(IEfGraphQLService<DatabaseContext> graphQlService) : base(graphQlService)
        {
            Field(x => x.Id);
            Field(x => x.Username);
            Field(x => x.Email);
            Field(x => x.IsDeleted);
            Field(x => x.Payload, true);
            Field(x => x.CreatedDateTime);

            Field<ListGraphType<NotificationGraphQl>>(
                name: "notifications",
                resolve: context =>
                {
                    var dbContext = (DatabaseContext) context.UserContext;
                    return dbContext.Relationship
                        .Where(x => !x.IsDeleted && x.FromType == ObjectType.User && x.ToType == ObjectType.Notification &&
                                    x.FromId == context.Source.Id).OrderByDescending(x => x.CreatedDateTime).ToList();
                }
            );
        }
    }
}