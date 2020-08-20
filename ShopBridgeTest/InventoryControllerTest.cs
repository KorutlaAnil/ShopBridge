using Microsoft.AspNetCore.Mvc;
using Moq;
using ShopBridge.Controllers;
using ShopBridge.DTO;
using ShopBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridgeTest
{
   public class InventoryControllerTest
    {
        private readonly Mock<IInventoryService> _InventoryService;
        public InventoryControllerTest()
        {
            _InventoryService = new Mock<IInventoryService>();
        }
        [Fact]
        public async void AddProductTest()
        {
            //Arrange
            _InventoryService.Setup(x => x.AddProductAsync(It.IsAny<ProductDto>())).Returns(Task.FromResult(1));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.AddProducts(It.IsAny<ProductDto>());
            //Assert
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public async void AddProductTestBadReq()
        {
            //Arrange
            _InventoryService.Setup(x => x.AddProductAsync(It.IsAny<ProductDto>())).Returns(Task.FromResult(1));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            controller.ModelState.AddModelError("key", "Invalid request.");
            var res =await controller.AddProducts(MockDataObjects.ProductsDto().Single());
            //Assert
            Assert.IsType<BadRequestObjectResult>(res);
        }

        [Fact]
        public async void GetProductTest()
        {
            //Arrange
            _InventoryService.Setup(x => x.GetProductAsync(It.IsAny<int>())).Returns(Task.FromResult(MockDataObjects.ProductsDto().Single()));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.GetProduct(1);
            //Assert
            Assert.IsType<OkObjectResult>(res);
        }
        [Fact]
        public async void GetProductTestNotfound()
        {
            //Arrange
            _InventoryService.Setup(x => x.GetProductAsync(It.IsAny<int>())).Returns(Task.FromResult<ProductDto>(null));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.GetProduct(1);
            //Assert
            Assert.IsType<NotFoundObjectResult>(res);
        }
        [Fact]
        public async void GetProductTestBadReq()
        {
            
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            controller.ModelState.AddModelError("key", "Invalid request.");
            var res = await controller.GetProduct(It.IsAny<int>());
            //Assert
            Assert.IsType<BadRequestObjectResult>(res);
        }
        [Fact]
        public async void GetProductsTest()
        {
            //Arrange
            _InventoryService.Setup(x => x.GetProductsAsync()).Returns(Task.FromResult(MockDataObjects.ProductsDto()));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.GetProducts();
            //Assert
            Assert.IsType<OkObjectResult>(res);
        }
        [Fact]
        public async void GetProductsTestNotfound()
        {
            //Arrange
            _InventoryService.Setup(x => x.GetProductsAsync()).Returns(Task.FromResult<List<ProductDto>>(null));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.GetProducts();
            //Assert
            Assert.IsType<NotFoundObjectResult>(res);
        }
        [Fact]
        public async void DeleteProductTest()
        {
            //Arrange
            _InventoryService.Setup(x => x.DeleteProductAsync(It.IsAny<int>())).Returns(Task.FromResult(true));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.DeleteProduct(1);
            //Assert
            Assert.IsType<OkObjectResult>(res);
        }
        [Fact]
        public async void DeleteProductTestNotfound()
        {
            //Arrange
            _InventoryService.Setup(x => x.DeleteProductAsync(It.IsAny<int>())).Returns(Task.FromResult(false));
            //Act
            var controller = new InventoryController(_InventoryService.Object);
            var res = await controller.DeleteProduct(1);
            //Assert
            Assert.IsType<NotFoundObjectResult>(res);
        }
        [Fact]
        public async void DeleteProductTestBadReq()
        {

            //Act
            var controller = new InventoryController(_InventoryService.Object);
            controller.ModelState.AddModelError("key", "Invalid request.");
            var res = await controller.DeleteProduct(It.IsAny<int>());
            //Assert
            Assert.IsType<BadRequestObjectResult>(res);
        }
    }

}
