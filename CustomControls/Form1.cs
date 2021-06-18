using CustomControls.CustomControls;
using CustomControls.Model;
using CustomControls.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class Form1 : Form
    {

        DataGridViewEx _dgv = null;
        BindingList<GirdViewDataModel> _dgvDataList = new BindingList<GirdViewDataModel>();
        public Form1()
        {
            InitializeComponent();

            _dgvDataList.Add(new GirdViewDataModel(true,"Hi.", "Lock", "creator01"));
            _dgvDataList.Add(new GirdViewDataModel(true, "Goodbye.", "UnLock", "creator02"));
            _dgvDataList.Add(new GirdViewDataModel(true, "Nice meet you.", "Lock", "creator03"));
          


            _dgv = new DataGridViewEx(Color.Black);
            _dgv.Size = new Size(panel1.Width - 5, panel1.Height - 5);
            this._dgv.DataGridView.CellFormatting += DataGridView_CellFormatting;
            var sourcedoc = new BindingSource(_dgvDataList, null);
            this._dgv.DataGridView.DataSource = sourcedoc;
            
            panel1.Controls.Add(_dgv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show(this.richTextBox1.Text, this.textBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this._dgv.SetBorderColor( colorDialog1.Color );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if( this.button3.Text.StartsWith("Show") == true )
            {
                this._dgv.DataGridView.CellPainting += DataGridView_CellPainting;
                this._dgv.DataGridView.DataSource = null;
                var sourcedoc = new BindingSource(_dgvDataList, null);
                this._dgv.DataGridView.DataSource = sourcedoc;
                this.button3.Text = "Hide Icon";
            }
            else
            {
               
                this._dgv.DataGridView.CellPainting -= DataGridView_CellPainting;
                this._dgv.DataGridView.DataSource = null;
                var sourcedoc = new BindingSource(_dgvDataList, null);
                this._dgv.DataGridView.DataSource = sourcedoc;               
                this.button3.Text = "Show Icon";
            }
                
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.button3.Text.StartsWith("Hide") == true)
               this._dgv.DataGridView.Columns[0].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0);
            else
               this._dgv.DataGridView.Columns[0].DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
        }

        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;
            Image img = null;
            //Choose image based on value
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            if (_dgvDataList[e.RowIndex].Icon == null) return;
            img = _dgvDataList[e.RowIndex].Icon.ToBitmap();

            //Paint cell
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
            e.Graphics.DrawImage(img, e.CellBounds.Left + 5, e.CellBounds.Top + 3,
                16, 16 /* e.CellBounds.Height - 3*/);


            //Prevent default paint
            e.Handled = true;
        }
    }
}
