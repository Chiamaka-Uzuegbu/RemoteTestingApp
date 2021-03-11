using Microsoft.Extensions.Configuration;
using Moq;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Controllers;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.ReviewRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForRemoteTestingApp.ControllerTest.ReviewDocumentControllerTest
{
    public class BaseControllerTest
    {
        protected Mock<IFileLogger> fileLogerMock;
        protected Mock<IReviewDocumentRepository> ReviewDocumentMock;
        protected Mock<ITokenProvider> tokenManagerMock;
        protected Mock<IConfiguration> configMock;
        protected ReviewDocumentController controller;

        protected BaseControllerTest()
        {
            fileLogerMock = new Mock<IFileLogger>();
            ReviewDocumentMock = new Mock<IReviewDocumentRepository>();
            tokenManagerMock = new Mock<ITokenProvider>();
            configMock = new Mock<IConfiguration>();


            controller = new ReviewDocumentController(fileLogerMock.Object, ReviewDocumentMock.Object, tokenManagerMock.Object);

        }
    }
}
