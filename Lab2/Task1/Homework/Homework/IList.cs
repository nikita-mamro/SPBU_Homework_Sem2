using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public interface IList
    {
        bool Add(int data, int position);
        bool Remove(int position);
        int Size();
        bool isEmpty();
        int GetDataByPosition(int position);
        bool SetDataByPosition(int data, int position);
        void Print();
        void Clear();
    }
}
