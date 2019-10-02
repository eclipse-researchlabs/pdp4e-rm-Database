using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database.Enums
{
    public enum ObjectType
    {
        Asset = 100,
        AssetGroup = 600,
        Vulnerabilitie = 200, 
        Risk = 300, 
        RiskPayload = 310,
        Treatment = 400,
        TreatmentPayload = 410,
        AssetEdge = 700,
        Evidence = 800
    }
}
