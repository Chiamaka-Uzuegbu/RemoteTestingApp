using Microsoft.Extensions.Configuration;
using Moq;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Controllers;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForRemoteTestingApp.ControllerTest.AuthenticationControllerTest
{
    public class BaseControllerTest
    {
        protected Mock<IFileLogger> fileLogerMock;
        protected Mock<IAuthenticationRepository> authenticationManagerMock;
        protected Mock<ITokenProvider> tokenManagerMock;
        protected Mock<IConfiguration> configMock;
        protected AuthenticationController controller;

        protected BaseControllerTest()
        {
            fileLogerMock = new Mock<IFileLogger>();
            authenticationManagerMock = new Mock<IAuthenticationRepository>();
            tokenManagerMock = new Mock<ITokenProvider>();
            configMock = new Mock<IConfiguration>();


            controller = new AuthenticationController(fileLogerMock.Object, authenticationManagerMock.Object, tokenManagerMock.Object);

        }
    }
}
