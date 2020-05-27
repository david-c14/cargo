using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carbon14.Cargo.Interfaces;

namespace Carbon14.Cargo
{
    public class UserCargo : UserControl, ICargo_Internal
    {
        ICargoPort_Internal _port;

        public Control Control => this;

        void ICargo_Internal.UndockFromPort()
        {
            Parent = null;
            _port = null;
        }

        void ICargo_Internal.DockInPort(ICargoPort_Internal port)
        {
            if (_port != null)
            {
                _port.UndockCargo(this);
            }
            _port = port;
            Parent = _port.Port;
        }

        //        string ICargo.Text { get => this.Text; set => this.Text = value; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

    }
}
