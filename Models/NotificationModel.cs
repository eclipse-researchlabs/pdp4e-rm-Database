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

        public Guid? GuidValue1 { get; set; }

        public string StringValue1 { get; set; }

        public string StringValue2 { get; set; }
    }
}
