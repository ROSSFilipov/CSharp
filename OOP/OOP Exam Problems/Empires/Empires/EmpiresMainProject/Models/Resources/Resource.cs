using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Models.Resources
{
    public abstract class Resource : IResource
    {
        private ResourceType type;
        private int quantity;

        protected Resource(ResourceType type, int quantity)
        {
            this.Type = type;
            this.Quantity = quantity;
        }

        public ResourceType Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
    }
}
