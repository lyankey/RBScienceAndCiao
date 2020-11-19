using ScienceAndCiao.Data;
using ScienceAndCiao.Models;
using ScienceAndCiao.Models.Kit;
using ScienceAndCiaoWebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Services
{
    public class KitService
    {
        private readonly Guid _userId;

        public KitService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateKit(KitCreate model)
        {
            var entity =
                new Kit()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Ingredients = model.Ingredients,
                    LengthMinutes = model.LengthMinutes,
                    Price = model.Price,
                    Description = model.Description,
                    DateAdded = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Kits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<KitListItem> GetKits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Kits
                        .Where(e => e.Id == Id)
                        .Select(
                            e =>
                                new KitListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    DateAdded = e.DateAdded
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateKit(KitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Kits
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Ingredients = model.Ingredients;
                entity.Description = model.Description;
                entity.DateAdded = DateTime.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteKit(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Kits
                        .Single(e => e.Id == Id);

                ctx.Kits.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
