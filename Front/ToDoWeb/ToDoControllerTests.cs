using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoWeb.Controllers;
using ToDoWeb.Models;
using Xunit;

namespace ToDoWeb
{
    public class ToDoControllerTests
    {
        private readonly Mock<IToDoService> _mockToDoService;
        private readonly ToDoController _controller;

        public ToDoControllerTests()
        {
            
            _controller = new ToDoController();
        }


        [Fact]
        public async Task GetToDos_ReturnsOkResult_WithListOfToDos()
        {
            // Arrange
            var mockToDos = new List<ToDo>
        {
            new ToDo { Id = 1, Titulo = "Test ToDo 1", Finalizada = false },
            new ToDo { Id = 2, Titulo = "Test ToDo 2", Finalizada = true }
        };
            _mockToDoService.Setup(service => service.GetToDosAsync());

            // Act
            var result = await _controller.Index();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ToDo>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

    }
}
