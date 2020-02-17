using Microsoft.VisualStudio.DebuggerVisualizers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IEnumerableVisualizerDotNetStandard.Tests
{
    [TestClass]
    public class IEnumerableVisualizerTests
    {
        [TestMethod]
        public void TestShowVisualizer()
        {
            //var objectToVisualize = new List<SerializableObject>();

            //for (int i = 0; i < 500; i++)
            //{
            //    objectToVisualize.Add(new SerializableObject()
            //    {
            //        Columns = new string[] {"1", "2", "3" },
            //        Values = new string[] { i.ToString(), (i + 1).ToString(), (i + 3).ToString() }
            //    });
            //}

            //VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(IEnumerableVisualizer));
            //visualizerHost.ShowVisualizer();
        }

        [TestMethod]
        public void TestShowVisualizerNoData()
        {
            //object objectToVisualize = new List<SerializableObject>();
            //VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(IEnumerableVisualizer));
            //visualizerHost.ShowVisualizer();
        }
    }
}
