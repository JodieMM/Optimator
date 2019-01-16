using System.Collections.Generic;

namespace Animator
{
    /// <summary>
    /// A class to encapsulate individual pieces and their grouped form, sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public abstract class Part
    {
        public abstract string Name { get; set; }
        public abstract List<string> Data { get; set; }


        /// <summary>
        /// Converts the Part into a readable format.
        /// </summary>
        /// <returns>The part's name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
