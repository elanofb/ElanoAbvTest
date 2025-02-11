using Xunit;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using AutoMapper;

public class UserTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CreateUserHandler _handler;
    private readonly Mock<IPasswordHasher> _iPasswordHasherMock;

    public UserTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _mapperMock = new Mock<IMapper>();
        _iPasswordHasherMock = new Mock<IPasswordHasher>();

        _handler = new CreateUserHandler(_userRepositoryMock.Object, _mapperMock.Object,_iPasswordHasherMock.Object);
    }

    [Fact]
    public async Task CreateUser_Should_Throw_ValidationException_When_InvalidData()
    {
        var command = new CreateUserCommand
        {
            Email = "invalidemail",
            Username = "a",
            Password = "123",
            Phone = "invalidphone"
        };

        await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task CreateUser_Should_Save_When_ValidData()
    {
        var command = new CreateUserCommand
        {
            Email = "valid@example.com",
            Username = "validUser",
            Password = "SecurePass123!",
            Phone = "+5511999999999"
        };

        var user = new User { Id = Guid.NewGuid(), Email = command.Email };
        _mapperMock.Setup(m => m.Map<User>(command)).Returns(user);
        _userRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(command.Email, result.Email);
    }
}