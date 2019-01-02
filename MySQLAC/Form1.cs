using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Conexion c = new Conexion();
            DataTable dt = c.Ejecutar("SELECT nombre FROM persona WHERE id=1");
            MessageBox.Show(dt.Rows[0][0].ToString());
        }
    }
}
