namespace LinqTasks
{
    public class Program
    {
        private static readonly IReadOnlyCollection<Person> _persons = new List<Person>()
        {
            new Person()
            {
                Name = "Bob",
                Height = 175,
                Weight = 74,
                HairColor = HairColor.Red
            },

            new Person()
            {
                Name = "Alice",
                Height = 163,
                Weight = 54,
                HairColor = HairColor.White
            },

            new Person()
            {
                Name = "Alexey",
                Height = 180,
                Weight = 90,
                HairColor = HairColor.Black
            },

            new Person()
            {
                Name = "Vladimir",
                Height = 156,
                Weight = 92,
                HairColor = HairColor.White
            },

            new Person()
            {
                Name = "Elena",
                Height = 190,
                Weight = 97,
                HairColor = HairColor.Red
            },
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Список людей:");
            PrintPersons(_persons);

            PrintWhiteHairedPeople();

            PrintHighPeopleCount();

            PrintPeopleWeight();

            PrintNotRedHairedPeopleTotalHeight();

            Console.ReadLine();
        }

        private static void PrintWhiteHairedPeople()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Светловолосые люди:");

            var whiteHairedPeople = _persons
                .Where(p => p.HairColor == HairColor.White)
                .ToList();

            PrintPersons(whiteHairedPeople);
        }

        private static void PrintHighPeopleCount()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Число высоких людей:");

            var highPeopleCount = _persons
                .Where(p => p.Height > 170)
                .Count();

            Console.WriteLine(highPeopleCount);
        }

        private static void PrintPeopleWeight()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Словарь с весом людей:");

            var weightDictionary = _persons
                .ToDictionary(p => p.Name, p => p.Weight);

            foreach(var kvp in weightDictionary)
            {
                Console.WriteLine($"Имя: { kvp.Key }, вес: { kvp.Value }");
            }
        }

        private static void PrintNotRedHairedPeopleTotalHeight()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Суммарный рост НЕ рыжих людей:");

            var totalHeight = _persons
                .Where(p => p.HairColor != HairColor.Red)
                .Sum(p => p.Height);

            Console.WriteLine(totalHeight);
        }

        private static void PrintPersons(IReadOnlyCollection<Person> persons)
        {
            foreach(var person in persons)
            {
                Console.WriteLine($"Имя: { person.Name }, рост: { person.Height }, вес: { person.Weight }, цвет волос: { person.HairColor }");
            }
        }
    }
}