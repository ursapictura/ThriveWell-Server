using ThriveWell.API.Interfaces;
using ThriveWell.API.Sevices;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ThriveWell.Tests
{
    public class DailyJournalTests
    {

        private readonly IThriveWellDailyJournalService _journalService;

        private readonly Mock<IThriveWellDailyJournalRepository> _mockJournalRepo;

        public DailyJournalTests()
        {
            _mockJournalRepo = new Mock<IThriveWellDailyJournalRepository>();
            _journalService = new ThriveWellDailyJournalService(_mockJournalRepo.Object);
        }

        [Fact]
        public async Task GetAllDailyJournalsAsync_WhenCalled_ReturnsAllDailyJournalsAsync()
        {
            string user1 = "NSkdshfjdfajdsh97834";
            string user2 = "KJHKBdskdaksjde9458v";
            var journals = new List<DailyJournal>
            {
                new DailyJournal { Id = 1, Uid = user1 },
                new DailyJournal { Id = 2, Uid = user1 },
                new DailyJournal { Id = 3, Uid = user2 },
            };

            _mockJournalRepo.Setup(j => j.GetAllDailyJournalsAsync(user1)).ReturnsAsync(journals.Where(j => j.Uid == user1).ToList());
            _mockJournalRepo.Setup(j => j.GetAllDailyJournalsAsync(user2)).ReturnsAsync(journals.Where( j => j.Uid == user2).ToList());

            var user1Result = await _journalService.GetAllDailyJournalsAsync(user1);
            var user2Result = await _journalService.GetAllDailyJournalsAsync(user2);

            Assert.NotNull(user1Result);
            Assert.Equal(2, user1Result.Count);
            Assert.NotNull(user2Result);
            Assert.Single(user2Result);

            //Assert that the jounals for user1 are not the same journals for user2
            Assert.All(user1Result, journal => Assert.Equal(user1, journal.Uid));
            Assert.All(user2Result, journal => Assert.Equal(user2, journal.Uid));
        }

        [Fact]
        public async Task GetDailyJournalDetails_WithValidId_ReturnJournalDetailsAsync()
        {
            int journalId = 1;

            var expectedJournal = new DailyJournal { Id = journalId };

            _mockJournalRepo.Setup(j => j.GetDailyJournalByIdAsync(journalId)).ReturnsAsync(expectedJournal);

            var actualJournal = await _journalService.GetDailyJournalByIdAsync(journalId);

            Assert.Equal(expectedJournal, actualJournal);
        }

        [Fact]
        public async Task CreateNewDailyJournal_WhenCalled_RetyurnsNewDailyJournalAsync()
        {
            var newJournalDTO = new AddDailyJournalDTO
            {
                Entry = "fjkdhalyfileu",
                Uid = "sfasf9457346",
                Date = new DateOnly(2024,04,29),
            };

            var newJournal = new DailyJournal
            {
                Entry = newJournalDTO.Entry,
                Uid = newJournalDTO.Uid,
                Date = newJournalDTO.Date,
            };

            _mockJournalRepo.Setup(j => j.PostDailyJournalAsync(newJournalDTO)).ReturnsAsync(newJournal);
            var result = await _journalService.PostDailyJournalAsync(newJournalDTO);

            Assert.NotNull(result);
            Assert.Equal(newJournalDTO.Entry, result.Entry);
            Assert.Equal(newJournal.Uid, result.Uid);
            Assert.Equal(newJournalDTO.Date, newJournalDTO.Date);
        }

        [Fact]
        public async Task UpdateDailyJournalAsync_WhenCalled_ReturnsUpdateDailyJournalAsync()
        {
            int journalId = 1;

            var currentJournal = new DailyJournal
            {
                Entry = "string",
                Uid = "sfasf9457346",
                Date = new DateOnly(2024, 04, 29),
            };

            var editJournalDTO = new AddDailyJournalDTO
            {
                Entry = "fjkdhalyfileu",
                Uid = "sfasf9457346",
                Date = new DateOnly(2024, 04, 29),
            };

            var updatedJournal = new DailyJournal
            {
                Entry = editJournalDTO.Entry,
                Uid = editJournalDTO.Uid,
                Date = editJournalDTO.Date,
            };

            _mockJournalRepo.Setup(j => j.GetDailyJournalByIdAsync(journalId)).ReturnsAsync(currentJournal);
            _mockJournalRepo.Setup(j => j.UpdateDailyJournalAsnyc(journalId, editJournalDTO)).ReturnsAsync(updatedJournal);

            var result = await _journalService.UpdateDailyJournalAsnyc(journalId, editJournalDTO);

            Assert.NotNull(result);
            Assert.Equal(editJournalDTO.Entry, result.Entry);
            Assert.Equal(editJournalDTO.Uid, result.Uid);
            Assert.Equal(editJournalDTO.Date, result.Date);
        }

        [Fact]
        public async Task DeleteDailyJournal_WhenCalledWithValidId_DeleteDailyJournal()
        {
            var journalId = 1;

            var newJournalDTO = new AddDailyJournalDTO
            {
                Entry = "fjkdhalyfileu",
                Uid = "sfasf9457346",
                Date = new DateOnly(2024, 04, 29),
            };

            var newJournal = new DailyJournal
            {
                Entry = newJournalDTO.Entry,
                Uid = newJournalDTO.Uid,
                Date = newJournalDTO.Date,
            };

            _mockJournalRepo.Setup(j => j.PostDailyJournalAsync(newJournalDTO)).ReturnsAsync(newJournal);
            _mockJournalRepo.Setup(j => j.DeleteDailyJournalAsync(journalId)).ReturnsAsync(newJournal);

            var result = await _journalService.DeleteDailyJournalAsync(journalId);

            Assert.NotNull(result);
            _mockJournalRepo.Verify(j => j.DeleteDailyJournalAsync(journalId), Times.Once);
        }
    }
}