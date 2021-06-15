using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls.CustomControls
{

    /// <summary>
    /// Change the outmost border color 
    /// </summary>
    public partial class DataGridViewEx : Panel
    {
        public DataGridView DataGridView = new DataGridView();       
        public DataGridViewEx( Color border_color )
        {
            InitializeComponent();

            this.DockPadding.Left = 1;
            this.DockPadding.Top = 0;
            this.DockPadding.Right = 1;
            this.DockPadding.Bottom = 1;
            this.BackColor = border_color; //outer border color
            this.BorderStyle = BorderStyle.None;
            this.DataGridView.Dock = DockStyle.Fill;
            this.DataGridView.DataBindingComplete += DataGridView_DataBindingComplete;


            SetUI();
            MethodInfo method = this.DataGridView.GetType().GetMethod("UpdateStyles", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(this.DataGridView, null);
            this.Controls.Add(this.DataGridView);

            //set duble buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

        }

        public void SetBorderColor(Color border_color)
        {
            this.BackColor = border_color; //outer border color
        }



        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            if (this.DataGridView.Enabled == false)
            {
                this.DataGridView.ClearSelection();
                if (this.DataGridView.CurrentRow != null)
                    this.DataGridView.CurrentRow.Selected = false;
            }

        }

        public void SetUI()
        {           
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AllowUserToOrderColumns = false;
            this.DataGridView.AllowUserToResizeColumns = true; // 파일명이 길어서 안보이는 경우가 있을 수 있으니 행은 조절 가능하도록 함
            this.DataGridView.AllowUserToResizeRows = false;
            this.DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.DataGridView.GridColor = Color.DarkGray;
            this.DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            this.DataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.DataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.MultiSelect = false;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 11.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;



            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            this.DataGridView.RowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.DataGridView.RowsDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
        }
    }
}
