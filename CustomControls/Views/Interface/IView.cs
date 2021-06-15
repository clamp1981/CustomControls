using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Views.Interface
{
    public interface IView
    {
        // Should handle Binding operations of the View's control properties to the Model's Properties
        void PerformBinding();
    }
}
