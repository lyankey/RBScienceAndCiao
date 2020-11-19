using ScienceAndCiao.Data;
using ScienceAndCiao.Models.Rental;
using ScienceAndCiaoWebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Services
{
    public class NewRentalsService
    {
        public CreateNewRental(RentalCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var member = ctx.Members.Single(
                 c => c.Id == model.MemberId);

                var kits = ctx.Kits.Where(
                    m => model.KitId.Equals(m.Id)).ToList();

                foreach (var kit in kits)
                {


                    var rental = new Rental
                    {
                        Member = member,
                        Kit = kit,
                        StartDate = DateTime.Now
                    };

                    ctx.Rentals.Add(rental);
                    return ctx.SaveChanges() == 1;
                }

            }
        }
        public bool CreateRental(RentalCreate model)  // this will create an instance of Note.
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Members.Single(
                 c => c.Id == model.MemberId);

                var kits = ctx.Kits.Where(
                 m => model.KitId.Equals(m.Id)).ToList();

                foreach (var kit in kits)
                {
                    var rental = new Rental()
                    {
                        MemberId = memberId,
                        Kit = kit,
                        StartDate = DateTime.Now
                    };
                }

                {
                    ctx.Rentals.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

}
