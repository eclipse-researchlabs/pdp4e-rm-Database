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
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Database.Enums;

namespace Core.Database.Tables
{
    [Table("Dictionary")]
    public class Dictionary : EntityBase
    {
        public ObjectType Type { get; set; }

        public string Symbol { get; set; }
        public string Value { get; set; }

        public string Payload { get; set; }
    }
}