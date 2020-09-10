using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Database.Enums;
using Core.Database.Models;
using Core.Database.QueryLanguages;
using Core.Database.Tables;
using GraphQL.Types;

namespace Core.Database.Payloads
{
    public class TreatmentPayloadModel
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public List<Evidence> Evidences = new List<Evidence>();


    }
}
