using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ThriveWell.API.Endpoint
{
    public static class SymptomTriggerEndpoints
    {
        public static void MapSymptomTriggerEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/symptom-trigger").WithTags(nameof(SymptomTrigger));

            group.MapGet("/", async (IThriveWellSymptomTriggerService symptomTriggerService, [FromBody] AddSymptomTriggerDTO symptomTriggerDTO) =>
            {
                return await symptomTriggerService.PostSymptomTriggerAsync(symptomTriggerDTO);
            })
                .WithName("PostSymptomTrigger")
                .WithOpenApi()
                .Produces<SymptomTrigger>(StatusCodes.Status201Created);

            group.MapDelete("/{id}", async (IThriveWellSymptomTriggerService symptomTriggerService, int id) =>
            {
                var symptomTrigger = await symptomTriggerService.DeleteSymptomTriggerAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteSymptomTrigger")
                .WithOpenApi()
                .Produces(StatusCodes.Status204NoContent);
        }
    }
}