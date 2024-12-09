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
using System.CodeDom;

namespace OgrBilgiSistemi
{
    public partial class OgrGirisi : Form
    {


        public static string PaylasilanDgr;
        public OgrGirisi()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

        private void veriyiAl()
        {
            string kAdi = txtKadi.Text;
            string query = $"select OgrNo from OgrGirisBilgileri where Kadi=@Kadi";
            SqlCommand komut2= new SqlCommand(query, con);
            komut2.Parameters.AddWithValue("@Kadi", kAdi);
            try
            {
                con.Open();
                SqlDataReader dataReader = komut2.ExecuteReader();

                if (dataReader.Read())
                {

                    PaylasilanDgr = dataReader["OgrNo"].ToString();

                }
            }
            
            
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            veriyiAl();
            SqlCommand komut = new SqlCommand("select *from OgrGirisBilgileri where Kadi='" + txtKadi.Text + "' and Sifre='" + txtSifre.Text + "'", con);

            con.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                OgrEkrani f2 = new OgrEkrani();
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
