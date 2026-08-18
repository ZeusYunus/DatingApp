using System;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// This file manages access to members, messages, and likes, saves any changes to the database, and checks whether anything has been changed.

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IMemberRepository? _memberRepository;
    private IMessageRepository? _messageRepository;
    private ILikesRepository? _likeRepository;
    public IMemberRepository MemberRepository => _memberRepository ??= new MemberRepository(context);

    public IMessageRepository MessageRepository => _messageRepository ??= new MessageRepository(context);

    public ILikesRepository LikesRepository => _likeRepository ??= new LikesRepository(context);

    public async Task<bool> Complete()
    {
        try
        {
            return await context.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occured while saving changes", ex);
        }
    }

    public bool HasChanges()
    {
        return context.ChangeTracker.HasChanges();
    }
}
