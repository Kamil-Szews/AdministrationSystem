using AdministrationSystem.Data;
using AdministrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ModelsTests
{
    public class UsersTests
    {
        [Fact]
        public void AddAndGetUser_Test()
        {
            // arrange
            FirebaseConnection firebaseConnection = new FirebaseConnection();
            Users users = new Users(firebaseConnection);
            var userId = users.Add(new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "TestEmail",
                Phone = "TestPhone",
                CourseId = "TestCourseId"
            });

            // act
            User user = users.Get(userId);
            users.Delete(userId);

            // assert
            Assert.Equal(userId, user.Id);
            Assert.Equal("TestName", user.Name);
            Assert.Equal("TestSurname", user.Surname);
            Assert.Equal("TestEmail", user.Email);
            Assert.Equal("TestPhone", user.Phone);
            Assert.Equal("TestCourseId", user.CourseId);
        }

        // with existing Id
        [Fact]
        public void DeleteUserFromDatabase1_Test()
        {
            // arrange
            FirebaseConnection firebaseConnection = new FirebaseConnection();
            Users users = new Users(firebaseConnection);
            User testUser = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "TestEmail",
                Phone = "TestPhone",
                CourseId = "TestCourseId"
            };
            var userId = users.Add(testUser);

            // act
            users.Delete(userId);
            User user = users.Get(userId);

            // assert
            Assert.Null(user.Id);
            Assert.Null(user.Name);
            Assert.Null(user.Surname);
            Assert.Null(user.Email);
            Assert.Null(user.Phone);
            Assert.Null(user.CourseId);
        }

        // with non-existent Id
        [Fact]
        public void DeleteUserFromDatabase2_Test()
        {
            // arrange
            FirebaseConnection firebaseConnection = new FirebaseConnection();
            Users users = new Users(firebaseConnection);

            // act
            try
            {
                users.Delete("There once was a ship");
            }
            
            // assert
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void GetAllUsers_Test()
        {
            // arrange
            FirebaseConnection firebaseConnection = new FirebaseConnection();
            Users users = new Users(firebaseConnection);
            var userId = users.Add(new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "TestEmail",
                Phone = "TestPhone",
                CourseId = "TestCourseId"
            });

            // act
            var ListOfUsers = users.GetAll();

            // assert
            if(ListOfUsers.Count > 0) 
            {
                foreach(var user in ListOfUsers)
                {
                    User tempUser = users.Get(user.Id);
                    if(tempUser.Id == null || tempUser.Id == "null")
                    {
                        users.Delete(userId);
                        Assert.Fail("");
                    }
                }
                users.Delete(userId);
            }
            else
            {
                users.Delete(userId);
                Assert.Fail("");
            }
        }

        [Fact]
        public void ModifyUser_Test()
        {
            // arrange
            FirebaseConnection firebaseConnection = new FirebaseConnection();
            Users users = new Users(firebaseConnection);
            var userId = users.Add(new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "TestEmail",
                Phone = "TestPhone",
                CourseId = "TestCourseId"
            });
            User newUser = new User()
            {
                Name = "TestNameNew",
                Surname = "TestSurnameNew",
                Email = "TestEmailNew",
                Phone = "TestPhoneNew",
                CourseId = "TestCourseIdNew"
            };

            // act
            users.Modify(userId, newUser);
            var user = users.Get(userId);
            users.Delete(userId);

            // assert
            Assert.Equal(userId, user.Id);
            Assert.Equal("TestNameNew", user.Name);
            Assert.Equal("TestSurnameNew", user.Surname);
            Assert.Equal("TestEmailNew", user.Email);
            Assert.Equal("TestPhoneNew", user.Phone);
            Assert.Equal("TestCourseIdNew", user.CourseId);
        }
    }
}
