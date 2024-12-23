using System;

    public delegate void ButtonPressedHandler(string message);

    public class Button
    {
        public event ButtonPressedHandler OnButtonPressed;
        public void Click(string buttonName)
        {
            // Проверяем, есть ли подписчики на событие
            OnButtonPressed.Invoke($"{buttonName} button was pressed!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Button saveButton = new Button();
            Button sendButton = new Button();
            Button readButton = new Button();

            saveButton.OnButtonPressed += SaveButtonPressed;
            sendButton.OnButtonPressed += SendButtonPressed;
            readButton.OnButtonPressed += ReadButtonPressed;

            saveButton.Click("Save");
            sendButton.Click("Send");
            readButton.Click("Read");
        }

        static void SaveButtonPressed(string message)
        {
            Console.WriteLine(message);
        }

        static void SendButtonPressed(string message)
        {
            Console.WriteLine(message);
        }

        static void ReadButtonPressed(string message)
        {
            Console.WriteLine(message);
        }
    }
