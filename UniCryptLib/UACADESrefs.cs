using System;
using System.Runtime.InteropServices;

namespace UniCryptLib
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UACADESrefs
    {
        public UARecord certRef;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public UARecord[] crlRefs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public UARecord[] ocspRefs;
        public int certStored;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] crlStored;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] ocspStored;
    }
}
