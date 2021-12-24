using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SantaClauseConsoleApp
{
    public class SantaClaus
    {
        public SantaClaus()
        {
            Name = "Santa Claus";
        }

        public string Name { get; set; }
        public List<Letter> LetterList { get; set; } = new List<Letter>();

        public void ReadLetters()
        {
            foreach (string file in Directory.EnumerateFiles(@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\", "*.txt"))
            {
                string[] itemNames = System.IO.File.ReadAllLines(file)[4].Split(",");
                Letter letter = new Letter();

                int count = 0;
                foreach (string itemName in itemNames)
                {
                    Item item = new Item(count++, itemName);
                    letter.AddItem(item);
                }

                LetterList.Add(letter);
                //Console.WriteLine(letter);
            }

           LetterList.ForEach(i => Console.WriteLine(i));
        }

        public void BuildReport()
        {
            var quantityReport = new List<( int quantity, string name)> { }; //empty tuple list

            List<int> quantity = new List<int>();
            List<string> name = new List<string>();           
            
            foreach(Letter letter in LetterList)
            {
                foreach (Item item in letter.itemList)
                {
                    bool alreadyExists = false;
                    for (int i = 0; i < name.Count; i++)
                    {
                        if (name[i] == item.itemName)
                        {
                            quantity[i] += 1;
                            alreadyExists = true;
                        }
                    }
                    if (alreadyExists==false)
                    {
                        name.Add(item.itemName);
                        quantity.Add(1);
                    }

                }
            }
            for(int i=0; i<name.Count; i++)
            {
                quantityReport.Add((quantity[i],name[i]));
            }

            quantityReport.Sort((x, y) => y.Item1.CompareTo(x.Item1));

            quantityReport.ForEach(j=>Console.WriteLine(j.name+"-"+j.quantity));

        }

        public void TravelItinerary()
        {
            List<string> addresses = new List<string>();
            foreach (string file in Directory.EnumerateFiles(@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\", "*.txt"))
            {

                string[] propozitii = System.IO.File.ReadAllLines(file)[2].Split(". ");
                addresses.Add(propozitii[1].Replace("I live at ",""));

            }
            Console.WriteLine("Before sorting the list:\n");
            addresses.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            addresses = addresses.OrderBy(q => q).ToList();

            Console.WriteLine("After sorting the list by city:\n");
            addresses.ForEach(i => Console.WriteLine(i)); //city is always the first, so the list is ordered alphabeticaly by city

        }
    }
}