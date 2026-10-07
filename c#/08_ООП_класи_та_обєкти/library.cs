using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Урок 8. Starter: класи та обʼєкти.
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // TODO 1: Створіть обʼєкт Point(3, 5). Виведіть його X і Y.
        Point p = new Point(3, 5);
        Console.WriteLine($"Точка: X = {p.X}, Y = {p.Y}\n");

        // TODO 2: Створіть 3 студентів (Student) і виведіть їх інформацію через Introduce().
        Student s1 = new Student("Олена", 15, "10-А", 10.5);
        Student s2 = new Student("Максим", 16, "10-Б", 9.8);
        Student s3 = new Student("Дмитро", 15, "10-А", 11.2);
        s1.Introduce();
        s2.Introduce();
        s3.Introduce();
        Console.WriteLine();

        // TODO 3: Створіть List<Student> з 5 студентів. Виведіть усіх.
        List<Student> students = new List<Student>
        {
            new Student("Анна", 15, "10-А", 11.0),
            new Student("Богдан", 16, "10-Б", 8.5),
            new Student("Вікторія", 15, "10-А", 10.2),
            new Student("Гліб", 16, "10-В", 9.0),
            new Student("Денис", 15, "10-Б", 11.8)
        };

        Console.WriteLine("--- Список усіх студентів ---");
        foreach (var student in students)
        {
            student.Introduce();
        }
        Console.WriteLine();

        // TODO 4 (бонус): Створіть бібліотеку (Library), додайте 3 книги (Book),
		// викличте ShowAll().

        //Тут бібліотека з назвами книг,їх авторами та роками видання. Користувач може переглядати книги, шукати їх за назвою або автором, брати та повертати книги.
        Library library = new Library();

        library.AddBook(new Book { Title = "Кобзар", Author = "Тарас Шевченко", Year = 1840 });
        library.AddBook(new Book { Title = "Тіні забутих предків", Author = "Михайло Коцюбинський", Year = 1911 });
        library.AddBook(new Book { Title = "1984", Author = "Джордж Орвелл", Year = 1949 });
        library.AddBook(new Book { Title = "Арфами, арфами...", Author = "Павло Тичина", Year = 1914 });
        library.AddBook(new Book { Title = "Я (Романтика)", Author = "Микола Хвильовий", Year = 1924 });
        library.AddBook(new Book { Title = "У теплі дні збирання винограду...", Author = "Максим Рильський", Year = 1927 });
        library.AddBook(new Book { Title = "Усмішка", Author = "Остап Вишня", Year = 1927 });
        library.AddBook(new Book { Title = "Майстер корабля", Author = "Юрій Яновський", Year = 1928 });
        library.AddBook(new Book { Title = "Місто", Author = "Валерян Підмогильний", Year = 1928 });
        library.AddBook(new Book { Title = "Мина Мазайло", Author = "Микола Куліш", Year = 1929 });
        library.AddBook(new Book { Title = "Тигролови", Author = "Іван Багряний", Year = 1944 });

        bool isRunning = true;
        //Це саме меню біблотеки 

        while (isRunning)
        {
            Console.WriteLine("=== БІБЛІОТЕКА ===");
            Console.WriteLine("1 — Показати всі книги");
            Console.WriteLine("2 — Знайти книгу (за назвою або автором)");
            Console.WriteLine("3 — Взяти книгу");
            Console.WriteLine("4 — Повернути книгу");
            Console.WriteLine("0 — Вийти з програми");
            Console.Write("Оберіть дію: ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();
            //Тут будуться дії користувача в залежності від його вибору
            switch (choice)
            {
                case "1":
                    library.ShowAll();
                    break;

                case "2":
                    Console.Write("Введіть назву або автора для пошуку: ");
                    string query = Console.ReadLine() ?? "";
                    library.Search(query);
                    break;

                case "3":
                    Console.Write("Введіть назву книги, яку хочете взяти: ");
                    string titleToTake = Console.ReadLine() ?? "";
                    library.TakeBook(titleToTake);
                    break;

                case "4":
                    Console.Write("Введіть назву книги, яку хочете повернути: ");
                    string titleToReturn = Console.ReadLine() ?? "";
                    library.ReturnBook(titleToReturn);
                    break;

                case "0":
                    isRunning = false;
                    Console.WriteLine("Дякуємо за користування бібліотекою!");
                    break;

                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine("\n-----------------------------------\n");
        }
    }
}

// ---------- Тут окремі класи ---------

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Student
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string ClassName { get; set; } = "";
    public double AverageGrade { get; set; }

    public Student(string name, int age, string className, double averageGrade)
    {
        Name = name;
        Age = age;
        ClassName = className;
        AverageGrade = averageGrade;
    }

    public void Introduce()
    {
        Console.WriteLine($"Я {Name}, {Age} р., {ClassName} клас, середня {AverageGrade}");
    }
}

class Book
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public int Year { get; set; }
    public bool IsAvailable { get; set; } = true;
}

class Library
{
    public List<Book> Books { get; } = new();

    public void AddBook(Book b) => Books.Add(b);

    public void ShowAll()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("Бібліотека порожня.");
            return;
        }

        Console.WriteLine("--- Список книг ---");
        foreach (var b in Books)
        {
            string status = b.IsAvailable ? "В наявності" : "Видана";
            Console.WriteLine($"  \"{b.Title}\" — {b.Author} ({b.Year}) [{status}]");
        }
    }

    public void Search(string query)
    {
        bool found = false;
        Console.WriteLine($"--- Результати пошуку за запитом \"{query}\" ---");

        foreach (var b in Books)
        {
            if (b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                string status = b.IsAvailable ? "В наявності" : "Видана";
                Console.WriteLine($"  \"{b.Title}\" — {b.Author} ({b.Year}) [{status}]");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Книг за таким запитом не знайдено.");
        }
    }

    public void TakeBook(string title)
    {
        foreach (var b in Books)
        {
            if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (b.IsAvailable)
                {
                    b.IsAvailable = false;
                    Console.WriteLine($"Ви успішно взяли книгу \"{b.Title}\"!");
                }
                else
                {
                    Console.WriteLine($"Книга \"{b.Title}\" зараз вилучена іншим читачем.");
                }
                return;
            }
        }
        Console.WriteLine($"Книгу з назвою \"{title}\" не знайдено.");
    }

    public void ReturnBook(string title)
    {
        foreach (var b in Books)
        {
            if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (!b.IsAvailable)
                {
                    b.IsAvailable = true;
                    Console.WriteLine($"Ви успішно повернули книгу \"{b.Title}\"!");
                }
                else
                {
                    Console.WriteLine($"Книга \"{b.Title}\" і так знаходиться в бібліотеці.");
                }
                return;
            }
        }
        Console.WriteLine($"Книгу з назвою \"{title}\" не знайдено у списку.");
    }
}