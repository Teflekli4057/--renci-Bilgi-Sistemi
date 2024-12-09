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
    public partial class OgrEkrani : Form
    {
        public OgrEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DersKyt frm = new DersKyt();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GrsBilgiGuncelleme frm2= new GrsBilgiGuncelleme();
            frm2.Show();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransGor frm= new TransGor();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DvzGör frm= new DvzGör();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DersGörme frm= new DersGörme();
            frm.Show();
        }
    }
}
