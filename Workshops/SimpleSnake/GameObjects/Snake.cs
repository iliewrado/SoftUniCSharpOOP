using SimpleSnake.GameObjects.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';
        private int foodIndex;
        private bool initialFood;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }

        private int RandomFoodNumber
            => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            if (!initialFood)
            {
                this.foods[foodIndex].SetRandomPosition(this.snakeElements);
                initialFood = true;
            }

            Point currentSnakeHead = snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(this.nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);

                foodIndex = this.RandomFoodNumber;
                this.foods[foodIndex].SetRandomPosition(this.snakeElements);
            }
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
        
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            foods[0] = new FoodHash(this.wall);
            foods[1] = new FoodDollar(this.wall);
            foods[2] = new FoodAsterisk(this.wall);
        }
    }
}
