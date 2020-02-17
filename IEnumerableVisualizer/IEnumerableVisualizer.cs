using IEnumerableVisualizerDotNetStandard;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

//reference to debugee side
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(List<>), Description = "List Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Array), Description = "Array Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Dictionary<,>), Description = "Dictionary Visualizer")]
namespace IEnumerableVisualizerDotNetStandard
{
    /// <summary>
    /// debugger side
    /// </summary>
    public class IEnumerableVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
            {
                throw new ArgumentNullException("windowService");
            }
            if (objectProvider == null)
            {
                throw new ArgumentNullException("objectProvider");
            }
            else
            {
                DataTable dataTable = new DataTable();
                DataTable additionalDataTable;
                Cursor.Current = Cursors.WaitCursor;

                do
                {
                    additionalDataTable = (DataTable)objectProvider.GetObject();

                    if (additionalDataTable != null)
                    {
                        dataTable.Merge(additionalDataTable);
                    }
                }
                while (additionalDataTable != null && additionalDataTable.Rows.Count == IEnumerableVisualizerObjectSource.PAGE_COUNT);

                using (var form = new IEnumerableVisualizerForm(dataTable))
                {
                    Cursor.Current = Cursors.Arrow;
                    windowService.ShowDialog(form);
                }
            }
        }
    }
}
