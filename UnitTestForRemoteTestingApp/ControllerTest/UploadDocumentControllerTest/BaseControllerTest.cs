using Microsoft.Extensions.Configuration;
using Moq;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Controllers;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.DocumentUploadRepository;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForRemoteTestingApp.ControllerTest.UploadDocumentControllerTest
{
    public class BaseControllerTest
    {
        protected Mock<IFileLogger> fileLogerMock;
        protected Mock<IUploadDocumentRepository> UploadDocumentMock;
        protected Mock<ITokenProvider> tokenManagerMock;
        protected Mock<IConfiguration> configMock;
        protected UploadDocumentsController controller;

        protected BaseControllerTest()
        {
            fileLogerMock = new Mock<IFileLogger>();
            UploadDocumentMock = new Mock<IUploadDocumentRepository>();
            tokenManagerMock = new Mock<ITokenProvider>();
            configMock = new Mock<IConfiguration>();


            controller = new UploadDocumentsController(fileLogerMock.Object, UploadDocumentMock.Object, tokenManagerMock.Object);

        }
    }
}
