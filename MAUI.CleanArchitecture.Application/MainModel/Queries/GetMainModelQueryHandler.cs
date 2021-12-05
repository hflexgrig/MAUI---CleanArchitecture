using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.MainModel.Queries
{
    public class GetMainModelQueryHandler : IRequestHandler<GetMainModelQuery, Domain.MainModel>
    {
        public Task<Domain.MainModel> Handle(GetMainModelQuery request, CancellationToken cancellationToken)
        {
            var mm = new Domain.MainModel();

            for (int i = 0; i < 50; i++)
            {
                mm.SubItems.Add(new Domain.SubItem { Name = $"Name {i}", Description = $"Desc {i}", Quantity = 0 });
            }

            return Task.FromResult(mm);
        }
    }
}
