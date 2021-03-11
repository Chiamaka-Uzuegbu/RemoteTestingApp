using Microsoft.AspNetCore.Mvc;
using Moq;
using RemoteTestingApp.Core.DTOs.Request;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestForRemoteTestingApp.ControllerTest.PersonalDetailsControllerTest
{
   public class PersonalDetailsControllerShould:BaseControllerTest
    {

        [Fact]
        public async Task Return_BadRequest_When_UnableTo_CreateUser()
        {
            PersonalDetailsMock.Setup(x => x.CreatePersonalDetailAsync(It.IsAny<PersonalDetailsRequestDTO>()))
            .ReturnsAsync(
                (false,default)
            );

            IActionResult result= await controller.CreatePersonalDetails(new PersonalDetailsRequestDTO { });

            var badRequestObject = Assert.IsType<BadRequestObjectResult>(result);
            var more = Assert.IsType<string>(badRequestObject.Value);
            Assert.True(badRequestObject.StatusCode == 400);
            Assert.Contains("Unable to Create User", more);
        }

        [Fact]
        public async Task Return_Success_When_AbleTo_CreateUser()
        {
            PersonalDetailsMock.Setup(x => x.CreatePersonalDetailAsync(It.IsAny<PersonalDetailsRequestDTO>()))
            .ReturnsAsync(
                (true, Guid.NewGuid())
            );

            IActionResult result = await controller.CreatePersonalDetails(new PersonalDetailsRequestDTO { });

            var createdObject = Assert.IsType<CreatedAtActionResult>(result);
            var more = Assert.IsType<string>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 201);
            Assert.Contains("User Details Created Successfully", more);
        }


        [Fact]
        public async Task Return_Success_When_AbleTo_GetUserPersonal()
        {
            PersonalDetailsMock.Setup(x => x.GetPersonalDetailAsync(It.IsAny<Guid>()))
            .ReturnsAsync(
                new PersonalDetailsRequestDTO
                {
                    FirstName = "Hello"
                }
            );

            IActionResult result = await controller.GetPersonalDetail(Guid.NewGuid());

            var createdObject = Assert.IsType<OkObjectResult>(result);
            var more = Assert.IsType<PersonalDetailsRequestDTO>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 200);
            Assert.True(more.FirstName == "Hello");
        }


        [Fact]
        public async Task Return_NotFound_When_UnableTo_GetUserPersonal()
        {

            IActionResult result = await controller.GetPersonalDetail(Guid.NewGuid());

            var createdObject = Assert.IsType<NotFoundObjectResult>(result);
            var more = Assert.IsType<string>(createdObject.Value);
            Assert.True(createdObject.StatusCode == 404);
            Assert.Contains("Details Not Found", more);
        }



    }
}
