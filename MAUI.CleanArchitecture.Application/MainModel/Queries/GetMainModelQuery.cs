using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.MainModel.Queries
{
    using MainModel = Domain.MainModel;

    public class GetMainModelQuery:IRequest<MainModel>
    {

    }
}
