using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Container")]
    public class Container : EntityBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Payload { get; set; }
    }
}
