using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Portal.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Extensions
{
    public static class MinimalApiMediatorExtensions
    {
        public static WebApplication MediateGet<TRequest>(
            this WebApplication app,
            string routeTempalte) where TRequest : IHttpRequest
        {
            app.MapGet(routeTempalte, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
            return app;
        }

        public static WebApplication MediatePost<TRequest>(
            this WebApplication app,
            string routeTempalte) where TRequest : IHttpRequest
        {
            app.MapPost(routeTempalte, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
            return app;
        }
    }
}
