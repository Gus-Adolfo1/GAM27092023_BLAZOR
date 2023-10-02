using GAM27092023_BLAZOR.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlTypes;

namespace GAM27092023_BLAZOR.Models.DAL
{
    public class MemberDAL
    {

        readonly dbContext _dbContext;

        //contructor
        public MemberDAL(dbContext context)
        {
            _dbContext = context;
        }

        public async Task<int> Create(memberGAM member)
        {
            _dbContext.Add(member);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<memberGAM> GetById(int id)
        {
            var member = await _dbContext.MembersGAM.FirstOrDefaultAsync(s => s.id == id);
            return member != null ? member : new memberGAM();
        }

        public async Task<int> Edit(memberGAM member)
        {
            int result = 0;
            var memberUpdate = await GetById(member.id);
            if (memberUpdate.id != 0)
            {
                //update

                memberUpdate.name = member.name;
                memberUpdate.lastname = member.lastname;
                memberUpdate.age = member.age;
                memberUpdate.height = member.height;
                memberUpdate.dob = member.dob;
                return await _dbContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var memberDelete = await GetById(id);
            if (memberDelete.id != 0)
            {
                //Delete
                _dbContext.Remove(memberDelete);
                return await _dbContext.SaveChangesAsync();
            }
            return result;
        }
        // method to create a query to look up by filters
        private IQueryable<memberGAM> Query(memberGAM member)
        {
            var query = _dbContext.MembersGAM.AsQueryable();
            if (!string.IsNullOrWhiteSpace(member.name))
                query = query.Where(s => s.name.Contains(member.name));
            if (!string.IsNullOrWhiteSpace(member.lastname))
                query = query.Where(s => s.lastname.Contains(member.lastname));
            return query;
        }
        public async Task<int> CountSearch(memberGAM member)
        {
            return await Query(member).CountAsync();
        }
        public async Task<List<memberGAM>> Search(memberGAM member, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(member);
            query = query.OrderByDescending(s => s.id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
