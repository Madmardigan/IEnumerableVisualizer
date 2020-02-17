using System.Data;
using System.Drawing;
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
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
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
    }
}
