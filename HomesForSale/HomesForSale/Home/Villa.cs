using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale.Home
{
  public class Villa : Home
  {
    // Define new variables for this type of estate
    // The ones defined in Estate are valid here also through properties
    // Also the ones defined in Home
    private int landSize; // Define a landSize size for villa

    /// <summary>
    /// Default constructor, uses the Estate constructor
    /// and also sets the type of estate
    /// </summary>
    public Villa()
     {
      RealEstateType = EstateType.Villa;
    }

    /// <summary>
    /// Copy constructor 
    /// </summary>
    /// <param name="other"></param>
    public Villa(Villa other)
    {
      this.RealEstateType = other.RealEstateType;
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
      this.Id = other.Id;
      this.landSize = other.landSize;
      // Then copy the special data for this estate
    }

    /// <summary>
    /// Copy the common data from a estate object
    /// </summary>
    /// <param name="other"></param>
    public Villa(Estate other)
    {
      RealEstateType = EstateType.Villa;
      this.LegalStatus = other.LegalStatus;
      this.Price = other.Price;
      this.NbrRooms = other.NbrRooms;
      this.PostAddress = new Address(other.PostAddress);
    }

    /// <summary>
    /// We add the property for landSize size
    /// </summary>
    public int LandSize
    {
      get { return landSize; }
      set { landSize = value; }
    }

    // To do: Add more  methods  for this kind of estate

    /// <summary>
    /// </summary>
    /// <returns>A formated string about the object.</returns>
    public override string ToString()
    {
        return String.Format(" {0} {1}", base.ToString(),
                                    landSize.ToString().ToUpper());
    }
  }
}
