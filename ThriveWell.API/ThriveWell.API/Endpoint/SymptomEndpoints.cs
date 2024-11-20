using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using System;

namespace ThriveWell.API.Endpoint
{
    public static class SymptomEndpoints
    {
        public static void MapSymptomEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/symptoms").WithTags(nameof(Symptom));

            group.MapGet("/", async (IThriveWellSymptomService symptomService, string uid) =>
            {
                return await symptomService.GetAllSymptomsAsync(uid);
            })
                .WithName("GetAllSymptoms")
                .WithOpenApi()
                .Produces<List<Symptom>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (IThriveWellSymptomService symptomService, int id) =>
            {
                return await symptomService.GetSymptomByIdAsync(id);
            })
                .WithName("GetSymptomById")
                .WithOpenApi()
                .Produces<Symptom>(StatusCodes.Status200OK);

            group.MapPost("/", async (IThriveWellSymptomService symptomService, AddSymptomDTO symptomDTO) =>
            {
                var symptom = await symptomService.PostSymptomAsync(symptomDTO);
                return Results.Created($"/symptoms/{symptom.Id}", symptom);
            })
                .WithName("PostSymptom")
                .WithOpenApi()
                .Produces<Symptom>(StatusCodes.Status201Created);

            group.MapPut("/{id}", async (IThriveWellSymptomService symptomService, int id, AddSymptomDTO symptomDTO) =>
            {
                var updatedSymptom = await symptomService.UpdateSymptomAsync(id, symptomDTO);
                return Results.Ok(updatedSymptom);
            })
                .WithName("UpdateSymptom")
                .WithOpenApi()
                .Produces<Symptom>(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IThriveWellSymptomService symptomService, int id) =>
            {
                var symptom = await symptomService.DeleteSymptomAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteSymptom")
                .WithOpenApi()
                .Produces(StatusCodes.Status204NoContent);
        }
    }
}