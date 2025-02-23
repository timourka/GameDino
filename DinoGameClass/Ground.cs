using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameClass
{
    public class Ground
    {
        Image image;
        public Image imageToUse;
        Bitmap bmp;


        int x;
        int len;
        public Ground(Image image, int len) 
        {
            this.image = image;
            this.len = len;
            bmp = new Bitmap(len, image.Height);
            x = 0;
        }

        public void Tick()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            for (int i = x; i < len; i+=image.Width) 
            {
                g.DrawImage(image, i, 0);
            }
            x-=8;
            if (x == -image.Width) 
                x = 0;

            imageToUse = bmp;
        }
    }
}
