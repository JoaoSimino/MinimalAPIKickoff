using Microsoft.EntityFrameworkCore;
using MinimalAPIKickoff.Domain.Entities;
using MinimalAPIKickoff.Infrastructure.Data;

namespace MinimalAPIKickoff.Application.Services;

public class UserService : CrudService<User>, IUserService
{

    public UserService(MinimalAPIKickoffContext context) : base(context)
    {}
    //specific queries must be created in the interface associated with this class and implemented here!

}
