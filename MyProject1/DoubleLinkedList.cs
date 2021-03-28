using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class DoubleLinkedList
    {
        private DoubleLNode _root;
        private DoubleLNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException("Индекс вне множества.");
                }

                DoubleLNode current = GetNodeByIndex(index);

                return current.Value;
            }

            set
            {
                DoubleLNode current = GetNodeByIndex(index);

                current.Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleLNode(value);
            _tail = _root;
        }

        public DoubleLinkedList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("На данное множество нет ссылки.");
            }

            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleLNode(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DoubleLNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
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
            DoubleLNode node = new DoubleLNode(value);

            if (Length == 0)
            {
                _root = node;
                _tail = _root;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }

            Length++;
        }

        // Добавление значения в начало.
        public void AddNumberAtFront(int value)
        {
            Length++;

            DoubleLNode node = new DoubleLNode(value);

            node.Next = _root;
            _root = node;
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

                DoubleLNode current = GetNodeByIndex(index);

                DoubleLNode node = new DoubleLNode(value);

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
            if(_root == _tail)
            {
                Length = 0;
                _root = null;
                _tail = null;
                
            }
            else
            {
                DoubleLNode tmp = null;
                tmp = _tail.Previous;
                _tail = tmp;
                tmp.Next = null;
                Length--;
            }
        }



        public override string ToString()
        {
            // возращаем пустую строку

            if (Length != 0)
            {
                DoubleLNode current = _root;

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
            DoubleLinkedList list = (DoubleLinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            DoubleLNode currentThis = this._root;
            DoubleLNode currentList = list._root;
            // byltrc out of range первое или последнее. 

            if (this.Length == 0 && list.Length == 0)
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

        private DoubleLNode GetNodeByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            DoubleLNode root = _root;
            DoubleLNode tail = _tail;

            if (index <= Length / 2)
            {
                for (int i = 1; i < index; i++)
                {
                    root = root.Next;
                }

                return root;
            }
            else
            {
                for (int i = Length - 1 ; i <= index; i++)
                {
                    tail = tail.Previous;
                }

                return tail;
            }

        }
    }
}
