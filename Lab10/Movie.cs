using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Movie
    {

        public Movie(string Title, string Category)
        {
            this.Title = Title;
            this.Category = Category;
        }

        private string title;
        private string category;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

    }
}
