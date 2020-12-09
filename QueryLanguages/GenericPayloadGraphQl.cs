using System;
using System.Collections.Generic;
using System.Text;
using Core.Database.Payloads;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class GenericPayloadModel
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }

    public class GenericPayloadGraphQl : ObjectGraphType<GenericPayloadModel>
    {
        public GenericPayloadGraphQl()
        {
            Field<StringGraphType>("input", resolve: x => x.Source.Input);
            Field<StringGraphType>("output", resolve: x => x.Source.Output);
        }
    }

}
