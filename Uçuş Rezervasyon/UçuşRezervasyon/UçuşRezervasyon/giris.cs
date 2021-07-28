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
    
    //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\muham\Desktop\giris.accdb
    public partial class giris : Form
    {
       
        public static int dil = 1;
       
        public giris()
        {
           
            InitializeComponent();
         
        }
        public void random()
        {
            Random rastgele = new Random();
            int sayi;
            sayi = rastgele.Next(1000, 9999);
            GuvSayi.Text = sayi.ToString();
        }
        private void giris_Load(object sender, EventArgs e)
        {
            
            random();

            if (dil == 1)
            {
                tr();
            }
            else
            {
                ing();
            }
          

        }
        void temizle()
        {
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox2.ResetText();
            guvText.ResetText();
        }

        public static string isim;
        public static string tc;
        public static string tel;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\muham\\Desktop\\Uçuş Rezervasyon\\giris.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT kullaniciGiris,kullaniciSifre,isim,tc,tel FROM giris WHERE kullaniciGiris=@kad AND kullaniciSifre=@sifre", baglanti);
            sorgu.Parameters.AddWithValue("@kad", bunifuMaterialTextbox1.Text);
            sorgu.Parameters.AddWithValue("@sifre", bunifuMaterialTextbox2.Text);
            
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                if (guvText.Text == GuvSayi.Text)
                {
                    
                   MessageBox.Show("Hoşgeldin! " + dr.GetValue(2).ToString());
                    girisSayfasi giris = new girisSayfasi();

                 
                    isim= dr.GetValue(2).ToString();
                    tc= dr.GetValue(3).ToString();
                    tel = dr.GetValue(4).ToString();



                    this.Hide();
                    giris.Show();
                    
                }
                else
                {
                    MessageBox.Show("Güvenlik Kodu Yanlış", "Sistem Uyarısı");
                    random();
                    temizle();
                    baglanti.Close();
                   
                }
                
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Yanlış Kullanıcı adı veya parola", "Sistem Uyarısı");
                random();
                temizle();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
            ing();
          
           
            
        }
        public void ing()
        {
            dil = 2;
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox1.HintText = "Enter Username";
            bunifuMaterialTextbox2.ResetText();
            bunifuMaterialTextbox2.HintText = "Enter Password";
            guvText.ResetText();
            guvText.HintText = "enter security password";
            bunifuFlatButton1.Text = "Sign in";
            bunifuTileButton1.LabelText = "Sign up";
        }
        public void tr()
        {
            dil = 1;
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox1.HintText = "Kullanıcı Giriniz";
            bunifuMaterialTextbox2.ResetText();
            bunifuMaterialTextbox2.HintText = "Şifre Giriniz";
            guvText.ResetText();
            guvText.HintText = "Güvenlik Kodu";
            bunifuFlatButton1.Text = "Giriş Yap";
            bunifuTileButton1.LabelText = "Kayıt Ol";
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            this.Hide();
            kayit.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tr();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
           
        }
     
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
            acik.Visible = false;
            kapali.Visible = true;
        }

        private void kapali_Click(object sender, EventArgs e)
        {
           
            bunifuMaterialTextbox2.isPassword = false;
            acik.Visible = true;
            kapali.Visible = false;

        }

        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void guvText_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guvText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void giris_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void giris_MouseDown(object sender, MouseEventArgs e)
        {
            

        }

        private void giris_MouseMove(object sender, MouseEventArgs e)
        {
          
        }
    }
}
