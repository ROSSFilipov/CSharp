using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperserProject
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        private List<string> parameters;

        public StringDisperser(params String[] parameters)
        {
            this.parameters = new List<string>();

            foreach (string currentParameter in parameters)
            {
                this.Parameters.Add(currentParameter);
            }
        }

        public List<string> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser otherDisperser = obj as StringDisperser;
            return string.Join("", this.Parameters).Length.Equals(string.Join("", otherDisperser).Length);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(", ", this.Parameters);
        }

        public object Clone()
        {
            StringDisperser clonedDisperser = new StringDisperser();

            clonedDisperser.Parameters.AddRange(this.Parameters);

            return clonedDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            return string.Join("", this.Parameters).CompareTo(string.Join("", other));
        }

        public static bool operator ==(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return firstDisperser.Equals(secondDisperser);
        }

        public static bool operator !=(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return !firstDisperser.Equals(secondDisperser);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public IEnumerator<char> GetEnumerator()
        {
            foreach (string currentParameter in this.Parameters)
            {
                for (int i = 0; i < currentParameter.Length; i++)
                {
                    yield return currentParameter[i];
                }
            }
        }
    }
}
