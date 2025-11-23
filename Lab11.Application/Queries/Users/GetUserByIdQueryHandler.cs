using Lab11.Application.DTOs;
using Lab11.Domain.Interfaces;
using Lab11.Domain.Entities;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11.Application.Queries.Users
{
    internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _uow.Repository<User>().GetByIdAsync(request.Id, cancellationToken);
            if (user == null) return null;
            return _mapper.Map<UserDto>(user);
        }
    }
}