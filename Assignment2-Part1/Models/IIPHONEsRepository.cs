
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Part1.Models
{
    public interface IIPHONEsRepository
    {
       
        
            // used for Unit Testing with Mock Store Manager IPHONE data
            IQueryable<IPHONE> iPHONEs { get; }
           
            IPHONE Save(IPHONE iPHONE );
            void Delete(IPHONE iPHONE);
        
    }
}

