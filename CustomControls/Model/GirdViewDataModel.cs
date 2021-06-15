using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Model
{
    class GirdViewDataModel
    {
        [DisplayName(@"제목")]        
        public string Title { get; set; }

        [DisplayName(@"문서유형")]
        public string DocumentTypeName { get; set; }

        [DisplayName(@"등록자")]       
        public string CreatorName { get; set; }


        public GirdViewDataModel( string title, string type, string creator )
        {
            this.Title = title;
            this.DocumentTypeName = type;
            this.CreatorName = creator;
        }
       
    }
}
