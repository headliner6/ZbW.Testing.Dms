using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using NUnit.Framework;

namespace ZbW.Testing.Dms.Client.Test.ModelTest
{
    [TestFixture]
    class MetadataItemTest
    {
        [Test]
        public void test()
        {
            var a = new MetadataItem("TestFile", DateTime.Now, "Vertrag", "TestFile zum Testen");
        }
    }
}
