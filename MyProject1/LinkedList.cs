using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class LinkedList
    {
        private Node _root;
        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException("Индекс вне множества.");
                }

                Node current = GetNodeByIndex(index);

                return current.Value;
            }

            set
            {
                Node current = GetNodeByIndex(index);

                current.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if(values is null)
            {
                throw new NullReferenceException("На данное множество нет ссылки.");
            }

            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    // добавление в конец
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next; // ссылка на новую ноду внутри тайл некст
                }
            }
            else
            {
                _root = null;
                _tail = _root;
            }

        }

        // Добавление значения в конец.
        public void Add(int value)
        {
            Node node = new Node(value);

            if (Length == 0)
            {
                _root = node;
                _tail = _root;
            }
            else
            {
                _tail.Next = node;
                _tail = _tail.Next;
            }

            Length++;
        }

        // Добавление значения в начало.
        public void AddNumberAtFront(int value)
        {

            Node node = new Node(value);

            if (_root is null)
            {
                _root = node;
                _tail = node;
            }
            else
            {
                node.Next = _root;
                _root = node;
            }

            Length++;
        }

        // Добавление значения по индексу.
        public void AddNumberByIndex(int index, int value)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            if (index == 0)
            {
                AddNumberAtFront(value);
            }
            else if (index != Length)
            {
                Length++;

                Node current = GetNodeByIndex(index);

                Node node = new Node(value);

                node.Next = current.Next;
                current.Next = node;
            }
            else
            {
                Add(value);
            }
        }

        // Удаление из конца одного элемента.
        public void RemoveLastItem()
        {
            Node current = GetNodeByIndex(Length - 1);

            //while (!(current.Next.Next is null))
            //{
            //    current = current.Next;
            //}

            current.Next = null;
            _tail = current;
            Length--;
        }

        // Удаление из начала одного элемента.
        public void RemoveFirstItem()
        {
            if(_root == null)
            {
                throw new NullReferenceException("Нет ссылки на лист.");
            }

            _root = _root.Next;
            Length--;
        }

        // Удаление по индексу одного элемента
        public void RemoveByIndex(int index)
        {
            RemoveByIndexElements(index, 1);
        }

        // Удаление из конца N элементов.
        public void RemoveSomeItemsAtLast(int items)
        {
            if (Length > 1)
            {
                Node current = GetNodeByIndex(Length - items);

                _tail = current;
                current.Next = null;

                Length -= items;
            }
            else
            {
                this._root = null;
                this._tail = null;
                Length = 0;
            }
        }

        // Удаление из начала N элементов.
        public void RemoveSomeItemsAtFront(int items)
        {
            if (items == 1)
            {
                RemoveFirstItem();
            }
            else if (Length - 1 == items)
            {
                for (int i = 0; i < items; i++)
                {
                    RemoveFirstItem();
                }
            }
            else
            {
                Node current = GetNodeByIndex(Length - items);

                current = _root;

                Length -= items;
            }
        }

        // Удаления по индексу N элементов.
        public void RemoveByIndexElements(int index, int items)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            if (Length - index < items)
            {
                throw new IndexOutOfRangeException("Длина множества после индекса меньше количества удаляемых элементов.");
            }

            if (items < 0)
            {
                throw new ArgumentException("Не существует отрицательное количество элементов.");
            }

            if ((index == 0) && (items == 1))
            {
                RemoveFirstItem();
            }
            else if ((items != 0) && (items == 1) && (index == Length - 1))
            {
                RemoveLastItem();
            }
            else if ((index + items) == Length)
            {
                RemoveSomeItemsAtLast(items);
            }
            else if ((items != 0) && (index != Length - 1))
            
            {
                Node tmpNext = _root;

                for (int i = 0; i < index + items; i++)
                {
                    tmpNext = tmpNext.Next;
                }

                Node current = GetNodeByIndex(index);
                current.Next = tmpNext;

                Length -= items;
            }


        }

        // Доступ по индексу. 
        public int GetByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            Node current = GetNodeByIndex(index + 1);

            return current.Value;
        }

        // Первый индекс по значению.
        public int GetIndexByItem(int value)
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

        // Изменение по индексу.
        public void ChangeItemByIndex(int index, int value)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            Node current = GetNodeByIndex(index + 1);

            current.Value = value;
        }

        // Реверс
        public void ReverseItems()
        {
            Node current = _root.Next;
            Node tmp = null;
            _tail = _root;

            while (!(_root.Next is null))
            {
                _root.Next = tmp;
                tmp = _root;
                _root = current;
                current = current.Next;
            }

            _root.Next = tmp;
        }

        // Поиск значения максимального элемента.
        public int FindMaximumNumber()
        {
            if (Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            Node node = new Node(0);

            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                if(node.Value < current.Value)
                {
                    node.Value = current.Value;
                    
                }

                current = current.Next;
            }

            return node.Value;
        }

        // Поиск значения минимального элемента.
        public int FindMinimumNumber()
        {
            if (Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            Node node = new Node(0);

            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (node.Value > current.Value)
                {
                    node.Value = current.Value;
                }

                current = current.Next;

            }

            return node.Value;
        }

        // Поиск индекс максимального элемента.
        public int FindIndexOfMaximumNumber()
        {
            if (Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            Node node = new Node(0);
            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                if(node.Value <= current.Value)
                {
                    node.Value = current.Value;
                }

                current = current.Next;
            }

            Node currentVal = _root;
            int index = 0;

            for (int i = 0; i < Length; i++)
            {
                if (currentVal.Value == node.Value)
                {
                    index = i;
                    break;
                }

                currentVal = currentVal.Next;
            }

            return index;
        }

        // Поиск индекс минимального элемента.
        public int FindIndexOfMinimumNumber()
        {
            if (Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            Node node = new Node(0);
            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (node.Value >= current.Value)
                {
                    node.Value = current.Value;
                }

                current = current.Next;
            }

            Node currentVal = _root;
            int index = 0;

            for (int i = 0; i < Length; i++)
            {
                if (currentVal.Value == node.Value)
                {
                    index = i;
                    break;
                }

                currentVal = currentVal.Next;
            }

            return index;
        }

        // Сортировка по возрастанию.
        //public void InsertSortNumberUp()
        //{
        //    Node current = _root;
        //    int tmp = 0;

        //    //for (int i = 1; i < Length; i++)
        //    //{
        //    //    if (current.Value > current.Next.Value)
        //    //    {
        //    //        tmp = current.Value;
        //    //        current.Value = current.Next.Value;
        //    //        current.Next.Value = tmp;



        //    //    }

        //    //    current = current.Next;
        //    //}

        //    //while(!(current is null))
        //    //{
        //    //    if(current.Next.Value)



        //    //}




        //}

        // Удаление по значению первого. (Вернуть индекс)
        public int RemoveFirstByValueAndGetIndex(int value)
        {
            int index = GetIndexByItem(value);

            if(index == 0)
            {
                RemoveFirstItem();
            }
            else if(index != -1)
            {
                RemoveByIndex(index);
            }

            return index;
        }

        // Удаление по значению всех.(Вернуть кол-во)
        public int RemoveAllByValue(int value)
        {
            Node current = _root;
            int count = 0;

            for(int i = 0; current.Next != null; i++)
            {
                if(current.Value == value)
                {
                    RemoveByIndex(i - count);
                    count++;
                }

                current = current.Next;
            }

            if (_tail.Value == value)
            {
                RemoveLastItem();
                count++;
            }

            return count;
        }

        // Добавление списка(вашего самодельного) в конец.
        public void AddListAtLast(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Add(arr[i]);
            }
        }

        // Добавление списка в начало.
        public void AddListAtFront(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                AddNumberAtFront(arr[i]);
            }
        }

        // Добавление списка по индексу.
        public void AddListByIndex(int index, int[] arr)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            int count = 0;

            Node current = _root;

            if(Length !=0)
            {
                while (count == index)
                {
                    current = current.Next;
                    count++;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    AddNumberByIndex(index, arr[i]);
                    index++;
                }
            }
            else
            {
                AddListAtFront(arr);
            }
        }


        public override string ToString()
        {
            // возращаем пустую строку

            if(Length != 0)
            {
                Node current = _root;

                string s = current.Value + " ";

                // смотрит на следущшийц желемент
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
            //LinkedList list = (LinkedList)obj;

            //if(this.Length != list.Length)
            //{
            //    return false;
            //}

            //Node currentThis = this._root;
            //Node currentList = list._root;
            //// byltrc out of range первое или последнее. 

            //if(this.Length == 0 && list.Length == 0)
            //{
            //    return true;
            //}

            //while (!(currentThis.Next is null))
            //{
            //    if (currentThis.Value != currentList.Value)
            //    {
            //        return false;
            //    }
            //    currentList = currentList.Next;
            //    currentThis = currentThis.Next;
            //}

            //if (currentList.Value != currentThis.Value)
            //{
            //    return false;
            //}

            //return true;


            LinkedList list = (LinkedList)obj;

            
            if (this.Length != list.Length)
            {
                return false;
            }

            if (this.Length == 0)
            {
                return true;
            }

            if (this._tail.Value != list._tail.Value)
            {
                return false;
            }

            if (!(this._tail.Next is null) || !(list._tail.Next is null))
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }

            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            return true;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private Node GetNodeByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            Node current = _root;

            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }
    }
}
