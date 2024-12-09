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
    public partial class OgrKayit : Form
    {
        public OgrKayit()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");



        private void button1_Click(object sender, EventArgs e)
        {


            string tabloAdi= textBox3.Text;
            string createTableQuery = $@" CREATE TABLE [{tabloAdi}] (
                      Not_id INT PRIMARY KEY IDENTITY(1,1),
                      Ders_kodu CHAR(5) NOT NULL,
                      Ders_adi NVARCHAR(100),
                      Vize FLOAT, Final FLOAT,
                      Ortalama AS ((Vize * 0.4) + (Final * 0.6)),
                      Dvz FLOAT, Durum AS (CASE WHEN Dvz > 4 OR ((Vize * 0.4) + (Final * 0.6)) < 50 THEN 'Kaldı' ELSE 'Geçti' END) );";

            string procedurName1 = "InsertOgrenci";
            string procedurName2 = "InsertOgrGirisBilgileri";




            con.Open();
            SqlCommand komut = new SqlCommand(procedurName1,con);
            SqlCommand komut1 = new SqlCommand(procedurName2,con);
            SqlCommand komut2 = new SqlCommand(createTableQuery,con);
            

            komut.CommandType = CommandType.StoredProcedure;
            komut1.CommandType=CommandType.StoredProcedure;
            

            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.Parameters.AddWithValue("@p4", textBox3.Text);
            komut.Parameters.AddWithValue("@p5", textBox4.Text);
            komut.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p7", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@p8", textBox5.Text);

            komut1.Parameters.AddWithValue("@2", textBox1.Text);
            komut1.Parameters.AddWithValue("@3", textBox2.Text);
            komut1.Parameters.AddWithValue("@4", textBox3.Text);
            komut1.Parameters.AddWithValue("@5", textBox4.Text);
            komut1.Parameters.AddWithValue("@6", textBox3.Text);

            komut.ExecuteNonQuery();
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();

            MessageBox.Show("Kayıt Başarıyla Oluşturuldu","Tamam");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";

            con.Close();

        }

        private void OgrKayit_Load(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select *from Bolumler",con);
            SqlDataAdapter da= new SqlDataAdapter(komut3);
            DataTable tablo= new DataTable();
            da.Fill(tablo);

            comboBox1.DisplayMember = "BolumAdi";
            comboBox1.ValueMember = "BolumID";
            comboBox1.DataSource = tablo;
        }
    }
}



/* "komut" komutuyla Ogrenciler tablosuna yeni kayıt yapılır
 * "komut1" komutuyla OgrGirisBilgileri tablosuna kullanıcı adı eposta şifre ise öğrenci numarası olacak şekilde eklenir
 * "komut2" komutuyla kaydı yapılan öğrencinin numarasıyını kullanarak numarası isminde notlar tablosu oluşturulur*/