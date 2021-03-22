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
                throw new NullReferenceException();
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
                _tail = null;
            }




        }


        public void Add(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        public void RemoveFirst()
        {
            _root = _root.Next;
        }

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


        public  override string ToString()
        {
            // возращаем пустую строку

            if(Length != 0)
            {
                Node current = _root;

                string s = current.Value + "";

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
            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }

                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            while (!(currentThis.Next is null));

            return true;
        }


    }
}
