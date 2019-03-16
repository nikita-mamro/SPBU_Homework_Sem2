using System;

namespace UList
{
    public class UniqueList : List.List
    {
        public override void Add(int data, int position)
        {
            if (Exists(data))
            {
                throw new Exceptions.ElementAlreadyInListException();
            }

            base.Add(data, position);
        }

        public override void AddToHead(int data)
        {
            if (Exists(data))
            {
                throw new Exceptions.ElementAlreadyInListException();
            }

            base.AddToHead(data);
        }
    }
}
