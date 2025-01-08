using ThriveWell.API.Interfaces;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using System;

namespace ThriveWell.API.Endpoint
{
    public static class DailyJournalEndpoints
    {
        public static void MapDailyJournalEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/journals").WithTags(nameof(DailyJournal));

            group.MapGet("/user/{uid}", async (IThriveWellDailyJournalService dailyJournalService, string uid) =>
            {
                return await dailyJournalService.GetAllDailyJournalsAsync(uid);
            })
                .WithName("GetAllDailyJournals")
                .WithOpenApi()
                .Produces<List<DailyJournal>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (IThriveWellDailyJournalService dailyJournalService, int id) =>
            {
                var journal = await dailyJournalService.GetDailyJournalByIdAsync(id);
                return journal;
            })
                .WithName("GetDailyJournalById")
                .WithOpenApi()
                .Produces<DailyJournal>(StatusCodes.Status200OK);

            group.MapGet("/user/{uid}/{year}/{month}", async (IThriveWellDailyJournalService dailyJournalService, string uid, int year, int month) =>
            {
                var journal = await dailyJournalService.GetDailyJournalsByMonthAndYearAsync(uid, year, month);
                return journal;
            })
                .WithName("GetDailyJournalByMonthAndYear")
                .WithOpenApi()
                .Produces<List<DailyJournal>>(StatusCodes.Status200OK);

            group.MapPost("/", async (IThriveWellDailyJournalService dailyJournalService, AddDailyJournalDTO dailyJournalDTO) =>
            {
                var journal = await dailyJournalService.PostDailyJournalAsync(dailyJournalDTO);
                return Results.Created($"/journals/{journal.Id}", journal);
            })
                .WithName("PostDailyJournal")
                .WithOpenApi()
                .Produces<DailyJournal>(StatusCodes.Status201Created);

            group.MapPut("/{id}", async (IThriveWellDailyJournalService dailyJournalService, int id, AddDailyJournalDTO dailyJournalDTO) =>
            {
                var updatedJournal = await dailyJournalService.UpdateDailyJournalAsnyc(id, dailyJournalDTO);
                return Results.Ok(updatedJournal);
            })
                .WithName("UpdateDailyJournal")
                .WithOpenApi()
                .Produces<DailyJournal>(StatusCodes.Status204NoContent);

            group.MapDelete("/{id}", async (IThriveWellDailyJournalService dailyJournalService, int id) =>
            {
                var journal = await dailyJournalService.DeleteDailyJournalAsync(id);
                return Results.NoContent();
            })
                .WithName("DeleteDailyJournal")
                .WithOpenApi()
                .Produces(StatusCodes.Status204NoContent);
        }
    }
}