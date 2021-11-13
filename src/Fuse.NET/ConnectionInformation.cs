using System;
using System.Runtime.InteropServices;

namespace Fuse.NET
{
    public class ConnectionInformation {
        private IntPtr conn;

        // fuse_conn_info member offsets
        const int 
            ProtMajor = 0,
            ProtMinor = 1,
            AsyncRead = 2,
            MaxWrite  = 3,
            MaxRead   = 4;

        internal ConnectionInformation (IntPtr conn)
        {
            this.conn = conn;
        }

        public uint ProtocolMajorVersion {
            get {return (uint) Marshal.ReadInt32 (conn, ProtMajor);}
        }

        public uint ProtocolMinorVersion {
            get {return (uint) Marshal.ReadInt32 (conn, ProtMinor);}
        }

        public bool AsynchronousReadSupported {
            get {return Marshal.ReadInt32 (conn, AsyncRead) != 0;}
            set {Marshal.WriteInt32 (conn, AsyncRead, value ? 1 : 0);}
        }

        public uint MaxWriteBufferSize {
            get {return (uint) Marshal.ReadInt32 (conn, MaxWrite);}
            set {Marshal.WriteInt32 (conn, MaxWrite, (int) value);}
        }

        public uint MaxReadahead {
            get {return (uint) Marshal.ReadInt32 (conn, MaxRead);}
            set {Marshal.WriteInt32 (conn, MaxRead, (int) value);}
        }
    }
}