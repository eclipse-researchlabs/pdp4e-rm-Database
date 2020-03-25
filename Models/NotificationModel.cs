using System;
using System.Collections.Generic;
using System.Text;
using Core.Database.Enums;
using Core.Database.Tables;
using Newtonsoft.Json.Linq;

namespace Core.Database.Models
{
    public class NotificationPayloadModel
    {
        public string Type { get; set; }
        public int IntValue1 { get; set; } = 1;

        public Guid? GuidValue1 { get; set; }

        public string StringValue1 { get; set; }
        public string StringValue2 { get; set; }
        public string StringValue3 { get; set; }
        public string StringValue4 { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public bool IsRead { get; set; } = false;
    }
}
