using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Config
    {
        public static InstanceEnum Instance { get; set; } = InstanceEnum.Core;

        public enum InstanceEnum
        {
            Core,
            Pro
        }
    }
}
