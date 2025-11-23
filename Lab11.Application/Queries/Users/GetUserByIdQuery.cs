using Lab11.Application.DTOs;
using MediatR;

namespace Lab11.Application.Queries.Users
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto?>;
}