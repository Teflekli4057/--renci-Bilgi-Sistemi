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
    public partial class AkademisyenEkrani : Form
    {
        public AkademisyenEkrani()
        {
            InitializeComponent();
        }

       

        private void BackupDatabase(string dbName , string backupPath)
        {
            string backupQuery = $"BACKUP DATABASE {dbName} TO DISK = @backupPath";
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(backupQuery, con);
                cmd.Parameters.AddWithValue("@backupPath", backupPath);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veritabanı yedeği başarıyla alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı yedeği alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            KytSilme frm2 = new KytSilme();
            frm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrKayit frm = new OgrKayit();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NotGirme frm3 = new NotGirme(); 
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DvzGirme frm = new DvzGirme();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KytliOgrler frm= new KytliOgrler();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string backupPath = @"C:\Users\Fatih Emir\Desktop\dbbackup\yedek.bak";
            BackupDatabase("dbObs", backupPath);
        }
    }
}
