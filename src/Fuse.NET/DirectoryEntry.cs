using System;
using Mono.Unix.Native;

namespace Fuse.NET
{
    public class DirectoryEntry {
        private string name;

        public string Name {
            get {return name;}
        }

        // This is used only if st_ino is non-zero and
        // FileSystem.SetsInodes is true
        public Stat Stat;

        private static char[] invalidPathChars = new char[]{'/'};

        public DirectoryEntry (string name)
        {
            if (name == null)
                throw new ArgumentNullException ("name");
            if (name.IndexOfAny (invalidPathChars) != -1)
                throw new ArgumentException (
                    "name cannot contain directory separator char", "name");
            this.name = name;
        }
    }
}