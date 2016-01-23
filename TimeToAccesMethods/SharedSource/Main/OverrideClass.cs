using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeToAccesMethods
{
    class OverrideClass: MyClass
    {
        public override void MyMethod()
        {
            int i = 0;
            i++;
        }
    }
}
