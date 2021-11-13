using System;
using System.Runtime.InteropServices;

namespace Fuse.NET
{
    [StructLayout (LayoutKind.Sequential)]
    public sealed class FileSystemOperationContext {
        internal IntPtr fuse;
        [Map ("uid_t")] private long userId;
        [Map ("gid_t")] private long groupId;
        [Map ("pid_t")] private int  processId;

        internal FileSystemOperationContext ()
        {
        }

        public long UserId {
            get {return userId;}
        }

        public long GroupId {
            get {return groupId;}
        }

        public int ProcessId {
            get {return processId;}
        }
    }
}