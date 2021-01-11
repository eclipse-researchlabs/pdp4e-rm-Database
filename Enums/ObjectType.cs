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

namespace Core.Database.Enums
{
    public enum ObjectType
    {
        Asset = 100,
        AssetGroup = 600,
        AssetGroupBpmn = 610,
        AssetBpmn = 110,
        Vulnerabilitie = 200,
        Risk = 300,
        RiskPayload = 310,
        Treatment = 400,
        TreatmentPayload = 410,
        Container = 500,
        AssetEdge = 700,
        AssetEdgeBpmn = 710,
        Evidence = 800,
        Role = 900,
        User = 1000,
        SecurityGroup = 1100,
        SecurityAccess = 1200,
        Branch = 1300,
        SubContractor = 1400,
        Notification = 1500,
        BpmnModel = 1600,
        Comments = 1700,
        Flight = 1800,
        Equipment = 1900,
        WeeklyReport = 2000,
        RiskStatusReport = 2010,
    }
}