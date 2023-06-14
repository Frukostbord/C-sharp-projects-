using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale
{
  public class Store : Estate
  {
     // Define new variables for this type of estate
    // The ones defined in Estate are valid here also through properties

    /// <summary>
    /// Default constructor, uses the Estate constructor
    /// and also sets the type of estate
    /// </summary>
    public Store()
      : base()
    {
      EType = EstateType.Store;
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="other"></param>
    public Store(Store other)
    {
      this.EType = other.EType;
      this.RentingForm = other.RentingForm;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAdress = new Adress(other.PostAdress);
      // Then copy the special data for this estate
    }

       /// <summary>
    /// Copy the common data from a estate object
    /// </summary>
    /// <param name="other"></param>
    public Store(Estate other)
    {
      EType = EstateType.Store;
      this.RentingForm = other.RentingForm;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAdress = new Adress(other.PostAdress);
    }

    // Then add the special methods used for this kind of estate
  }
}
