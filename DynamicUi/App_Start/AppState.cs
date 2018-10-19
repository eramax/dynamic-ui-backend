using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicUi.App_Start
{
    public class AppState
    {
        public Dictionary<string, string> Aside = new Dictionary<string, string>();
        public Dictionary<string, AppComponent> Components = new Dictionary<string, AppComponent>();
    }
    public class AppComponent
    {

    }
}