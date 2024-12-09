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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace OgrBilgiSistemi
{
    public partial class KytliOgrler : Form
    {
        public KytliOgrler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");


        void Listele()
        {
            SqlCommand komut = new SqlCommand("select OgrID as 'ID', OgrAdi as 'İsim',  OgrSoyad as 'Soyisim', OgrNo as 'Öğrenci Numarası', Eposta,  KayitTarihi as 'Kayıt Tarihi', Bolum as 'Bölüm',Tc as 'T.C. Kimlik No' from Ogrenciler ", con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        void createPDF(string filePath, DataGridView dataGridView)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4.Rotate());
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    PdfPTable pdfTable = new PdfPTable(dataGridView.ColumnCount);
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString());

                        }
                    }
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                }
                MessageBox.Show("PDF başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void KytliOgrler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) 
            { 
                saveFileDialog.Filter = "PDF Dosyaları|*.pdf";
                saveFileDialog.Title = "PDF olarak kaydet";
                saveFileDialog.FileName = "MyPDF.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) 
                { 
                    string filePath = saveFileDialog.FileName; 
                    createPDF(filePath, dataGridView1); 
                }
            }

        }

    }
}
