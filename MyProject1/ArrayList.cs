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
                if ((index > _array.Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException("Индекс вне множества");
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
            if (Length == _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;
            Length++;
        }

        public void AddNumberAtFront(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            for (int i = _array.Length - 1; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[0] = value;

            Length++;

        }

        // Добавление значения по индексу.
        public void AddNumberByIndex(int index, int value)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            int oldLenght = Length;
            Length++;

            for (int i = oldLenght -1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = value;
        }

        // Удаление из конца одного элемента.
        public void RemoveLastItem()
        {
            Length--;

            if (Length < (_array.Length / 2))
            {
                DownSize();
            }
        }

        // Удаление из начала одного элемента.
        public void RemoveFirstItem()
        {
            if (Length != 0)
            {
                for (int i = 0; i < _array.Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }

                Length--;

                if (Length < (_array.Length / 2))
                {
                    DownSize();
                }
            }
        }

        // Удаление по индексу одного элемента.
        public void RemoveItemByIndex(int index)
        {
            if (Length != 0)
            {
                if (index > Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Индекс вне множества.");
                }

                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }

                Length--;

                if (Length <= (_array.Length / 2))
                {
                    DownSize();
                }
            }
            else
            {
                if (index > Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Индекс вне множества.");
                }
            }
        }

        // Удаление из конца N элементов.
        public void RemoveSomeItemsAtLast(int items)
        {
            if (items > Length)
            {
                throw new ArgumentOutOfRangeException("Множество меньше количества удаляемых элементов.");
            }

            if (items < 0)
            {
                throw new ArgumentException("Не существует отрицательное количество элементов.");
            }

            Length -= items;

            if (Length < (_array.Length / 2))
            {
                DownSize();
            }
        }

        // Удаление из начала N элементов.
        public void RemoveSomeItemsAtFront(int items)
        {
            if (items > Length)
            {
                throw new ArgumentOutOfRangeException("Множество меньше количества удаляемых элементов.");
            }

            if (items < 0)
            {
                throw new ArgumentException("Не существует отрицательное количество элементов.");
            }

            if (Length != 0)
            {

                for (int i = 0; i < Length - items; i++)
                {
                    _array[i] = _array[i + items];
                }

                Length -= items;

                if (Length < (_array.Length / 2))
                {
                    DownSize();
                }
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

            for (int i = index; i < Length - items; i++)
            {
                _array[i] = _array[i + items];
            }

            Length -= items;

            if (Length <= (_array.Length / 2))
            {
                DownSize();
            }
        }

        // Вернуть длину.
        public int GetByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            return _array[index];
        }

        // Первый индекс по значению.
        public int GetIndexByItem(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if(value == _array[i])
                {
                    return i;
                }
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

            _array[index] = value;
        }

        // Реверс(123 -> 321)
        public void ReverseItems()
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множество.");
            }
            // Вопрос про длинну.
            int[] arrayTmp = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                arrayTmp[i] = _array[i];
            }

            for (int i = 0; i < (arrayTmp.Length / 2); i++)
            {
                int index = arrayTmp.Length - i - 1;
                int tmp = arrayTmp[i];

                arrayTmp[i] = arrayTmp[index];
                arrayTmp[index] = tmp;
            }

            _array = arrayTmp;
        }

        // Поиск значения максимального элемента.
        public int FindMaximumNumber()
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            int maximum = _array[0];

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > maximum)
                {
                    maximum = _array[i];
                }
            }

            return maximum;
        }

        // Поиск значения минимального элемента.
        public int FindMinimumNumber()
        {

            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            int minimum = _array[0];

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < minimum)
                {
                    minimum = _array[i];
                }
            }

            return minimum;
        }

        // Поиск индекс максимального элемента.
        public int FindIndexOfMaximumNumber()
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            int numberIndex = 0;

            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] > _array[numberIndex])
                {
                    numberIndex = i;
                }
            }

            return numberIndex;
        }

        // Поиск индекс минимального элемента.
        public int FindIndexOfMinimumNumber()
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            int numberIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < _array[numberIndex])
                {
                    numberIndex = i;
                }
            }

            return numberIndex;
        }

        // Сортировка по возрастанию.
        public void BubleSortNumberUp()
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            for (int j = Length - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (_array[i] > _array[i + 1])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[i + 1];
                        _array[i + 1] = tmp;
                    }
                }
            }
        }

        // Сортировка по убыванию.
        public void BubleSortNumberDown()
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            for (int j = 0; j < Length; j++)
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    if (_array[i] < _array[i + 1])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[i + 1];
                        _array[i + 1] = tmp;
                    }
                }
            }
        }

        // Удаление по значению первого. (Вернуть индекс)
        public int RemoveFirstByValueAndGetIndex(int value)
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            int result = -1;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    result = i;
                    break;
                }
            }

            if (result != -1)
            {
                for (int i = result; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }

                Length--;
            }

            
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }

            return result;
        }

        // Удаление по значению всех.(Вернуть кол-во)
        public int RemoveAllByValue(int value)
        {
            if (_array.Length == 0)
            {
                throw new ArgumentException("Пустое множества.");
            }

            int result = -1;
            int count = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    result = i;
                    for (int j = result; j < Length - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    count++;
                }
            }

            Length -= count;

            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }

            if (count == 0)
            {
                count = result;
            }

            return count;
        }

        // Добавление списка(вашего самодельного) в конец.
        public void AddArrayAtLast(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Add(arr[i]);
            }
        }

        // Добавление списка в начало.
        public void AddArrayAtFront(int[] arr)
        {
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                AddNumberAtFront(arr[i]);
            }
        }

        // Добавление списка по индексу.
        public void AddArrayByIndex(int index, int[] arr)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            int oldLenght = Length;
            Length += arr.Length;

            UpSize(arr); // перегрузка

            for(int i = oldLenght; i >= index; i--)
            {
                _array[i + arr.Length] = _array[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                _array[i + index] = arr[i];
            }
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

        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
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

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;

        }

        private void UpSize(int[] arr)
        {
            int newLenght = (int)(_array.Length * 1.33d + 1 + arr.Length);

            int[] tmpArray = new int[newLenght];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void DownSize()
        {

            int newLenght = (int)(_array.Length + 0.67d + 1);

            int[] tmpArray = new int[newLenght];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }
}
