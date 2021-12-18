using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SelectManyEx3();
        }

        public static void SelectManyEx3()
        {
            PetOwner[] petOwners =
                { new PetOwner { Name="Higa",
              Pets = new List<string>{ "Scruffy", "Sam" } },
          new PetOwner { Name="Ashkenazi",
              Pets = new List<string>{ "Walker", "Sugar" } },
          new PetOwner { Name="Price",
              Pets = new List<string>{ "Scratches", "Diesel" } },
          new PetOwner { Name="Hines",
              Pets = new List<string>{ "Dusty" } } };

            // Project the pet owner's name and the pet's name.
            var query =
                petOwners
                .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
                .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                .Select(ownerAndPet =>
                        new
                        {
                            Owner = ownerAndPet.petOwner.Name,
                            Pet = ownerAndPet.petName
                        }
                );

            // Print the results.
            foreach (var obj in query)
            {
                Console.WriteLine(obj);
            }
        }

    }

    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }


}
