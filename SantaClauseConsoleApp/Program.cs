using System;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            Console.WriteLine("Question 1: \n");
            
            Item item1 = new Item(0, "doll");
            Item item2 = new Item(1, "teddy bear");
            Item item3 = new Item(2, "car");
            Item item4 = new Item(3, "sweets");

            Letter letter1 = new Letter("2021-12-21");
            letter1.AddItem(item1);
            letter1.AddItem(item3);

            Letter letter2 = new Letter("2021-12-22");
            letter2.AddItem(item1);
            letter2.AddItem(item2);

            Letter letter3 = new Letter("2021-12-23");
            letter3.AddItem(item2);
            letter3.AddItem(item4);


            Child child1 = new Child(0, "Charlotte", "2013-12-25", "Cluj str Lalelelor nr 7", BehaviorEnum.Good, letter1);
            Child child2 = new Child(1, "Elijah", "2007-11-13", "Constanta str Primaverii nr 12", BehaviorEnum.Bad, letter2);
            Child child3 = new Child(2, "Eva", "2010-10-2", "Brasov str Carol nr 20", BehaviorEnum.Good, letter3);

            Console.WriteLine(child1);
            Console.WriteLine();
            Console.WriteLine(child2);
            Console.WriteLine();
            Console.WriteLine(child3);
            Console.WriteLine();

        }

        static void Question2()
        {
            Console.WriteLine("Question 2: \n");

            //Child child1 = new Child(0);
            //Child child2 = new Child(1);
            //Child child3 = new Child(2);
            //child1.ReadFromLetter(@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\LetterNo1.txt", child1);
            //child2.ReadFromLetter(@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\LetterNo2.txt", child2);
            //child3.ReadFromLetter(@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\LetterNo3.txt", child3);

            //cheeky implementation
            for (int i=1; i<4; i++)
            {
                Child child = new Child(i);
                child.ReadFromLetter($@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\LetterNo{i}.txt");
            }
            Console.WriteLine();
        }

        static void Question3()
        {
            Console.WriteLine("Question 3: \n");

            //reusing code from Question1
            Item item1 = new Item(0, "doll");
            Item item2 = new Item(1, "teddy bear");
            Item item3 = new Item(2, "car");
            Item item4 = new Item(3, "sweets");

            Letter letter1 = new Letter("2021-12-21");
            letter1.AddItem(item1);
            letter1.AddItem(item3);

            Letter letter2 = new Letter("2021-12-22");
            letter2.AddItem(item1);
            letter2.AddItem(item2);

            Letter letter3 = new Letter("2021-12-23");
            letter3.AddItem(item2);
            letter3.AddItem(item4);


            Child child1 = new Child(0, "Charlotte", "2013-12-25", "Cluj str Lalelelor nr 7", BehaviorEnum.Good, letter1);
            Child child2 = new Child(1, "Elijah", "2007-11-13", "Constanta str Primaverii nr 12", BehaviorEnum.Bad, letter2);
            Child child3 = new Child(2, "Eva", "2010-10-2", "Brasov str Carol nr 20", BehaviorEnum.Good, letter3);

            child1.WriteToLetter();
            Console.WriteLine();
            child2.WriteToLetter();
            Console.WriteLine();
            child3.WriteToLetter();
            Console.WriteLine();

        }

        static void Question4()
        {
            Console.WriteLine("Question 4: \n");

            SantaClaus santaClaus =new SantaClaus();
            santaClaus.ReadLetters();
            Console.WriteLine();
            Console.WriteLine("SantaClaus's report list ordered descending by toy quantities:");
            santaClaus.BuildReport();
            Console.WriteLine();
        }

        static void Question5()
        {
            Console.WriteLine("Question 5: ");

            //Though generally regarded as a good avoidance, 
            //the idea of a singleton pattern could be viable in the current implementation. For example, 
            //by having a single Santa instance. This would be both mythically and functionally accurate 
            //since there is only one Santa and all of the Santa class functionalities would be globally 
            //accessible and modifiable through its single instance.

            Console.WriteLine(@"
Though generally regarded as a good avoidance,
the idea of a singleton pattern could be viable in the current implementation.For example,
by having a single Santa instance.This would be both mythically and functionally accurate
since there is only one Santa and all of the Santa class functionalities would be globally
accessible and modifiable through its single instance.
            ");

        }

        static void Question6()
        {
            Console.WriteLine("Question 6: \n");

            SantaClaus santaClaus = new SantaClaus();
            santaClaus.TravelItinerary();
        }
    }
}
