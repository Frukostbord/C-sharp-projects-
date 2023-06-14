using System;

namespace Apu_Animal_Park_4
{
    /// <summary>
    /// This interface is to give information on what getters and setters as well as methods must be created
    /// to successfully create an Animal class.
    /// </summary>
    public interface IAnimal
    {

        // Getters & Setters
        int Age { get; set; }
        string Name { get; set; }

        float Weight { get; set; }
        Guid ID { set; }
        Gender Gender { get; set; }

        AnimalDiet AnimalDiet { get; set; }


        // Methods to be implemented
        string IdTrunc(); // Truncated version of Guid

        string[] GetSpecieInfo(); // An array of strings of information for just that animal


    }
}
