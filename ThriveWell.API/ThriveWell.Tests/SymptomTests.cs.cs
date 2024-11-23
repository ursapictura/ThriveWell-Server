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
    public class SymptomTests
    {
        private readonly IThriveWellSymptomService _symptomService;

        private readonly Mock<IThriveWellSymptomRepository> _mockSymptomRepo;

        public SymptomTests()
        {
            _mockSymptomRepo = new Mock<IThriveWellSymptomRepository>();
            _symptomService = new ThriveWellSymptomService(_mockSymptomRepo.Object);
        }

        [Fact]
        public async Task GetAllSymtpomsAsync_WhenCalled_ReturnsAllSymptomsAsync()
        {
            string user1 = "NSkdshfjdfajdsh97834";
            string user2 = "KJHKBdskdaksjde9458v";

            var symptoms = new List<Symptom>
            {
                new Symptom { Id = 1, Name = "fever", Uid = user1 },
                new Symptom { Id = 2, Name = "rash", Uid = user1 },
                new Symptom { Id = 3, Name = "bloating", Uid = user2 },
            };

            _mockSymptomRepo.Setup(s => s.GetAllSymptomsAsync(user1)).ReturnsAsync(symptoms.Where(s => s.Uid == user1).ToList());
            _mockSymptomRepo.Setup(s => s.GetAllSymptomsAsync(user2)).ReturnsAsync(symptoms.Where(s => s.Uid == user2).ToList());

            var user1Result = await _symptomService.GetAllSymptomsAsync(user1);
            var user2Result = await _symptomService.GetAllSymptomsAsync(user2);

            Assert.NotNull(user1Result);
            Assert.Equal(2, user1Result.Count);
            Assert.NotNull(user2Result);
            Assert.Single(user2Result);

            //Asser that symptoms for user1 are not the same symptoms for user2

        Assert.All(user1Result, symptom => Assert.Equal(user1,symptom.Uid));
        Assert.All(user2Result, symptom => Assert.Equal(user2, symptom.Uid));
        }

        [Fact]
        public async Task GetSymptomDetailsAsync_WithValidId_ReturnsSymptomDetails()
        {
            int symptomId = 1;

            var expectedSymptom = new Symptom { Id = symptomId };

            _mockSymptomRepo.Setup(s => s.GetSymptomByIdAsync(symptomId)).ReturnsAsync(expectedSymptom);

            var actualSymptom = await _symptomService.GetSymptomByIdAsync(symptomId);

            Assert.Equal(expectedSymptom, actualSymptom);
        }

        [Fact]
        public async Task CreateSymptomAsync_WhenCalled_ReturnsNewSymptom()
        {
            var newSymptomDTO = new AddSymptomDTO
            {
                Name = "string",
                Uid = "string"
            };

            var newSymptom = new Symptom
            {
                Name = newSymptomDTO.Name,
                Uid = newSymptomDTO.Uid,
            };

            _mockSymptomRepo.Setup(s => s.PostSymptomAsync(newSymptomDTO)).ReturnsAsync(newSymptom);
            var result = await _symptomService.PostSymptomAsync(newSymptomDTO);

            Assert.NotNull(result);
            Assert.Equal(newSymptomDTO.Name, result.Name);
            Assert.Equal(newSymptom.Uid, result.Uid);
        }

        [Fact]
        public async Task UpdateSymptomAsync_WithValidId_ReturnsUpdatedSymptom()
        {
            var symptomId = 1;

            var currentSymptom = new Symptom
            {
                Name = "test",
                Uid = "test"
            };

            var editSymptomDTO = new AddSymptomDTO
            {
                Name = "string",
                Uid = "string"
            };

            var updatedSymptom = new Symptom
            {
                Name = editSymptomDTO.Name,
                Uid = editSymptomDTO.Uid,
            };

            _mockSymptomRepo.Setup(s => s.GetSymptomByIdAsync(symptomId)).ReturnsAsync(currentSymptom);
            _mockSymptomRepo.Setup(s => s.UpdateSymptomAsync(symptomId, editSymptomDTO)).ReturnsAsync(updatedSymptom);

            var result = await _symptomService.UpdateSymptomAsync(symptomId, editSymptomDTO);

            Assert.NotNull(result);
            Assert.Equal(editSymptomDTO.Name, result.Name);
            Assert.Equal(editSymptomDTO.Uid, result.Uid);
        }

        [Fact]
        public async Task DeleteSymptomAsync_WithValidId_ReturnsDeleteSymptom()
        {
            var symptomId = 1;
            var newSymptomDTO = new AddSymptomDTO
            {
                Name = "string",
                Uid = "string"
            };

            var newSymptom = new Symptom
            {
                Name = newSymptomDTO.Name,
                Uid = newSymptomDTO.Uid,
            };

            _mockSymptomRepo.Setup(s => s.PostSymptomAsync(newSymptomDTO)).ReturnsAsync(newSymptom);
            _mockSymptomRepo.Setup(s => s.DeleteSymptomAsync(symptomId)).ReturnsAsync(newSymptom);

            var result = await _symptomService.DeleteSymptomAsync(symptomId);

            Assert.NotNull(result);
            _mockSymptomRepo.Verify(s => s.DeleteSymptomAsync(symptomId), Times.Once);
        }
    }
}
