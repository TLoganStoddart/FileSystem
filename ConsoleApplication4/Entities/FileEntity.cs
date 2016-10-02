using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    /// <summary>
    /// The base class for all file entities (drives, folders, text, and zip)
    /// </summary>
    /// <author>Trevor Stoddart</author>
    class FileEntity
    {
        // File Entity properties
        private string name;
        private string type;
        private double size;
        public Dictionary<string, FileEntity> children = new Dictionary<string, FileEntity>();
        public FileEntity parent;

        /// <summary>
        /// Name of the file entity;
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// The concatenation of the names of the containing entities,
        /// from the drive down to and including the entity.
        /// The names are separated by ‘\’.
        /// </summary>
        public virtual string Path
        {
            get
            {
                return parent.Path + "\\" + this.Name;
            }
        }

        /// <summary>
        /// Drive, Folders, Text files, Zip Files
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Contains the sum of all sizes of the entities it contains
        /// </summary>
        public virtual double Size
        {
            get
            {
                double total = 0;
                foreach( FileEntity entity in children.Values)
                {
                    total += entity.Size;
                }
                return this.size + total;         
            }
            set
            {
                size = value;
            }
        }

        /// <summary>
        /// override GetHashCode so we can look up our children in constant time.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
