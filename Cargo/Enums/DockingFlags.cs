using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbon14.Cargo
{
    [Flags]
    public enum DockingFlags
    {
        None = 0x0,

        Single = 0x01,
        Tabbed = 0x02,
        VSplit = 0x04,
        HSplit = 0x08,
        Floating = 0x10,

        SubTab = 0x100,

        Left = 0x1000,
        Right = 0x2000,
        Top = 0x4000,
        Bottom = 0x8000

    }
}
