using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1234
{
    class Program
    {
        static void Main(string[] args)
        {
            //string rooms = Console.ReadLine();
            int rooms = int.Parse(Console.ReadLine());
            string status = Console.ReadLine();
            
            List<char> roomsStatus = new List<char>();
            int counter = 0;
            int index = 0;
            while (counter != rooms)
            {
                if (counter == rooms)
                {
                    break;
                }
                else if (index >= status.Length)
                {
                    index = 0;
                    roomsStatus.Add(status[index]);
                    index++;
                    counter++;
                }
                else
                {
                    roomsStatus.Add(status[index]);
                    index++;
                    counter++;
                }
            }

            string input = Console.ReadLine();
            int roomInTHeMiddle = rooms / 2;
            List<string> listIt2 = input.Split(' ').ToList();
            int counterDark = 0;

            int currentRoom = 0;
            if (listIt2[0] == "LEFT")
            {
                // check to see if sober or not???
                string sober = "";
                if (int.Parse(listIt2[1]) > rooms || int.Parse(listIt2[1]) > (rooms / 2) - 1)
                {
                    listIt2[1] = "0";
                    sober = "sober";
                }

                if (sober == "sober")
                {
                    if (roomsStatus[int.Parse(listIt2[1])] == 'D')
                    {
                        roomsStatus[int.Parse(listIt2[1])] = 'L';
                        currentRoom = int.Parse(listIt2[1]);
                    }
                    else
                    {
                        roomsStatus[int.Parse(listIt2[1])] = 'D';
                        counterDark++;
                        currentRoom = int.Parse(listIt2[1]);
                    }
                }
                else
                {
                    if (roomsStatus[2 - (Convert.ToInt32(listIt2[1]) + 1)] == 'D')
                    {
                        roomsStatus[2 - (Convert.ToInt32(listIt2[1]) + 1)] = 'L';
                        currentRoom = 2 - (Convert.ToInt32(listIt2[1]) + 1);
                    }
                    else
                    {
                        roomsStatus[2 - (Convert.ToInt32(listIt2[1]) + 1)] = 'D';
                        counterDark++;
                        currentRoom = 2 - (Convert.ToInt32(listIt2[1]) + 1);
                    }
                }


            }
            else //RIGHT
            {
                // check to see if sober or not???
                string sober = "";
                if (int.Parse(listIt2[1]) > rooms || int.Parse(listIt2[1]) > (rooms / 2) - 1)
                {
                    listIt2[1] = (rooms - 1).ToString();
                    Console.WriteLine(listIt2[1]);
                    sober = "sober";
                }

                if (sober == "sober")
                {
                    if (roomsStatus[int.Parse(listIt2[1])] == 'D')
                    {
                        roomsStatus[int.Parse(listIt2[1])] = 'L';
                        currentRoom = int.Parse(listIt2[1]);
                    }
                    else
                    {
                        roomsStatus[int.Parse(listIt2[1])] = 'D';
                        counterDark++;
                        currentRoom = int.Parse(listIt2[1]);
                    }
                }
                else
                {
                    if (roomsStatus[2 + (Convert.ToInt32(listIt2[1]) + 1)] == 'D')
                    {
                        roomsStatus[2 + (Convert.ToInt32(listIt2[1]) + 1)] = 'L';
                        currentRoom = 2 + (Convert.ToInt32(listIt2[1]) + 1);
                    }
                    else
                    {
                        roomsStatus[2 + (Convert.ToInt32(listIt2[1]) + 1)] = 'D';
                        counterDark++;
                        currentRoom = 2 + (Convert.ToInt32(listIt2[1]) + 1);
                    }
                }

            }

            


            while (true)
            {

                input = Console.ReadLine();

                if(input.Equals("END")) 
                    break;
                listIt2 = input.Split(' ').ToList();

                // if its in the begging set it to the room[2]
                if (listIt2[0] == "LEFT")
                {
                    // check to see if sober or not???
                    string sober = "";
                    if (int.Parse(listIt2[1]) > rooms || currentRoom + 1 + int.Parse(listIt2[1]) > rooms - 1)
                    {
                        listIt2[1] = "0";
                        sober = "sober";
                    }

                    if (sober == "sober")
                    {
                        if (roomsStatus[int.Parse(listIt2[1])] == 'D')
                        {
                            roomsStatus[int.Parse(listIt2[1])] = 'L';
                            currentRoom = int.Parse(listIt2[1]);
                        }
                        else
                        {
                            roomsStatus[int.Parse(listIt2[1])] = 'D';
                            counterDark++;
                            currentRoom = int.Parse(listIt2[1]);
                        }
                    }
                    else
                    {
                        if (roomsStatus[currentRoom - (Convert.ToInt32(listIt2[1]) + 1)] == 'D')
                        {
                            roomsStatus[currentRoom - (Convert.ToInt32(listIt2[1]) + 1)] = 'L';
                            currentRoom = currentRoom - (Convert.ToInt32(listIt2[1]) + 1);
                        }
                        else
                        {
                            roomsStatus[currentRoom - (Convert.ToInt32(listIt2[1]) + 1)] = 'D';
                            counterDark++;
                            currentRoom = currentRoom - (Convert.ToInt32(listIt2[1]) + 1);
                        }
                    }


                }
                else //RIGHT
                {
                    // check to see if sober or not???
                    string sober = "";
                    if (int.Parse(listIt2[1]) > rooms || currentRoom + 1 + int.Parse(listIt2[1]) > rooms - 1)
                    {
                        listIt2[1] = (rooms - 1).ToString();
                        sober = "sober";
                    }

                    if (sober == "sober")
                    {
                        if (roomsStatus[int.Parse(listIt2[1])] == 'D')
                        {
                            roomsStatus[int.Parse(listIt2[1])] = 'L';
                            currentRoom = int.Parse(listIt2[1]);
                        }
                        else
                        {
                            roomsStatus[int.Parse(listIt2[1])] = 'D';
                            counterDark++;
                            currentRoom = int.Parse(listIt2[1]);
                        }
                    }
                    else
                    {
                        if (roomsStatus[currentRoom + (Convert.ToInt32(listIt2[1]) + 1)] == 'D')
                        {
                            roomsStatus[currentRoom + (Convert.ToInt32(listIt2[1]) + 1)] = 'L';
                            currentRoom = currentRoom + (Convert.ToInt32(listIt2[1]) + 1);
                        }
                        else
                        {
                            roomsStatus[currentRoom + (Convert.ToInt32(listIt2[1]) + 1)] = 'D';
                            counterDark++;
                            currentRoom = currentRoom + (Convert.ToInt32(listIt2[1]) + 1);
                        }
                    }
                }
                
            }

            int sum = 0;

            foreach (var item in roomsStatus)
            {
                if (item == 'D')
                {
                    sum++;
                }
            }

            Console.WriteLine(sum * (int)'D');
        }
    }
}
