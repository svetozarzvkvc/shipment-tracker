using ShipmentTracker.Application;
using ShipmentTracker.Application.UseCases;
using ShipmentTracker.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ShipmentTracker.Application.Exceptions;

namespace ShipmentTracker.Infrastructure
{
    public class UseCaseHandler
    {
        private readonly ILogger<UseCaseHandler> _logger;
        public UseCaseHandler(ILogger<UseCaseHandler> logger)
        {
            _logger = logger;
        }

        public void HandleCommand<TData>(ICommand<TData> command, TData data)
        {
            command.Execute(data);
            HandleCrossCuttingConcerns(command, data);
        }

        public TResult HandleQuery<TResult, TSearch>(IQuery<TResult, TSearch> query, TSearch search)
            where TResult : class

        {
            var result = query.Execute(search);
            HandleCrossCuttingConcerns(query, search);
            return result;

        }

        private void HandleCrossCuttingConcerns(IUseCase useCase, object data)
        {
            DateTime date = DateTime.UtcNow;
            string username = "Mike";
            string useCaseName = useCase.Name;
            string useCaseData = JsonConvert.SerializeObject(data);
            _logger.LogInformation($"Date: {date.ToLongDateString()} {date.ToLongTimeString()}, User: {username}, UseCase: {useCaseName}, Data: {useCaseData}");
        }
    }
}
