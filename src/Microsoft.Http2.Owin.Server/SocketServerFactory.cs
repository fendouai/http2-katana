﻿// Copyright © Microsoft Open Technologies, Inc.
// All Rights Reserved       
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0

// THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT.

// See the Apache 2 License for the specific language governing permissions and limitations under the License.
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Microsoft.Http2.Owin.Server
{
    using AppFunc = Func<IOwinContext, Task>;

    public class SocketServerFactory
    {
        public static void Initialize(IDictionary<string, object> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }
        }

        // todo pass ServerOptions insted of properties
        public static IDisposable Create(AppFunc app, IDictionary<string, object> properties)
        {
            var isDirectEnabled = ServerOptions.IsDirectEnabled;
            var serverName = ServerOptions.ServerName;
            properties.Add(Strings.DirectEnabled, isDirectEnabled);
            properties.Add(Strings.ServerName, serverName);
            return new HttpSocketServer(app, properties);
        }
    }
}
