﻿// Problem 3. Animal hierarchy
// * Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define 
//   useful constructors and methods. Dogs, frogs and cats are Animals. 
//   All animals can produce sound (specified by the ISound interface). 
//   Kittens and tomcats are cats. All animals are described by age, name 
//   and sex. Kittens can be only female and tomcats can be only male. 
//   Each animal produces a specific sound.
// * Create arrays of different kinds of animals and calculate the 
//   average age of each kind of animal using a static method (you 
//   may use LINQ).

namespace _03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AnimalHierarchy
    {
        static void Main(string[] args)
        {
            List<Animal> animals = GenerateAnimals();

            var dogsAvgAge = GetAverageAge(animals, typeof(Dog));

            var catsAvgAge = GetAverageAge(animals, typeof(Cat));

            var frogsAvgAge = GetAverageAge(animals, typeof(Frog));

            var kittenAvgAge = GetAverageAge(animals, typeof(Kitten));

            var tomcatAvgAge = GetAverageAge(animals, typeof(Tomcat));

            Console.WriteLine("dogs average age: {0}", dogsAvgAge);
            Console.WriteLine("cats average age: {0}", catsAvgAge);
            Console.WriteLine("frogs average age: {0}", frogsAvgAge);
            Console.WriteLine("kitten average age: {0}", kittenAvgAge);
            Console.WriteLine("tomcat average age: {0}", tomcatAvgAge);

            Console.WriteLine();
            Console.WriteLine("Animals: ");
            foreach (var item in animals)
            {
                Console.WriteLine(item + " " + item.MakeSound());
            }
        }

        private static double GetAverageAge(List<Animal> animals, Type currentType)
        {
            double avgAge = animals
                .Where(x => x.GetType() == currentType)
                .Average(x => x.Age);

            return avgAge;
        }

        private static List<Animal> GenerateAnimals()
        {
            List<Animal> animals = new List<Animal>();

            animals.Add(new Dog("gosho", 5, true));
            animals.Add(new Dog("desi", 4, false));
            animals.Add(new Cat("atanas", 7, true));
            animals.Add(new Frog("ivan", 2, true));
            animals.Add(new Cat("mara", 4, false));
            animals.Add(new Frog("mitko", 3, true));
            animals.Add(new Frog("stamat", 7, true));
            animals.Add(new Dog("tosho", 10, true));
            animals.Add(new Cat("tisho", 6, true));
            animals.Add(new Tomcat("krasi", 3));
            animals.Add(new Tomcat("petko", 1));
            animals.Add(new Tomcat("genadi", 2));
            animals.Add(new Kitten("mimi", 1));
            animals.Add(new Kitten("lili", 2));
            animals.Add(new Kitten("petia", 3));

            return animals;
        }
    }
}
