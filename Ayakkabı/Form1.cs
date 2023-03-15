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
namespace Ayakkabı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan;
        SqlDataAdapter da;
        SqlCommand komut;
        DataSet ds;



       

        private void Form1_Load(object sender, EventArgs e)
        {
            goruntule();
        }


        void goruntule()
        {
        baglan = new SqlConnection(@"Data Source = DESKTOP-SU0HMSG\SQLEXPRESS; Initial Catalog =Ayakkabı Müşteri; Integrated Security = True");
            da = new SqlDataAdapter("Select*From musteri", baglan);
            ds = new DataSet();
            baglan.Open();
            da.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];
            baglan.Close();


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "insert into musteri (musteri_no,musteri_ad,musteri_soyad,musteri_tel) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "depo" && textBox6.Text == "123123")
            {
                Form2 yeni = new Form2();
                yeni.Show();
                this.Hide();
                MessageBox.Show("Başarılı Depo Girişi..");
            }


            else
            {

                MessageBox.Show("Yanlış Id veya Şifre..");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "delete from musteri where musteri_no =" + textBox1.Text + "";
            komut.ExecuteNonQuery();
            baglan.Close();
            goruntule();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
    }
}
