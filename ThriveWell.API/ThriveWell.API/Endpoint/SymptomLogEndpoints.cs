using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using System;

namespace ThriveWell.API.Endpoint
{
    public static class SymptomLogEndpoints
    {
        public static void MapSymptomLogEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/logs").WithTags(nameof(SymptomLog));

            group.MapGet("/user/{uid}", async (IThriveWellSymptomLogService symptomLogService, string uid) =>
            {
                return await symptomLogService.GetAllSymptomLogsAsync(uid);
            })
                .WithName("GetAllSymptomLogs")
                .WithOpenApi()
                .Produces<List<SymptomLog>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (IThriveWellSymptomLogService symptomLogService, int id) =>
            {
                var log = await symptomLogService.GetSymptomLogByIdAsync(id);
                return log;
            })
                .WithName("GetSymptomLogById")
                .WithOpenApi()
                .Produces<SymptomLog>(StatusCodes.Status200OK);

            group.MapPost("/", async (IThriveWellSymptomLogService symptomLogService, AddSymptomLogDTO symptomLogDTO) =>
            {
                var log = await symptomLogService.PostSymtpomLogAsync(symptomLogDTO);
                return Results.Created($"/logs/{log.Id}", log);
            })
                .WithName("PostSymptomLog")
                .WithOpenApi()
                .Produces<SymptomLog>(StatusCodes.Status201Created);

            group.MapPut("/{id}", async (IThriveWellSymptomLogService symptomLogService, int id, AddSymptomLogDTO symptomLogDTO) =>
            {
                var updatedLog = await symptomLogService.UpdateSymptomLogAsync(id, symptomLogDTO);
                return Results.Ok(updatedLog);
            })
                .WithName("UpdateSymptomLog")
                .WithOpenApi()
                .Produces<SymptomLog>(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IThriveWellSymptomLogService symptomLogService, int id) =>
            {
                var log = await symptomLogService.DeleteSymptomLogAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteSymptomLog")
                .WithOpenApi()
                .Produces(StatusCodes.Status204NoContent);
        }
    }
}