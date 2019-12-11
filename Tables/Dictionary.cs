using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Database.Enums;

namespace Core.Database.Tables
{
    [Table("Dictionary")]
    public class Dictionary : EntityBase
    {
        public ObjectType Type { get; set; }

        public string Symbol { get; set; }
        public string Value { get; set; }

        public string Payload { get; set; }
    }
}
