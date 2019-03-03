using System;

namespace Homework
{
    public interface IHashFunction
    {
        uint HashFunctionAdler(string word);
        long HashFunctionMurmur2(string word);
        long HashFunction3();
    }
}
