using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class LinkedList
    {
        public int Length { get; private set; }

        public int this[int index]
        {
            
            get
            {

                //private Node GetNodeByIndex(int index)
                //{
                //    Node current = _root;
                //    for (int i = 1; i < index; i++)
                //    {
                //        current = current.Next;
                //    }
                //    return current;
                //}


                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException("Индекс вне множества.");
                }


                // exception indexoutofrange
                // переменная которая будет шагать по списку.
                Node current = _root;
                // нулевой элемен туже внутри current

                for(int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }

            set
            {
                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        private Node _root;
        private Node _tail;

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

            if(values.Length != 0)
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
            Length++;

            Node node = new Node(value);

            node.Next = _root;
            _root = node;
        }

        // Добавление значения по индексу.
        public void AddNumberByIndex(int index, int value)
        {
            if(index < 0)
            {
                throw new IndexOutOfRangeException("Не существует отрицательного индекса");
            }

            if (index == 0)
            {
                AddNumberAtFront(value);
            }
            else if (index != Length)
            {
                Length++;

                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

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
            Node current  = _root;

            while (!(current.Next is null))
            {
                current = current.Next;
            }

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

        // Деление по индексу одного элемента
        public void RemoveByIndex(int index)
        {
            Node current = _root;

            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;

            Length--;
        }

        // Удаление из конца N элементов.
        public void RemoveSomeItemsAtLast(int items)
        {
            if (Length > 1)
            {
                Node current = _root;

                for (int i = 0; i < Length - items; i++)
                {
                    current = current.Next;
                }

                current = _tail;
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
                Node current = _root;

                for (int i = 0; i < Length - items; i++)
                {
                    current = current.Next;
                }

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


            if(items != 0)
            {
                Node tmpNext = _root;

                for (int i = 0; i < index + items; i++)
                {
                    tmpNext = tmpNext.Next;
                }

                Node currtent = _root;

                for (int i = 0; i < index - 1; i++)
                {
                    currtent = currtent.Next;
                }

                currtent.Next = tmpNext;

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

            Node current = _root;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

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

            Node current = _root;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }



        // Реверс
        public void ReverseItems()
        {
            Node current = _root;

            Node tmp = null;

            if(!(current is null))
            {

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
            LinkedList list = (LinkedList)obj;

            if(this.Length != list.Length)
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;
            // byltrc out of range первое или последнее. 
            
            if(this.Length == 0 && list.Length == 0)
            {
                return true;
            }


            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }

            //do
            //{
            //    if (currentThis.Value != currentList.Value)
            //    {
            //        return false;
            //    }


            //    currentList = currentList.Next;
            //    currentThis = currentThis.Next;
            //}
            //while (!(currentThis.Next is null));



            if (currentList.Value != currentThis.Value)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
