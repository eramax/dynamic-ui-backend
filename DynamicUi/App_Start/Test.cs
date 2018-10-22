using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicUi.App_Start
{
    public class Calc
    {
        public int x { get; set; }
        public int y { get; set; }
        public int calc()
        {
            return x + y;
        }
    }

    public class Calc2
    {
        public int calc(int x , int y)
        {
            return x + y;
        }
    }
}