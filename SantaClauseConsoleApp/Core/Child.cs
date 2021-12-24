using System;
using System.IO;
using System.Linq;

namespace SantaClauseConsoleApp
{
    public class Child
    {

        private int childId { get; set; }
        private string childName { get; set; }
        private string dateOfBirth { get; set; }
        private string childAddress { get; set; }
        private BehaviorEnum behavior { get; set; }
        private Letter? letter { get; set; }//each child can write only one letter

        public Child(int childId, string childName, string dateOfBirth, string childAddress, BehaviorEnum behavior, Letter letter)
        {
            this.childId = childId;
            this.childName = childName;
            this.dateOfBirth = dateOfBirth;
            this.childAddress = childAddress;
            this.behavior = behavior;
            this.letter = letter;

        }

        public Child() { }
        public Child(int childId)
        {
            this.childId = childId;
        }

        public override string ToString()
        {
            return $"Child {childId}, Name: {childName}, Birthdate: {dateOfBirth}, ChildAddress: {childAddress}, Behaviour: {behavior}\nLetter: {letter}";
        }


        public void ReadFromLetter(string letterPath)
        {

            //reading from letter
            string[] letter = System.IO.File.ReadAllLines(@letterPath);

            //parsing childName from line 2
            this.childName = letter[1].Remove(0, 5);

            //parsing dateOfBirth, childAddress, behaviour from line 3
            string[] row3 = letter[2].Split(". ");
            string writtenAge = row3[0].Replace("I am ", "").Replace(" years old", "");
            this.dateOfBirth = CalculateDateOfBirth(writtenAge);
            this.childAddress = row3[1].Remove(0, 10);
            this.behavior = row3[2].Replace("I have been a very ", "").Replace(" child this year", "") == "good" ? BehaviorEnum.Good : BehaviorEnum.Bad;

            //parsing wish list items from line 5
            this.letter = new Letter(DateTime.Now.ToString());
            string[] itemNames = letter[4].Split(",");

            int count = 0;
            foreach (string itemName in itemNames)
            {
                Item item = new Item(count++, itemName);
                this.letter.AddItem(item);
            }

            Console.WriteLine(this);
        }

        public string CalculateDateOfBirth(string writtenAge)
        {
            const int currentYear = 2021;
            int age = Int32.Parse(writtenAge); //converting to int
            int birthDate = currentYear - age;
            return birthDate.ToString();//converting back to string after the calculation is done
        }

        public int CalculateAge()
        {
            const int currentYear = 2021;
            int birthYear = Int32.Parse(this.dateOfBirth.Remove(4));
            return currentYear - birthYear;
        }


        public void WriteToLetter()
        {

            string letterTemplate = System.IO.File.ReadAllText(@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\letter-template.txt");

            string fileName = $@"D:\Madalina\Ddroidd\WinterInternship2022-Backend-main\WinterInternship2022-Backend-main\SantaClauseConsoleApp\SantaClauseConsoleApp\Core\Letters\Letter{this.childName}.txt";

            letterTemplate = letterTemplate.Replace("[FULL_NAME]", this.childName)
                .Replace("[AGE]", this.CalculateAge().ToString())
                .Replace("[ADDRESS]", this.childAddress)
                .Replace("[BEHAVIOR]", this.behavior == BehaviorEnum.Good ? "good" : "bad")
                .Replace("[PRESENT1],[PRESENT2]", String.Join(",", this.letter.itemList.Select(item => $"{item.itemName}")));


            if (!File.Exists(fileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.Write(letterTemplate);
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }


            }
        }
    }
}
