using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeToAccessMethods
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
