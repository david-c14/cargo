using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon14.Cargo.Interfaces
{
    public interface ICargoPort
    {
        DockingFlags PortType { get; }

        void DockCargo(ICargo cargo);

        void DockCargo(ICargo cargo, DockingFlags flags);

        void UndockCargo(ICargo cargo);
    }
}
