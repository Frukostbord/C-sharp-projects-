using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale.Commercial
{
  public class Store : Commercial
  {
    // Define new variables for this type of estate
    // The ones defined in Estate are accessible here also through properties
    // Also the ones defined in Commercial are accessible

    /// <summary>
    /// Default constructor, uses the Estate constructor
    /// and also sets the type of estate
    /// </summary>
    public Store()
      : base()
    {
      RealEstateType = EstateType.Store;
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="other"></param>
    public Store(Store other)
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
    public Store(Estate other)
    {
      RealEstateType = EstateType.Store;
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
    }
      //To DO - complete this class
      //Add the special methods used for this kind of estate
  }
}
