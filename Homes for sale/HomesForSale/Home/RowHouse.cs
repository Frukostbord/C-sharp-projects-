using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale.Home
{
  public class RowHouse : Villa
  {
    // Define new variables for this type of estate
    // The ones defined in Estate are valid here also through properties
    // Also the ones defined in Home
    // and the ones defined in Villa

    /// <summary>
    /// Default constructor, uses the Estate constructor
    /// and also sets the type of estate
    /// </summary>
    public RowHouse()
      : base()
    {
      RealEstateType = EstateType.RowHouse;
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="other"></param>
    public RowHouse(RowHouse other)
    {
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
      this.Id = other.Id;
      this.LandSize = other.LandSize;
      // Then copy the special data for this estate
    }
    
    /// <summary>
    /// Copy the common data from a estate object
    /// </summary>
    /// <param name="other"></param>
    public RowHouse(Estate other)
    {
      RealEstateType = EstateType.RowHouse;
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
    }


    //TO DO:  Complete this class with more logics.
  }
}
