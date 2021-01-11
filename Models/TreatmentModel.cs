﻿// /********************************************************************************
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
using Core.Database.Tables;

namespace Core.Database.Models
{
    public class TreatmentModel : Treatment
    {
        public int ClosedDescriptionProbability { get; set; } = 0;

        public TreatmentPayload Payload { get; set; }
    }
}