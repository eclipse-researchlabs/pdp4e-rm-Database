using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Risk_Payload")]
    public class RiskPayload : EntityBase
    {
        public string Payload { get; set; }
    }
}
