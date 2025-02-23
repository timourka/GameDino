using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DinoGameClass;

namespace GameDino
{
    public partial class Form1 : Form
    {
        DinoGameClass.GameField gameField;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            timer1.Start();

            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.BackgroundImage = Image.FromFile(@"./src/restart.png");
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Size = new Size(77, 73);
            pictureBox2.Visible = false;

            /*
            Bitmap dino = new Bitmap(50,50);
            Graphics gr = Graphics.FromImage(dino);
            gr.Clear(Color.Gray);
            Bitmap dinoSit = new Bitmap(50, 25);
            gr = Graphics.FromImage(dinoSit);
            gr.Clear(Color.Gray);
            Bitmap dinoDeath = new Bitmap(50, 50);
            gr = Graphics.FromImage(dinoDeath);
            gr.Clear(Color.Red);
            Bitmap Kaktus = new Bitmap(25,40);
            gr = Graphics.FromImage(Kaktus);
            gr.Clear(Color.Green);
            Bitmap KaktusBig = new Bitmap(35, 40);
            gr = Graphics.FromImage(KaktusBig);
            gr.Clear(Color.Green);
            Bitmap KaktusSmall = new Bitmap(25, 35);
            gr = Graphics.FromImage(KaktusSmall);
            gr.Clear(Color.Green);
            Bitmap Pterich = new Bitmap(40, 20);
            gr = Graphics.FromImage(Pterich);
            gr.Clear(Color.DarkGray);
            Bitmap Pterich2 = new Bitmap(40, 20);
            gr = Graphics.FromImage(Pterich2);
            gr.Clear(Color.Gray);
            Bitmap grace = new Bitmap(pictureBox1.Width/2, 5);
            gr = Graphics.FromImage(grace);
            Random random = new Random();
            for (int i = 0; i < grace.Width; i++)
            {
                Pen[] pens = { Pens.Green, Pens.GreenYellow, Pens.PaleGreen, Pens.DarkGreen, Pens.LawnGreen, Pens.DarkOliveGreen, Pens.Gray, Pens.LightGreen, Pens.ForestGreen, Pens.LightSeaGreen, Pens.SpringGreen};
                gr.DrawLine(pens[random.Next(pens.Length)], i, grace.Height, i, random.Next(grace.Height+1));
            }
            Bitmap cloud = new Bitmap(50, 35);
            gr = Graphics.FromImage(cloud);
            gr.Clear(Color.FromArgb(128, 146, 196, 209));

            gameField = new DinoGameClass.GameField(pictureBox1.Width, Kaktus, KaktusBig, KaktusSmall, Pterich, Pterich2, dino, dino, dinoDeath, dino, dinoSit, dinoSit, grace, cloud, cloud, cloud);
            */

            Image pter1 = Image.FromFile("D:\\ptr1.png");
            Image pter2 = Image.FromFile("D:\\ptr2.png");
            Image kaktus1 = Image.FromFile("D:\\kaktussa.png");
            Image kaktus2 = Image.FromFile("D:\\kaktussa2.png");
            Image kaktus3 = Image.FromFile("D:\\kaktussa3.png");
            Image dino1 = Image.FromFile("D:\\dino1.png");
            Image dino2 = Image.FromFile("D:\\dino2.png");
            Image dino3 = Image.FromFile("D:\\dino6.png");
            Image dino4 = Image.FromFile("D:\\dino3.png");
            Image dino5 = Image.FromFile("D:\\dino4.png");
            Image dino6 = Image.FromFile("D:\\dino5.png");
            Image cloud = Image.FromFile("D:\\cloud.png");
            Image cloud2 = Image.FromFile("D:\\cloud2.png");
            Image cloud3 = Image.FromFile("D:\\cloud3.png");
            Bitmap grace = new Bitmap(pictureBox1.Width / 2, 5);
            Graphics gr = Graphics.FromImage(grace);
            Random random = new Random();
            for (int i = 0; i < grace.Width; i++)
            {
                Pen[] pens = { Pens.Green, Pens.GreenYellow, Pens.PaleGreen, Pens.DarkGreen, Pens.LawnGreen, Pens.DarkOliveGreen, Pens.Gray, Pens.LightGreen, Pens.ForestGreen, Pens.LightSeaGreen, Pens.SpringGreen };
                gr.DrawLine(pens[random.Next(pens.Length)], i, grace.Height, i, random.Next(grace.Height + 1));
            }

            gameField = new DinoGameClass.GameField(pictureBox1.Width, kaktus1, kaktus2, kaktus3, pter1, pter2, dino1, dino2, dino3, dino4, dino5, dino6, grace, cloud, cloud2, cloud3);
            
        }

        int r = 0;
        static double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return (radians);
        }
        void redraw()
        {
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            foreach(LeNuage leNuage in gameField.nuages.lesNuages)
            {
                gr.DrawImage(leNuage.image, leNuage.x, bmp.Height - leNuage.image.Height - leNuage.y);
            }
            gr.DrawImage(gameField.dino.imageToUse, gameField.dino.x, pictureBox1.Height - gameField.dino.y - gameField.dino.imageToUse.Height);
            foreach (Obstacle obstacle in gameField.obstacles.obstacles)
            {
                gr.DrawImage(obstacle.imageToUse, obstacle.x, pictureBox1.Height - obstacle.y - obstacle.imageToUse.Height);
            }
            gr.DrawImage(gameField.ground.imageToUse, 0, bmp.Height - gameField.ground.imageToUse.Height);
            if (gameField.gameOver)
            {
                gr.DrawImage(Image.FromFile("D:\\gameOver2.png"), 200 + Convert.ToInt32(7 * Math.Sin(ConvertDegreesToRadians(r))), 10 + Convert.ToInt32(7 * Math.Cos(ConvertDegreesToRadians(r))));
                gr.DrawImage(Image.FromFile("D:\\gameOver1.png"), 200, 10);
            }
            pictureBox1.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameField.gameOver)
            {
                pictureBox2.Visible = true;
                r+=5;
                if (r > 360)
                    r = 0;
            }
            else
                gameField.GameTick();
            label1.Text = gameField.score.ToString();
            
                redraw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    gameField.Jump();
                    break;
                case Keys.Down:
                    gameField.Sit();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    gameField.GetUp();
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;

            Image pter1 = Image.FromFile("D:\\ptr1.png");
            Image pter2 = Image.FromFile("D:\\ptr2.png");
            Image kaktus1 = Image.FromFile("D:\\kaktussa.png");
            Image kaktus2 = Image.FromFile("D:\\kaktussa2.png");
            Image kaktus3 = Image.FromFile("D:\\kaktussa3.png");
            Image dino1 = Image.FromFile("D:\\dino1.png");
            Image dino2 = Image.FromFile("D:\\dino2.png");
            Image dino3 = Image.FromFile("D:\\dino6.png");
            Image dino4 = Image.FromFile("D:\\dino3.png");
            Image dino5 = Image.FromFile("D:\\dino4.png");
            Image dino6 = Image.FromFile("D:\\dino5.png");
            Image cloud = Image.FromFile("D:\\cloud.png");
            Image cloud2 = Image.FromFile("D:\\cloud2.png");
            Image cloud3 = Image.FromFile("D:\\cloud3.png");
            Bitmap grace = new Bitmap(pictureBox1.Width / 2, 5);
            Graphics gr = Graphics.FromImage(grace);
            Random random = new Random();
            for (int i = 0; i < grace.Width; i++)
            {
                Pen[] pens = { Pens.Green, Pens.GreenYellow, Pens.PaleGreen, Pens.DarkGreen, Pens.LawnGreen, Pens.DarkOliveGreen, Pens.Gray, Pens.LightGreen, Pens.ForestGreen, Pens.LightSeaGreen, Pens.SpringGreen };
                gr.DrawLine(pens[random.Next(pens.Length)], i, grace.Height, i, random.Next(grace.Height + 1));
            }

            gameField = new DinoGameClass.GameField(pictureBox1.Width, kaktus1, kaktus2, kaktus3, pter1, pter2, dino1, dino2, dino3, dino4, dino5, dino6, grace, cloud, cloud2, cloud3);
        }
    }
}
