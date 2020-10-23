using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphQL.Types;
using Newtonsoft.Json;

namespace Core.Database.Payloads
{
    public class RiskPayloadModel
    {
        [JsonProperty("StrideCategory", NullValueHandling = NullValueHandling.Include)]
        public string StrideCategory { get; set; }

        [JsonProperty("LindunCategory", NullValueHandling = NullValueHandling.Include)]
        public string LindunCategory { get; set; }

        public string Impact { get; set; }
        public string Likelihood { get; set; }

        public string ImpactText { get; set; }
        public string LikelihoodText { get; set; }

        public bool PrivacyExtensionEnabled { get; set; }
        public bool IsQuantitiveEnabled { get; set; }

        public string Status { get; set; }
        public string StatusAdditionalData1 { get; set; }

        public List<OwaspDictionary> Owasp { get; set; }
    }

    public class RiskPayloadModelGraphQl : ObjectGraphType<RiskPayloadModel>
    {
        public RiskPayloadModelGraphQl()
        {
            Field<StringGraphType>("impact", resolve: x => x.Source.Impact);
            Field<StringGraphType>("impactText", resolve: x => x.Source.ImpactText);
            Field<StringGraphType>("likelihood", resolve: x => x.Source.Likelihood);
            Field<StringGraphType>("likelihoodText", resolve: x => x.Source.LikelihoodText);
            Field<StringGraphType>("stride", resolve: x => x.Source.StrideCategory);
            Field<StringGraphType>("lindun", resolve: x => x.Source.LindunCategory);
            Field<StringGraphType>("privacyExtensionEnabled", resolve: x => x.Source.PrivacyExtensionEnabled);
            Field<StringGraphType>("isQuantitiveEnabled", resolve: x => x.Source.IsQuantitiveEnabled);
            Field<StringGraphType>("status", resolve: x => x.Source.Status);
            Field<StringGraphType>("statusAdditionalData1", resolve: x => x.Source.StatusAdditionalData1);
            Field<ListGraphType<OwaspDictionaryGraphType>>("owasp", resolve: x => x.Source.Owasp);
        }
    }

    [Serializable]
    public class OwaspDictionary
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class OwaspDictionaryGraphType : ObjectGraphType<OwaspDictionary>
    {
        public OwaspDictionaryGraphType()
        {
            Field<StringGraphType>("name", resolve: x => x.Source.Name);
            Field<IntGraphType>("value", resolve: x => x.Source.Value);
        }
    }
}
