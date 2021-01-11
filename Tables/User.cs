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

namespace Core.Database.Tables
{
    [Table("User")]
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string AccountId { get; set; }

        //[Key, Column(Order = 1)]
        public string Email { get; set; }

        public string Payload { get; set; }
    }
}