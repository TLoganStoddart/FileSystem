using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    /// <summary>
    /// File entity used to store all other file entities.
    /// A drive is not contained in any entity.
    /// </summary>
    /// <author>Trevor Stoddart</author>
    class Drive : FileEntity
    {

        /// <summary>
        /// Drive constructor sets parent to null, Type to Drive, size to 0 and sets name;
        /// </summary>
        /// <param name="name"></param>
        public Drive(string name)
        {
            Name = name;
            Type = "Drive";
            parent = null;
        }

        /// <summary>
        /// Drive Path returns the drive name as drives will have no parent.
        /// </summary>
        public override string Path
        {
            get
            {
                return Name;
            }
        }       
    }
}
