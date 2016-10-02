using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    /// <summary>
    /// Basic file entity for storing other entities.
    /// </summary>
    /// <author>Trevor Stoddart</author>
    class Folder : FileEntity
    {
        public Folder(string name)
        {
            Name = name;
            Type = "Folder";
        }
    }
}
