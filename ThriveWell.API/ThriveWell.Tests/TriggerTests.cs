using ThriveWell.API.Interfaces;
using ThriveWell.API.Sevices;
using ThriveWell.API.Models;
using ThriveWell.API.DTOs;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ThriveWell.Tests
{
    public class TriggerTests
    {
        private readonly IThriveWellTriggerService _triggerService;
        private readonly Mock<IThriveWellTriggerRepository> _mockTriggerRepo;

        public TriggerTests()
        {
            _mockTriggerRepo = new Mock<IThriveWellTriggerRepository>();
            _triggerService = new ThriveWellTriggerService(_mockTriggerRepo.Object);
        }

        [Fact]
        public async Task CreateTriggerAsync_WhenCalled_ReturnsNewTrigger()
        {
            var newTriggerDTO = new AddTriggerDTO
            {
                Name = "string",
                Uid = "string"
            };

            var newTrigger = new Trigger
            {
                Name = newTriggerDTO.Name,
                Uid = newTriggerDTO.Uid,
            };

            _mockTriggerRepo.Setup(t => t.PostTriggerAsync(newTriggerDTO)).ReturnsAsync(newTrigger);
            var result = await _triggerService.PostTriggerAsync(newTriggerDTO);

            Assert.NotNull(result);
            Assert.Equal(newTriggerDTO.Name, result.Name);
            Assert.Equal(newTriggerDTO.Uid, result.Uid);
        }

        [Fact]
        public async Task UpdateTriggerAsync_WithValidId_ReturnsUpdateTriggerAsync()
        {
            var triggerId = 1;

            var currentTrigger = new Trigger
            {
                Name = "string",
                Uid = "string"
            };

            var editTriggerDTO = new AddTriggerDTO
            {
                Name = "test",
                Uid = "test"
            };

            var updatedTrigger = new Trigger
            {
                Name = editTriggerDTO.Name,
                Uid = editTriggerDTO.Uid,
            };

            _mockTriggerRepo.Setup(t => t.GetTriggerByIdAsync(triggerId)).ReturnsAsync(currentTrigger);
            _mockTriggerRepo.Setup(t => t.UpdateTriggerAsync(triggerId, editTriggerDTO)).ReturnsAsync(updatedTrigger);

            var result = await _triggerService.UpdateTriggerAsync(triggerId, editTriggerDTO);

            Assert.NotNull(result);
            Assert.Equal(editTriggerDTO.Name, result.Name);
            Assert.Equal(editTriggerDTO.Uid, result.Uid);
        }

        [Fact]
        public async Task DeleteTriggerAsync_WithValidId_ReturnsDeleteTrigger()
        {
            var triggerId = 1;

            var newTriggerDTO = new AddTriggerDTO
            {
                Name = "string",
                Uid = "string"
            };

            var newTrigger = new Trigger
            {
                Name = newTriggerDTO.Name,
                Uid = newTriggerDTO.Uid,
            };

            _mockTriggerRepo.Setup(t => t.PostTriggerAsync(newTriggerDTO)).ReturnsAsync(newTrigger);
            _mockTriggerRepo.Setup(t => t.DeleteTriggerAsync(triggerId)).ReturnsAsync(newTrigger);

            var result = await _triggerService.DeleteTriggerAsync(triggerId);

            Assert.NotNull(result);
            _mockTriggerRepo.Verify(t => t.DeleteTriggerAsync(triggerId), Times.Once);
        }
    }
}
