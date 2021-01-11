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
using Core.Database.Payloads;
using GraphQL.Types;

namespace Core.Database.QueryLanguages
{
    public class GenericPayloadModel
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }

    public class GenericPayloadGraphQl : ObjectGraphType<GenericPayloadModel>
    {
        public GenericPayloadGraphQl()
        {
            Field<StringGraphType>("input", resolve: x => x.Source.Input);
            Field<StringGraphType>("output", resolve: x => x.Source.Output);
        }
    }
}