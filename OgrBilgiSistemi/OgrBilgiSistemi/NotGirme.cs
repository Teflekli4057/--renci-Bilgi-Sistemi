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
    public partial class NotGirme : Form
    {
        public NotGirme()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

        void Listele()
        {
            string tblAdi= txtOgrNo.Text;
            string selectQuery = $"SELECT Not_id AS 'ID', Ders_kodu AS 'Ders Kodu', Ders_adi AS 'Ders Adı', Vize AS 'Vize Notu', Final AS 'Final Notu' FROM [{tblAdi}]";
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
            string tblAdi1= txtOgrNo.Text;
            
            string updateQuery = $"update [{tblAdi1}] set Vize=@Vize ,Final=@Final where Ders_kodu='"+txtKod.Text+"' "; 
            
            con.Open();  
            SqlCommand komut1 = new SqlCommand(updateQuery, con);
            komut1.Parameters.AddWithValue("@Vize", txtVize.Text);
            komut1.Parameters.AddWithValue("@Final",txtFinal.Text);

            komut1.ExecuteNonQuery();

            

            MessageBox.Show("Not Girme İşlemi Başarıyla Gerçekleşmiştir","Tamam");
            txtKod.Text = "";
            txtVize.Text = "";
            txtFinal.Text = "";
            con.Close();
            Listele();


        }
    }
}
