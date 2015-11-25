using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    [VersionAttribute(9, 11)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int CAPACITY = 16;

        private T[] list = new T[CAPACITY];

        private int index = 0;

        public void Add(T element)
        {
            if (this.index >= this.list.Length)
            {
                ReSize();
            }

            this.list[this.index] = element;
            this.index++;
        }

        private void ReSize()
        {
            T[] newList = new T[this.list.Length * 2];

            for (int i = 0; i < this.list.Length; i++)
            {
                newList[i] = this.list[i];
            }

            this.list = newList;
        }

        public T ElementAt(int index)
        {
            return this.list[index];
        }

        public void Clear()
        {
            //for (int i = 0; i < this.list.Length; i++)
            //{
            //    this.list[i] = default(T);
            //    this.index = 0;
            //}

            this.list = new T[index];
            index = 0;
        }

        public int IndexOfElement(T element)
        {
            int index = -1;
            for (int i = 0; i < this.list.Length; i++)
            {
                if (this.list[i].CompareTo(element) == 0)
                {
                    index = i;
                }
            }

            return index;
        }

        public bool Contains(T element)
        {
            //bool isFound = false;

            //if (this.IndexOfElement(element) != -1)
            //{
            //    isFound = true;
            //}

            //return isFound;

            return this.list.Any(x => x.CompareTo(element) == 0);
        }

        public int Length
        {
            get
            {
                return this.index;
            }
        }

        public int Capacity
        {
            get
            {
                return this.list.Length;
            }
        }

        public void Remove(int index)
        {
            T[] newList = new T[this.list.Length];

            if (index >= this.list.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < this.list.Length - 1; i++)
            {
                if (i < index)
                {
                    newList[i] = this.list[i];
                }
                else
                {
                    newList[i] = this.list[i + 1];
                }
            }

            this.index--;
            this.list = newList;
        }

        public void InsertAt(int index, T element)
        {
            T[] newList = new T[this.list.Length + 1];

            if (index >= this.list.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < this.list.Length; i++)
            {
                if (i < index)
                {
                    newList[i] = this.list[i];
                }
                else if (i == index)
                {
                    newList[i] = element;
                }
                else
                {
                    newList[i] = this.list[i - 1];
                }
            }

            this.index++;
            this.list = newList;
        }

        public static GenericList<T> operator +(GenericList<T> listOne, GenericList<T> listTwo)
        {
            GenericList<T> newList = new GenericList<T>();

            for (int i = 0; i < listOne.Length; i++)
            {
                newList.Add(listOne.ElementAt(i));
            }

            for (int i = 0; i < listTwo.Length; i++)
            {
                newList.Add(listTwo.ElementAt(i));
            }

            return newList;
        }

        public T Min()
        {
            T minValue = this.list.ElementAt(0); ;

            for (int i = 0; i < this.index; i++)
            {
                if (minValue.CompareTo(this.list[i]) == 1)
                {
                    minValue = this.list[i];
                }
            }

            return minValue;
        }

        public T Max()
        {
            T minValue = this.list.ElementAt(0);

            for (int i = 0; i < this.index; i++)
            {
                if (minValue.CompareTo(this.list[i]) == -1)
                {
                    minValue = this.list[i];
                }
            }

            return minValue;
        }

        public override string ToString()
        {
            Type type = typeof(GenericList<T>);
            object[] allAttributes = type.GetCustomAttributes(false);
            return string.Format("Generic List: {0}{2}Version: {1}", 
                string.Join(", ", this.list.Take(this.index)), string.Join(", ", allAttributes), Environment.NewLine);
        }
    }
}
