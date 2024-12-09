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

namespace OgrBilgiSistemi
{
    public partial class GrsBilgiGuncelleme : Form
    {
        public GrsBilgiGuncelleme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("update OgrGirisBilgileri set Kadi='" + txtYeniKadi.Text + "' where Kadi='" + txtEskiKadi.Text + "'", con);
            SqlCommand komut2 = new SqlCommand("update OgrGirisBilgileri set Sifre='" + txtYeniSifre.Text + "' where Sifre='" + txtEskiSifre.Text + "'", con);
            komut.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı bilgileriniz başarıyla değiştirildi", "Tamam");
            txtEskiKadi.Text = "";
            txtEskiSifre.Text = "";
            txtYeniKadi.Text = "";
            txtYeniSifre.Text = "";
            con.Close();
        }
    }
}
