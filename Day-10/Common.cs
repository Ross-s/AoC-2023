using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    public static class Common
    {
        public static List<List<char>> ParseMap(string input)
        {
            var map = new List<List<char>>();
            var lines = input.Split("\n");
            foreach (var line in lines)
            {
                var chars = line.ToCharArray().ToList();
                map.Add(chars);
            }

            return map;
        }

        public static (int x, int y) FindLetter(string letter, List<List<char>> map)
        {
            var yCord = 0;
            var xCord = 0;


            // Find "S"
            var tempY = 0;
            foreach (var y in map) {
                var tempX = 0;
                foreach (var x in y) {
                    if (x == 'S') {
                        xCord = tempX;
                        yCord = tempY;
                    }
                    tempX++;
                }
                tempY++;
            }

            return (xCord, yCord);
        }

        public static int CalculateStepsToFarthestPoint(List<List<char>> map)
        {
            var start = FindLetter("S", map);
            var distances = new Dictionary<(int x, int y), int>();
            distances[start] = 0;

            var queue = new Queue<(int x, int y)>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var neighbors = GetNeighbors(current, map);

                foreach (var neighbor in neighbors)
                {
                    if (!distances.ContainsKey(neighbor))
                    {
                        distances[neighbor] = distances[current] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return distances.Values.Max();
        }

        private static List<(int x, int y)> GetNeighbors((int x, int y) position, List<List<char>> map)
        {
            var neighbors = new List<(int x, int y)>();
            var directions = new List<(int dx, int dy)> { (0, -1), (0, 1), (-1, 0), (1, 0) };

            foreach (var (dx, dy) in directions)
            {
                var neighborX = position.x + dx;
                var neighborY = position.y + dy;

                var direction = "";

                switch (dx, dy)
                {
                    case (0, -1):
                        direction = "up";
                        break;
                    case (0, 1):
                        direction = "down";
                        break;
                    case (-1, 0):
                        direction = "left";
                        break;
                    case (1, 0):
                        direction = "right";
                        break;
                }

                if (IsValidPosition(neighborX, neighborY, map, direction))
                {
                    neighbors.Add((neighborX, neighborY));
                }
            }

            return neighbors;
        }

        private static bool IsValidPosition(int x, int y, List<List<char>> map, string direction)
        {
            if (y >= 0 && y < map.Count && x >= 0 && x < map[y].Count)
            {
                if (direction == "up")
                {
                    if (map[y][x] is '|' or '7' or 'F') 
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (direction == "down")
                {
                    if (map[y][x] is '|' or 'J' or 'L') 
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (direction == "left")
                {
                    if (map[y][x] is '-' or 'F' or 'L') 
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (direction == "right")
                {
                    if (map[y][x] is '-' or '7' or 'J') 
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            } else {
                return false;
            }
        } 
    }
}







