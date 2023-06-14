using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This item represents a food item. It get all it´s methods from it´s parent class - GenericListManager.
    /// </summary>
   
    [Serializable]
    public class FoodItem : GenericListManager<string>
    {
        
        private string name;
        public string Name { get { return name; } set { name = value; } }

    }
}
