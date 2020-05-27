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
    public class WindowPort : Form, ICargoPort_Internal
    {
        ICargo_Internal _cargo = null;

        Control ICargoPort_Internal.Port => this;

        public DockingFlags PortType => DockingFlags.Floating;

        public void DockCargo(ICargo cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo));
            if (_cargo == cargo)
                return;
            if (_cargo != null)
                throw new ArgumentException("There is already cargo docked in this port. You must specify a docking method", nameof(cargo));
            if (!(cargo is ICargo_Internal))
                throw new ArgumentException("Cargo does not provide the necessary docking services", nameof(cargo));
            _cargo = (ICargo_Internal)cargo;
            _cargo.DockInPort(this);
            _cargo.Control.Dock = DockStyle.Fill;
            Text = _cargo.Text;
        }

        public void DockCargo(ICargo cargo, DockingFlags dockingMethod)
        {
            throw new NotImplementedException();
        }
        public void UndockCargo(ICargo cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo));
            if (cargo == _cargo)
            {
                _cargo.UndockFromPort();
                _cargo = null;
                Text = "";
                return;
            }
            //TODO Add recursive undock here
            throw new ArgumentException("That cargo is not currently docked in this port", nameof(cargo));
        }

    }
}
