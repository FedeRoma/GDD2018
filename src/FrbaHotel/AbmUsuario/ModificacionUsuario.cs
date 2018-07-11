using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.AbmUsuario
{
    public partial class ModificacionUsuario : Form
    {
        public ModificacionUsuario(string username,
                                    string nombre,
                                    string apellido,
                                    string email,
                                    string telefono,
                                    string numeroDoc,
                                    string estado)
        {
            InitializeComponent();
        }
    }
}
