using CustomControls.Model;
using CustomControls.ViewModels;
using CustomControls.Views.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls.Views
{
    internal partial class CustomMessageView : Form, IView
    {
        #region WIN_API       
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion
        private CustomMessageViewModel _model;
        public CustomMessageView(CustomMessageViewModel model)
        {
            InitializeComponent();
            _model = model;
            PerformBinding();
        }


        public void PerformBinding()
        {
            this.lbTitle.DataBindings.Add("Text", _model, nameof(_model.Title), false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbMessage.DataBindings.Add("Text", _model, nameof(_model.Message), false, DataSourceUpdateMode.OnPropertyChanged);
            this.btnOK.DataBindings.Add("Text", _model, nameof(_model.OkCapion), false, DataSourceUpdateMode.OnPropertyChanged);
            this.btnOK.DataBindings.Add("Visible", _model, nameof(_model.IsVisibleButtonOK), false, DataSourceUpdateMode.OnPropertyChanged);
            this.btnCancel.DataBindings.Add("Text", _model, nameof(_model.CancelCapion), false, DataSourceUpdateMode.OnPropertyChanged);
            this.btnCancel.DataBindings.Add("Visible", _model, nameof(_model.IsVisibleButtonCancel), false, DataSourceUpdateMode.OnPropertyChanged);
            this.pbIcon.DataBindings.Add(new Binding("Image", _model, nameof(_model.MessageTypeImage), false, DataSourceUpdateMode.OnPropertyChanged));
        }


        private void CustomMessageView_Load(object sender, EventArgs e)
        {
            if (panel3.Height < (this.lbMessage.Size.Height + this.lbMessage.Location.Y))
            {
                int gap = this.lbMessage.Size.Height - panel3.Height;
                this.Size = new Size(this.Size.Width, this.Size.Height + gap + this.lbMessage.Location.Y);
            }

            if (panel3.Width < (this.lbMessage.Size.Width + this.lbMessage.Location.X))
            {
                int gap = this.lbMessage.Size.Width - panel3.Width;
                this.Size = new Size(this.Size.Width + gap + this.lbMessage.Location.X + 10, this.Size.Height);
            }

            this.plCenter.Size = new Size(this.panel3.Width - 2, this.panel3.Height);
            this.plBottom.Size = new Size(this.panel2.Width - 2, this.panel2.Height - 1);

            this.btnClose.Location = new Point(this.Width - this.btnClose.Width - 5, this.btnClose.Location.Y);

            if (_model.IsVisibleButtonCancel == false)
            {
                this.btnOK.Location = new Point((this.Width - this.btnOK.Width) / 2, this.btnOK.Location.Y);
            }
            else
            {
                this.btnOK.Location = new Point(((this.Width - this.btnOK.Width) / 2) - (this.btnOK.Width / 2) - 5, this.btnOK.Location.Y);
                this.btnCancel.Location = new Point((this.Width - this.btnCancel.Width) / 2 + (this.btnCancel.Width / 2) + 5, this.btnCancel.Location.Y);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_model.ButtonType == MessageButtonType.YRS_NO)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_model.ButtonType == MessageButtonType.YRS_NO)
            {
                this.DialogResult = DialogResult.No;
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        
    }
}
