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
using System.Linq;
using System.Text;
using Core.Database.Enums;
using Core.Database.Models;
using Core.Database.QueryLanguages;
using Core.Database.Tables;
using GraphQL.Types;

namespace Core.Database.Payloads
{
    public class TreatmentPayloadModel
    {
        public List<Evidence> Evidences = new List<Evidence>();
        public string Status { get; set; }
        public string Description { get; set; }
    }
}