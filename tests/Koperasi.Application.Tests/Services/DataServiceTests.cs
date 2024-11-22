using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Koperasi.Application.Models;
using Koperasi.Application.Models.Request;
using Koperasi.Application.Models.Response;
using Koperasi.Application.Services;
using Koperasi.Domain.Entities;
using Koperasi.Infrastructure.Abstractions;
using Koperasi.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Koperasi.Application.Tests.Services
{
    public class DataServiceTests
    {
        private readonly DataService _dataService;
        private readonly ILogger<DataService> _logger;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IUserRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IConnectionStringProvider _connectionStringProvider;
        private readonly DataContext _dataContext;

        public DataServiceTests()
        {
            _logger = Substitute.For<ILogger<DataService>>();
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _productImagesRepository = Substitute.For<IProductImagesRepository>();
            _productsRepository = Substitute.For<IUserRepository>();
            _mapper = Substitute.For<IMapper>();
            _connectionStringProvider = Substitute.For<IConnectionStringProvider>();
            _dataContext = new DataContext(new DbContextOptions<DataContext>(), _connectionStringProvider);

            _dataService = new DataService(_logger, _productCategoryRepository, _productImagesRepository, _productsRepository, _mapper, _connectionStringProvider);
        }

        [Fact]
        public async Task Return_Product_Categories()
        {
            //Arrange
            var productResponseItem1 = new ProductCategoryResponseItems
            {
                ProductCategoryId = 1,
                ProductCategoryName = "Product1"
            };
            var productResponseItem2 = new ProductCategoryResponseItems
            {
                ProductCategoryId = 2,
                ProductCategoryName = "Product2"
            };

            var categories = new List<ProductCategoryResponseItems>();
            categories.Add(productResponseItem1);
            categories.Add(productResponseItem2);

            var expectedResult = new ProductCategoryResponse
            {
                ProductCategories = categories
            };


            var entityItems1 = new ProductCategoryEntity { ProductCategoryId = 1, ProductCategoryName = "Product1" };
            var entityItems2 = new ProductCategoryEntity { ProductCategoryId = 2, ProductCategoryName = "Product2" };

            var entityData = new List<ProductCategoryEntity> { entityItems1, entityItems2 };
            var readOnlyList = new ReadOnlyCollection<ProductCategoryEntity>(entityData);

            _productCategoryRepository.GetAllAsync().Returns(readOnlyList);

            //Act
            var result = await _dataService.GetProductCategories();

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Return_Product_Category_By_Id()
        {
            //Arrange
            var productResponseItem1 = new ProductCategoryResponseItems
            {
                ProductCategoryId = 1,
                ProductCategoryName = "Product1"
            };
           

            var categories = new List<ProductCategoryResponseItems>();
            categories.Add(productResponseItem1);
           

            var expectedResult = new ProductCategoryResponse
            {
                ProductCategories = categories
            };


            var entityItems1 = new ProductCategoryEntity { ProductCategoryId = 1, ProductCategoryName = "Product1" };

            _productCategoryRepository.GetByIdAsync(1).Returns(entityItems1);

            //Act
            var result = await _dataService.GetProductCategoryById(new ProductCategoryRequest { ProductCategoryId = 1 });

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Return_Product_Images()
        {
            //Arrange
            var imageItem1 = new ProductImagesResponseItems
            {
                ProductId = 1,
                ProductImageId = 1,
                ProductImageName = "Image1"
            };
            var imageItem2 = new ProductImagesResponseItems
            {
                ProductId = 2,
                ProductImageId = 2,
                ProductImageName = "Image2"
            };

            var images = new List<ProductImagesResponseItems> { imageItem1, imageItem2 };

            var expectedResult = new ProductImagesResponse
            {
                ProductImages = images
            };


            var entityItems1 = new ProductImagesEntity 
            {
                ProductId = 1,
                ProductImageId = 1,
                ProductImageName = "Image1"
            };
            var entityItems2 = new ProductImagesEntity 
            {
                ProductId = 2,
                ProductImageId = 2,
                ProductImageName = "Image2"
            };

            var entityData = new List<ProductImagesEntity> { entityItems1, entityItems2 };
            var readOnlyList = new ReadOnlyCollection<ProductImagesEntity>(entityData);

            _productImagesRepository.GetAllAsync().Returns(readOnlyList);

            //Act
            var result = await _dataService.GetProductImages();

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Return_Products()
        {
            //Arrange
            var productItem1 = new ProductsResponseItems
            {
                ProductId = 1,
                ProductName = "ProductName1",
                ProductCategory = 1,
                ProductPrice = 1.4,
                ProductRating = 1
            };
            var productItem2 = new ProductsResponseItems
            {
                ProductId = 2,
                ProductName = "ProductName2",
                ProductCategory = 2,
                ProductPrice = 2.4,
                ProductRating = 2
            };

            var products = new List<ProductsResponseItems> { productItem1, productItem2 };

            var expectedResult = new ProductsResponse
            {
                Products = products
            };


            var entityItems1 = new UserEntity
            {
                ProductId = 1,
                ProductName = "ProductName1",
                ProductCategory = 1,
                ProductPrice = 1.4,
                ProductRating = 1
            };
            var entityItems2 = new UserEntity
            {
                ProductId = 2,
                ProductName = "ProductName2",
                ProductCategory = 2,
                ProductPrice = 2.4,
                ProductRating = 2
            };

            var entityData = new List<UserEntity> { entityItems1, entityItems2 };
            //var readOnlyList = new ReadOnlyCollection<ProductsEntity>(entityData);

            //_productsRepository.GetAllAsync().Returns(readOnlyList);
            _connectionStringProvider.GetConnectionString().Returns("Server=127.0.0.1;port=5432;user id=postgres;password=admin;database=Koperasi;pooling=true;");
            //Act
            var result = await _dataService.GetProducts();

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> ProductRatingRequest
        {
            get
            {
                yield return new object[] { new SetProductRatingRequest { ProductId = 1, ProductRating = 3, ProductCategory = 3 } };
            }
        }

        [Theory]
        [MemberData(nameof(ProductRatingRequest))]
        public async Task Return_Product_Rating(SetProductRatingRequest ratingRequest)
        {
            //Arrange
            var entityData = new UserEntity
            {
                ProductId = 1,
                ProductName = "ProductName1",
                ProductCategory = 1,
                ProductPrice = 1.4,
                ProductRating = 1
            };

            _productsRepository.GetByIdAsync(entityData.ProductId).Returns(entityData);

            var expectedResult = new SetProductRatingResponse
            {
                ProductId = 1,
                ProductRating = 3
            };

            //Act
            var result = await _dataService.SetProductRating(ratingRequest);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> Request
        {
            get
            {
                yield return new object[] { new UserRegistrationRequest { ProductId = 1, ProductName = "ProductName", ProductRating = 3, ProductCategory = 3, ProductPrice = 3.6 } };
            }
        }

        [Theory]
        [MemberData(nameof(Request))]
        public async Task Return_Product_Details(UserRegistrationRequest request)
        {
            //Arrange
            var entityData = new UserEntity
            {
                ProductId = 1,
                ProductName = "ProductName",
                ProductCategory = 3,
                ProductPrice = 3.6,
                ProductRating = 3
            };

            _mapper.Map<UserEntity>(request).Returns(entityData);

            _productsRepository.AddAsync(entityData).Returns(entityData);

            var expectedResult = new UserRegistrationResponse
            {
                ProductName = "ProductName",
            };

            _mapper.Map<UserRegistrationResponse>(entityData).Returns(expectedResult);

            //Act
            var result = await _dataService.CreateProduct(request);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> UpdateRequest
        {
            get
            {
                yield return new object[] { new UserRegistrationRequest { ProductId = 1, ProductName = "ProductName", ProductRating = 3, ProductCategory = 3, ProductPrice = 3.6 } };
            }
        }

        [Theory]
        [MemberData(nameof(UpdateRequest))]
        public async Task Update_Product_Details(UserRegistrationRequest request)
        {
            //Arrange
            var entityData = new UserEntity
            {
                ProductId = 1,
                ProductName = "Name",
                ProductCategory = 1,
                ProductPrice = 1,
                ProductRating = 1
            };


            _productsRepository.GetByIdAsync(entityData.ProductId).Returns(entityData);

            var expectedResult = new UserRegistrationResponse
            {
                ProductName = "ProductName",
            };

            //Act
            var result = await _dataService.UpdateProduct(request);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        
        [Theory]
        [InlineData(1)]
        public async Task Delete_Product_Details(int request)
        {
            //Arrange
            var entityData = new UserEntity
            {
                ProductId = 1,
                ProductName = "ProductName",
                ProductCategory = 1,
                ProductPrice = 1,
                ProductRating = 1
            };


            _productsRepository.GetByIdAsync(request).Returns(entityData);

            var expectedResult = new DeleteProductResponse
            {
                IsProductDeleted = true
            };

            //Act
            var result = await _dataService.DeleteProduct(request);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
