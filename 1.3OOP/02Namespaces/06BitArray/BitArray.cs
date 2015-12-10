using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _06BitArray
{
    public class BitArray
    {
        private int capacity;
        private byte[] bitArr;

        public int Capacity
        {
            set
            {
                if (value < 1 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("The size is too big!");
                }
                capacity = value;
            }
        }

        public byte this[int index]
        {
            get { return GetBitAtIndex(index); }
            set { SetBitAtIndex(index, value); }
        }

        public BitArray(int capacity)
        {
            Capacity = capacity;
            bitArr = new byte[this.capacity];
        }

        public BitArray(params byte[] bits)
        {
            bitArr = new byte[bits.Length];
            for (int i = 0; i < bits.Length; i++)
            {
                bitArr[i] = bits[i];
            }
        }

        public BitArray(BigInteger number)
        {
            List<byte> bits = new List<byte>();
            while (true)
            {
                byte remainder = (byte)(number%2);
                bits.Add(remainder);
                number /= 2;
                if (number == 0)
                {
                    break;
                }
            }
        }

        private byte GetBitAtIndex(int index)
        {
            if (index < 0 || index > this.bitArr.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return this.bitArr[index];
        }

        private void SetBitAtIndex(int index, byte bit)
        {
            if (index < 0 || index > this.bitArr.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            if (bit != 0 && bit != 1)
            {
                throw new ArgumentException("A bit can be only 0 or 1");
            }
            bitArr[index] = bit;
        }

        public override string ToString()
        {
            BigInteger result = 0;
            for (int i = 0; i < bitArr.Length; i++)
            {
                result += (BigInteger) (bitArr[i]*Math.Pow(2, i));
            }
            return result.ToString();
        }
    }
}
