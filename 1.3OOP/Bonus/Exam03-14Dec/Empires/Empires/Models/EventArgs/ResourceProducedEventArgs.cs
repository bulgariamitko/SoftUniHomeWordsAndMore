using Empires.Interfaces;
using System;

namespace Empires.Models.EventArgs
{
    public class ResourceProducedEventArgs : System.EventArgs
    {
         public IResource Resource { get; set; }
    }
}