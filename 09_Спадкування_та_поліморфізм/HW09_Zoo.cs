using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Створюємо зоопарк
        Zoo myZoo = new Zoo();

        // 2. Додаємо тварин
        Lion l = new Lion();
        l.Name = "Сімба";
        l.Age = 5;
        myZoo.AddAnimal(l);

        Elephant e = new Elephant();
        e.Name = "Дамбо";
        e.Age = 10;
        myZoo.AddAnimal(e);

        Monkey m = new Monkey();
        m.Name = "Джордж";
        m.Age = 3;
        myZoo.AddAnimal(m);

        Snake s = new Snake();
        s.Name = "Каа";
        s.Age = 12;
        myZoo.AddAnimal(s);

        Parrot p = new Parrot();
        p.Name = "Кеша";
        p.Age = 2;
        myZoo.AddAnimal(p);

        // 3. Ранковий обхід
        myZoo.MorningRound();
        Console.WriteLine();

        // 4. Шукаємо найстарішу тварину
        Animal oldest = myZoo.FindOldest();
        if (oldest != null)
        {
            Console.WriteLine("Найстаріша тварина: " + oldest.Name + " (" + oldest.Age + " років)");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}

// ================= БАЗОВИЙ КЛАС =================

abstract class Animal
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    // Абстрактний метод (дочірні класи зобов'язані його написати)
    public abstract string Sound();

    // Віртуальний метод, який можна перевизначити
    public virtual void Introduce()
    {
        Console.WriteLine("Я " + Name + ", мені " + Age + " р. Я кажу: " + Sound());
    }
}

// ================= ДОЧІРНІ КЛАСИ =================

class Lion : Animal
{
    public override string Sound()
    {
        return "Рик!";
    }
}

class Elephant : Animal
{
    public override string Sound()
    {
        return "Топ!";
    }
}

class Monkey : Animal
{
    public override string Sound()
    {
        return "У-у!";
    }
}

class Snake : Animal
{
    public override string Sound()
    {
        return "С-с-с!";
    }
}

class Parrot : Animal
{
    public override string Sound()
    {
        return "Привіт!";
    }
}

// ================= КЛАС ЗООПАРК =================

class Zoo
{
    // Список для зберігання тварин
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal a)
    {
        animals.Add(a);
    }

    public void MorningRound()
    {
        Console.WriteLine("=== РАНКОВИЙ ОБХІД ЗООПАРКУ ===");
        foreach (Animal a in animals)
        {
            a.Introduce();
        }
    }

    public Animal FindOldest()
    {
        if (animals.Count == 0)
        {
            return null;
        }

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
}