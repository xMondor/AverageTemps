using AutoFixture;
using AverageTempsApp.Handlers;
using AverageTempsApp.Infrastructure;
using AverageTempsApp.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AverageTempsApp.Test
{
    public class GenerateReport
    {
        private readonly IFixture _fixture;
        public GenerateReport()
        {
            _fixture = new Fixture();
        }
        [Fact(DisplayName ="ReportGenerator Success Test")]
        public void ReportGeneratorSuccessTest()
        {
            // Arrange
            var timeSpans = new List<FileModel>
            {
                new FileModel{Temperature="72" , Time="00:00:00"},
                new FileModel{Temperature="73", Time="00:01:00"}
            };
            var currentTime = "00:01:00";
            var expectedResult = "72.5";
            var handler = new ReportGenerator();

            // Act
            var result = handler.GenerateReport(timeSpans, currentTime);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact(DisplayName ="ReportGenerator Empty List Test")]
        
        public void ReportGeneratorEmptyListTest()
        {
            // Arrange
            List<FileModel> timeSpans = null;
            var currentTime = "00:01:00";
            var expectedResult = "72.5";
            var handler = new ReportGenerator();

            // Act
            Action act = () => handler.GenerateReport(timeSpans, currentTime);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "ReportGenerator Empty Time Test")]
        public void ReportGeneratorEmptyTimeTest()
        {
            // Arrange
            var timeSpans = new List<FileModel>();
            var currentTime = string.Empty;
            var expectedResult = "72.5";
            var handler = new ReportGenerator();

            // Act
            Action act = () => handler.GenerateReport(timeSpans, currentTime);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}