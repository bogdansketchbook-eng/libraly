using System;
using System.Collections.Generic;
//# Урок 09. Зоопарк
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //Створюємо зоопарк
        Zoo myZoo = new Zoo();

        //Додаємо 5–7 тваринок
        Lion l = new Lion { Name = "Сімба", Age = 5 };
        Elephant e = new Elephant { Name = "Дамбо", Age = 10 };
        Monkey m = new Monkey { Name = "Джордж", Age = 3 };
        Snake s = new Snake { Name = "Каа", Age = 12 };
        Parrot p = new Parrot { Name = "Кеша", Age = 2, CanFly = true };
        Lion l2 = new Lion { Name = "Шархан", Age = 7 };

        myZoo.AddAnimal(l);
        myZoo.AddAnimal(e);
        myZoo.AddAnimal(m);
        myZoo.AddAnimal(s);
        myZoo.AddAnimal(p);
        myZoo.AddAnimal(l2);

        //Ранковий обхід зоопарку
        myZoo.MorningRound();
        Console.WriteLine();

        //Найстаріша тварина
        Animal oldest = myZoo.FindOldest();
        if (oldest != null)
        {
            Console.WriteLine($"Найстаріша тварина: {oldest.Name} ({oldest.Age} років)");
        }
        Console.WriteLine();

        //Метод CountByType (скільки левів у зоопарку)
        int lionCount = myZoo.CountByType<Lion>();
        Console.WriteLine($"Кількість левів у зоопарку: {lionCount}");

        //Бонус для пернатих
        Console.WriteLine();
        Console.WriteLine("ТЕСТУВАННЯ БОНУСУ (ПТАХИ)");
        p.Introduce();
        p.Fly();

        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}

//=== БАЗОВИЙ КЛАС ===
abstract class Animal
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public abstract string Sound();

    public virtual void Introduce()
    {
        Console.WriteLine($"Я {Name}, мені {Age} р. Я кажу: {Sound()}");
    }
}

//=== ДОЧІРНІ КЛАСИ ===

class Lion : Animal
{
    public override string Sound() => "Рик!";
}

class Elephant : Animal
{
    public override string Sound() => "Топ!";
}

class Monkey : Animal
{
    public override string Sound() => "У-у!";
}

class Snake : Animal
{
    public override string Sound() => "С-с-с!";
}

//Бонус (★): Клас Bird від Animal з полем CanFly і методом Fly()
class Bird : Animal
{
    public bool CanFly { get; set; } = true;

    public override string Sound() => "Чик-чирик!";

    public void Fly()
    {
        if (CanFly)
        {
            Console.WriteLine($"{Name} летить у небі! ");
        }
        else
        {
            Console.WriteLine($"{Name} не вміє літати.");
        }
    }
}

//Тут Parrot успадковується від Bird (Parrot : Bird)
class Parrot : Bird
{
    public override string Sound() => "Привіт!";
}

//=== КЛАС ЗООПАРК ===

class Zoo
{
    //Тут поле List<Animal> animals
    private List<Animal> animals = new List<Animal>();

    //Метод AddAnimal(Animal a)
    public void AddAnimal(Animal a)
    {
        animals.Add(a);
    }

    //Метод `MorningRound()` — обходить усіх і кожен «представляється» (виклик `Introduce()`)
    public void MorningRound()
    {
        Console.WriteLine("=== РАНКОВИЙ ОБХІД ЗООПАРКУ ===");
        foreach (Animal a in animals)
        {
            a.Introduce();
        }
    }

    //Метод `FindOldest()` — повертає найстарішу тварину
    public Animal FindOldest()
    {
        if (animals.Count == 0) return null;

        Animal oldest = animals[0];
        foreach (Animal a in animals)
        {
            if (a.Age > oldest.Age)
            {
                oldest = a;
            }
        }
        return oldest;
    }

    //Метод `CountByType<T>()` — кількість тварин конкретного типу
    public int CountByType<T>() where T : Animal
    {
        int count = 0;
        foreach (Animal a in animals)
        {
            if (a is T)
            {
                count++;
            }
        }
        return count;
    }
}