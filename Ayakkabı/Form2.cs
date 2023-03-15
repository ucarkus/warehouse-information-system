using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Ayakkabı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan;
        SqlDataAdapter da;
        SqlCommand komut;
        DataSet ds;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            goruntule();
        }
        void goruntule()
        {

            baglan = new SqlConnection(@"Data Source = DESKTOP-SU0HMSG\SQLEXPRESS; Initial Catalog =Ayakkabı Müşteri; Integrated Security = True");
            da = new SqlDataAdapter("Select*From urun", baglan);
            ds = new DataSet();
            baglan.Open();
            da.Fill(ds, "urun");
            dataGridView1.DataSource = ds.Tables["urun"];
            baglan.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "insert into urun (model_no,ayakkabi_no,fiyat_no) values ('" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"')";
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "delete from urun where ayakkabi_no =" + textBox2.Text + "";
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
