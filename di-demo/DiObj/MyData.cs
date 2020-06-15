using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc1
{
    public interface IMyData
    {
        int Counter { get; }
        string Name { get; set; }
    }

        public class MyData : IMyData
        {
        private int _counter = 1;
            public int Counter { get {
                return _counter++;
            } 
        }
        
            public string Name { get; set; } = "Bruce";
        }
}
