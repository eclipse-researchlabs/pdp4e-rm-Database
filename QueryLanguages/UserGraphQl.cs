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
    public class UserGraphQl : EfObjectGraphType<BeawreContext, User>
    {
        public UserGraphQl(IEfGraphQLService<BeawreContext> graphQlService) : base(graphQlService)
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
                    var dbContext = (BeawreContext)context.UserContext;
                    return dbContext.Relationship
                        .Where(x => x.FromType == ObjectType.User && x.ToType == ObjectType.Notification &&
                                    x.FromId == context.Source.Id).OrderByDescending(x => x.CreatedDateTime).ToList();
                }
            );
        }
    }
}
