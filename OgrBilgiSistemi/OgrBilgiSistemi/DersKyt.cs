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
    public partial class DersKyt : Form
    {
        public DersKyt()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");
        string alinanDgr = OgrGirisi.PaylasilanDgr;
        void Listele()
        {

            SqlConnection con1= new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

                con1.Open();
                SqlCommand komut = new SqlCommand("select  Ders_kodu as 'Ders Kodu', Ders_adi as 'Ders Adı',Kredi, Aktss 'AKTS'  from Dersler", con1);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;



                string query3 = $"select Ders_kodu as 'Ders Kodu', Ders_adi as 'Ders Adı' from [{alinanDgr}]";
                SqlCommand komut4 = new SqlCommand(query3, con1);
                SqlDataAdapter da1 = new SqlDataAdapter(komut4);
                DataTable tablo1 = new DataTable();
                da1.Fill(tablo1);
                dataGridView2.DataSource = tablo1;
            con1.Close();
                
            
        }

        
        private void DersKyt_Load(object sender, EventArgs e)
        {
            Listele();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
            string query = $"select *from Dersler where Ders_kodu='" + txtKod + "'";
            string query2 = $" INSERT INTO [{alinanDgr}] ( Ders_kodu, Ders_adi) SELECT  Ders_kodu, Ders_adi FROM Dersler where Ders_kodu=@Derskodu";
            con.Open();
            SqlCommand komut2 = new SqlCommand(query, con);
            SqlCommand komut3 = new SqlCommand(query2,con);
            komut3.Parameters.AddWithValue("@Derskodu",txtKod.Text);
            komut2.ExecuteNonQuery();
            komut3.ExecuteNonQuery();
            MessageBox.Show("Ders başarıyla Kaydedilmiştir","Tamam");
            txtKod.Text = "";
            con.Close();
            Listele();
            


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
