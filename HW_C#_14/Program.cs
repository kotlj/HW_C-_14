using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__14
{
    public class PQueue<T>
    {
        private T[] _item;
        private int[] _prioryty;
        int Size;
        int CurMax;

        public PQueue()
        {
            _item = new T[8];
            _prioryty = new int[8];
            Size = 8;
            CurMax = 0;
        }
        public PQueue(T[] item, int[] prioryty, int size, int curMax)
        {
            _item = item;
            _prioryty = prioryty;
            Size = item.Length;
            CurMax = Size;
        }
        public bool IsFull()
        {
            if (CurMax == Size)
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty()
        {
            if (CurMax == 0)
            {
                return true;
            }
            return false;
        }

        public void Extend(int extd)
        {
            if (extd == 0)
            {
                if (IsFull())
                {
                    extd = Size + 8;
                    T[] temp = new T[extd];
                    int[] InTemp = new int[extd];
                    for(int i = 0; i < Size; i++)
                    {
                        temp[i] = _item[i]; InTemp[i] = _prioryty[i];
                    }
                    temp = null; InTemp = null;
                    Size += 8;
                }
            }
            else
            {
                T[] temp = new T[Size + extd];
                int[] InTemp = new int[Size + extd];
                for (int i = 0; i < Size; i++)
                {
                    temp[i] = _item[i]; InTemp[i] = _prioryty[i];
                }
                temp = null; InTemp = null;
                Size += extd;
            }
        }
        private void remove(int indx)
        {
            if (!IsEmpty())
            {
                T[] temp = new T[Size];
                int[] Npriority = new int[Size];
                for (int i = 0; i<Size; i++)
                {
                    if (i < indx)
                    {
                        temp[i] = _item[i]; Npriority[i] = _prioryty[i];
                    }
                    else if (i > indx)
                    {
                        temp[i] = _item[i - 1]; Npriority[i - 1] = _prioryty[i - 1];
                    }
                }
                _item = temp; _prioryty = Npriority;
                temp = null; _prioryty = null;
            }
        }
        public T pop()
        {
            T toRet;
            toRet = default(T);
            if (!IsEmpty())
            {
                int indx = _prioryty.Max();
                toRet = _item[indx];
                remove(indx);
            }
            return toRet;
        }
        public T peek()
        {
            T toRet;
            toRet = default(T);
            if (!IsEmpty())
            {
                int indx = _prioryty.Max();
                toRet = _item[indx];
            }
            return toRet;
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {

        }
    }
}
