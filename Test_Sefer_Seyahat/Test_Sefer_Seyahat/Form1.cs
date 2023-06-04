using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Test_Sefer_Seyahat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    SqlConnection baglanti= new SqlConnection ("Data Source=DESKTOP-U9PHQ3C;Initial Catalog=TestYolcuBilet;Integrated Security=True");

        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLSEFERB�LG�", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLYOLCUB�LG� (ad,soyad,telefon,tc,c�ns�yet,ma�l) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", MskTC.Text);
            komut.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);

            
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu Bilgisi Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnKaptan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblkaptan (kaptanno,adsoyad,telefon) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKaptanNo.Text);
            komut.Parameters.AddWithValue("@p2", TxtKaptanAd.Text);
            komut.Parameters.AddWithValue("@p3", MskKaptanTelefon.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERB�LG� (kalk�s,var�s,tar�h,saat,kaptan,f�yat) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKalk�s.Text);
            komut.Parameters.AddWithValue("@p2", TxtVar�s.Text);
            komut.Parameters.AddWithValue("@p3", MskTarih.Text);
            komut.Parameters.AddWithValue("@p4", MskSaat.Text);
            komut.Parameters.AddWithValue("@p5", MskKaptan.Text);
            komut.Parameters.AddWithValue("@p6", TxtFiyat.Text);
            
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            seferlistesi();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtSeferNumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "9";
        }

        private void Btnrezervasyon_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERDETAY (seferno,yolcutc,koltuk) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSeferNumara.Text);
            komut.Parameters.AddWithValue("@p2", MskYolcuTc.Text);
            komut.Parameters.AddWithValue("@p3", TxtKoltukNo.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}