using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// added references
using System.Web;
using System.Data.Entity;


namespace Assignment2_Part1.Models
{
    public class EFIPHONEsRepository : IIPHONEsRepository
    {
        // db connection
        AppleModel db = new AppleModel();

        public IQueryable<IPHONE> iPHONEs { get { return db.IPHONEs; } }
       
        public void Delete(IPHONE iPHONE)
        {
            db.IPHONEs.Remove(iPHONE);
            db.SaveChanges();
        }

        public IPHONE Save(IPHONE iPHONE)
        {
            if (iPHONE.PRODUCT_ID == 0)
            {
                db.IPHONEs.Add(iPHONE);
            }
            else
            {
                db.Entry(iPHONE).State = EntityState.Modified;
            }
            db.SaveChanges();

            return iPHONE;
        }
    }
}