using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Risk")]
    public class Risk : EntityBase
    {

        public string Name { get; set; }
        public string Description { get; set; }
        
        public string Payload { get; set; }
    }
}
