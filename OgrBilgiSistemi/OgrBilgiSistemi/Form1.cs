using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrBilgiSistemi
{
    public partial class ObsAnaGrs : Form
    {
        public ObsAnaGrs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AkademisyenGrs frm = new AkademisyenGrs();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrGirisi frm2= new OgrGirisi();
            frm2.Show();

        }
    }
}
