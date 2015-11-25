using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvent
{
    public class PropertyChangeArguments : EventArgs
    {
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public PropertyChangeArguments(string oldValue, string newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}
