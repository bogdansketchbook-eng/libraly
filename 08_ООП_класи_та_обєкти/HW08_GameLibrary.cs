using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// 1. Створіть `GameLibrary`.
GameLibrary myLibrary = new GameLibrary();

// 2. Додайте 5 своїх улюблених ігор (вигадайте дані).
myLibrary.Add(new Game("Genshin Impact", "RPG", 2020, 9.0, false));
myLibrary.Add(new Game("The Witcher 3", "RPG", 2015, 9.8, true));
myLibrary.Add(new Game("Minecraft", "Sandbox", 2011, 9.5, true));
myLibrary.Add(new Game("CS:GO / CS2", "Shooter", 2012, 8.5, false));
myLibrary.Add(new Game("Cyberpunk 2077", "Action RPG", 2020, 8.8, true));

// 3. Виведіть усі.
Console.WriteLine("=== УСІ ІГРИ В БІБЛІОТЕЦІ ===");
myLibrary.ShowAll();
Console.WriteLine();

// 4. Виведіть кількість пройдених і середній рейтинг.
Console.WriteLine($"Кількість пройдених ігор: {myLibrary.CountCompleted()}");
Console.WriteLine($"Середній рейтинг: {myLibrary.AverageRating():F1}/10");
Console.WriteLine();

// 5. Виведіть найкращу за рейтингом.
Game? bestGame = myLibrary.FindHighestRated();
if (bestGame != null)
{
    Console.Write("Найкраща гра за рейтингом: ");
    bestGame.Print();
}
Console.WriteLine();

// Бонус (★): Сортування за спаданням рейтингу
Console.WriteLine("=== ІГРИ, ВІДСОРТОВАНІ ЗА РЕЙТИНГОМ (СПАДАННЯ) ===");
myLibrary.SortByRating();
myLibrary.ShowAll();


// ================= КЛАСИ =================

class Game
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
    public bool IsCompleted { get; set; }

    // Конструктор з 5 параметрів
    public Game(string title, string genre, int year, double rating, bool isCompleted)
    {
        Title = title;
        Genre = genre;
        Year = year;
        Rating = rating;
        IsCompleted = isCompleted;
    }

    public void Print()
    {
        Console.WriteLine($"[{Title}] жанр: {Genre}, рік: {Year}, рейтинг: {Rating:F1}/10, пройдена: {IsCompleted}");
    }
}

class GameLibrary
{
    private List<Game> games = new List<Game>();

    public void Add(Game g)
    {
        games.Add(g);
    }

    public void ShowAll()
    {
        foreach (var g in games)
        {
            g.Print();
        }
    }

    public int CountCompleted()
    {
        int count = 0;
        foreach (var g in games)
        {
            if (g.IsCompleted)
                count++;
        }
        return count;
    }

    public double AverageRating()
    {
        if (games.Count == 0) return 0;

        double sum = 0;
        foreach (var g in games)
        {
            sum += g.Rating;
        }
        return sum / games.Count;
    }

    public Game? FindHighestRated()
    {
        if (games.Count == 0) return null;

        Game highest = games[0];
        foreach (var g in games)
        {
            if (g.Rating > highest.Rating)
            {
                highest = g;
            }
        }
        return highest;
    }

    // Бонус (★)
    public void SortByRating()
    {
        games = games.OrderByDescending(g => g.Rating).ToList();
    }
}
