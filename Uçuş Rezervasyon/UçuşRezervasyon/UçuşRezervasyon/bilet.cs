using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace UçuşRezervasyon
{
    public partial class bilet : Form
    {
        public bilet()
        {
            InitializeComponent();
        }

        private void bilet_Load(object sender, EventArgs e)
        {
            if (giris.dil == 1)
            {
                tr();
            }
            else
            {
                ing();
            }
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\muham\Desktop\Uçuş Rezervasyon\UçuşRezervasyon\UçuşRezervasyon\Resources\party.wav");
            simpleSound.Play();
            biletisim.Text = giris.isim;
            bilettc.Text = giris.tc;
            bilettel.Text = giris.tel;
            label7.Text = girisSayfasi.yolcusay.ToString();
            random();
        
        }
        public void random()
        {
            Random rastgele = new Random();
            int sayi;
            sayi = rastgele.Next(200,250);
            label8.Text = sayi.ToString();

        }
        void tr()
        {
            giris.dil = 1;
            groupBox1.ResetText();
            groupBox1.Text = "Kişisel Bilgiler";
            groupBox2.ResetText();
            groupBox2.Text = "Kapı";
            groupBox3.ResetText();
            groupBox3.Text = "İniş ve Biniş";
            groupBox4.ResetText();
            groupBox4.Text = "Yolcu Sayısı";
            groupBox5.ResetText();
            groupBox5.Text = "Tutar";
            label4.ResetText();
            label4.Text = "İsim Soy isim:";
            label5.ResetText();
            label5.Text = "TC Kimlik Numarası:";
            label6.ResetText();
            label6.Text = "Telefon Numarası:";
            if (tutarbilet.Text == "FREE")
            {
                tutarbilet.ResetText();
                tutarbilet.Text = "ÜCRETSİZ";
            }
           




        }
        void ing()
        {
            giris.dil = 2;
            groupBox1.ResetText();
            groupBox1.Text = "Personal Information";
            groupBox2.ResetText();
            groupBox2.Text = "GATE";
            groupBox3.ResetText();
            groupBox3.Text = "Time Information";
            groupBox4.ResetText();
            groupBox4.Text = "Number of passengers";
            groupBox5.ResetText();
            groupBox5.Text = "Total";
            label4.ResetText();
            label4.Text = "Name Surname:";
            label5.ResetText();
            label5.Text = "TC ID NO:";
            label6.ResetText();
            label6.Text = "Phone Number:";
            if (tutarbilet.Text == "ÜCRETSİZ")
            {
                tutarbilet.ResetText();
                tutarbilet.Text = "FREE";
            }
           




        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tr();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ing();
        }
    }
}
