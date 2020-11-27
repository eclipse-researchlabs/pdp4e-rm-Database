using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("Asset")]
    public class Asset : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsGroup { get; set; } = false;

        public string Payload { get; set; }

    }

    public class AssetPayloadModel {
        public string Type { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
        public string Size { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Icon { get; set; }
        public string Src { get; set; }
        public string LabelOffsetY { get; set; }
        public object DfdQuestionaire { get; set; }
        public int GeneratingVRT { get; set; }

    }
}
