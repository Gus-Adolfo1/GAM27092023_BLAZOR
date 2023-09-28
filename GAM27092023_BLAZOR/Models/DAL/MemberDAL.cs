using GAM27092023_BLAZOR.EN;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace GAM27092023_BLAZOR.Models.DAL
{
    public class MemberDAL
    {

        readonly dbContext _dbContext;

        //contructor
        public MemberDAL(dbContext memberDAL)
        {
            _dbContext = memberDAL;
        }

        public async Task<int> Create(memberGAM member)
        {
            _dbContext.Add(member);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<memberGAM> GetById(int id)
        {
            var member = await _dbContext.MembersGAM.FirstOrDefaultAsync(s => s.Id == id);
            return member != null ? member : new memberGAM();
        }

        public async Task<int> Edit(memberGAM member)
        {
            int result = 0;
            var memberUpdate = await GetById(member.Id);
            if (memberUpdate.Id != 0)
            {
                //update
                memberUpdate.name = member.name;
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
            if (memberDelete.Id != 0)
            {
                //Delete
                _dbContext.Remove(memberDelete);
                return await _dbContext.SaveChangesAsync();
            }
            return result;
        }
        // method to create a query to look up by filters
        private IQueryable<memberGAM> Search (memberGAM member)
        {
            var query = _dbContext.MembersGAM.AsQueryable();
            if (!string.IsNullOrWhiteSpace(member.name))
                query = query.Where(s => s.name.Contains(member.name));

            return query;
        }
    }
}
