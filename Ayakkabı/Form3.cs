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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan;
        SqlDataAdapter da;
        SqlCommand komut;
        DataSet ds;
        SqlDataReader dr;
        //DataTable dt;

        private void Form3_Load(object sender, EventArgs e)
        {

            goruntule();
            baglan = new SqlConnection(@"Data Source = DESKTOP-SU0HMSG\SQLEXPRESS; Initial Catalog =Ayakkabı Müşteri; Integrated Security = True");
            komut = new SqlCommand();
            komut.CommandText = "select * from urun";
            komut.Connection = baglan;
            komut.CommandType = CommandType.Text;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())

                    
            {
                comboBox1.Items.Add(dr["model_no"]);
                comboBox3.Items.Add(dr["ayakkabi_no"]);
                comboBox4.Items.Add(dr["fiyat_no"]);

            }


            baglan.Close();



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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan = new SqlConnection(@"Data Source = DESKTOP-SU0HMSG\SQLEXPRESS; Initial Catalog =Ayakkabı Müşteri; Integrated Security = True");
            da = new SqlDataAdapter("Select*From urun where model_no='"+comboBox1.Text+"' ", baglan);
            ds = new DataSet();
            baglan.Open();
            da.Fill(ds, "urun");
            dataGridView1.DataSource = ds.Tables["urun"];
            baglan.Close();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan = new SqlConnection(@"Data Source = DESKTOP-SU0HMSG\SQLEXPRESS; Initial Catalog =Ayakkabı Müşteri; Integrated Security = True");
            da = new SqlDataAdapter("Select*From urun where ayakkabi_no='" + comboBox3.Text + "' ", baglan);
            ds = new DataSet();
            baglan.Open();
            da.Fill(ds, "urun");
            dataGridView1.DataSource = ds.Tables["urun"];
            baglan.Close();


            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan = new SqlConnection(@"Data Source = DESKTOP-SU0HMSG\SQLEXPRESS; Initial Catalog =Ayakkabı Müşteri; Integrated Security = True");
            da = new SqlDataAdapter("Select*From urun where fiyat_no='" + comboBox4.Text + "' ", baglan);
            ds = new DataSet();
            baglan.Open();
            da.Fill(ds, "urun");
            dataGridView1.DataSource = ds.Tables["urun"];
            baglan.Close();
        }
    }
}
