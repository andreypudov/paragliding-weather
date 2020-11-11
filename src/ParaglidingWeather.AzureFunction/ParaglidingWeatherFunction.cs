// <copyright file="ParaglidingWeatherFunction.cs" company="Andrey Pudov">
//     Copyright (c) Andrey Pudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.
// </copyright>

namespace ParaglidingWeather.AzureFunction
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using ParaglidingWeather.Bot;

    /// <summary>
    /// Represents the Azure function processes requests from a Telegram client.
    /// </summary>
    public static class ParaglidingWeatherFunction
    {
        /// <summary>
        /// Azure HTTP trigger function.
        /// </summary>
        /// <param name="request">The HTTP request from the client.</param>
        /// <param name="logger">The instance of the logger.</param>
        /// <returns>The status of the request processing.</returns>
        [FunctionName("ParaglidingWeatherFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest request,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(ParaglidingWeatherFunction)} HTTP trigger function processed a request.");

            var body = await request.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(body))
            {
                return new BadRequestResult();
            }

            var client = new WebhookClient("1352055876:AAE4IRhh2jcSLm1T14P4J_8tNK26RK6TH5k", logger);
            await client.Update(body).ConfigureAwait(false);

            return new OkResult();
        }
    }
}