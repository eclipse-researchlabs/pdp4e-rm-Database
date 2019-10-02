using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Treatment")]
    public class Treatment : EntityBase
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
    }
}
