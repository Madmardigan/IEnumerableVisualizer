using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace IEnumerableVisualizerDotNetStandard
{
    public partial class IEnumerableVisualizerForm : Form
    {
        public IEnumerableVisualizerForm(DataTable dataTable)
        {
            InitializeComponent();
            var screen = Screen.FromControl(this);

            if (screen != null && screen.Bounds != null && screen.Primary)
            {
                var scale = (float)(screen.Bounds.Width / SystemParameters.PrimaryScreenWidth);
                Font = new Font(Font.FontFamily.Name, scale * Font.Size);
            }
                
            button1.TabIndex = 0;

            if (dataTable != null)
            {
                Text = string.Format("{0} Visualizer", dataTable.Namespace);

                if (dataTable.Rows.Count > 0)
                {
                    var columnNames = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).OrderBy(x => x).ToList();

                    for (int i = 0; i < columnNames.Count; i++)
                    {
                        dataTable.Columns[columnNames[i]].SetOrdinal(i);
                    }

                    var column = dataTable.Columns.Add(string.Empty, typeof(int));
                    column.SetOrdinal(0);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].HeaderText = string.Empty;

                    for (var i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i][0] = i;
                    }

                    if (dataGridView1.RowHeadersWidth * dataGridView1.Columns.Count < dataGridView1.Width)
                    {
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                    dataGridView1.Visible = true;
                }
                else
                {
                    label1.Visible = true;
                    Size = MinimumSize;
                }
            }
            else
            {
                label1.Visible = true;
                Size = MinimumSize;
            }
        }

        private void IEnumerableVisualizerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = string.Format("[{0}]", e.Value);
            }
        }

        private void IEnumerableVisualizerForm_Shown(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
        }

        private void IEnumerableVisualizerForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private void IEnumerableVisualizerForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Controls.OfType<VScrollBar>().FirstOrDefault()?.Visible != true )
            {
                int offset = dataGridView1.HorizontalScrollingOffset + e.Delta;

                if (offset < 0)
                {
                    offset = 0;
                }

                dataGridView1.HorizontalScrollingOffset = offset;
            }
        }
    }
}
