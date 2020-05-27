using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carbon14.Cargo.Interfaces;

namespace Carbon14.Cargo
{
    internal class TabPagePort : TabPage, ICargoPort_Internal
    {
        public ICargo_Internal _cargo;
        public TabPort _parentPort;
        Control ICargoPort_Internal.Port => this;

        public DockingFlags PortType => DockingFlags.Tabbed;

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
            _parentPort.RemoveCargo(cargo);
            return;
            //TODO Add recursive undock here
        }
    }
}
