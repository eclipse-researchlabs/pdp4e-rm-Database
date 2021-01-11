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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database
{
    public class EntityBase
    {
        public EntityBase()
        {
            Branch = "def";
            Version = 1;
            CreatedDateTime = DateTime.Now;
            IsDeleted = false;
        }

        [Key, Column(Order = 0)] public Guid Id { get; set; }

        public string Branch { get; set; }
        public int Version { get; set; }

        public Guid RootId { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public Guid CreateByUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}