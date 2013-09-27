using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oak;
using PiranhaCMSOak.Support;

namespace PiranhaCMSOak.Tests
{
    class describe_Reflection : nspec
    {
        public class A
        {
            public string B { get; set; }
        }
        public class C
        {
            public string B { get; set; }
        }

        void specify_test_CopyProperties()
        {
            A a = new A();
            a.B = "b";
            C c = new C();
            a.CopyProperties(c);
            a.B.should_be("b");
        }
    }
}
