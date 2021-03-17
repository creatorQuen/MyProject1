using System;

namespace MyProject1
{
    public class ArrayList
    {
        // Длинна массива с точки зрения клиента.
        public int Length { get; private set; }
        // Реальный массив.
        private int[] _array;
        private int _realLengthArr = 0;

        public int this[int index]
        {
            get
            {
                // OutOfrangeIndexExcpeption
                if((index > _array.Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException("Индекс не существует.");
                }

                return _array[index];
            }

            set
            {
                _array[index] = value; 
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

        public ArrayList(int[] value)
        {
            Length = value.Length;
            _array = value;

            UpSize();
        }

        // Добавление значения в конец.
        public void Add(int value)
        {
            if(Length == _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;
            Length++;
        }

        // Добавление значения в начало.
        public void AddNumberAtFront(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            

            int[] tmpArr = new int[_array.Length];
            for(int i = 0; i < _array.Length; i++)
            {
                tmpArr[i] = _array[i];
            }


            for (int i = 1; i < _array.Length; i++)
            {
                _array[i] = tmpArr[i - 1];
            }

            _array[0] = value;

            Length++;

        }

        // Добавление значения по индексу.
         public void AddNumberByIndex(int index, int value)
         {
            if (Length == _array.Length)
            {
                UpSize();
            }

            int[] tmpArr = new int[_array.Length];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArr[i] = _array[i];
            }

            _array[index] = value;

            for (int i = index + 1; i < _array.Length; i++)
            {
                _array[i] = tmpArr[i - 1];
            }

            Length++;
         }

        // Удаление из конца одного элемента.
        public void DeleteLastItem(int value)
        {
            if (Length < (_array.Length / 2))
            {
                DownSize();
            }


        }

        public int[] ToArray()
        {
            int[] tmpArr = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                tmpArr[i] = _array[i];
            }

            return tmpArr;
        }





        public override bool Equals(object obj)
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

        //public override bool Equals(object obj)
        //{
        //    int[] arrayList = (int[])obj;

        //    if(this.Length != arrayList.Length)
        //    {
        //        return false;
        //    }

        //    for(int i =0; i < Length; i++)
        //    {
        //        if(this._array[i] != arrayList[i])
        //        {
        //            return false;
        //        }
        //    }


        //    return true;
        //}


        //public override string ToString()
        //{
        //    string s = "";

        //    for(int i =0; i < Length; i++)
        //    {
        //        s += _array[i] + " ";
        //    }

        //    return s;
        //}


        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Length; i++)
            {
                if (i < (Length -1))
                {
                    s += " " + _array[i] + ",";
                }
                else
                {
                    s += " " + _array[i] + " ";
                }
            }

            return s;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void UpSize()
        {
            int newLenght = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLenght];

            for(int i=0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;

        }

        private void DownSize()
        {
            
            int newLenght = (int)(_array.Length - (_array.Length * 0.33d));

            int[] tmpArray = new int[newLenght];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
        
    }
}
