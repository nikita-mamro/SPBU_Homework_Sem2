using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public interface IStack
    {
        void Push(int data);
        int Pop();
        int Peek();
        bool IsEmpty { get; }
        void Clear(); 
        int Count { get; }
    }
}
