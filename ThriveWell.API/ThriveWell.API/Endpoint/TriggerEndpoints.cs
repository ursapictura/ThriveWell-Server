using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using System;

namespace ThriveWell.API.Endpoint
{
    public static class TriggerEndpoints
    {
        public static void MapTriggerEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/triggers").WithTags(nameof(Trigger));

            group.MapGet("/user/{uid}", async (IThriveWellTriggerService triggerService, string uid) =>
            {
                return await triggerService.GetAllTriggersAsync(uid);
            })
                .WithName("GetAllTrigger")
                .WithOpenApi()
                .Produces<List<Trigger>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (IThriveWellTriggerService triggerService, int id) =>
            {
                return await triggerService.GetTriggerByIdAsync(id);
            })
                .WithName("GetTriggerById")
                .WithOpenApi()
                .Produces<Trigger>(StatusCodes.Status200OK);

            group.MapPost("/", async (IThriveWellTriggerService triggerService, AddTriggerDTO triggerDTO) =>
            {
                var trigger = await triggerService.PostTriggerAsync(triggerDTO);
                return Results.Created($"/trigger/{trigger.Id}", trigger);
            })
                .WithName("PostTrigger")
                .WithOpenApi()
                .Produces<Trigger>(StatusCodes.Status201Created);

            group.MapPut("/{id}", async (IThriveWellTriggerService symptomService, int id, AddTriggerDTO triggerDTO) =>
            {
                var updatedTrigger = await symptomService.UpdateTriggerAsync(id, triggerDTO);
                return Results.Ok(updatedTrigger);
            })
                .WithName("UpdateTrigger")
                .WithOpenApi()
                .Produces<Trigger>(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IThriveWellTriggerService triggerService, int id) =>
            {
                var trigger = await triggerService.DeleteTriggerAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteTrigger")
                .WithOpenApi()
                .Produces(StatusCodes.Status204NoContent);
        }
    }
}