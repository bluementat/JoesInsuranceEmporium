using JoesInsuranceEmporium.DataClasses;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyGenerationApi.Modules
{
    public class PropertyGenerationEngine : BackgroundService
    {
        private readonly IRandomPropertyGenerator _generator;
        private readonly HttpClient _client;

        private readonly string _inventoryServiceUrl;
        private int _timeInterval = 0;

        private readonly ILogger<PropertyGenerationEngine> _logger;

        public PropertyGenerationEngine(IRandomPropertyGenerator generator, ILogger<PropertyGenerationEngine> logger)
        {
            if (!Int32.TryParse(Environment.GetEnvironmentVariable("PropGenInt"), out _timeInterval))
            {
                _timeInterval = 20000;
            }
            _inventoryServiceUrl = Environment.GetEnvironmentVariable("InvetoryServiceUrl") ?? String.Empty;

            _generator = generator;
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(5);

            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    Property newProperty = await _generator.Generate();
                    string encodedProperty = JsonConvert.SerializeObject(newProperty);
                    var content = new StringContent(encodedProperty, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = await _client.PostAsync(_inventoryServiceUrl, content);
                    response.EnsureSuccessStatusCode();
                    
                    _logger.LogInformation("Engine running at: {time}", DateTimeOffset.Now);                   
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message.Substring(0, 50) + "...";
                    _logger.LogInformation($"Engine Error at {DateTimeOffset.Now} - {errorMessage}");
                }

                await Task.Delay(_timeInterval, stoppingToken);
            }
        }
    }
}
