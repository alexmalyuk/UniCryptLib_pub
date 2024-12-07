using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace UniCryptLib
{
    internal sealed class Crc32 : HashAlgorithm
    {
        public const uint DefaultPolynomial = 3988292384;
        public const uint DefaultSeed = 4294967295;
        private static uint[] _defaultTable;
        private static readonly int ControlNumberDivisor = (int)Math.Pow(10.0, 4.0);
        private readonly uint _seed;
        private readonly uint[] _table;
        private uint _hash;

        public Crc32()
          : this(3988292384U, uint.MaxValue)
        {
        }

        public Crc32(uint polynomial, uint seed)
        {
            _table = InitializeTable(polynomial);
            _seed = _hash = seed;
        }

        public override void Initialize() => _hash = _seed;

        protected override void HashCore(byte[] array, int ibStart, int cbSize) => _hash = CalculateHash(_table, _hash, array, ibStart, cbSize);

        protected override byte[] HashFinal()
        {
            byte[] bigEndianBytes = UInt32ToBigEndianBytes(~_hash);
            HashValue = bigEndianBytes;
            return bigEndianBytes;
        }

        public static uint Compute(uint seed, byte[] buffer) => Compute(3988292384U, seed, buffer);

        public static uint Compute(uint polynomial, uint seed, byte[] buffer) => ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);

        private static uint[] InitializeTable(uint polynomial)
        {
            if (polynomial == 3988292384U && _defaultTable != null)
                return _defaultTable;
            uint[] numArray = new uint[256];
            for (int index1 = 0; index1 < 256; ++index1)
            {
                uint num = (uint)index1;
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    if (((int)num & 1) == 1)
                        num = num >> 1 ^ polynomial;
                    else
                        num >>= 1;
                }
                numArray[index1] = num;
            }
            if (polynomial == 3988292384U)
                _defaultTable = numArray;
            return numArray;
        }

        private static uint CalculateHash(
          uint[] table,
          uint seed,
          IList<byte> buffer,
          int start,
          int size)
        {
            uint num = seed;
            for (int index = start; index < size + start; ++index)
                num = num >> 8 ^ table[buffer[index] ^ (int)num & byte.MaxValue];
            return num;
        }

        private static byte[] UInt32ToBigEndianBytes(uint uint32)
        {
            byte[] bytes = BitConverter.GetBytes(uint32);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }


        public static int CalculateControlNumber(
          string OflSeed,
          string DocumentDate,
          string DocumentTime,
          long DocumentNumberLocal,
          long CashRegNumberFiscal,
          long CashRegNumberLocal,
          string DocumentSum,
          string DocumentHash)
        {
            StringBuilder stringBuilder = new StringBuilder(string.Format("{0},{1},{2},{3},{4},{5}", OflSeed, DocumentDate, DocumentTime, DocumentNumberLocal, CashRegNumberFiscal, CashRegNumberLocal));
            if (!string.IsNullOrWhiteSpace(DocumentSum))
            {
                stringBuilder.Append(",");
                stringBuilder.Append(DocumentSum);
            }
            if (!string.IsNullOrWhiteSpace(DocumentHash))
            {
                stringBuilder.Append(",");
                stringBuilder.Append(DocumentHash);
            }
            return CalculateControlNumber(stringBuilder.ToString());

        }

        public static int CalculateControlNumber(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(new Regex("\\s+", RegexOptions.Compiled | RegexOptions.Singleline).Replace(str, ""));
            using (Crc32 crc32 = new Crc32())
            {
                crc32.Initialize();
                crc32.ComputeHash(bytes);
                int num = (int)(BitConverter.ToUInt32(crc32.Hash, 0) % ControlNumberDivisor);
                if (num == 0)
                    num = 1;
                return num;
            }

        }
    }
}
