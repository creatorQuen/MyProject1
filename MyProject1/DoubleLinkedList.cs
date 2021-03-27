using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject1
{
    public class DoubleLinkedList
    {
        private DoLiNode _root;
        private DoLiNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException("Индекс вне множества.");
                }

                DoLiNode current = GetNodeByIndex(index);

                return current.Value;
            }

            set
            {
                DoLiNode current = GetNodeByIndex(index);

                current.Value = value;
            }
        }


        public override string ToString()
        {
            // возращаем пустую строку

            if (Length != 0)
            {
                DoLiNode current = _root;

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

            DoLiNode currentThis = this._root;
            DoLiNode currentList = list._root;
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

        private DoLiNode GetNodeByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            DoLiNode root = _root;
            DoLiNode tail = _tail;

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
