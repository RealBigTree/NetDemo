using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1 {
    public class S2 : IF {
        public string _Name { get; set; }
        public void ShowName() {
            //base.ShowName();
            Console.WriteLine("S2-------------------------");
        }
    }
}
