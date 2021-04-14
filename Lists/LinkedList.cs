using System;
namespace List
{
    public class LinkedList : IList
    {
        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                if (value >= 0)
                {
                    _length = value;
                }
                else
                {
                    _length = 0;
                }
            }

        }
        private int _length;

        public int this[int index]
        {
            get
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }

            set
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        private Node _root;
        private Node _tail;

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            //if(values is null)

            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = _root;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = _root;
        }

        private Node GetNodeByIndex(int index)
        {
            Node current = _root;
            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public void Add(int value)
        {
            if (_root is null)
            {
                Length++;
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
        }

        public void AddFirst(int value)
        {
            Length++;
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
        }

        public void AddByIndex(int index, int value)
        {
            Node addValue = new Node(value);
            if ((index > 0) && (index < Length - 1))
            {
                Length++;
                Node current = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                addValue.Next = current.Next;
                current.Next = addValue;
            }
            else if (index == Length - 1)
            {
                Add(value);
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        public void RemoveFirst()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length == 1)
            {
                Length--;
                _root = null;
                _tail = null;
            }
            else
            {
                Length--;
                _root = _root.Next;

            }
        }

        public void RemoveByIndex(int index)
        {
            if (index > (Length - 1) || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = _root;
            if (index == 0)
            {
                RemoveFirst();
            }
            else if ((index > 0) && (index <= Length))
            {
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                Length--;
                current.Next = current.Next.Next;
            }
            if (Length == 0)
            {
                _root = null;
                _tail = _root;
            }

        }

        public void RemoveEnd()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length == 0)
            {
                throw new ArgumentException("List has less elements then You want to Remove");
            }
            else
            {
                Length--;
                Node current = _root;
                for (int i = 0; i < Length - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = null;
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
                if (Length <= count)
                {
                    _root = null;
                    _tail = null;
                }
                else
                {
                    int tempIndex = Length - count;
                    Node current = _root;
                    for (int i = 0; i < tempIndex - 1; ++i)
                    {
                        current = current.Next;
                    }
                    _tail = current;
                    current.Next = null;
                    Length -= count;
                }
            }
        }

        public void RemoveRangeFromFirst(int count) //удаляет из списка count элементов, начиная с начала
        {
            if (count > Length || count < 0)
            {
                throw new ArgumentException("Count must be greater then 0 or less then list Length");
            }
            for (int i = 0; i < count; i++)
            {
                _root = _root.Next;
                Length--;
            }
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

            if (count == Length)
            {
                Length -= count;
                _root = null;
                _tail = null;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    RemoveByIndex(index);
                }
            }
        }

        public int GetLength() //Возврат длинны
        {
            return Length;
        }

        public int GetFirstIndexByValue(int value) //Возврат первый индекс по значению
        {
            Node current = _root;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }

        public void Reverse() //реверс (123 -> 321)
        {
            if (Length > 0)
            {
                Node previous = null;
                Node current = _root;
                Node following = _root;

                while (!(current is null))
                {
                    following = following.Next;
                    current.Next = previous;
                    previous = current;
                    current = following;
                }

                current = _root;
                _root = _tail;
                _tail = current;
            }

        }

        public int FindIndexOfMaxValue() //поиск индекс максимального элемента
        {
            int arrayIndexMaxValue = 0;
            Node current = _root;
            int MaxValue = current.Value;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value > MaxValue)
                {
                    MaxValue = current.Value;
                    arrayIndexMaxValue = i;
                }
                current = current.Next;
            }

            return arrayIndexMaxValue;
        }

        public int FindIndexOfMinValue() //поиск индекс максимального элемента
        {
            int arrayIndexMinValue = 0;
            Node current = _root;
            int MinValue = current.Value;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value < MinValue)
                {
                    MinValue = current.Value;
                    arrayIndexMinValue = i;
                }
                current = current.Next;
            }

            return arrayIndexMinValue;
        }

        public int FindMaxValue() //поиск значения максимального элемента
        {
            int result = this[FindIndexOfMaxValue()];
            return result;
        }

        public int FindMinValue() //поиск значения минимального элемента
        {
            int result = this[FindIndexOfMinValue()];
            return result;
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

        public void AddListLast(IList list) //добавление списка (вашего самодельного) в конец
        {
            if (list is LinkedList)
            {
                LinkedList linkedList = (LinkedList)list;
                Node current = this._tail;
                Node temp = current.Next;
                current.Next = linkedList._root;
                linkedList._tail.Next = temp;
                Length += linkedList.Length;
            }
        }

        public void AddListFirst(IList list) //добавление списка в начало
        {
            if (list is LinkedList)
            {
                LinkedList linkedList = (LinkedList)list;
                linkedList._tail.Next = this._root;
                this._root = linkedList._root;
                Length += linkedList.Length;
            }
        }

        public void AddListByIndex(int index, IList list) //добавление списка по индексу
        {
            if (list is LinkedList)
            {
                LinkedList linkedList = (LinkedList)list;
                if (index > Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (index == 0)
                {
                    AddListFirst(linkedList);
                }
                if (index == this.Length)
                {
                    AddListLast(linkedList);
                }
                else
                {
                    Node current = this._root;
                    for (int i = 1; i < index; i++)
                    {
                        current = current.Next;
                    }
                    Node temp = current.Next;
                    current.Next = linkedList._root;
                    linkedList._tail.Next = temp;
                    Length += linkedList.Length;
                }
            }

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

        public void Merge(LinkedList leftl, LinkedList rightl)
        {
            _root = null;
            Length = 0;
            Node l = leftl._root;
            Node r = rightl._root;
            while (!(l is null) || !(r is null))
            {
                if (l is null)
                {
                    Add(r.Value);
                    r = r.Next;
                }
                else if (r is null)
                {
                    Add(l.Value);
                    l = l.Next;
                }
                else
                {
                    if (l.Value < r.Value)
                    {
                        Add(l.Value);
                        l = l.Next;
                    }
                    else
                    {
                        Add(r.Value);
                        r = r.Next;
                    }
                }
            }
        }

        public void Sort()
        {
            if (Length == 1 )
            {
                return;
            }
            LinkedList leftl = new LinkedList();
            LinkedList rightl = new LinkedList();
            int mid = Length / 2;

            for (int i = 0; i < Length; i++)
            {
                if (i < mid)
                {
                    leftl.Add(this[i]);
                }
                else
                {
                    rightl.Add(this[i]);
                }
            }
            leftl.Sort();
            rightl.Sort();
            Merge(leftl, rightl);
        }



        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;

            if ((this._root is null) && (list._root is null))
            {
                return true;
            }

            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                if ((currentList.Next is null) || (currentThis.Next is null))
                {
                    break;
                }

                currentList = currentList.Next;
                currentThis = currentThis.Next;
            } while (!(currentThis.Next is null));

            return true;
        }
    }
}

