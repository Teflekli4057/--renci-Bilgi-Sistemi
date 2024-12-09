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
    public partial class DvzGirme : Form
    {
        public DvzGirme()
        {
            InitializeComponent();
        }

        SqlConnection con= new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

        void Listele()
        {
            string tblAdi = txtOgrno.Text;
            string selectQuery = $"SELECT Not_id AS 'ID', Ders_kodu AS 'Ders Kodu', Ders_adi AS 'Ders Adı', Dvz as 'Devamsızlık Bilgisi' FROM [{tblAdi}]";
            SqlCommand komut = new SqlCommand(selectQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tblAdi= txtOgrno.Text;
            string updateQuery = $"update [{tblAdi}] set Dvz=@Dvz where Ders_kodu='" + txtKod.Text+ "'";
            con.Open();
            SqlCommand komut = new SqlCommand(updateQuery, con);
            komut.Parameters.AddWithValue("@Dvz", txtDvz.Text);

            komut.ExecuteNonQuery();
            MessageBox.Show("Devamsızlık bilgisi başarıyla girildi.","Tamam");
            txtKod.Text = "";
            txtDvz.Text = "";
            con.Close();
            Listele();

        }
    }

    
 
}
