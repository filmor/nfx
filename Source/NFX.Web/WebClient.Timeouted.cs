/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2014 IT Adapter Inc / 2015 Aum Code LLC
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NFX.Web
{
  public static partial class WebClient
  {



          private class WebClientTimeouted : System.Net.WebClient
          {
            public WebClientTimeouted(IWebClientCaller caller)
            {
              WebSettings.RequireInitializedSettings();
              m_Caller = caller;
            }

            private IWebClientCaller m_Caller;

            protected override WebRequest GetWebRequest(Uri uri)
            {
              var w = base.GetWebRequest(uri) as HttpWebRequest;
              w.Timeout = m_Caller.WebServiceCallTimeoutMs;
              w.KeepAlive = m_Caller.KeepAlive;
              w.Pipelined = m_Caller.Pipelined;
              return w;
            }
          }



  }
}