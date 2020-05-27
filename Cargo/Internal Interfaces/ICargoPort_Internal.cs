using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon14.Cargo.Interfaces
{
    internal interface ICargoPort_Internal : ICargoPort
    {
        Control Port { get; }
    }
}
