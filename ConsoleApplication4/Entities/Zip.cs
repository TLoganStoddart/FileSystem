using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    /// <summary>
    /// Zip file can contain other entities, size is half of sum of children.
    /// </summary>
    /// <author>Trevor Stoddart</author>
    class Zip : FileEntity
    {
        /// <summary>
        /// Zip FileEntity constructor
        /// </summary>
        /// <param name="name"></param>
        public Zip(string name)
        {
            Name = name;
            Type = "Zip";
        }

        /// <summary>
        /// Zip files return the size of all their contents divided by two.
        /// </summary>
        public override double Size
        {
            get
            {
                return base.Size / 2;
            }
        }
    }
}
