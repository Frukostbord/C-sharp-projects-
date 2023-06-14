using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale.Commercial
{
  public class WareHouse : Commercial
  {
    // Define new variables for this type of estate
    // The ones defined in Estate are valid here also through properties
    // Also the ones defined in Commercial

    /// <summary>
    /// Default constructor, uses the Estate constructor
    /// and also sets the type of estate
    /// </summary>
    public WareHouse()
    {
      RealEstateType = EstateType.WareHouse;
    }

    /// <summary>
    /// The copy constructor
    /// </summary>
    /// <param name="other"></param>
    public WareHouse(WareHouse other)
    {
      this.RealEstateType = other.RealEstateType;
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
      this.Id = other.Id;
      // Then copy the special data for this estate
    }

    /// <summary>
    /// Copy the common data from a estate object
    /// </summary>
    /// <param name="other"></param>
    public WareHouse(Estate other)
    {
      RealEstateType = EstateType.WareHouse;
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
    }
    //To DO - complete this class
    //Add the special methods used for this kind of estate

  }
}
