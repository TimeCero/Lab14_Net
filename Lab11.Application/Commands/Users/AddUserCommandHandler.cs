using Lab11.Domain.Interfaces;
using Lab11.Domain.Entities; // ✅ correcto
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11.Application.Commands.Users
{
    internal sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.Password // puedes encriptar después
            };

            _uow.Repository<User>().Add(user);
            await _uow.CompleteAsync(cancellationToken);

            return user.UserId;
        }
    }
}