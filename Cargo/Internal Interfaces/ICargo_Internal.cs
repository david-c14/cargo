using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon14.Cargo.Interfaces
{
    internal interface ICargo_Internal : ICargo
    {
        Control Control { get; }

        void DockInPort(ICargoPort_Internal port);

        void UndockFromPort();
    }
}
