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
    [Table("Relationship")]
    public class Relationship : EntityBase
    {
        public ObjectType FromType { get; set; }
        public Guid FromId { get; set; }

        public ObjectType ToType { get; set; }
        public Guid ToId { get; set; }

        public string Payload { get; set; }
    }
}