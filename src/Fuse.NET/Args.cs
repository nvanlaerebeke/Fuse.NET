using System;
using System.Runtime.InteropServices;

namespace Fuse.NET
{
    [Map ("struct fuse_args")]
    [StructLayout (LayoutKind.Sequential)]
    class Args {
        public int argc;
        public IntPtr argv;
        public int allocated;
    }
}