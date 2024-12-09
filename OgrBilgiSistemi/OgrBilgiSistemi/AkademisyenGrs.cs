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
    public partial class AkademisyenGrs : Form
    {
        public AkademisyenGrs()
        {
            InitializeComponent();
        }

        SqlConnection con= new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from Kullanıcılar where KullaniciAdi='" + txtKadi.Text + "' and Sifre='" + txtSifre.Text + "'", con);

            con.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AkademisyenEkrani f2 = new AkademisyenEkrani();
                f2.Show();
            }
            else
                MessageBox.Show("Hatalı kullanıcı adı veya parola", "Giriş ekranı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtKadi.Text = "";
            txtSifre.Text = "";
            this.Close();
            con.Close();
        }
    }
}
