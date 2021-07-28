using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UçuşRezervasyon
{
   
    public partial class kayit : Form
    {
        OleDbCommand komut;
        public kayit()
        {
            InitializeComponent();
           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\muham\\Desktop\\Uçuş Rezervasyon\\giris.accdb");
            baglanti.Open();
            string sorgu = "INSERT INTO giris (kullaniciGiris,kullaniciSifre,isim,tc,tel) VALUES(@kul,@sifre,@isim,@tc,@tel)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kul", bunifuMaterialTextbox1.Text);
            komut.Parameters.AddWithValue("@sifre", bunifuMaterialTextbox2.Text);
            komut.Parameters.AddWithValue("@isim", isimText.Text);
            komut.Parameters.AddWithValue("@tc", TcText.Text);
            komut.Parameters.AddWithValue("@tel", telText.Text);

            if (guvText.Text == GuvSayi.Text)
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Yapıldı!");
                random();
                temizle();
                giris giris = new giris();
                this.Hide();
                giris.Show();
            }
            else
            {

                MessageBox.Show("Güvenlik Kodu Yanlış Girildi", "Sistem Mesajı");
                
                baglanti.Close();
                random();
                temizle();
                


            }
            
        }
        public void temizle()
        {
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox2.ResetText();
            guvText.ResetText();
        }
        public void random()
        {
            Random rastgele = new Random();
            int sayi;
            sayi = rastgele.Next(1000, 9999);
            GuvSayi.Text = sayi.ToString();

        }
        public void tr()
        {
            
            giris.dil = 1;
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox1.HintText = "Kullanıcı Giriniz";
            bunifuMaterialTextbox2.ResetText();
            bunifuMaterialTextbox2.HintText = "Şifre Giriniz";
            guvText.ResetText();
            guvText.HintText = "Güvenlik Kodu";
            bunifuFlatButton1.Text = "Kayıt Ol";
            isimText.ResetText();
            isimText.HintText = "İsim Soyisim";
            TcText.ResetText();
            TcText.HintText = "TC kimlik numarası";
            telText.ResetText();
            telText.HintText = "Telefon numarası";
        }

    public void ing()
        {
            giris.dil = 2;
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox1.HintText = "Enter Username";
            bunifuMaterialTextbox2.ResetText();
            bunifuMaterialTextbox2.HintText = "Enter Password";
            guvText.ResetText();
            guvText.HintText = "Enter security password";
            bunifuFlatButton1.Text = "Sign up";
            isimText.ResetText();
            isimText.HintText = "Enter Full Name ";
            TcText.ResetText();
            TcText.HintText = "TR ID NO";
            telText.ResetText();
            telText.HintText = "Phone Number";
        }
        private void kayit_Load(object sender, EventArgs e)
        {
            random();
            if (giris.dil == 1)
            {
                tr();
            }
            else
            {
                ing();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            this.Hide();
            giris.Show();

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
          
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

            tr();
           
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ing();
           
        }

        private void kapali_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = false;
            acik.Visible = true;
            kapali.Visible = false;
        }

        private void acik_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
            acik.Visible = false;
            kapali.Visible = true;
        }

        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void guvText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void TcText_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
           
        }

        private void telText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
    }

