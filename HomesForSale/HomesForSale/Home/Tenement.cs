using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale.Home
{
  public class Tenement : Apartment
  {
    // This is a special sort of apartment, add it's own fields, properties and methods

    public Tenement()
      : base()
    {
      this.LegalStatus = LegalType.Tenement;
    }

    //TO DO:  Complete this class with more logics
  }
}
