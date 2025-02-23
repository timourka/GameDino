using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameClass
{
    public class Obstacle
    {
        public int x;
        public int y;
        int img;
        int ticksFromImg;
        public System.Drawing.Image image1;
        public System.Drawing.Image image2;
        public System.Drawing.Image imageToUse;
        public Obstacle(Image image1, Image image2, int x, int y)
        {
            this.image1 = image1;
            this.image2 = image2;
            this.x = x;
            this.y = y;
            this.img = 1;
            this.ticksFromImg = 0;
        }
        public void Tick()
        {
            if (img == 1)
            {
                imageToUse = image1;
                if (ticksFromImg >= 7)
                {
                    img = 2;
                    ticksFromImg = 0;
                }
            }
            else
            {
                imageToUse = image2;
                if (ticksFromImg >= 7)
                {
                    img = 1;
                    ticksFromImg = 0;
                }
            }
            ticksFromImg++;
            x -= 8;
        }

        public Obstacle Copy()
        {
            return new Obstacle(image1, image2, x, y);
        }
    }
    public class Obstacles
    {
        public List<Obstacle> obstacles = new List<Obstacle>();

        /*Image imageKaktus;
        Image imageKaktusBig;
        Image imageKaktusSmall;
        Image imagePterodaktil1;
        Image imagePterodaktil2;*/

        Random random = new Random();

        List<Obstacle> obstacleExemples = new List<Obstacle>();

        int fieldLength;

        int ticksForDelay;
        public Obstacles(int dinoSitHeight, int fieldLength, Image imageKaktus, Image imageKaktusBig, Image imageKaktusSmall, Image imagePterodaktil1, Image imagePterodaktil2)
        {
            /*this.imageKaktus = imageKaktus;
            this.imageKaktusBig = imageKaktusBig;
            this.imageKaktusSmall = imageKaktusSmall;
            this.imagePterodaktil1 = imagePterodaktil1;
            this.imagePterodaktil2 = imagePterodaktil2;
            this.fieldLength = fieldLength;*/

            obstacleExemples.Add(new Obstacle(imageKaktus, imageKaktus, fieldLength, 0));
            obstacleExemples.Add(new Obstacle(imageKaktusBig, imageKaktusBig, fieldLength, 0));
            obstacleExemples.Add(new Obstacle(imageKaktusSmall, imageKaktusSmall, fieldLength, 0));
            obstacleExemples.Add(new Obstacle(imagePterodaktil1, imagePterodaktil2, fieldLength, 0));
            obstacleExemples.Add(new Obstacle(imagePterodaktil1, imagePterodaktil2, fieldLength, 30));
            obstacleExemples.Add(new Obstacle(imagePterodaktil1, imagePterodaktil2, fieldLength, dinoSitHeight+10));
        }

        public void Tick()
        {
            if (random.Next(100) > 97 && ticksForDelay == 0)
            {
                obstacles.Add(obstacleExemples[random.Next(obstacleExemples.Count)].Copy());
                ticksForDelay = 50;
            }

            if (ticksForDelay > 0)
            {
                ticksForDelay--;
            }

            for(int i = obstacles.Count - 1; i >= 0; i--) 
            { 
                obstacles[i].Tick(); 
                if (obstacles[i].x < 0 - obstacles[i].imageToUse.Width)
                {
                    obstacles.RemoveAt(i);
                }
            }
        }

    }
}
