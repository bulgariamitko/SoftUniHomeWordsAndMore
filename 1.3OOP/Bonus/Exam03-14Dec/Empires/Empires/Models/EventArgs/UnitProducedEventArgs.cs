using Empires.Interfaces;

namespace Empires.Models.EventArgs
{
    public class UnitProducedEventArgs : System.EventArgs
    {
         public IUnit Unit { get; set; }
    }
}