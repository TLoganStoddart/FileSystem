using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    /// <summary>
    /// File Entity that can store a string of text, but contains no children.
    /// </summary>
    class Text : FileEntity
    {
        /// <summary>
        /// string of content unique to text file.
        /// </summary>
        /// <author>Trevor Stoddart</author>
        public string content { get; set; }

        /// <summary>
        /// Constructor for Text FileEntity
        /// </summary>
        /// <param name="name"></param>
        public Text(string name)
        {
            Name = name;
            content = "";
        }

        /// <summary>
        /// Text files return the size of the content string for their size
        /// </summary>
        public override double Size
        {
            get
            {
                return content.Length;
            }
        }

    }
}
