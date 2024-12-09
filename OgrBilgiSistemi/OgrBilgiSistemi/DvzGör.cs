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
using System.Data.Common;

namespace OgrBilgiSistemi
{
    public partial class DvzGör : Form
    {
        public DvzGör()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");
        string alinanDgr = OgrGirisi.PaylasilanDgr;

        void Listele()
        {
            SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");

            con1.Open();

            string query3 = $"select Ders_kodu as 'Ders Kodu',Ders_adi as 'Ders Adı',Dvz 'Devam Durumu' from[{alinanDgr}]";
            SqlCommand komut4 = new SqlCommand(query3, con1);
            SqlDataAdapter da1 = new SqlDataAdapter(komut4);
            DataTable tablo1 = new DataTable();
            da1.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
            con1.Close();
        }
        

        private void DvzGör_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
