using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosses
{
    struct Square
    {
        public string Type ;
        public int Number ;
        public string DrawSquare ;
        public void ChangeDrawSquare() 
        {
            if (Type == "X")
            {
                DrawSquare = " [   X    ] ";
            }
            else
            {
                if (Type == "O")
                {
                    DrawSquare = " [   O    ] ";
                }
                else
                {
                    DrawSquare = " [   "+Number+"    ] ";

                }
            }
         
        }
        
      
        
      
    }

    
}
