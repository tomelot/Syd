using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace YoutubePlayer
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Player VideoPlayer;
        public Form1()
        {
            InitializeComponent();

        }

        private void Navigate_Click(object sender, EventArgs e)
        {
            VideoPlayer.PlayURL(URLtb.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoPlayer = new Player(player, play, TimeBar, Time, FullTime);
        }
        
    }
}
