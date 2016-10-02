using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    /// <summary>
    /// Main file system implementation combining File entities with functionality
    /// </summary>
    /// <author>Trevor Stoddart</author>
    /// <created>Saturday, October 1st 2016</created>
    /// <edited>Sunday, October 2nd 2016</edited>
    class FileSystem
    {
        ///Collection of drives that will store all other entities
        Dictionary<string, Drive> drives = new Dictionary<string, Drive>();
        public void create(string type, string name, string path)
        {
            FileEntity current;
            //traverse to current element in path
            if (type != "Drive")
            {
                current = traverse(path);
            }
            else
            {
                current = null;
            }


            if(current is Text)
            {
                throw new IllegalFileSystemOperationException("Cannot create new entity in text file");
            }

            switch (type)
            {
                case "Drive":
                    if (path == name || path == "")
                    {
                        if (drives.ContainsKey(name))
                            throw new PathAlreadyExistsException();
                        else
                        {
                            drives.Add(name, new Drive(name));
                        }
                    }
                    else throw new IllegalFileSystemOperationException("Drives may not be stored in other File Entities.");
                    break;

                case "Folder":
                    current.children.Add(name, new Folder(name));
                    traverse(path + "\\" + name).parent = current;
                    break;

                case "Text":
                    current.children.Add(name, new Text(name));
                    traverse(path + "\\" + name).parent = current;
                    break;

                case "Zip":
                    current.children.Add(name, new Zip(name));
                    traverse(path + "\\" + name).parent = current;
                    break;

                default:
                    throw new IllegalFileSystemOperationException("Type did not match 'Drive', 'Folder', 'Text', or 'Zip'");
            }
        }


        /// <summary>
        /// Removes the entity given in the path
        /// </summary>
        /// <exception cref="PathNotFoundException"></exception>"
        /// <param name="path"></param>
        public void delete(string path)
        {
            FileEntity entity = traverse(path);
            if (entity is Drive)
            {
                drives.Remove(entity.Name);
            }
            else
                entity.parent.children.Remove(entity.Name);
        }

        /// <summary>
        /// Moves file from source (including file name) to destination path.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void move(string source, string destination)
        {
            FileEntity current = traverse(source);
            FileEntity newParent = traverse(destination);
            if(newParent.children.ContainsKey(current.Name))
            {
                throw new PathAlreadyExistsException();
            }
            else
            {
                current.parent.children.Remove(current.Name);
                newParent.children.Add(current.Name, current);
                current.parent = newParent;
            }
        }

        /// <summary>
        /// Writes to a text file
        /// </summary>
        /// <exception cref="NotATextFileException">Exception thrown if entity is not a text file.</exception>
        /// <param name="Path"></param>
        /// <param name="content"></param>
        public void writeToFile(string Path, string content)
        {
            FileEntity current = traverse(Path);
            if (current is Text)
            {
                (current as Text).content = content;
            }
            else throw new NotATextFileException();

        }


        /// <summary>
        /// Helper method to traverse paths in file system
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Entity given in the path</returns>
        public FileEntity traverse(string path)
        {
            List<string> allPathEntities = path.Split('\\').ToList();
            FileEntity current;
            //first check if drive exists
            if (drives.ContainsKey(allPathEntities[0]))
            {
                current = drives[allPathEntities[0]];
                allPathEntities.RemoveAt(0);

                foreach(string s in allPathEntities)
                {
                    if (current.children.ContainsKey(s))
                    {
                        current = current.children[s];
                    }
                    else throw new PathNotFoundException();
                }
                return current;
            }
            throw new PathNotFoundException();
        }
    }

    //custom exceptions for file system
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException() : base() { }
        public PathNotFoundException(string e) : base(e) { }
    }
    public class PathAlreadyExistsException : Exception
    {
        public PathAlreadyExistsException() : base() { }
        public PathAlreadyExistsException(string e) : base(e) { }
    }
    public class IllegalFileSystemOperationException : Exception
    {
        public IllegalFileSystemOperationException() : base() { }
        public IllegalFileSystemOperationException(string e) : base(e) { }
    }

    public class NotATextFileException : Exception
    {
        public NotATextFileException() : base() { }
        public NotATextFileException(string e) : base(e) { }
    }
}
