using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Card.Commands.CreateCardItem
{
    public class UpdateCardItemCommandHandler : IRequestHandler<UpdateCardItemCommand, Unit>
    {
        private readonly IStoreDbContext _storeDbContext;

        public UpdateCardItemCommandHandler(IStoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<Unit> Handle(UpdateCardItemCommand request, CancellationToken cancellationToken)
        {
            var cardItems = _storeDbContext.CardItems.Where(x => x.SessionId == request.SessionId);
            foreach (var cardItem in cardItems)
            {
                cardItem.UserId = request.UserId;
            }

            await _storeDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
