using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question353
    {
    }

    // https://leetcode.com/problems/design-snake-game/discuss/230606/C-Queue-and-Hashset-solution
    public class SnakeGame
    {
        private int _width = 0,
                    _height = 0,
                    _foodIndex = 0,
                    _score = 0;
        private int[][] _food = null;
        private int[] _headPosition = new int[] { 0, 0 };
        private Queue<string> _snake = new Queue<string>();
        private HashSet<string> _snakeCoordinate = new HashSet<string>();

        public SnakeGame(int width, int height, int[][] food)
        {
            this._width = width;
            this._height = height;
            this._food = food;

            this._snake.Enqueue(string.Join(",", _headPosition));
            this._snakeCoordinate.Add(string.Join(",", _headPosition));
        }

        public int Move(string direction)
        {
            string tail = string.Empty;

            switch (direction)
            {
                case "U":
                    if (--_headPosition[0] < 0)
                        return -1;
                    break;
                case "D":
                    if (++_headPosition[0] == this._height)
                        return -1;
                    break;
                case "L":
                    if (--_headPosition[1] < 0)
                        return -1;
                    break;
                case "R":
                    if (++_headPosition[1] == this._width)
                        return -1;
                    break;
            }

            if (foundFood())
                this._score++;
            else
            {
                tail = _snake.Dequeue();
                _snakeCoordinate.Remove(tail);
            }

            if (_snakeCoordinate.Contains(string.Join(",", _headPosition)))
                return -1;

            _snake.Enqueue(string.Join(",", _headPosition));
            _snakeCoordinate.Add(string.Join(",", _headPosition));

            return this._score;
        }

        private bool foundFood()
        {
            if (this._foodIndex < this._food.Length && _headPosition[0] == this._food[this._foodIndex][0] && _headPosition[1] == this._food[this._foodIndex][1])
            {
                this._foodIndex++;
                return true;
            }

            return false;
        }
    }
}
