using Carbon14.Cargo.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon14.Cargo.CargoHarness
{
    public partial class Form1 : Form
    {
        private WindowPort port1;
        private WindowPort port2;
        private HarnessCargo cargo1;
        private HarnessCargo2 cargo2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port1 = new WindowPort();
            port1.Show(this);
            port2 = new WindowPort();
            port2.Show(this);
            cargo1 = new HarnessCargo();
            cargo2 = new HarnessCargo2();
            port1.DockCargo(cargo1);
            port2.DockCargo(cargo2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port1.DockCargo(cargo1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            port2.DockCargo(cargo1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabCargoPort1.DockCargo(cargo1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            port1.DockCargo(cargo2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            port2.DockCargo(cargo2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabCargoPort1.DockCargo(cargo2);
        }
    }   

}
