using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database.Models
{
    public class AssetEdgePayloadModel
    {
        public string Name { get; set; }
        public string Shape { get; set; }
        public int Asset1Anchor { get; set; }
        public int Asset2Anchor { get; set; }
    }
}
