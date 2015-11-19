using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    public class ElementBuilder
    {
        private string elementName;

        private string result;

        private List<string> attributes;

        private List<string> contents;

        public ElementBuilder(string element)
        {
            this.elementName = element;
            this.result = element;
            this.attributes = new List<string>();
            this.contents = new List<string>();
        }

        public void AddAttribute(string currentAttribute, string value)
        {
            this.attributes.Add(string.Format("{0}=\"{1}\"", currentAttribute, value));
        }

        public void AddContent(string currentContent)
        {
            this.contents.Add(currentContent);
        }

        private string ElementName
        {
            get
            {
                return this.elementName;
            }
            set
            {
                this.elementName = value;
            }
        }

        public static string operator *(ElementBuilder currentBuilder, int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(currentBuilder);
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<" + this.elementName + " ");
            sb.Append(string.Join(" ", this.attributes));
            sb.Append(">");
            sb.Append(string.Join(" ", this.contents));
            sb.Append("</" + this.elementName + ">");

            return sb.ToString();
        }
    }
}
