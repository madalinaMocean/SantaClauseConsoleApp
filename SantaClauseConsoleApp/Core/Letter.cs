using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        //we take the "construction" time of the letter as the date of writing
        //we imagine that the moment when the constructor is called is the moment when the child writes the letter
        private string writtenDate { get; set; } = DateTime.Now.ToString(); 

        public List<Item> itemList { get; set; } = new List<Item>();


        public Letter(string writtenDate)
        {
            this.writtenDate = writtenDate;
        }

        public Letter(){}

        public override string ToString()
        {
            return $"WrittenDate: {writtenDate}, Items: [{String.Join("; ", itemList)}]";
        }

        public void AddItem(Item i)
        {
            itemList.Add(i);
        }
    }
}
