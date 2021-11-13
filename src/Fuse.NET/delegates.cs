using System;
using System.Runtime.InteropServices;

namespace Fuse.NET
{

	delegate int GetPathStatusCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr stat);
	delegate int ReadSymbolicLinkCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr buf, ulong bufsize);
	delegate int CreateSpecialFileCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, uint perms, ulong dev);
	delegate int CreateDirectoryCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, uint mode);
	delegate int RemoveFileCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path);
	delegate int RemoveDirectoryCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path);
	delegate int CreateSymbolicLinkCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string oldpath, 
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string newpath);
	delegate int RenamePathCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string oldpath, 
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string newpath);
	delegate int CreateHardLinkCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string oldpath, 
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string newpath);
	delegate int ChangePathPermissionsCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, uint mode);
	delegate int ChangePathOwnerCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, long owner, long group);
	delegate int TruncateFileb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, long length);
	delegate int ChangePathTimesCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr buf);
	delegate int OpenHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr info); 
	delegate int ReadHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, 
			IntPtr buf, ulong size, long offset, IntPtr info, out int bytesRead);
	delegate int WriteHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, 
			[In, MarshalAs (UnmanagedType.LPArray, ArraySubType=UnmanagedType.U1, SizeParamIndex=2)]
			byte[] buf, ulong size, long offset, IntPtr info, out int bytesWritten);
	delegate int GetFileSystemStatusCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr buf);
	delegate int FlushHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr info);
	delegate int ReleaseHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr info);
	delegate int SynchronizeHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, bool onlyUserData, IntPtr info);
	delegate int SetPathExtendedAttributeCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, 
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string name, 
			[In, MarshalAs (UnmanagedType.LPArray, ArraySubType=UnmanagedType.U1, SizeParamIndex=3)]
			byte[] value, ulong size, int flags);
	delegate int GetPathExtendedAttributeCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, 
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string name, 
			[Out, MarshalAs (UnmanagedType.LPArray, ArraySubType=UnmanagedType.U1, SizeParamIndex=3)]
			byte[] value, ulong size, out int bytesWritten);
	delegate int ListPathExtendedAttributesCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, 
			[Out, MarshalAs (UnmanagedType.LPArray, ArraySubType=UnmanagedType.U1, SizeParamIndex=2)]
			byte[] list, ulong size, out int bytesWritten);
	delegate int RemovePathExtendedAttributeCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, 
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string name);
	delegate int OpenDirectoryCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr info);
	delegate int ReadDirectoryCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr buf, IntPtr filler, 
			long offset, IntPtr info, IntPtr stbuf);
	delegate int ReleaseDirectoryCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr info);
	delegate int SynchronizeDirectoryCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, bool onlyUserData, IntPtr info);
	delegate IntPtr InitCb (IntPtr conn);
	delegate void DestroyCb (IntPtr conn);
	delegate int AccessPathCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, int mode);
	delegate int CreateHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, uint mode, IntPtr info);
	delegate int TruncateHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, long length, IntPtr info);
	delegate int GetHandleStatusCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr buf, IntPtr info);
	delegate int LockHandleCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, IntPtr info, int cmd, IntPtr flockp);
	// TODO: utimens
	delegate int MapPathLogicalToPhysicalIndexCb (
			[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))]
			string path, ulong logical, out ulong physical);
}