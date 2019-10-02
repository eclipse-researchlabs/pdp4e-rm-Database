using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database
{
    public class EntityBase
    {
        [Key, Column(Order = 0)]
        public Guid Id { get; set; }

        public string Branch { get; set; }
        public int Version { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public Guid CreateByUserId { get; set; }

        public bool IsDeleted { get; set; }

        public EntityBase()
        {
            Branch = "def";
            Version = 1;
            CreatedDateTime = DateTime.Now;
            IsDeleted = false;
        }

    }
}
