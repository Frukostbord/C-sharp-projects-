using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale
{
  public class Villa : Estate
  {
    // Define new variables for this type of estate
    // The ones defined in Estate are valid here also through properties
    private int garden; // Define a garden size for villa

    /// <summary>
    /// Default constructor, uses the Estate constructor
    /// and also sets the type of estate
    /// </summary>
    public Villa()
      : base()
    {
      EType = EstateType.Villa;
    }

    /// <summary>
    /// Copy constructor 
    /// </summary>
    /// <param name="other"></param>
    public Villa(Villa other)
    {
      this.EType = other.EType;
      this.RentingForm = other.RentingForm;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAdress = new Adress(other.PostAdress);
      this.garden = other.garden;
      // Then copy the special data for this estate
    }

    /// <summary>
    /// Copy the common data from a estate object
    /// </summary>
    /// <param name="other"></param>
    public Villa(Estate other)
    {
      EType = EstateType.Villa;
      this.RentingForm = other.RentingForm;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAdress = new Adress(other.PostAdress);
    }

    /// <summary>
    /// We add the property for garden size
    /// </summary>
    public int Garden
    {
      get { return garden; }
      set { garden = value; }
    }

    // Then add the special methods used for this kind of estate

    /// <summary>
    /// This estate has an additional parameter (garden), so it is NOT using the base class'
    /// toString, but has its own, in order to write this parameter too
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      string strRentalForm = LegalType.Rental.ToString();

      if (RentingForm == LegalType.Tenement)
        strRentalForm = LegalType.Tenement.ToString();

      //Vhat is {0, -12}, {3, 6} eller {4} ?
      string strOut = String.Format(" {0, -12} {1,-12} {5, 5} {2, 6}, {3, 6} {4}",
          EType, strRentalForm, Price, NbrRooms, PostAdress.ToString(), garden);

      strOut = strOut.ToUpper();
      return strOut;
    }
  }
}
