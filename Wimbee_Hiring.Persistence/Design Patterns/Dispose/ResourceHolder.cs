using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Wimbee_Hiring.Persistence.Design_Patterns.Dispose
{
    class ResourceHolder : IDisposable
    {
        private readonly IntPtr unmanagedRessource;
        private readonly SafeHandle managedRessource;
        public ResourceHolder()
        {
            unmanagedRessource = Marshal.AllocHGlobal(sizeof(int));
            managedRessource = new SafeFileHandle(new IntPtr(), true);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedRessource(unmanagedRessource);
            if (disposing)
            {
                ReleaseManagedRessource(managedRessource);
            }
        }

        private void ReleaseManagedRessource(SafeHandle safeHandle)
        {
            if (safeHandle != null)
            {
                safeHandle.Dispose();
            }
        }

        private void ReleaseUnmanagedRessource(IntPtr intPtr)
        {
            Marshal.FreeHGlobal(intPtr);
        }

        ~ResourceHolder()
        {
            Dispose(false);
        }
    }

    
}