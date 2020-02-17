using Microsoft.VisualStudio.DebuggerVisualizers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace IEnumerableVisualizerDotNetStandard.Tests
{
    [TestClass]
    public class IEnumerableVisualizerTests
    {
        [TestMethod]
        public void TestShowVisualizer()
        {
            var objectToVisualize = new DataTable();
            objectToVisualize.Columns.Add("Column1");

            for (int i = 0; i < 500; i++)
            {
                var row = objectToVisualize.NewRow();
                row[0] = i;
                objectToVisualize.Rows.Add(row);
            }

            VisualizerDevelopmentHost visualizerHost = 
                new VisualizerDevelopmentHost(objectToVisualize, typeof(IEnumerableVisualizer));

            visualizerHost.ShowVisualizer();
        }

        [TestMethod]
        public void TestShowVisualizerNoData()
        {
            object objectToVisualize = new  DataTable();

            VisualizerDevelopmentHost visualizerHost = 
                new VisualizerDevelopmentHost(objectToVisualize, typeof(IEnumerableVisualizer));

            visualizerHost.ShowVisualizer();
        }
    }
}
