using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameClass
{
    public class LeNuage
    {
        public Image image;
        public int x;
        public int y;
        Random random;
        public double yD;
        public double yV;
        public LeNuage(Image image, int len, int y)
        {
            this.image = image;
            this.x = len;
            this.y = y;
            this.yD = y;
            this.yV = 0;
            random = new Random();
        }

        public void Tick()
        {
            x--;
            yV += (random.NextDouble()-0.5)/10;
            yD = yD + yV;
            y = (int)yD;
        }

        public LeNuage Copy()
        {
            return new LeNuage(image, x, y);
        }
    }
    public class LesNuages
    {
        List<LeNuage> lesNuagesExemples;
        int ticksLastNuage;
        int ticksLastNuageNorm;
        Random random;

        public List<LeNuage> lesNuages;

        public LesNuages(int len, Image imageNuage1, Image imageNuage2, Image imageNuage3)
        {
            random = new Random();
            lesNuagesExemples = new List<LeNuage>();
            lesNuages = new List<LeNuage>();

            ticksLastNuageNorm = len/3 - random.Next(0,len/9);
            ticksLastNuage = 0;

            lesNuagesExemples.Add(new LeNuage(imageNuage1, len, 100));
            lesNuagesExemples.Add(new LeNuage(imageNuage2, len, 100));
            lesNuagesExemples.Add(new LeNuage(imageNuage3, len, 100));
            lesNuagesExemples.Add(new LeNuage(imageNuage1, len, 220));
            lesNuagesExemples.Add(new LeNuage(imageNuage2, len, 220));
            lesNuagesExemples.Add(new LeNuage(imageNuage3, len, 220));
            lesNuagesExemples.Add(new LeNuage(imageNuage1, len, 300));
            lesNuagesExemples.Add(new LeNuage(imageNuage2, len, 300));
            lesNuagesExemples.Add(new LeNuage(imageNuage3, len, 300));
        }

        public void Tick()
        {
            if (ticksLastNuage == 0)
            {
                lesNuages.Add(lesNuagesExemples[random.Next(lesNuagesExemples.Count)].Copy());
                ticksLastNuage = ticksLastNuageNorm;
            }

            if (ticksLastNuage > 0)
            {
                ticksLastNuage--;
            }
            foreach (LeNuage leNuage in lesNuages)
                leNuage.Tick();
            for (int i = lesNuages.Count - 1; i >= 0; i--)
            {
                if (lesNuages[i].x < -lesNuages[i].image.Width) 
                    lesNuages.RemoveAt(i);
            }
        }
    }
}
