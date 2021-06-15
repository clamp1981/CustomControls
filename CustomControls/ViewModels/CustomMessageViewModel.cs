using CustomControls.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.ViewModels
{
    public class CustomMessageViewModel : ViewModelBase
    {

        public MessageButtonType ButtonType { get; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }


        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Message"));
            }
        }



        private string _okCapion;
        public string OkCapion
        {
            get { return _okCapion; }
            set
            {
                _okCapion = value;
                OnPropertyChanged(new PropertyChangedEventArgs("OkCapion"));
            }
        }


        private string _cancelCapion;
        public string CancelCapion
        {
            get { return _cancelCapion; }
            set
            {
                _cancelCapion = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CancelCapion"));
            }
        }


        private Image _messageTypeImage;
        public Image MessageTypeImage
        {
            get { return _messageTypeImage; }
            set
            {
                _messageTypeImage = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MessageTypeImage"));
            }
        }

        private bool _isVisibleButtonOK;
        public bool IsVisibleButtonOK
        {
            get { return _isVisibleButtonOK; }
            set
            {
                _isVisibleButtonOK = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsVisibleButtonOK"));
            }
        }

        private bool _isVisibleButtonCancel;
        public bool IsVisibleButtonCancel
        {
            get { return _isVisibleButtonCancel; }
            set
            {
                _isVisibleButtonCancel = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsVisibleButtonCancel"));
            }
        }


        public CustomMessageViewModel(string message,  string caption,  MessageType messagetype = MessageType.Information, MessageButtonType btntype = MessageButtonType.OK)
        {
            this.Title = caption;
            this.Message = message;

            if (messagetype == MessageType.Error)
                this.MessageTypeImage = Properties.Resources.error01;
            else if (messagetype == MessageType.Information)
                this.MessageTypeImage = Properties.Resources.info01;
            else
                this.MessageTypeImage = Properties.Resources.help01;

            this.ButtonType = btntype;


            this.OkCapion = (btntype == MessageButtonType.OK || btntype == MessageButtonType.OK_CANCEL) ? "OK" : "Yes";
            this.CancelCapion = btntype == MessageButtonType.OK_CANCEL ? "Cancel" : "No";

            this.IsVisibleButtonOK = true;
            if (btntype == MessageButtonType.OK)
            {
                this.IsVisibleButtonCancel = false;
            }
            else
                this.IsVisibleButtonCancel = true;
        }



    }
}
