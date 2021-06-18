using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Model
{
    class GirdViewDataModel
    {
        //add icon 
        [Browsable(false)]
        public Icon Icon { get; set; }

        [DisplayName(@"Title")]        
        public string Title { get; set; }

        [DisplayName(@"Type")]
        public string DocumentTypeName { get; set; }

        [DisplayName(@"Creator")]       
        public string CreatorName { get; set; }


        public GirdViewDataModel( string title, string type, string creator )
        {
            this.Icon = null;
            this.Title = title;
            this.DocumentTypeName = type;
            this.CreatorName = creator;
        }

        public GirdViewDataModel( bool isdisplayicon, string title, string type, string creator)
        {
            
            this.Title = title;
            this.DocumentTypeName = type;
            this.CreatorName = creator;

            if(isdisplayicon == true)
            {
                if( this.DocumentTypeName == "Lock")
                {
                    this.Icon = new Icon("..\\..\\Resources\\lock_01.ico");
                }
                else
                    this.Icon = new Icon("..\\..\\Resources\\padlock_01.ico");
            }
        }


    }


   
}
