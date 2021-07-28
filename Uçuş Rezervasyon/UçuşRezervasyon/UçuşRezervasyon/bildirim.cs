using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UçuşRezervasyon
{
    public partial class bildirim : Form
    {
        public bildirim()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\muham\Desktop\Uçuş Rezervasyon\UçuşRezervasyon\UçuşRezervasyon\Resources\bildirim.wav");
            simpleSound.Play();

        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void bildirim_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
