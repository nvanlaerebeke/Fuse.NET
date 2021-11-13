using System;
using System.Runtime.InteropServices;
using Mono.Unix.Native;

namespace Fuse.NET
{
    [Map]
    [StructLayout (LayoutKind.Sequential)]
    public sealed class  OpenedPathInfo {
        internal OpenFlags flags;
        private int   write_page;
        private bool  direct_io;
        private bool  keep_cache;
        private ulong file_handle;

        internal OpenedPathInfo ()
        {
        }

        public OpenFlags OpenFlags {
            get {return flags;}
            set {flags = value;}
        }

        private const OpenFlags accessMask = 
            OpenFlags.O_RDONLY | OpenFlags.O_WRONLY | OpenFlags.O_RDWR;

        public OpenFlags OpenAccess {
            get {return flags & accessMask;}
        }

        public int WritePage {
            get {return write_page;}
            set {write_page = value;}
        }

        public bool DirectIO {
            get {return direct_io;}
            set {direct_io = value;}
        }

        public bool KeepCache {
            get {return keep_cache;}
            set {keep_cache = value;}
        }

        public IntPtr Handle {
            get {return (IntPtr) (long) file_handle;}
            set {file_handle = (ulong) (long) value;}
        }

        /// <summary>
        /// Provides a way to store a managed object in <see cref="Handle"/> using GCHandle.
        /// Note: Remember to set this to null in *Release method to avoid memory leaks!
        /// </summary>
        public object HandleRef {
            get => Handle != IntPtr.Zero ? ((GCHandle) Handle).Target : null;
            set {
                if (Handle != IntPtr.Zero) {
                    ((GCHandle) Handle).Free ();
                    Handle = IntPtr.Zero;
                }

                if (value != null)
                    Handle = (IntPtr) GCHandle.Alloc (value);
            }
        }
    }
}