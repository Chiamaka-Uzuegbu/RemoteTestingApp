using Microsoft.Extensions.Configuration;
using Moq;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Controllers;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForRemoteTestingApp.ControllerTest.PersonalDetailsControllerTest
{
    public class BaseControllerTest
    {
        protected Mock<IFileLogger> fileLogerMock;
        protected Mock<IPersonalDetailsRepository> PersonalDetailsMock;
        protected Mock<ITokenProvider> tokenManagerMock;
        protected Mock<IConfiguration> configMock;
        protected PersonalDetailsController controller;

        protected BaseControllerTest()
        {
            fileLogerMock = new Mock<IFileLogger>();
            PersonalDetailsMock = new Mock<IPersonalDetailsRepository>();
            tokenManagerMock = new Mock<ITokenProvider>();
            configMock = new Mock<IConfiguration>();


            controller = new PersonalDetailsController(fileLogerMock.Object, PersonalDetailsMock.Object, tokenManagerMock.Object);

        }
    }
}
