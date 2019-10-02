using System;
using System.Collections.Generic;
using System.Text;
using Core.Database.Tables;

namespace Core.Database.Models
{
    public class TreatmentModel : Treatment
    {
        public int ClosedDescriptionProbability { get; set; } = 0;
    }
}
