using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;




namespace UçuşRezervasyon
{
    
    public partial class girisSayfasi : Form
    {

        public static int secildi=2;      
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,    
            int nTopRect,      
            int nRightRect,    
            int nBottomRect,   
            int nWidthEllipse, 
            int nHeightEllipse 
        );
        
        public girisSayfasi()
        {
  
            InitializeComponent();
           
           
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
          
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Dikkat!";
            Aciklama.ToolTipIcon = ToolTipIcon.Info;
            Aciklama.IsBalloon = true;

            Aciklama.SetToolTip(oturum, "Bu işlem Oturumunuzu Kapatacaktır.");

        }
        public static int tut, tut1;
        private void girisSayfasi_Load(object sender, EventArgs e)
        {
            if (giris.dil == 1)
            {
                tr();

                
            }
           else if (giris.dil == 2)
            {
                eng();
                
                
            }
            secildi = 2;
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\muham\\Desktop\\Uçuş Rezervasyon\\giris.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT *FROM ucus", baglanti);
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                nereden.Items.Add(dr["sehirler"]);
                nereye.Items.Add(dr["sehirler"]);
            }

            nereden.SelectedIndex = 1;
            nereye.SelectedIndex = 5;
            isim.Text = giris.isim;
            tc.Text = giris.tc;
            
            

        }
        void tr()
        {
            giris.dil = 1;
            bunifuCustomLabel1.ResetText();
            bunifuCustomLabel1.Text = "Uçak Bileti Ara,Ucuza Uçak Biletleri";
            label9.ResetText();
            label9.Text = "Hoşgeldin:";
            label4.ResetText();
            label4.Text = "Nereden";
            label6.ResetText();
            label6.Text = "Nereye";
            label5.ResetText();
            label5.Text = "Yolcu Sayısı";
            label8.ResetText();
            label8.Text = "Ekonomi";
            bunifuFlatButton1.ResetText();
            bunifuFlatButton1.Text = "Uçak Bileti Ara";
            label10.ResetText();
            label10.Text = "TC Kimlik No:";
        }
        void eng()
        {
            giris.dil = 2;
            bunifuCustomLabel1.ResetText();
            bunifuCustomLabel1.Text = "Search for Flights,Cheap Flight Tickets";
            label9.ResetText();
            label9.Text = "Welcome:";
            label4.ResetText();
            label4.Text = "Departing From";
            label6.ResetText();
            label6.Text = "Arriving at";
            label5.ResetText();
            label5.Text = "Number of passengers";
            label8.ResetText();
            label8.Text = "Economy";
            bunifuFlatButton1.ResetText();
            bunifuFlatButton1.Text = "Search flights";
            label10.ResetText();
            label10.Text = "TC ID NO:";
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
          
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if (nereden.SelectedIndex!= nereye.SelectedIndex)
            {
                nereye.Enabled = true;
                bunifuFlatButton1.Enabled = true;

            }
            else
            {
                nereye.Enabled = false;
                bunifuFlatButton1.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (ekonomich.Checked == false)
            {
                businessch.Checked = true;
                secildi = 2;
            }
            else
            {
                
                businessch.Checked = false;
                ekonomich.Checked = true;
                secildi = 1;
            }

        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if(businessch.Checked == false)
            {
               
                ekonomich.Checked = true;
                secildi = 1;
            }
            else
            {   
                ekonomich.Checked = false;
                businessch.Checked = true;
                secildi = 2;
            }
    
        }

     
            public static int yolcusay;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            
            liste liste = new liste();
           
            yolcusay = Convert.ToInt32(yolcu.Value);
            tut = nereden.SelectedIndex;
            tut1 = nereye.SelectedIndex;
          
            if(ekonomich.Checked==true && businessch.Checked == false)
            {
                secildi = 1;
                liste.ek1.Text = "Ekonomi";
                liste.ek2.Text = "Ekonomi";
                liste.ek3.Text = "Ekonomi";
                liste.ek4.Text = "Ekonomi";
                liste.ek5.Text = "Ekonomi";
                liste.ek6.Text = "Ekonomi";
                
              
                
              


            }
            else if(ekonomich.Checked == false && businessch.Checked == true)
            {
                secildi = 2;
                liste.ek1.Text = "Business";
                liste.ek2.Text = "Business";
                liste.ek3.Text = "Business";
                liste.ek4.Text = "Business";
                liste.ek5.Text = "Business";
                liste.ek6.Text = "Business";
                
               

            }
            liste.kal1.Text = nereden.SelectedItem.ToString();
            liste.kal2.Text = nereden.SelectedItem.ToString();
            liste.kal3.Text = nereden.SelectedItem.ToString();
            liste.kal4.Text = nereden.SelectedItem.ToString();
            liste.kal5.Text = nereden.SelectedItem.ToString();
            liste.kal6.Text = nereden.SelectedItem.ToString();
            liste.var1.Text = nereye.SelectedItem.ToString();
            liste.var2.Text = nereye.SelectedItem.ToString();
            liste.var3.Text = nereye.SelectedItem.ToString();
            liste.var4.Text = nereye.SelectedItem.ToString();
            liste.var5.Text = nereye.SelectedItem.ToString();
            liste.var6.Text = nereye.SelectedItem.ToString();
            if(nereden.SelectedIndex==2 && nereye.SelectedIndex == 5 || nereden.SelectedIndex==5 && nereye.SelectedIndex==2)
            {
                liste.akt1.Visible = true;
                liste.akt2.Visible = true;
                liste.akt3.Visible = true;
                liste.akt4.Visible = true;
                liste.akt5.Visible = true;
                liste.akt6.Visible = true;

            }


            this.Hide();
            liste.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void isim_Click(object sender, EventArgs e)
        {

        }

        private void isim_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            int a;
            a = nereden.SelectedIndex;
            nereden.SelectedIndex = nereye.SelectedIndex;
           nereye.SelectedIndex= a;
           

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tc_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris giris = new giris();
            giris.Show();
        }

        private void nereye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nereden.SelectedIndex == 0 && nereye.SelectedIndex == 1 || nereden.SelectedIndex == 1 && nereye.SelectedIndex == 0)
            {
                MessageBox.Show("İstanbul'dan İstanbul'a uçak seferimiz yoktur", "Sistem Mesajı");
                nereden.SelectedIndex = 0;
                nereye.SelectedIndex = 2;
            }
            else
            {
                if (nereden.SelectedIndex != nereye.SelectedIndex)
                {

                    nereye.Enabled = true;
                    bunifuFlatButton1.Enabled = true;
                }
                else
                {
                    nereye.Enabled = false;
                    bunifuFlatButton1.Enabled = false;
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tr();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            eng();
        }

        private void nereden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nereden.SelectedIndex == 0 && nereye.SelectedIndex == 1 || nereden.SelectedIndex == 1 && nereye.SelectedIndex == 0)
            {
                MessageBox.Show("İstanbul'dan İstanbul'a uçak seferimiz yoktur", "Sistem Mesajı");
                nereden.SelectedIndex = 0;
                nereye.SelectedIndex = 2;
            }
            else
            {
                if (nereden.SelectedIndex != nereye.SelectedIndex)
                {

                    nereye.Enabled = true;
                    bunifuFlatButton1.Enabled = true;
                }
                else
                {
                    nereye.Enabled = false;
                    bunifuFlatButton1.Enabled = false;
                }
            }

        }
    }
}
