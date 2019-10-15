using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Tables
{
    [Table("AuditTrail")]
    public class AuditTrail : EntityBase
    {
        public AuditTrailAction Action { get; set; }
        public Guid ObjectId { get; set; }

        public string Payload { get; set; }
    }

    public enum AuditTrailAction
    {
        CreateAsset = 1,
        MoveAsset = 2,

        CreateContainer = 100,

        CreateAssetGroup = 200, 
        RemoveAssetGroup = 201,

        GraphQlQuery = 300,

        CreateRisk = 400,

        CreateTreatment = 500,

        CreateVulnerabilities = 600,

        CreateAssetEdge = 700,

        CreateUser = 800,

        CreateRelationship = 900
    }
}
