using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carbon14.Cargo.Interfaces;

namespace Carbon14.Cargo
{
    internal class PanelPort : Panel, ICargoPort_Internal
    {
        public ICargo_Internal _cargo;
        Control ICargoPort_Internal.Port => this;

        public DockingFlags PortType => DockingFlags.Single;

        public void DockCargo(ICargo cargo)
        {
            _cargo = (ICargo_Internal)cargo;
            Text = cargo.Text;
            _cargo.DockInPort(this);
            _cargo.Control.Dock = DockStyle.Fill;
        }

        public void DockCargo(ICargo cargo, DockingFlags flags)
        {
            throw new NotImplementedException();
        }

        public void UndockCargo(ICargo cargo)
        {
            _cargo.UndockFromPort();
            _cargo = null;
            Text = "";
            return;
            //TODO Add recursive undock here
        }
    }
}
