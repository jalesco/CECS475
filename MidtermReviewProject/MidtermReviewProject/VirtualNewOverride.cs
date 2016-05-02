using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermReviewProject
{
    public class VirtualNewOverride
    {
        public virtual void show() {
            Console.WriteLine("Hello! I am the base class!");
            //Console.Read();
        }//end method

    } //end parent class

    public class Virtual : VirtualNewOverride {

        //Override is used with the virtual method. Override is used to 
        public override void show()
        {
            Console.WriteLine("Hello! I am Virtual!");
            //Console.Read();
        }

    }//end class


    public class New : VirtualNewOverride {
        public new void show() {
            Console.WriteLine("Hello! I am New!");
            //Console.Read();
        }


    }




}//end namespace
