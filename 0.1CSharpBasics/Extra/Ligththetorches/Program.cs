using System;
using System.Diagnostics;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int rooms = byte.Parse(Console.ReadLine());
            string orentation = Console.ReadLine();
            int counter = 0;
            int lastPosition = Convert.ToByte(rooms / 2);
            int currentPosition = 0;

            char[] basementRooms = new char[rooms];

            for (int i = 0; i < basementRooms.Length; i++)
            {
                if (counter % orentation.Length == 0)
                {
                    counter = 0;
                }
                basementRooms[i] = orentation[counter];
                counter++;
            }
            string move = Console.ReadLine();
            //            counter = 0;
            while (move != "END")
            {
                string[] directions = move.Split(' ');
                string direction = directions[0];
                int steps = byte.Parse(directions[1]) + 1;

                if (direction == "LEFT")
                {
                    currentPosition = Convert.ToInt32(lastPosition - steps);
                    if (currentPosition < 0)
                    {
                        currentPosition = 0;
                    }
                }
                if (direction == "RIGHT")
                {
                    currentPosition = Convert.ToInt32(lastPosition + steps);
                    if (currentPosition > basementRooms.Length)
                    {
                        currentPosition = basementRooms.Length - 1;
                    }
                }


                char roomLight = basementRooms[currentPosition];
                SwitchRoomLight(roomLight, basementRooms, currentPosition);

                lastPosition = currentPosition;
                counter++;
                Console.WriteLine(basementRooms);
                move = Console.ReadLine();
            }

            int countD = 0;

            for (int i = 0; i < basementRooms.Length; i++)
            {
                if (basementRooms[i] == 'D')
                {
                    countD++;
                }
            }
            int dInASCII = (char)'D';
            Console.WriteLine(countD * dInASCII);
        }

        private static void SwitchRoomLight(char roomLight, char[] basementRooms, int currentPosition)
        {
            switch (roomLight)
            {
                case 'L':
                    basementRooms[currentPosition] = 'D';
                    break;
                case 'D':
                    basementRooms[currentPosition] = 'L';
                    break;
                default:
                    throw new AggregateException("There is no such a light!");
                    break;
            }
        }
    }
}