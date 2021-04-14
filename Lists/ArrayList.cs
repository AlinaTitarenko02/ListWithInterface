using System;

namespace List
{
    public class ArrayList : IList
    {
        public int Length { get; private set; }

        private int[] _array;

        public int this[int index] //доступ по индексу //изменение по индексу
        {
            get
            {
                if (index > Length || index < 0) throw new IndexOutOfRangeException();
                else return _array[index];
            }
            set
            {
                if (index > Length || index < 0) throw new IndexOutOfRangeException();
                else _array[index] = value;
            }
        }

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;

            _array = new int[10];
            _array[0] = value;


        }

        public ArrayList(int[] arrayValues)
        {
            Length = arrayValues.Length;

            _array = new int[Length];

            Resize();
            for (int i = 0; i < Length; i++)
            {
                _array[i] = arrayValues[i];
            }

        }

        public void Add(int value) // Добавление значения в конец
        {
            if (Length >= _array.Length)
            {
                Resize();
            }

            _array[Length] = value;
            Length++;

        }

        public void AddByIndex(int index, int value) //Добавление значения по индексу
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Length++;
                if (Length >= _array.Length)
                {
                    Resize();
                }

                MoveElements(index, Length, 1);
                _array[index] = value;
            }
        }

        public void AddFirst(int value) // Добавление значения в начало
        {
            AddByIndex(0, value);
        }

        public void RemoveEnd() //удаляет из конца списка элемент
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Length--;
                if (Length < _array.Length / 2)
                {
                    Resize();
                }
            }
        }

        public void RemoveFirst() //удаляет из начала списка элемент
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                RemoveByIndex(0);
            }
        }

        public void RemoveByIndex(int index) //удаляет из списка элемент по индексу index
        {
            if (index > (Length - 1) || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            MoveElements(index, Length, -1);
            Length--;
            if (Length < _array.Length / 2)
            {
                Resize();
            }

        }

        public void RemoveRangeFromLast(int count) //удаляет из списка count элементов, начиная с конца
        {
            if (count > Length || count < 0)
            {
                throw new ArgumentException("Count must be greater then 0 or less then list Length");
            }

            if (count != 0)
            {
                RemoveRangeFromIndex(Length - count, count);
            }
        }

        public void RemoveRangeFromFirst(int count) //удаляет из списка count элементов, начиная с начала
        {
            if (count > Length || count < 0)
            {
                throw new ArgumentException("Count must be greater then 0 or less then list Length");
            }

            RemoveRangeFromIndex(0, count);
        }

        public void RemoveRangeFromIndex(int index, int count) //удаляет из списка count элементов, начиная с индекса index
        {
            if (index > (Length - 1) || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (count > (Length - index) || count < 0)
            {
                throw new ArgumentException("List has less elements then You want to Remove");
            }

            Length -= count;
            MoveElements(index, Length, -count);

            if (Length <= _array.Length / 2)
            {
                Resize();
            }
        }

        public int RemoveFirstByValue(int value) //удаление по значению первого
        {
            int index = GetFirstIndexByValue(value);
            if (index >= 0)
            {
                RemoveByIndex(index);
            }

            return index;
        }

        public int RemoveAllByValue(int value) //удаление по значению всех
        {
            int count = 0;
            int index;
            bool find = true;
            while (find)
            {
                index = GetFirstIndexByValue(value);
                if (index >= 0)
                {
                    RemoveByIndex(index);
                    count++;
                }
                else
                {
                    find = false;
                }
            }

            return count;
        }

        public int GetLength() //Возврат длинны
        {
            return Length;
        }

        public int GetFirstIndexByValue(int value) //Возврат первый индекс по значению
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Reverse() //реверс (123 -> 321)
        {
            for (int i = 0; i < Length / 2; i++)
            {
                var tmp = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmp;
            }
        }

        public int FindIndexOfMaxValue() //поиск индекс максимального элемента
        {
            int arrayIndexMaxValue = 0;
            int arrayMaxValue = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > arrayMaxValue)
                {
                    arrayMaxValue = _array[i];
                    arrayIndexMaxValue = i;
                }
            }

            return arrayIndexMaxValue;
        }

        public int FindIndexOfMinValue() //поиск индекс минимального элемента
        {
            int arrayIndexMinValue = 0;
            int arrayMinValue = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < arrayMinValue)
                {
                    arrayMinValue = _array[i];
                    arrayIndexMinValue = i;
                }
            }

            return arrayIndexMinValue;
        }

        public int FindMaxValue() //поиск значения максимального элемента
        {
            return _array[FindIndexOfMaxValue()];
        }

        public int FindMinValue() //поиск значения минимального элемента
        {
            return _array[FindIndexOfMinValue()];
        }

        public void Sort()
        { 
            for (int i = 0; i < Length; i++)
            {
                var lessIndex = i;
                var lessValue = _array[i];
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] < lessValue)
                    {
                        lessIndex = j;
                        lessValue = _array[j];
                    }
                }

                _array[lessIndex] = _array[i];
                _array[i] = lessValue;
            }
        }

        public void AddListLast(IList list) //добавление списка (вашего самодельного) в конец
        {
            if (list is ArrayList)
            {
                ArrayList arrayList = (ArrayList)list;
                AddListByIndex(Length, arrayList);
            }
        }

        public void AddListFirst(IList list) //добавление списка в начало
        {
            if (list is ArrayList)
            {
                ArrayList arrayList = (ArrayList)list;
                AddListByIndex(0, arrayList);
            }
        }

        public void AddListByIndex(int index, IList list) //добавление списка по индексу
        {
            if (list is ArrayList)
            {
                ArrayList arrayList = (ArrayList)list;
                if (index > Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Length += arrayList.Length;
                if (Length >= _array.Length)
                {
                    Resize();
                }

                MoveElements(index, Length - 1, arrayList.Length);

                for (int i = 0; i < arrayList.Length; ++i)
                {
                    _array[index] = arrayList[i];
                    ++index;
                }
            }
        }

        private void Resize()
        {
            int newLength = (int)(Length * 1.33d + 1);
            int[] tmpArray = new int[newLength];
            int minLength;

            if (_array.Length < tmpArray.Length)
            {
                minLength = _array.Length;
            }
            else
            {
                minLength = tmpArray.Length;
            }

            for (int i = 0; i < minLength; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void MoveElements(int indexFrom, int indexTo, int count)
        {
            if (count > 0)
            {
                for (int i = indexTo; (i - count) >= indexFrom; i--)
                {
                    _array[i] = _array[i - count];
                }
            }
            else
            {
                for (int i = indexFrom; i < indexTo; i++)
                {
                    _array[i] = _array[i - count];
                }
            }

        }

        public void Print()
        {
            this.PrintArray();
            this.PrintList();
        }

        private void PrintArray() //For manual testing
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"Array[{i}] = {_array[i]}");
            }
        }

        private void PrintList() //For manual testing
        {
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"List<{i}> = {_array[i]}");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayList)
            {
                ArrayList arrayList = (ArrayList)obj;
                if (this.Length != arrayList.Length)
                {
                    return false;
                }

                for (int i = 0; i < Length; i++)
                {
                    if (this._array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       
    }
}
