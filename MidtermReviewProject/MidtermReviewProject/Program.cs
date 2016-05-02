using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermReviewProject
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             These are to test the differences between virtual/override combo and "new"
             */

            /* You can instantiate the parent as a child object. A child object can't be instantiated with the parent class.
               Basically, every Virtual and New object is a VitualNewOverride object, not every VirutalNewOverride object is a 
               Virtual or New
             * 
             * "new" will execute the base class's method. "new" hides base class through derived class
            */

            VirtualNewOverride vno = new Virtual();
            VirtualNewOverride vno2 = new New();

            VirtualNewOverride vno3 = new VirtualNewOverride();

            New n = new New();
            Virtual v = new Virtual();


            vno.show();  //should output Virtual's show method
            vno2.show(); //should output parent's show method 
            vno3.show(); //should show parent show()

            n.show(); //will show New show()
            v.show(); //will show Virtual show()



            Console.Read();

        }//end main
    }//end class
}//end namespace
