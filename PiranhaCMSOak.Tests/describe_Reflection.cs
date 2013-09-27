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
            public string D { get; set; }
            public string E { get; set; }
        }
        public class C
        {
            public string B { get; set; }
            public string D { get; set; }
            public string E { get; set; }
        }

        void specify_test_CopyProperties()
        {
            A a = new A();
            a.B = "b";
            a.D = "d";
            a.E = "e";
            C c = new C();
            c.B = "b1";
            c.D = "d1";
            c.E = "e1";
            a.CopyProperties(c);
            c.B.should_be("b");
            c.D.should_be("d");
            c.E.should_be("e");
        }
    }
}
