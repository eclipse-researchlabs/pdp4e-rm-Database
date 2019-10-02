using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Treatment_Payload")]
    public class TreatmentPayload : EntityBase
    {
        public string Payload { get; set; }
    }
}
