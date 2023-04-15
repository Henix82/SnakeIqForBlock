using eshoraz.engine;
using System.Drawing;
using System.Windows.Forms;

namespace eshoraz
{
    public partial class Form1 : Form
    {
        private readonly int screenX;
        private readonly int screenY;
        private readonly int sizeCell;
        private readonly int width;
        private readonly int height;
        private Graphics graphics;
        private SnakesEngine snakesEngine;
        public Form1()
        {
            InitializeComponent();
            sizeCell = 5;
            screenX = pictureBox1.Width;
            screenY = pictureBox1.Height;
            width = screenX / sizeCell;
            height = screenY / sizeCell;
            pictureBox1.Image = new Bitmap(screenX, screenY);
            graphics = Graphics.FromImage(pictureBox1.Image);

            numericSnake.Maximum = (width - 2) * (height - 2) - numericFeed.Value;
            numericFeed.Maximum = (width - 2) * (height - 2)- numericSnake.Value;

            snakesEngine = new SnakesEngine(width, height, (int)numericSnake.Value, (int)numericFeed.Value);
            timer1.Enabled = true;
        }
        private void Draw()
        {
            graphics.Clear(Color.Gray);
            int countX = screenX / sizeCell;
            int countY = screenY / sizeCell;
            for (int i = 0; i < countX; i++)
                for (int j = 0; j < countY; j++)
                    switch (snakesEngine.GetCell(i, j))
                    {
                        case TypeCell.Obstacle: graphics.FillRectangle(Brushes.Black, sizeCell * i, sizeCell * j, sizeCell, sizeCell); break;
                        case TypeCell.Feed: graphics.FillRectangle(Brushes.Green, sizeCell * i, sizeCell * j, sizeCell, sizeCell); break;
                        case TypeCell.Snake: graphics.FillRectangle(Brushes.Aquamarine, sizeCell * i, sizeCell * j, sizeCell, sizeCell); break;
                        default: break;
                    }
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            snakesEngine.NextGeneration();
            Draw();
        }

        private void buttonSnake_Click(object sender, System.EventArgs e)
        {
            snakesEngine.IncrimentSnake();
            numericSnake.Value++;
        }

        private void buttonFeed_Click(object sender, System.EventArgs e)
        {
            snakesEngine.IncrimentFeed();
            numericFeed.Value++;
        }

        private void buttonRestart_Click(object sender, System.EventArgs e)
        {
            snakesEngine = new SnakesEngine(width, height, (int)numericSnake.Value, (int)numericFeed.Value);
        }
    }
}
