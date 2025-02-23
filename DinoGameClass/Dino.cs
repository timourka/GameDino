using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameClass
{
    public class Dino
    {
        System.Drawing.Image image1;
        System.Drawing.Image image2;
        int img;
        System.Drawing.Image imageDeath;
        System.Drawing.Image imageJump;
        System.Drawing.Image imageSit1;
        System.Drawing.Image imageSit2;

        public System.Drawing.Image imageToUse;

        public int state; // 1 - run, 2 - jump, 3 - sit, 4 - death
        public int x;
        public int y;

        int ticksFromJump;
        int ticksFromImg;

        public Dino(Image image1, Image image2, Image imageDeath, Image imageJump, Image imageSit1, Image imageSit2)
        {
            this.image1 = image1;
            this.image2 = image2;
            this.imageDeath = imageDeath;
            this.imageJump = imageJump;
            this.imageSit1 = imageSit1;
            this.imageSit2 = imageSit2;
            this.x = 50;
            this.y = 0;
            this.ticksFromJump = 0;
            this.ticksFromImg = 0;
            this.state = 1;
            this.img = 1;
        }

        public void Tick()
        {
            switch (state) {
                case 1:
                    if (img == 1)
                    {
                        imageToUse = image1;
                        if (ticksFromImg >= 4)
                        {
                            img = 2;
                            ticksFromImg = 0;
                        }
                    }
                    else
                    {
                        imageToUse = image2;
                        if (ticksFromImg >= 4)
                        {
                            img = 1;
                            ticksFromImg = 0;
                        }
                    }
                    ticksFromImg++;
                    if (y > 0)
                        y-=10;
                    break;
                case 2:
                    imageToUse = imageJump;

                    if (ticksFromJump < 16)
                        y+=10;

                    ticksFromJump++;
                    if (ticksFromJump == 25)
                    {
                        state = 1;
                        ticksFromJump = 0;
                    }
                    break; 
                case 3:
                    if (img == 1)
                    {
                        imageToUse = imageSit1;
                        if (ticksFromImg >= 4)
                        {
                            img = 2;
                            ticksFromImg = 0;
                        }
                    }
                    else
                    {
                        imageToUse = imageSit2;
                        if (ticksFromImg >= 4)
                        {
                            img = 1;
                            ticksFromImg = 0;
                        }
                    }
                    ticksFromImg++;
                    if (y > 0)
                        y -= 5;
                    break;
                case 4:
                    imageToUse = imageDeath;
                    break;
            }
        }
    }
}
