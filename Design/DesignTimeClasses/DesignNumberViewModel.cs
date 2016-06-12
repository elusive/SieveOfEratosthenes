using System.Windows.Media;
using SieveOfEratosthenes.Core.Models;

namespace DesignTimeClasses
{
    /// <summary>
    /// Design time class for number view models.
    /// </summary>
    public class DesignNumberViewModel
    {
        protected NumberModel Model;

        public DesignNumberViewModel(NumberModel model)
        {
            Model = model;
        }

        public int Number
        {
            get { return Model.Number; }
        }

        public Color DisplayColor
        {
            get { return Model.DisplayColor; }
        }

        public bool IsPrime
        {
            get { return Model.IsPrime; }
        }
    }
}