using System.Collections.Generic;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// These classes contains different iteration of Icomparer to sort animal´s by different properties
    /// </summary>
    class Animal_SortByWeight : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }

    class Animal_SortByAge : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Age.CompareTo(y.Age);
        }

    }

    class Animal_SortByName : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return string.Compare(x.Name, y.Name);
        }

    }

    class Animal_SortByGender : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return string.Compare(x.Gender.ToString(), y.Gender.ToString());
        }
    }

}
