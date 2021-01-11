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

namespace Core.Database.Models
{
    public class AssetEdgePayloadModel
    {
        public string Name { get; set; }
        public string Shape { get; set; }
        public int Asset1Anchor { get; set; }
        public int Asset2Anchor { get; set; }
    }
}