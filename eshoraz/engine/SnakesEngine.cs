using eshoraz.engine;
using System;
using System.Collections.Generic;
using System.Drawing;
namespace eshoraz
{
    public class SnakesEngine
    {
        private Cell[,] field; //Main field
        private List<Snake> snakes; //List with Snake
        public readonly int countX; //Count "Cell" X
        public readonly int countY; //Count "Cell" Y
        private int maxCountSnake; //Max count Snake on field
        private int maxCountFeed; //Max count Feed on field
        private int currentCountFeed; // Curren count Feed on field
        public readonly Random random; // For random position
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="countX"></param>
        /// <param name="countY"></param>
        /// <param name="Snake"></param>
        /// <param name="Feed"></param>
        public SnakesEngine(int countX, int countY, int Snake, int Feed)
        {
            this.countX = countX;
            this.countY = countY;
            maxCountFeed = Feed;
            maxCountSnake = Snake;
            if ((countX - 2) * (countY - 2) < maxCountFeed + maxCountSnake)
                throw new ArgumentException("too much не влезает");
            field = new Cell[countX, countY];
            for (int i = 0; i < countX; i++)
                for (int j = 0; j < countY; j++)
                {
                    field[i, j] = new Cell
                    {
                        Point = new Point(i, j)
                    };
                }
            SetObstacle();
            snakes = new List<Snake>();
            random = new Random();
        }

        public void NextGeneration()
        {
            for (int i = 0; i < snakes.Count; i++)
            {
                snakes[i].ChoiseDuration(this);
                snakes[i].MoveSnake();
            }

            for (int i = 0; i < snakes.Count; i++)
            {
                if (field[snakes[i].points[0].X, snakes[i].points[0].Y].Type == TypeCell.Snake ||
                    field[snakes[i].points[0].X, snakes[i].points[0].Y].Type == TypeCell.Obstacle)
                {
                    DeleteSnake(i);
                    i--;
                }
                else if (field[snakes[i].points[0].X, snakes[i].points[0].Y].Type == TypeCell.Feed)
                {
                    snakes[i].length++;
                    currentCountFeed--;
                }
            }
            ClearFieldOfSnakes();
            while (snakes.Count < maxCountSnake)
            {
                AddSnake();
            }
            while (currentCountFeed < maxCountFeed)
            {
                AddFeed();
            }
            DrawSnakesOnField();
        }

        public TypeCell GetCell(int i, int j)
        {
            return field[i, j].Type;
        }

        public void IncrimentSnake()
        {
            maxCountSnake++;
        }

        public void IncrimentFeed()
        {
            maxCountFeed++;
        }

        private void SetObstacle()
        {
            for (int i = 0; i < countX; i++)
                for (int j = 0; j < countY; j++)
                    if (i == 0 || j == 0 || i == countX - 1 || j == countY - 1)
                        field[i, j].Type = TypeCell.Obstacle;
        }

        private void AddSnake()
        {
            snakes.Add(new Snake(random, this));
            while (true)
            {
                int x = random.Next(countX);
                int y = random.Next(countY);
                if (field[x, y].Type == TypeCell.Void)
                {
                    snakes[snakes.Count - 1].points[0] = new Point(x, y);
                    snakes[snakes.Count - 1].ChoiseDuration(this);
                    field[x, y].Type = TypeCell.Snake;
                    break;
                }
            }
        }

        private void DeleteSnake(int index)
        {
            snakes.RemoveAt(index);
        }

        private void AddFeed()
        {
            while (true)
            {
                int x = random.Next(countX);
                int y = random.Next(countY);
                if (field[x, y].Type == TypeCell.Void)
                {
                    field[x, y].Type = TypeCell.Feed;
                    currentCountFeed++;
                    break;
                }
            }
        }
        private void ClearFieldOfSnakes()
        {
            for (int i = 0; i < countX; i++)
                for (int j = 0; j < countY; j++)
                    if (field[i, j].Type == TypeCell.Snake)
                        field[i, j].Type = TypeCell.Void;
        }
        private void DrawSnakesOnField()
        {
            for (int i = 0; i < snakes.Count; i++)
                for (int j = 0; j < snakes[i].points.Length; j++)
                    field[snakes[i].points[j].X, snakes[i].points[j].Y].Type = TypeCell.Snake;
        }

    }
}
