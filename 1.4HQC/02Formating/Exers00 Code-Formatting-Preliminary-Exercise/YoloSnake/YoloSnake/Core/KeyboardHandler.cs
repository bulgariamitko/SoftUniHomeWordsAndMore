namespace YoloSnake.Core
{
    using System;
    using Interfaces;

    public class KeyboardHandler : IKeyboardHandler
    {
        public ConsoleKey PressedKey => Console.ReadKey().Key;

        public bool IsKeyAvailable => Console.KeyAvailable;
    }
}