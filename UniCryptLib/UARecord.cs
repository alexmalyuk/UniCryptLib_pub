using System;
using System.Runtime.InteropServices;

namespace UniCryptLib
{

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UARecord : IDisposable
    {
        public IntPtr data;
        public int datalen;

        public UARecord(int len)
        {
            datalen = len;
            data = Marshal.AllocHGlobal(datalen);
        }

        public UARecord(byte[] src)
        {
            if (src != null)
            {
                datalen = src.Length;
                data = Marshal.AllocHGlobal(datalen);
                Marshal.Copy(src, 0, data, datalen);
            }
            else
            {
                datalen = 0;
                data = IntPtr.Zero;
            }
        }

        public void Init(int len)
        {
            Dispose();
            datalen = len;
            data = Marshal.AllocHGlobal(datalen);
        }

        public void Init(byte[] src)
        {
            Dispose();
            if (src != null)
            {
                datalen = src.Length;
                data = Marshal.AllocHGlobal(datalen);
                Marshal.Copy(src, 0, data, datalen);
            }
            else
            {
                datalen = 0;
                data = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            datalen = 0;
            if (!(data != IntPtr.Zero))
                return;
            Marshal.FreeHGlobal(data);
            data = IntPtr.Zero;
        }

        public byte[] GetArray
        {
            get
            {
                if (!(data != IntPtr.Zero))
                    return null;
                byte[] destination = new byte[datalen];
                Marshal.Copy(data, destination, 0, datalen);
                return destination;
            }
        }
    }
}

