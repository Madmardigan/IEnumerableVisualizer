﻿using IEnumerableVisualizerDotNetStandard;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

//reference to debugee side
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Array), Description = "Array Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(ArrayList), Description = "ArrayList Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(BitArray), Description = "BitArray Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(BlockingCollection<>), Description = "BlockingCollection<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(CollectionBase), Description = "Collection Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(ConcurrentBag<>), Description = "ConcurrentBag<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(ConcurrentDictionary<,>), Description = "ConcurrentDictionary<,> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(ConcurrentQueue<>), Description = "ConcurrentQueue<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(ConcurrentStack<>), Description = "ConcurrentStack<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Dictionary<,>), Description = "Dictionary Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(DictionaryBase), Description = "Dictionary Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(List<>), Description = "List<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(LinkedList<>), Description = "LinkedList<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(ReadOnlyCollectionBase), Description = "ReadOnlyCollection Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Stack<>), Description = "Stack<> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Stack), Description = "Stack Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(SortedList), Description = "SortedList Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(SortedList<,>), Description = "SortedList<,> Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(SortedSet<>), Description = "SortedSet Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Queue), Description = "Queue Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(Queue<>), Description = "Queue Visualizer")]
[assembly: DebuggerVisualizer(typeof(IEnumerableVisualizer), typeof(IEnumerableVisualizerObjectSource), Target = typeof(DataRow), Description = "DataRow Visualizer")]

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
                DataTable serializeDataTable;
                Cursor.Current = Cursors.WaitCursor;

                do
                {
                    serializeDataTable = (DataTable)objectProvider.GetObject();

                    if (serializeDataTable != null)
                    {
                        dataTable.Merge(serializeDataTable);
                    }
                }
                while (serializeDataTable != null && serializeDataTable.Rows.Count == IEnumerableVisualizerObjectSource.SERIALIZE_COUNT);

                using (var form = new IEnumerableVisualizerForm(dataTable))
                {
                    windowService.ShowDialog(form);
                }
            }
        }
    }
}
