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

            _dgvDataList.Add(new GirdViewDataModel("안녕하세요.", "비밀문서", "써니"));
            _dgvDataList.Add(new GirdViewDataModel("안녕히계세요.", "공개문서", "글쓰니"));
            _dgvDataList.Add(new GirdViewDataModel("반갑습니다.", "비밀문서", "으르신"));
          


            _dgv = new DataGridViewEx(Color.Black);
            _dgv.Size = new Size(panel1.Width - 5, panel1.Height - 5);
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
    }
}
