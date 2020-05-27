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
    public class TabPort : TabControl, ICargoPort_Internal
    {
        Dictionary<ICargo_Internal, TabPagePort> _cargoTabs = new Dictionary<ICargo_Internal, TabPagePort>();

        Control ICargoPort_Internal.Port => this;

        public DockingFlags PortType => DockingFlags.Tabbed;

        public void DockCargo(ICargo cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo));
            if (!(cargo is ICargo_Internal))
                throw new ArgumentException("Cargo does not provide the necessary docking services", nameof(cargo));
            ICargo_Internal _cargo = (ICargo_Internal)cargo;
            if (_cargoTabs.ContainsKey(_cargo))
                return;
            TabPagePort tabPage = new TabPagePort();
            tabPage._parentPort = this;
            TabPages.Add(tabPage);
            tabPage.DockCargo(cargo);
            _cargoTabs.Add(_cargo, tabPage);
        }

        public void DockCargo(ICargo cargo, DockingFlags flags)
        {
            throw new NotImplementedException();
        }

        public void UndockCargo(ICargo cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo));
            ICargo_Internal _cargo = (ICargo_Internal)cargo;
            if (_cargoTabs.ContainsKey(_cargo))
            {
                TabPagePort tabPage = _cargoTabs[_cargo];
                tabPage.UndockCargo(_cargo);
                tabPage._parentPort = null;
                return;
            }
            //TODO Add recursive undock here
            throw new ArgumentException("That cargo is not currently docked in this port", nameof(cargo));
        }

        internal void RemoveCargo(ICargo cargo)
        {
            ICargo_Internal _cargo = (ICargo_Internal)cargo;
            if (_cargoTabs.ContainsKey(_cargo))
            {
                TabPagePort tabPage = _cargoTabs[_cargo];
                _cargoTabs.Remove(_cargo);
                TabPages.Remove(tabPage);
                return;
            }
        }
    }
}
