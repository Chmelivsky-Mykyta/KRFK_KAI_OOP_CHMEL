//1
int age = 18;
double weight = 56.7;
char grade = 'A'; ;
bool isStudent = true;
string name = "Микита";
Console.WriteLine($"Вік: {age}\nВага: {weight}\nОцінка: {grade}\nСтудент: {isStudent}\nІм'я: {name}");
//2 
Console.Write("Введіть число: ");
double x = Convert.ToDouble(Console.ReadLine());
int y = (int)x;
string z = y.ToString();
Console.WriteLine($"Double: {x}\nInt: {y}\nString: {z}");
//3 
Console.Write("Введіть ваше ім'я: ");
string Name = Console.ReadLine();
Console.Write("Введіть ваш вік: ");
int Age = int.Parse(Console.ReadLine());
Console.WriteLine($"Привіт, {Name}! Твій вік: {Age} років.");
//4 V — середня швидкість (км/год) S — відстань (км) t — час (год)
Console.Write("Введіть відстань (км): ");
double s = double.Parse(Console.ReadLine());
Console.Write("Введіть час (год): ");
double t = double.Parse(Console.ReadLine());

double v = s / t;
Console.WriteLine($"Середня швидкість: {v} км/год");
*/
//5
Console.Write("Введіть речення: ");
string text = Console.ReadLine();
Console.WriteLine($"Довжина: {text.Length} символів");
Console.WriteLine($"Верхній регістр: {text.ToUpper()}");
Console.WriteLine($"Замінені пробіли: {text.Replace(" ", "-")}");

