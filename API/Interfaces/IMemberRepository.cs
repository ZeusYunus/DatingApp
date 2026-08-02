using System;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

// This class is what you call to use the function/method IMemberRepository. We interact with this file
// MemberRepository is where all the code is placed

public interface IMemberRepository
{
    void Update(Member member);
    Task<bool> SaveAllAsync();
    Task<PaginatedResult<Member>> GetMembersAsync(MemberParams memberParams);
    Task<Member?> GetMemberByIdAsync(string id);
    Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId);
    Task<Member?> GetMemberForUpdate(string id);
}
