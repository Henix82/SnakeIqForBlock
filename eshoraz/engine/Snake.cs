using System;
using System.Drawing;
using System.Linq;

namespace eshoraz.engine
{
    internal enum Duration
    {
        Up, Down, Left, Right
    }

    internal class Snake
    {
        private const int firstLength = 1;
        private const int durations = 4;
        private const int radiusView = 5;
        private const int sizeView = radiusView * 2 + 1;
        public int length;
        public Point[] points;
        private readonly Random random;
        public Duration Duration { get; set; }
        private int[,,] viewObsatcle;
        private int[,,] viewFeed;

        public Snake(Random random, SnakesEngine engine)
        {
            points = new Point[firstLength];
            length = firstLength;
            this.random = random;

            viewObsatcle = new int[sizeView, sizeView, durations];
            for (int i = 0; i < sizeView; i++)
                for (int j = 0; j < sizeView; j++)
                    for (int k = 0; k < durations; k++)
                        viewObsatcle[i, j, k] = random.Next(-100, 0);

            viewFeed = new int[sizeView, sizeView, durations];
            for (int i = 0; i < sizeView; i++)
                for (int j = 0; j < sizeView; j++)
                    for (int k = 0; k < durations; k++)
                        viewFeed[i, j, k] = random.Next(0, 100);

            ChoiseDuration(engine);
        }

        public void ChoiseDuration(SnakesEngine engine)
        {
            int[] dur = new int[durations];
            for (int i = -(sizeView / 2), trueI = 0; i < sizeView / 2; i++, trueI++)
                for (int j = -(sizeView / 2), trueJ = 0; j < sizeView / 2; j++, trueJ++)
                {
                    if (i + points[0].X < 0 || j + points[0].Y < 0
                    || i + points[0].X > engine.countX - 1 || j + points[0].Y > engine.countY - 1 ||
                    (i == 0 && j == 0))
                    {
                        continue;
                    }
                    if (engine.GetCell(i + points[0].X, j + points[0].Y) == TypeCell.Snake
                        || engine.GetCell(i + points[0].X, j + points[0].Y) == TypeCell.Obstacle)
                    {
                        for (int k = 0; k < durations; k++)
                        {
                            dur[k] += viewObsatcle[trueI, trueJ, k];
                        }
                    }
                    else if (engine.GetCell(i + points[0].X, j + points[0].Y) == TypeCell.Feed)
                    {
                        for (int k = 0; k < durations; k++)
                        {
                            dur[k] += viewFeed[trueI, trueJ, k];
                        }
                    }
                }
            int max = dur.Max();
            if (max == 0)
            {
                Duration = (Duration)random.Next(durations);
            }
            else
            {
                Duration d = Duration;
                switch (dur.ToList().IndexOf(max))
                {
                    case 0: if (d == Duration.Down) { break; } else { Duration = Duration.Up; } break;
                    case 1: if (d == Duration.Up) { break; } else { Duration = Duration.Down; } break;
                    case 2: if (d == Duration.Right) { break; } else { Duration = Duration.Left; } break;
                    case 3: if (d == Duration.Left) { break; } else { Duration = Duration.Right; } break;
                }
            }
        }
        public void MoveSnake()
        {
            Point[] temp = new Point[length];
            temp[0] = points[0];
            switch (Duration)
            {
                case Duration.Up:
                    temp[0].Y -= 1; break;
                case Duration.Down:
                    temp[0].Y += 1; break;
                case Duration.Left:
                    temp[0].X -= 1; break;
                case Duration.Right:
                    temp[0].X += 1; break;
            }
            for (int i = 0; i < length - 1; i++)
                temp[i + 1] = points[i];
            points = temp;
        }
    }
}
