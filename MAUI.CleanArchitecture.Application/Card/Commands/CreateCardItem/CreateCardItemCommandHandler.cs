using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Card.Commands.CreateCardItem
{
    public class CreateCardItemCommandHandler : IRequestHandler<CreateCardItemCommand, Unit>
    {
        private readonly IStoreDbContext _storeDbContext;

        public CreateCardItemCommandHandler(IStoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<Unit> Handle(CreateCardItemCommand request, CancellationToken cancellationToken)
        {
            _storeDbContext.CardItems.Add(request.CardItem);
            await _storeDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
