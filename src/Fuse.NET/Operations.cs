using System.Runtime.InteropServices;

namespace Fuse.NET
{
    [Map]
    [StructLayout (LayoutKind.Sequential)]
    class Operations {
        public GetPathStatusCb                getattr;
        public ReadSymbolicLinkCb             readlink;
        public CreateSpecialFileCb            mknod;
        public CreateDirectoryCb              mkdir;
        public RemoveFileCb                   unlink;
        public RemoveDirectoryCb              rmdir;
        public CreateSymbolicLinkCb           symlink;
        public RenamePathCb                   rename;
        public CreateHardLinkCb               link;
        public ChangePathPermissionsCb        chmod;
        public ChangePathOwnerCb              chown;
        public TruncateFileb                  truncate;
        public ChangePathTimesCb              utime;
        public OpenHandleCb                   open;
        public ReadHandleCb                   read;
        public WriteHandleCb                  write;
        public GetFileSystemStatusCb          statfs;
        public FlushHandleCb                  flush;
        public ReleaseHandleCb                release;
        public SynchronizeHandleCb            fsync;
        public SetPathExtendedAttributeCb     setxattr;
        public GetPathExtendedAttributeCb     getxattr;
        public ListPathExtendedAttributesCb   listxattr;
        public RemovePathExtendedAttributeCb  removexattr;
        public OpenDirectoryCb                opendir;
        public ReadDirectoryCb                readdir;
        public ReleaseDirectoryCb             releasedir;
        public SynchronizeDirectoryCb         fsyncdir;
        public InitCb                         init;
        public DestroyCb                      destroy;
        public AccessPathCb                   access;
        public CreateHandleCb                 create;
        public TruncateHandleCb               ftruncate;
        public GetHandleStatusCb              fgetattr;
        public LockHandleCb                   @lock;
        public MapPathLogicalToPhysicalIndexCb  bmap;
    }
}