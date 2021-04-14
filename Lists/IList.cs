using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList 
    {
        public int this[int index] { get; set; }

        public void Add(int value);

        public void AddFirst(int value);

        public void AddByIndex(int index, int value);

        void AddListFirst(IList linkedList);

        void AddListLast(IList linkedList);

        void AddListByIndex(int index, IList linkedList);

        public void RemoveEnd();

        public void RemoveFirst();

        public void RemoveByIndex(int index);

        public void RemoveRangeFromLast(int count);

        public void RemoveRangeFromFirst(int count);

        public void RemoveRangeFromIndex(int index, int count);

        public int RemoveFirstByValue(int value);

        public int RemoveAllByValue(int value);

        public void Reverse();

        public int GetFirstIndexByValue(int value);

        public int FindMaxValue();

        public int FindMinValue();

        public int FindIndexOfMaxValue();

        public int FindIndexOfMinValue();

        public string ToString();

        public void Sort();
    }
}
