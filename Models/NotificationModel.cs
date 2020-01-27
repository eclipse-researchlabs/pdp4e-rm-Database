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
        public NotificationTypes Type { get; set; }
        public Guid? GuidValue1 { get; set; }
    }
}
