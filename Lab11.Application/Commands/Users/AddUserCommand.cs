using MediatR;

namespace Lab11.Application.Commands.Users
{
    public record AddUserCommand(string Username, string Email, string Password) : IRequest<int>;
}