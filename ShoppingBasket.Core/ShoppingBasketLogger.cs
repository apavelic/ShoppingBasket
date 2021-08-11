using ShoppingBasket.Core.Interfaces;
using System.Diagnostics;

namespace ShoppingBasket.Core
{
  public class ShoppingBasketLogger : IShoppingBasketLogger
  {
    public void Log(string message)
    {
      Trace.WriteLine(message);
    }
  }
}