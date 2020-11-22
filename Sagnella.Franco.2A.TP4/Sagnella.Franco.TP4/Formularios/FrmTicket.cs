using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Formularios
{
    public partial class FrmTicket : Form
    {
        public FrmTicket()
        {
            InitializeComponent();
        }

        public FrmTicket(string cadena)
            :this()
        {
            this.textBox1.Text = cadena;
        }
    }
}
