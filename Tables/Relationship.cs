using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Database.Enums;

namespace Core.Database.Tables
{
    [Table("Relationship")]
    public class Relationship : EntityBase
    {
        public ObjectType FromType { get; set; }
        public Guid FromId { get; set; }

        public ObjectType ToType { get; set; }
        public Guid ToId { get; set; }

        public string Payload { get; set; }


    }
}
