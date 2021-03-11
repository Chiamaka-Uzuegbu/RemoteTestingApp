using Microsoft.AspNetCore.Mvc;
using Moq;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Helpers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestForRemoteTestingApp.ControllerTest.AuthenticationControllerTest
{
    public class AuthenticationControllerShould:BaseControllerTest
    {
        [Fact]
        public async Task Return_Error_When_InputIsInvalidForRegister()
        {

            await Assert.ThrowsAsync<NullReferenceException>(async () => await controller.Registration(null));

        }

        [Fact]
        public async Task Return_Error_When_InputIsInvalidForLogin()
        {
            IActionResult response = await controller.UserLogin(null);
            var okObjectResult = Assert.IsType<UnauthorizedObjectResult>(response);

            Assert.True(okObjectResult.StatusCode == 401);
            Assert.Contains("Login Failed", okObjectResult.Value.ToString());
        }

        [Fact]
        public async Task Return_Success_When_InputIsvalidForRegister()
        {
            authenticationManagerMock.Setup(x => x.RegisterAsync(It.IsAny<RegisterRequestDTO>()))
            .ReturnsAsync(

              true
                );

            IActionResult result = await controller.Registration(
                new RegisterRequestDTO
                {
                    Email = "ade@gmail.com",
                    FirstName = "drey",
                    password = "null@bool",
                    LastName = "durake"
                });

           
            var okObjectResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.True(okObjectResult.StatusCode == 201);
            var more = Assert.IsType<string>(okObjectResult.Value);
            Assert.Contains("Registration Successful", more);
        }


        [Fact]
        public async Task Return_Success_When_InputIsvalidForLogin()
        {



            tokenManagerMock.Setup(x => x.GeneratedToken(It.IsAny<string>(), It.IsAny<string>(), DateTime.Now)).Returns("ldsjgfgljfcgflfgdfsgkjhbjkgdfhklfdg");

            authenticationManagerMock.Setup(x => x.LoginAsync(It.IsAny<SigninRequestDTO>()))
                .ReturnsAsync(
                    true
                );




            IActionResult result = await controller.UserLogin(
                new SigninRequestDTO
                {
                    Email = "drey",
                    Password = "null@bool"
                });
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okObjectResult.StatusCode == 200);
            var more = Assert.IsType<LoginTokenData>(okObjectResult.Value);

           
        }
    }
}
