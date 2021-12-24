
using System;

namespace SantaClauseConsoleApp
{
    public class Item
    {

        public int itemId { get; set; }
        public string itemName { get; set; }

        

        public Item(int itemId, string itemName)
        {
            this.itemId = itemId;
            this.itemName = itemName;
        }

        public override string ToString()
        {
            //return String.Format("({0}, Item Name={1})", itemId, itemName);
            return $"Item {itemId}, Name: {itemName}";
        }


    }

  
}
