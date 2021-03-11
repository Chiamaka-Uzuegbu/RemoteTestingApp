using Microsoft.AspNetCore.Mvc;
using Moq;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestForRemoteTestingApp.ControllerTest.ReviewDocumentControllerTest
{
    public class ReviewDocumentControllerShould:BaseControllerTest
    {
        [Fact]
        public async Task Return_BadRequest_When_UnableTo_Review()
        {
            ReviewDocumentMock.Setup(x => x.CreateReviewDocumentAsync(It.IsAny<ReviewCompanyDocumentRequest>()))
            .ReturnsAsync(
                false
            );

            IActionResult result = await controller.CreateReview(new ReviewCompanyDocumentRequest { });

            var badRequestObject = Assert.IsType<BadRequestObjectResult>(result);
            var more = Assert.IsType<string>(badRequestObject.Value);
            Assert.True(badRequestObject.StatusCode == 400);
            Assert.Contains("Unable to save review", more);
        }

        [Fact]
        public async Task Return_Success_When_AbleTo_CreateReview()
        {
            ReviewDocumentMock.Setup(x => x.CreateReviewDocumentAsync(It.IsAny<ReviewCompanyDocumentRequest>()))
            .ReturnsAsync(
                true
            );

            IActionResult result = await controller.CreateReview(new ReviewCompanyDocumentRequest { });

            var okObject = Assert.IsType<OkObjectResult>(result);
            var more = Assert.IsType<string>(okObject.Value);
            Assert.True(okObject.StatusCode == 200);
            Assert.Contains("Review saved successfully", more);
        }


        [Fact]
        public async Task Return_Success_When_AbleTo_GetReview()
        {
            ReviewDocumentMock.Setup(x => x.GetCompanyDocumentAsync(1))
            .ReturnsAsync(
               new CompanyDocument
               {
                   CompanyPolicy = "hello",
                   TermsAndConditions = "world"

               }
            );

            IActionResult result = await controller.GetCompanyDocument();

            var createdObject = Assert.IsType<OkObjectResult>(result);
            var more = Assert.IsType<CompanyDocument>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 200);
            Assert.True(more.CompanyPolicy == "hello");
        }


        [Fact]
        public async Task Return_NotFound_When_UnableTo_GetUserPersonal()
        {

            IActionResult result = await controller.GetCompanyDocument();

            var createdObject = Assert.IsType<NotFoundObjectResult>(result);
            var more = Assert.IsType<string>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 404);
            Assert.Contains("Unable to find document", more);
        }


    }
}
