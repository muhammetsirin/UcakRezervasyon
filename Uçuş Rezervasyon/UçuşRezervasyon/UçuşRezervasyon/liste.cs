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
    
    public partial class liste : Form
    {
        public liste()
        {
            
           
            InitializeComponent();
           



            

        }
        public static int num1,num2,num3,num4,num5,num6;
        
        public void random()
        {   
            Random rastgele = new Random();
            
            num1 = rastgele.Next(50);
            num2 = rastgele.Next(50);
            num3 = rastgele.Next(50);
            num4 = rastgele.Next(50);
            num5 = rastgele.Next(50);
            num6 = rastgele.Next(50);
            

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            girisSayfasi giris = new girisSayfasi();
           this.Hide();
            giris.Show();
        }
     
        private void indirim_Click(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public string tutar;
        int i,y,z,w,q,t;

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            bilet bilet = new bilet();
            bilet.yazi.Text = p2.Text;
            bilet.logo.Image = pictureBox10.Image;
            bilet.saatx.Text = saat6.Text;
            bilet.tutarbilet.Text = fiyat6.Text;
            bilet.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bilet bilet =new bilet();
            bilet.yazi.Text = thy1.Text;
            bilet.logo.Image = pictureBox4.Image;
            bilet.saatx.Text = saat1.Text;
            bilet.tutarbilet.Text = fiyat1.Text;
            bilet.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bilet bilet = new bilet();
            bilet.yazi.Text = thy2.Text;
            bilet.logo.Image = pictureBox5.Image;
            bilet.saatx.Text = saat2.Text;
            bilet.tutarbilet.Text = fiyat2.Text;
            bilet.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bilet bilet = new bilet();
            bilet.yazi.Text = a1.Text;
            bilet.logo.Image = pictureBox6.Image;
            bilet.saatx.Text = saat3.Text;
            bilet.tutarbilet.Text = fiyat3.Text;
            bilet.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bilet bilet = new bilet();
            bilet.yazi.Text = a2.Text;
            bilet.logo.Image = pictureBox8.Image;
            bilet.saatx.Text = saat4.Text;
            bilet.tutarbilet.Text = fiyat4.Text;
            bilet.Show();
            this.Hide();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            bilet bilet = new bilet();
            bilet.yazi.Text = p1.Text;
            bilet.logo.Image = pictureBox9.Image;
            bilet.saatx.Text = saat5.Text;
            bilet.tutarbilet.Text = fiyat5.Text;
            bilet.Show();
            this.Hide();
        }

        public void saatler()
        {
           
                saat1.Text = "06:20 - 10:10 ";
                saat2.Text = "12:15 - 16:25 ";
                saat3.Text = "07:00 - 10:00 ";
                saat4.Text = "13:55 - 17:05 ";
                saat5.Text = "09:45 - 13:45 ";
                saat6.Text = "22:20 - 02:10 ";
          
        }
        public void saatler1()
        {
            saat1.Text = "05:00 - 06:22 ";
            saat2.Text = "14:15 - 15:30 ";
            saat3.Text = "08:00 - 09:00 ";
            saat4.Text = "15:55 - 17:21 ";
            saat5.Text = "11:00 - 12:00 ";
            saat6.Text = "23:20 - 00:17 ";

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tr();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ing();
        }

        private void liste_Load(object sender, EventArgs e)
        {
            if (akt1.Visible == false)
            {
                saatler1();
            }
            else
            {
                saatler();
            }
            if (giris.dil == 1)
            {
                tr();
                
            }
            else
            {
                
                ing();
                
            }
              
            ToolTip Aciklama = new ToolTip();
                
                Aciklama.ToolTipTitle = "İndirim Alanı";
                Aciklama.ToolTipIcon = ToolTipIcon.Info;
                Aciklama.IsBalloon = true;
                Aciklama.SetToolTip(indirim, "İndirim Kullanmak için tıklayın");
            
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\muham\\Desktop\\Uçuş Rezervasyon\\giris.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT *FROM seyahat WHERE ucus=" + girisSayfasi.tut + " AND ucus1=" + girisSayfasi.tut1 + "", baglanti);
            OleDbDataReader dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                if (girisSayfasi.secildi == 1)
                {
                    string a = dr[2].ToString();
                    random();
                    fiyat1.Text = (Convert.ToInt32(a) * girisSayfasi.yolcusay).ToString();
                    int b = (Convert.ToInt32(a) + num1) * girisSayfasi.yolcusay;

                    fiyat2.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num2) * girisSayfasi.yolcusay;
                    fiyat3.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num3) * girisSayfasi.yolcusay;
                    fiyat4.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num4) * girisSayfasi.yolcusay;
                    fiyat5.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num5) * girisSayfasi.yolcusay;
                    fiyat6.Text = b.ToString();
                }
                else if (girisSayfasi.secildi == 2)
                {
                   
                    string a = dr[1].ToString();
                    random();
                    fiyat1.Text = (Convert.ToInt32(a) * girisSayfasi.yolcusay).ToString();
                    int b = (Convert.ToInt32(a) + num1) * girisSayfasi.yolcusay;
                    fiyat2.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num2) * girisSayfasi.yolcusay;
                    fiyat3.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num3) * girisSayfasi.yolcusay;
                    fiyat4.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num4) * girisSayfasi.yolcusay;
                    fiyat5.Text = b.ToString();
                    b = (Convert.ToInt32(a) + num5) * girisSayfasi.yolcusay;
                    fiyat6.Text = b.ToString();


                }
                else
                {
                    MessageBox.Show("hata");
                    this.Close();
                }



            }
            else
            {
                MessageBox.Show("Bir Sorun Oluştu Tekrar Deneyiniz");
            }
        }
        void tr()
        {
            giris.dil = 1;
            bunifuCustomLabel1.ResetText();
            bunifuCustomLabel1.Text = "Uçak Bileti Ara,Ucuza Uçak Biletleri";
            bunifuFlatButton1.ResetText();
            bunifuFlatButton1.Text = "Rezerve Et";
            bunifuFlatButton2.ResetText();
            bunifuFlatButton2.Text = "Rezerve Et";
            bunifuFlatButton3.ResetText();
            bunifuFlatButton3.Text = "Rezerve Et";
            bunifuFlatButton4.ResetText();
            bunifuFlatButton4.Text = "Rezerve Et";
            bunifuFlatButton5.ResetText();
            bunifuFlatButton5.Text = "Rezerve Et";
            bunifuFlatButton6.ResetText();
            bunifuFlatButton6.Text = "Rezerve Et";
            kontrol();

          
          
            




        }
        void ing()
        {
            giris.dil = 2;
            bunifuCustomLabel1.ResetText();
            bunifuCustomLabel1.Text = "Search for Flights,Cheap Flight Tickets";
            bunifuFlatButton1.ResetText();
            bunifuFlatButton1.Text = "Reserve";
            bunifuFlatButton2.ResetText();
            bunifuFlatButton2.Text = "Reserve";
            bunifuFlatButton3.ResetText();
            bunifuFlatButton3.Text = "Reserve";
            bunifuFlatButton4.ResetText();
            bunifuFlatButton4.Text = "Reserve";
            bunifuFlatButton5.ResetText();
            bunifuFlatButton5.Text = "Reserve";
            bunifuFlatButton6.ResetText();
            bunifuFlatButton6.Text = "Reserve";
            kontrol();
          
           

        }
        private void onay_Click(object sender, EventArgs e)
        {


        }

        private void fiyat1_Click(object sender, EventArgs e)
        {

        }

        private void iptal_Click(object sender, EventArgs e)
        {
            onay.Visible = true;
            iptal.Visible = false;
            kodalani.ResetText();
            kodalani.Enabled = true;
            fiyat1.Text = Convert.ToString(i);
            fiyat2.Text = Convert.ToString(y);
            fiyat3.Text = Convert.ToString(z);
            fiyat4.Text = Convert.ToString(w);
            fiyat5.Text = Convert.ToString(q);
            fiyat6.Text = Convert.ToString(t);
        }

        private void onay_Click_1(object sender, EventArgs e)
        {
          
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\muham\\Desktop\\giris.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT kupon,indirimtutar FROM kupon WHERE kupon=@kupon", baglanti);
            sorgu.Parameters.AddWithValue("@kupon", kodalani.Text);
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(kodalani.Text + " " +"%"+ dr.GetValue(1).ToString() + " kuponu uygulandı!", "İndirim Alanı");

                string tutar = dr.GetValue(1).ToString();
                int tutar1 = Convert.ToInt32(tutar);
                i = Convert.ToInt32(fiyat1.Text);
                y = Convert.ToInt32(fiyat2.Text);
                z = Convert.ToInt32(fiyat3.Text);
                w = Convert.ToInt32(fiyat4.Text);
                q = Convert.ToInt32(fiyat5.Text);
                t = Convert.ToInt32(fiyat6.Text);
                fiyat1.Text = (i - (i * tutar1 / 100)).ToString();
                fiyat2.Text = (y - (y * tutar1 / 100)).ToString();
                fiyat3.Text = (z - (z * tutar1 / 100)).ToString();
                fiyat4.Text = (w - (w * tutar1 / 100)).ToString();
                fiyat5.Text = (q - (q * tutar1 / 100)).ToString();
                fiyat6.Text = (t - (t * tutar1 / 100)).ToString();
                kontrol();
                kodalani.Enabled = false;
                onay.Visible = false;
                kodalani.Text = "İndirim Kullanıldı";
                iptal.Visible = true;
            }
            else
            {

                bildirim bildirim = new bildirim();
                bildirim.Show();
                iptal.Visible = false;

                baglanti.Close();
            }
        
    }
        void kontrol()
        {
            if ((fiyat1.Text == "0" || fiyat1.Text=="FREE") && giris.dil == 1)
            {

                fiyat1.ResetText();
                fiyat2.ResetText();
                fiyat3.ResetText();
                fiyat4.ResetText();
                fiyat5.ResetText();
                fiyat6.ResetText();

                fiyat1.Text = "ÜCRETSİZ";
                fiyat2.Text = "ÜCRETSİZ";
                fiyat3.Text = "ÜCRETSİZ";
                fiyat4.Text = "ÜCRETSİZ";
                fiyat5.Text = "ÜCRETSİZ";
                fiyat6.Text = "ÜCRETSİZ";
            }
            else if ((fiyat1.Text == "0" || fiyat1.Text=="ÜCRETSİZ") && giris.dil == 2)
            {

                fiyat1.ResetText();
                fiyat2.ResetText();
                fiyat3.ResetText();
                fiyat4.ResetText();
                fiyat5.ResetText();
                fiyat6.ResetText();

                fiyat1.Text = "FREE";
                fiyat2.Text = "FREE";
                fiyat3.Text = "FREE";
                fiyat4.Text = "FREE";
                fiyat5.Text = "FREE";
                fiyat6.Text = "FREE";
            }

        }

        private void akt1_Click(object sender, EventArgs e)
        {

        }

        private void ek2_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
