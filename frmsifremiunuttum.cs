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
using System.Drawing.Text;

namespace SqlKullaniciAdSifre
{
    public partial class frmsifremiunuttum : Form
    {
        public frmsifremiunuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=IRFAN\\SQLEXPRESS;Initial Catalog=KullaniciAdSifre;Integrated Security=True");
        private void devam()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from kaydolbilgiler where kullaniciad=@kullaniciadi", baglan);
            komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                checkBox1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                button3.Visible = true;
                button1.Visible = false;
            }

            else
            {
                MessageBox.Show("HATALI KULLANICI ADI GİRDİNİZ!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            devam();
        }

        private void frmsifremiunuttum_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
            checkBox1.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("update kaydolbilgiler set sifre='" + textBox2.Text + "'where kullaniciad='" + textBox1.Text + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                devam();
                MessageBox.Show("Şifre başarıyla değiştirildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 git = new Form1();
                git.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Şifre değiştirme işlemi BAŞARISIZ!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '•';
            }
        }
    }
}
