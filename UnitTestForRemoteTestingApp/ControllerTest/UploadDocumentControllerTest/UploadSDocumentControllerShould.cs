using Microsoft.AspNetCore.Mvc;
using Moq;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestForRemoteTestingApp.ControllerTest.UploadDocumentControllerTest
{
    public class UploadSDocumentControllerShould:BaseControllerTest
    {
        [Fact]
        public async Task Return_BadRequest_When_UnableTo_UploadDocuments()
        {
            UploadDocumentMock.Setup(x => x.AddUploadDocumentAsync(It.IsAny<UploadCertificatesRequestDTO>()))
            .ReturnsAsync(
                false
            );

            IActionResult result = await controller.Upload(new UploadCertificatesRequestDTO { });

            var badRequestObject = Assert.IsType<BadRequestObjectResult>(result);
            var more = Assert.IsType<string>(badRequestObject.Value);
            Assert.True(badRequestObject.StatusCode == 400);
            Assert.Contains("Unable to save documents please try again", more);
        }

        [Fact]
        public async Task Return_Success_When_AbleTo_UploadDocuments()
        {
            UploadDocumentMock.Setup(x => x.AddUploadDocumentAsync(It.IsAny<UploadCertificatesRequestDTO>()))
            .ReturnsAsync(
                true
            );

            IActionResult result = await controller.Upload(new UploadCertificatesRequestDTO { });

            var okObject = Assert.IsType<CreatedAtActionResult>(result);
            var more = Assert.IsType<string>(okObject.Value);
            Assert.True(okObject.StatusCode == 201);
            Assert.Contains("Document upload successful", more);
        }


        [Fact]
        public async Task Return_Success_When_AbleTo_GetReview()
        {
            UploadDocumentMock.Setup(x => x.GetUploadedDocumentAsync(It.IsAny<Guid>()))
            .ReturnsAsync(
                new UploadedDocumentResponseDTO
                {
                    Description = "score"
                }
            );

            IActionResult result = await controller.GetDocuments(Guid.NewGuid());

            var createdObject = Assert.IsType<OkObjectResult>(result);
            var more = Assert.IsType<UploadedDocumentResponseDTO>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 200);
            Assert.True(more.Description == "score");
        }


        [Fact]
        public async Task Return_NotFound_When_UnableTo_GetUserPersonal()
        {

            IActionResult result = await controller.GetDocuments(Guid.NewGuid());

            var createdObject = Assert.IsType<NotFoundObjectResult>(result);
            var more = Assert.IsType<string>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 404);
            Assert.Contains("Document not found for this user", more);
        }

    }
}
