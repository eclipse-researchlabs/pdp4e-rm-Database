// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

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