
namespace LAB3
{
    public class program
    {
        public static void Main(string[] args)
        {
            TaskOne();
            TaskTwo();
            TaskThree();
        }
        //1
        private static void TaskOne()

        {
            int userAge = 20;
            string userName = "Андрій";

            Console.WriteLine("Привіт, " + userName + "! Твій вік: " + userAge);
        }

        //2
        private static void TaskTwo()
        {
            int number = 10;
            string message = "Hi";
            bool isNew = true;

            Console.WriteLine(number + " " + message + " " + isNew);
        }

        //3
        private static void TaskThree()
        {
            // Оголошуємо змінну name та присвоюємо їй значення "Анна"
            string name = "Анна";
            // Оголошуємо змінну age та присвоюємо їй значення 25
            int age = 25;
            // Виводимо на консоль привітання з ім'ям і віком користувача
            Console.WriteLine("Привіт, " + name + "! Твій вік: " + age);
        }

    }
}


