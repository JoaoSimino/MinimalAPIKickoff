using Microsoft.EntityFrameworkCore;
using MinimalAPIKickoff.Application.Services;
using MinimalAPIKickoff.Domain.Entities;
using MinimalAPIKickoff.Infrastructure.Data;

namespace MinimalAPIKickoff.API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes) 
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", async (IUserService service) =>
        {
            var listaDeUsuarios = await service.GetAllAsync();
            //Logar aqui
            return listaDeUsuarios;
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, IUserService service) =>
        {
            var user = await service.GetByIdAsync(id);
            //Logar aqui
            return user;
        })
        .WithName("GetUserById")
        .WithOpenApi();

        group.MapPost("/", async (User user, IUserService service) =>
        {
            await service.AddAsync(user);

            return TypedResults.Created($"/api/User/{user.Id}", user);
        })
        .WithName("CreateUser")
        .WithOpenApi();


    }
}
