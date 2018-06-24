using System;
using System.Collections.Generic;

namespace TruckFour
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = GetAccurateQueue();
            var lowestPipe = GetLowestPossiblePipe(queue);
            Console.WriteLine(lowestPipe - 1);

        }

        private static int GetLowestPossiblePipe(Queue<KeyValuePair<int, int>> queue)
        {
            var index = queue.Count;
            var tempSum = 0;
            var pipe = 0;

            while (index != 0)
            {
                var current = queue.Dequeue();
                var petrol = current.Key;
                var distance = current.Value;
                queue.Enqueue(current);
                pipe++;

                if ((petrol - distance) + tempSum < 0)
                {
                    index = queue.Count;
                    continue;
                }
                else
                {
                    tempSum += petrol - distance;
                    index--;
                }

                if (pipe == 3)
                {
                    pipe = 1;
                }

            }

            return pipe;
        }

        private static Queue<KeyValuePair<int, int>> GetAccurateQueue()
        {
            int numberOfStations = int.Parse(Console.ReadLine());
            var queue = new Queue<KeyValuePair<int, int>>();

            for (int i = 0; i < numberOfStations; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var petrol = int.Parse(input[0]);
                var distance = int.Parse(input[1]);
                queue.Enqueue(new KeyValuePair<int, int>(petrol, distance));
            }

            return queue;
        }
    }
}
