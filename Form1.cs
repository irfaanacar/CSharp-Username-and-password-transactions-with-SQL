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

namespace SqlKullaniciAdSifre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan=new SqlConnection("Data Source=IRFAN\\SQLEXPRESS;Initial Catalog=KullaniciAdSifre;Integrated Security=True");
        private void Kontrolet()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from kaydolbilgiler where kullaniciad=@kullaniciadi and sifre=@sifresi", baglan);
            komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
            komut.Parameters.AddWithValue("@sifresi", textBox2.Text);
            SqlDataReader oku=komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("GİRİŞ BAŞARILI","LOG-IN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("HATALI GİRİŞ!!!","UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            baglan.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmsifremiunuttum yeni = new frmsifremiunuttum();
            yeni.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kontrolet();
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
