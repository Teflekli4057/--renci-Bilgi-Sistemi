using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OgrBilgiSistemi
{
    public partial class KytSilme : Form
    {
        public KytSilme()
        {
            InitializeComponent();

        }

 
        SqlConnection con= new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");


        void Listele()
        {
            SqlCommand komut = new SqlCommand("select OgrID as 'ID', OgrAdi as 'İsim',  OgrSoyad as 'Soyisim', OgrNo as 'Öğrenci Numarası', Eposta,  KayitTarihi as 'Kayıt Tarihi', Bolum as 'Bölüm',Tc as 'T.C. Kimlik No' from Ogrenciler ",con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo= new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;   


        }


        private void button1_Click(object sender, EventArgs e)
        {
            int OgrNumara = Convert.ToInt16(textBox1.Text);
            string dropTableQuery = $"drop table [{OgrNumara}]";
            SqlCommand komut1 = new SqlCommand("delete from Ogrenciler where OgrNo='" + OgrNumara + "'", con);
            SqlCommand komut2 = new SqlCommand("delete from OgrGirisBilgileri where OgrNo='"+OgrNumara+"' ",con);
            SqlCommand komut3 = new SqlCommand(dropTableQuery,con);

            con.Open();

            int sonuc = komut1.ExecuteNonQuery();
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            komut3.ExecuteNonQuery();

            if (sonuc > 0)
            {
                MessageBox.Show("Kayıt başarıyla silindi.", "Silme ekranı");

            }
            else
                MessageBox.Show("Hatalı bilgi girdiniz. Kayıt silinemedi.", "Silme ekranı.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            textBox1.Text = "";

            con.Close();
            Listele();
        }

        private void KytSilme_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SilinenOgr frm = new SilinenOgr();
            frm.Show();
        }
    }
}
