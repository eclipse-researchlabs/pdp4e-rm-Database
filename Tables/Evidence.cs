using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Evidence")]
    public class Evidence : EntityBase
    {
        public string Name { get; set; }

        // Type?

        public string Payload { get; set; }
    }
}
