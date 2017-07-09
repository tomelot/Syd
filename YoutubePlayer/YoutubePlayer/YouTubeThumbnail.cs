using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YoutubePlayer
{
    class YouTubeThumbnail
    {
        public Panel panel;
        public PictureBox image;
        public Label label;
        public string url;

        public YouTubeThumbnail(Form form)
        {
            panel = new Panel();
            image = new PictureBox();
            label = new Label();
            form.Controls.Add(panel);
            form.Controls.Add(image);
            form.Controls.Add(label);
            panel.Size = new Size(166, 150);
            image.Parent = panel;
            label.Parent = panel;
            image.Size = new Size(160, 90);
            image.Location = new Point(3, 3);
            label.AutoSize = false;
            label.Size = new Size(160, 50);
            label.Location = new Point(3, 96);
            label.TextAlign = ContentAlignment.TopCenter;

        }
    }
}
