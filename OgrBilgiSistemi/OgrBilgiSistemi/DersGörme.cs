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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace OgrBilgiSistemi
{
    public partial class DersGörme : Form
    {
        public DersGörme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");
        string alinanDgr = OgrGirisi.PaylasilanDgr;

        void Listele()
        {
            SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-AVTCPRK3\\SQLEXPRESS;Initial Catalog=dbObs;Integrated Security=True;TrustServerCertificate=True");
            con1.Open();
            string query3 = $"select Ders_kodu as 'Ders Kodu',Ders_adi as 'Ders Adı' from [{alinanDgr}]";
            SqlCommand komut4 = new SqlCommand(query3, con1);
            SqlDataAdapter da1 = new SqlDataAdapter(komut4);
            DataTable tablo1 = new DataTable();
            da1.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
        }
        private void DersGörme_Load(object sender, EventArgs e)
        {
            Listele();
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
