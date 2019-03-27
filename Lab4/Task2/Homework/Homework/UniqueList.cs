﻿using System;

namespace Lists
{
    public class UniqueList : List
    {
        public override void Add(int data, int position)
        {
            if (Exists(data))
            {
                throw new Exceptions.ElementAlreadyInListException("Попытка добавления в UniqueList существующего значения");
            }

            base.Add(data, position);
        }

        public override void AddToHead(int data)
        {
            if (Exists(data))
            {
                throw new Exceptions.ElementAlreadyInListException("Попытка добавления в голову UniqueList существующего значения");
            }

            base.AddToHead(data);
        }
    }
}