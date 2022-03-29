using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesClassNamespace
{
    public class MoviesClass
    {
        string _name = "";
        DateTime _year = DateTime.Now;
        string _description = "";
        MovieCategory _movieCategory = MovieCategory.Drama;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }

    public enum MovieCategory
    {
        Drama,
        Comedy,
        Action,
        Horror
    }
}
