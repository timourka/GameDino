using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameClass
{
    public class GameField
    {
        public int score = 0;

        public Dino dino;

        public bool gameOver = false;

        public Ground ground;

        public LesNuages nuages;

        public Obstacles obstacles;
        public GameField(int fieldLength, Image imageKaktus, Image imageKaktusBig, Image imageKaktusSmall, Image imagePterodaktil1, Image imagePterodaktil2, Image imageDino1, Image imageDino2, Image imageDinoDeath, Image imageDinoJump, Image imageDinoSit1, Image imageDinoSit2, Image imageGround, Image imageCloud1, Image imageCloud2, Image imageCloud3)
        {
            dino = new Dino(imageDino1, imageDino2, imageDinoDeath, imageDinoJump, imageDinoSit1, imageDinoSit2);
            obstacles = new Obstacles(imageDinoSit1.Height, fieldLength, imageKaktus, imageKaktusBig, imageKaktusSmall, imagePterodaktil1, imagePterodaktil2);
            ground = new Ground(imageGround, fieldLength);
            nuages = new LesNuages(fieldLength, imageCloud1, imageCloud2, imageCloud3);
        }

        public void GameTick()
        {
            if (CheckCollision())
            {
                gameOver = true;
                dino.state = 4;
            }
            dino.Tick();
            obstacles.Tick();
            ground.Tick();
            nuages.Tick();
            score++;
        }

        public void Jump()
        {
            if (dino.y != 0)
                return;
            dino.state = 2;
        }

        public void GetUp()
        {
            dino.state = 1;
        }

        public void Sit()
        {
            if (dino.y != 0)
                return;
            dino.state = 3;
        }
        private bool CheckCollision()
        {
            for (int i = 0; i < obstacles.obstacles.Count; i++)
            {
                if (
                    (obstacles.obstacles[i].x >= dino.x && obstacles.obstacles[i].x <= dino.x + dino.imageToUse.Width) ||
                    (obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width >= dino.x && obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width <= dino.x + dino.imageToUse.Width) ||
                    (dino.x >= obstacles.obstacles[i].x && dino.x <= obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width) ||
                    (dino.x + dino.imageToUse.Width >= obstacles.obstacles[i].x && dino.x + dino.imageToUse.Width <= obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width)
                    )
                {
                    if (
                        (obstacles.obstacles[i].y >= dino.y && obstacles.obstacles[i].y <= dino.y + dino.imageToUse.Height) ||
                        (obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height >= dino.y && obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height <= dino.y + dino.imageToUse.Height) ||
                        (dino.y >= obstacles.obstacles[i].y && dino.y <= obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height) ||
                        (dino.y + dino.imageToUse.Height >= obstacles.obstacles[i].y && dino.y + dino.imageToUse.Height <= obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height)
                        )
                    {
                        Console.Write(obstacles.obstacles[i].x.ToString() + " >= " + dino.x.ToString() + " = " + (obstacles.obstacles[i].x >= dino.x).ToString() + " && ");
                        Console.WriteLine(obstacles.obstacles[i].x.ToString() + " <= " + (dino.x + dino.imageToUse.Width).ToString() + " = " + (obstacles.obstacles[i].x <= dino.x + dino.imageToUse.Width).ToString());
                        Console.Write((obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width).ToString() + " >= " + dino.x.ToString() + " = " + (obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width >= dino.x).ToString() + " && ");
                        Console.WriteLine((obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width).ToString() + " <= " + (dino.x + dino.imageToUse.Width).ToString() + " = " + (obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width <= dino.x + dino.imageToUse.Width).ToString());
                        Console.Write(dino.x.ToString() + " >= " + obstacles.obstacles[i].x.ToString() + " = " + (dino.x >= obstacles.obstacles[i].x).ToString() + " && ");
                        Console.WriteLine(dino.x.ToString() + " <= " + (obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width).ToString() + " = " + (dino.x <= obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width).ToString());
                        Console.Write((dino.x + dino.imageToUse.Width).ToString() + " >= " + obstacles.obstacles[i].x.ToString() + " = " + (dino.x + dino.imageToUse.Width >= obstacles.obstacles[i].x).ToString() + " && ");
                        Console.WriteLine((dino.x + dino.imageToUse.Width).ToString() + " <= " + (obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width).ToString() + " = " + (dino.x + dino.imageToUse.Width <= obstacles.obstacles[i].x + obstacles.obstacles[i].imageToUse.Width).ToString());
                        Console.WriteLine("&&");
                        Console.Write(obstacles.obstacles[i].y.ToString() + " >= " + dino.y.ToString() + " = " + (obstacles.obstacles[i].y >= dino.y).ToString() + " && ");
                        Console.WriteLine(obstacles.obstacles[i].y.ToString() + " <= " + (dino.y + dino.imageToUse.Height).ToString() + " = " + (obstacles.obstacles[i].y <= dino.y + dino.imageToUse.Height).ToString());
                        Console.Write((obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height).ToString() + " >= " + dino.y.ToString() + " = " + (obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height >= dino.y).ToString() + " && ");
                        Console.WriteLine((obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height).ToString() + " <= " + (dino.y + dino.imageToUse.Height).ToString() + " = " + (obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height <= dino.y + dino.imageToUse.Height).ToString());
                        Console.Write(dino.y.ToString() + " >= " + obstacles.obstacles[i].y.ToString() + " = " + (dino.y >= obstacles.obstacles[i].y).ToString() + " && ");
                        Console.WriteLine(dino.y.ToString() + " <= " + (obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height).ToString() + " = " + (dino.y <= obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height).ToString());
                        Console.Write((dino.y + dino.imageToUse.Height).ToString() + " >= " + obstacles.obstacles[i].y.ToString() + " = " + (dino.y + dino.imageToUse.Height >= obstacles.obstacles[i].y).ToString() + " && ");
                        Console.WriteLine((dino.y + dino.imageToUse.Height).ToString() + " <= " + (obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height).ToString() + " = " + (dino.y + dino.imageToUse.Height <= obstacles.obstacles[i].y + obstacles.obstacles[i].imageToUse.Height).ToString());

                        Rectangle itersection = Rectangle.Intersect
                            (
                            new Rectangle(dino.x, dino.y, dino.imageToUse.Width, dino.imageToUse.Height),
                            new Rectangle(obstacles.obstacles[i].x, obstacles.obstacles[i].y, obstacles.obstacles[i].imageToUse.Width, obstacles.obstacles[i].imageToUse.Height)
                            );

                        for (int y = itersection.Top; y < itersection.Bottom; y++)
                            for (int x = itersection.Left; x < itersection.Right; x++) 
                            {
                                if (new Bitmap(dino.imageToUse).GetPixel(x - dino.x, dino.imageToUse.Height - (y - dino.y)-1).A != 0 && new Bitmap(dino.imageToUse).GetPixel(x - obstacles.obstacles[i].x, obstacles.obstacles[i].imageToUse.Height - (y - obstacles.obstacles[i].y) - 1).A != 0)
                                {
                                    Console.WriteLine(new Bitmap(dino.imageToUse).GetPixel(x - dino.x, dino.imageToUse.Height - (y - dino.y) - 1).A);
                                    Console.WriteLine(new Bitmap(dino.imageToUse).GetPixel(x - obstacles.obstacles[i].x, obstacles.obstacles[i].imageToUse.Height - (y - obstacles.obstacles[i].y) - 1).A);
                                    return true;
                                }
                                
                            }
                    }
                }
            }

            return false;
        }
    }
}
