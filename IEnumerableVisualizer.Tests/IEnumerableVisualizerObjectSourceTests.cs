using IEnumerableVisualizerDotNetStandard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace IEnumerableVisualizer.Tests
{
    [TestClass]
    public class IEnumerableVisualizerObjectSourceTests
    {
        [TestMethod]
        public void TestIEnumerableVisualizerObjectSource()
        {
            var ienumerableVisualizerObjectSource = new IEnumerableVisualizerObjectSource();
            Assert.IsNotNull(ienumerableVisualizerObjectSource);
            object objects = new byte[] { Convert.ToByte(0x01), Convert.ToByte(0x01) };
            ienumerableVisualizerObjectSource.GetData(objects, new MemoryStream());
            //Assert.IsNotNull(dataTable);
            //Assert.IsTrue(dataTable.Rows.Count > 1);
        }
    }
}
