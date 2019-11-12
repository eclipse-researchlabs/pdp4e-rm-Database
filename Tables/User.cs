using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("User")]
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string AccountId { get; set; }

        //[Key, Column(Order = 1)]
        public string Email { get; set; }
    }
}
