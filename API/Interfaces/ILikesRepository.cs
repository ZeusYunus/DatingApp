using System;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

// This file defines a contract between the interface and implementation class and specify what methods are available to use
// Implementation = data/LikesRepository | Interface = currentFile
public interface ILikesRepository
{
    Task<MemberLike?> GetMemberLike(string sourceMemberId, string targetMemberId);
    Task<PaginatedResult<Member>> GetMemberLikes(LikesParams likesParams);
    Task<IReadOnlyList<string>> GetCurrentMemberLikeIds(string memberId);
    void DeleteLike(MemberLike like);
    void AddLike(MemberLike like);
    Task<bool> SaveAllChanges();
}
