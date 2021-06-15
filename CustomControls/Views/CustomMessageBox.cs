using CustomControls.Model;
using CustomControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls.Views
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string text, string caption, MessageBoxButtons btn, MessageBoxIcon icon)
        {
            MessageType messagetype = MessageType.Information;
            MessageButtonType btntype = MessageButtonType.OK;
            if (btn == MessageBoxButtons.YesNo)
                btntype = MessageButtonType.YRS_NO;
            else if (btn == MessageBoxButtons.OKCancel)
                btntype = MessageButtonType.OK_CANCEL;

            if (icon == MessageBoxIcon.Error)
                messagetype = MessageType.Error;
            else if (icon == MessageBoxIcon.Question)
                messagetype = MessageType.Question;

            using (var view = new CustomMessageView(new CustomMessageViewModel(text, caption, messagetype, btntype)))
            {
                view.TopMost = true;
                DialogResult re = view.ShowDialog();
                if (btntype == MessageButtonType.YRS_NO && re == DialogResult.Cancel)
                    re = DialogResult.No;

                return re;
            }
        }
    }
}
