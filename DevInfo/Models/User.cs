using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInfo.Models
{
    public class User
    {
    public User()
        {
        }
    public User(string name, string lastName, int nvrCount)
        {
            Name = name;
            LastName = lastName;
            NvrCount = nvrCount = 0;

        }



        public string Name { get; set; }
        public string LastName { get; set; }
        public int NvrCount { get; set; }
    }


}
