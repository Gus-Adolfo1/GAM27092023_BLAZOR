using GAM27092023_BLAZOR.EN;
using GAM27092023_BLAZOR.Models.DAL;
using member.DTOs.memberDTOs;
using System;

namespace GAM27092023_BLAZOR.EndPoints
{
    public static class MemberEndPoint
    {
        public static void AddMemberEndPoint(this WebApplication app)
        {
            app.MapPost("/member/search", async(searchQueryDTO memberDTOs, MemberDAL MemberDAL) =>
            {
                var mem = new memberGAM
                {
                    name = memberDTOs.nameLike!= null ? memberDTOs.nameLike : string.Empty,
                    lastname = memberDTOs.lastnameLike != null ? memberDTOs.lastnameLike : string.Empty
                };

                var member = new List<memberGAM>();
                int countRow = 0;

                if (memberDTOs.SendRowCount == 2)
                {
                    member = await MemberDAL.Search(mem, skip: memberDTOs.Skip, take: memberDTOs.Take);
                    if (member.Count > 0)
                        countRow = await MemberDAL.CountSearch(mem);
                }
                else
                {
                    member = await MemberDAL.Search(mem, skip: memberDTOs.Skip, take: memberDTOs.Take);
                }

                var memberResults = new searchOutputDTO
                {
                    Data = new List<searchOutputDTO.memberDTOs>(),
                    CountRow = countRow
                };

                member.ForEach(s =>
                {
                    memberResults.Data.Add(new searchOutputDTO.memberDTOs
                    {
                        id = s.id,
                        name = s.name,
                        lastname = s.lastname,
                        age = s.age,
                        height = s.height,
                        dob = s.dob
                    });
                });
                return memberResults;
            });

            app.MapGet("/member/{id}", async (int id, MemberDAL memDAL) =>
            {
                var member = await memDAL.GetById(id);

                var personResult = new searchOutputDTO.memberDTOs
                {
                     id = member.id,
                    name = member.name,
                    lastname = member.lastname,
                    age = member.age,
                    height = member.height,
                    dob = member.dob
                };

                if (personResult.id > 0)
                    return Results.Ok(personResult);
                else
                    return Results.NotFound(member);
            });

            app.MapPost("/member", async (createMemberDTO memDTO, MemberDAL memDAL) =>
            {


                var member = new memberGAM
                {
                    name = memDTO.name,
                    lastname = memDTO.lastname,
                    age = memDTO.age,
                    height = memDTO.height,
                    dob = memDTO.dob
                };


                int result = await memDAL.Create(member);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapPut("/member", async (EditMemberDTO memberDTO, MemberDAL memDAL) =>
            {
                var member = new memberGAM {    
                
                    name = memberDTO.name,
                    lastname = memberDTO.lastname,
                    age = memberDTO.age,
                    height = memberDTO.height,
                    dob = memberDTO.dob
                };

                int result = await memDAL.Edit(member);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapDelete("/member/{id}", async (int id, MemberDAL memDAL) =>
            {
                int result = await memDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
