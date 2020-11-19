using ScienceAndCiao.Data;
using ScienceAndCiao.Models.Member;
using ScienceAndCiaoWebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Services
{
    public class MemberService
    {
        //CREATE /members
        public bool CreateMember(MemberCreate model)
        {
            var newMember = new Member()
            {
                Id = model.Id,
                CreatedAt = DateTimeOffset.Now
            };
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Members.Add(newMember);
                    return ctx.SaveChanges() == 1;
                }
            }
        }

        // GET /members
        public IEnumerable<MemberListItem> GetAllMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Members
                    .Select(m => new MemberListItem
                    {
                        Id = m.Id,
                        Member = m.Name,
                        CreatedAt = m.CreatedAt
                    }
                    ).ToList();
            }
        }



        public MemberListItem GetMemberById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    return ctx.Members
                        .Where(r => r.Id == id)
                        .Select(r => new MemberListItem()
                        {
                            Id = r.Id,
                            Member = r.Name,
                            CreatedAt = r.CreatedAt
                        })
                        .FirstOrDefault();
                }
            }
        
    }
}

