using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeForSale.Home
{
  public class Rental : Apartment  //"is a"
  {
    // This is a special sort of apartment, add it's own fields, properties and methods

    public Rental()
      : base()
    {
      this.LegalStatus = LegalType.Rental;
    }

    //TO DO:  Complte this class with more logics
  }
}
