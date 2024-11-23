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
    public class SymptomLogTests
    {
        private readonly IThriveWellSymptomLogService _logService;

        private readonly Mock<IThriveWellSymptomLogRepository> _mockLogRepo;

        public SymptomLogTests()
        {
            _mockLogRepo = new Mock<IThriveWellSymptomLogRepository>();
            _logService = new ThriveWellSymptomLogService( _mockLogRepo.Object );
        }

        [Fact]
        public async Task CreateSymptomLogAsync_WhenCalled_ReturnsNewSymptomLogAsync()
        {
            var newLogDTO = new AddSymptomLogDTO
            {
                Date = new DateOnly(2024, 11, 20),
                SymptomId = 3,
                Severity = 4,
                Uid = "string"
            };

            var newLog = new SymptomLog
            {
                Date = newLogDTO.Date,
                SymptomId = newLogDTO.SymptomId,
                Severity = newLogDTO.Severity,
                Uid = newLogDTO.Uid,
            };

            _mockLogRepo.Setup(l => l.PostSymtpomLogAsync(newLogDTO)).ReturnsAsync(newLog);
            var result = _logService.PostSymtpomLogAsync(newLogDTO);

            Assert.NotNull(result);
            Assert.Equal(newLogDTO.Date, newLog.Date);
            Assert.Equal(newLogDTO.SymptomId, newLog.SymptomId);
            Assert.Equal(newLogDTO.Severity, newLog.Severity);
            Assert.Equal(newLogDTO.Uid, newLog.Uid);
        }

        [Fact]
        public async Task UpdateSymptomLogAsync_WithValidId_ReturnsUpdatedSymtpomAsync()
        {
            var logId = 1;

            var currentLog = new SymptomLog
            {
                Date = new DateOnly(2024, 11, 20),
                SymptomId = 3,
                Severity = 4,
                Uid = "string"
            };

            var editLogDTO = new AddSymptomLogDTO
            {
                Date = new DateOnly(2024, 11, 18),
                SymptomId = 2,
                Severity = 5,
                Uid = "test"
            };

            var updatedLog = new SymptomLog
            {
                Date = editLogDTO.Date,
                SymptomId = editLogDTO.SymptomId,
                Severity = editLogDTO.Severity,
                Uid = editLogDTO.Uid
            };

            _mockLogRepo.Setup(l => l.GetSymptomLogByIdAsync(logId)).ReturnsAsync(currentLog);
            _mockLogRepo.Setup(l => l.UpdateSymptomLogAsync(logId, editLogDTO)).ReturnsAsync(updatedLog);

            var result = await _logService.UpdateSymptomLogAsync(logId, editLogDTO);

            Assert.NotNull(result);
            Assert.Equal(editLogDTO.Date, result.Date);
            Assert.Equal(editLogDTO.SymptomId, result.SymptomId);
            Assert.Equal(editLogDTO.Severity, result.Severity);
            Assert.Equal(editLogDTO.Uid, result.Uid);
        }

        [Fact]
        public async Task DeleteSymptomLogAsync_WithValidId_ReturnsDeleteSymptomLogAsync()
        {
            var logId = 1;

            var newLogDTO = new AddSymptomLogDTO
            {
                Date = new DateOnly(2024, 11, 20),
                SymptomId = 3,
                Severity = 4,
                Uid = "string"
            };

            var newLog = new SymptomLog
            {
                Date = newLogDTO.Date,
                SymptomId = newLogDTO.SymptomId,
                Severity = newLogDTO.Severity,
                Uid = newLogDTO.Uid,
            };

            _mockLogRepo.Setup(l => l.PostSymtpomLogAsync(newLogDTO)).ReturnsAsync(newLog);
            _mockLogRepo.Setup(l => l.DeleteSymptomLogAsync(logId)).ReturnsAsync(newLog);

            var result = await _logService.DeleteSymptomLogAsync(logId);

            Assert.NotNull(result);
            _mockLogRepo.Verify(l => l.DeleteSymptomLogAsync(logId), Times.Once);

        }
    }
}
