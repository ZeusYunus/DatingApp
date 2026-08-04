using System;

namespace API.Entities;

// Join table for the likes features many to many
public class MemberLike
{
    public required string SourceMemberId { get; set; }
    public Member SourceMember { get; set; } = null!;
    public required string TargetMemberId { get; set; }
    public Member TargetMember { get; set; } = null!;
}
