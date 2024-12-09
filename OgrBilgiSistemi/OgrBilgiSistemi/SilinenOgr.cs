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
    public partial class SilinenOgr : Form
    {
        public SilinenOgr()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

        void Listele()
        {
            string selectQuery = $"select OgrAdi as 'İsim', OgrSoyad as 'Soyad', OgrNo as 'Öğrenci Numarası', Eposta,KayitTarihi as 'Kayıt Tarihi', Bolum as 'Bölüm', Tc as 'T.C. Kimlik No' from SilinenOgrenciler ";
            SqlCommand komut = new SqlCommand(selectQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void SilinenOgr_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
