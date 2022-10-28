using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Portal.Domain.Requests
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
