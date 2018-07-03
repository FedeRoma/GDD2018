using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class MenuAbmRol : Form
    {
        public static AltaRol AltaRol;

        public MenuAbmRol()
        {
            InitializeComponent();
        }

        private void altaRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaRol = new AltaRol();
            AltaRol.Show();
        }

    }
}
