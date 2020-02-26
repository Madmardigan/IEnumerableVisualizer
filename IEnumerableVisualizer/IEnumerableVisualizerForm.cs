using System.Data;
using System.Windows.Forms;

namespace IEnumerableVisualizerDotNetStandard
{
    public partial class IEnumerableVisualizerForm : Form
    {
        public IEnumerableVisualizerForm(DataTable dataTable)
        {
            InitializeComponent();
            button1.TabIndex = 0;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
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

        private void KeyPressKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
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
    }
}
