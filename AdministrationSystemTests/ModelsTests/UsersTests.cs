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
            var userId = users.AddUserToDatabase(new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "TestEmail",
                Phone = "TestPhone",
                CourseId = "TestCourseId"
            });

            // act
            User user = users.GetUser(userId);
            users.DeleteUserFromDatabase(userId);

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
            var userId = users.AddUserToDatabase(testUser);

            // act
            users.DeleteUserFromDatabase(userId);
            User user = users.GetUser(userId);

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
                users.DeleteUserFromDatabase("There once was a ship");
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
            var userId = users.AddUserToDatabase(new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "TestEmail",
                Phone = "TestPhone",
                CourseId = "TestCourseId"
            });

            // act
            var ListOfUsers = users.GetAllUsers();

            // assert
            if(ListOfUsers.Count > 0) 
            {
                foreach(var user in ListOfUsers)
                {
                    User tempUser = users.GetUser(user.Id);
                    if(tempUser.Id == null || tempUser.Id == "null")
                    {
                        users.DeleteUserFromDatabase(userId);
                        Assert.Fail("");
                    }
                }
                users.DeleteUserFromDatabase(userId);
            }
            else
            {
                users.DeleteUserFromDatabase(userId);
                Assert.Fail("");
            }
        }

        [Fact]
        public void ModifyUser_Test()
        {
            // arrange
            FirebaseConnection firebaseConnection = new FirebaseConnection();
            Users users = new Users(firebaseConnection);
            var userId = users.AddUserToDatabase(new User()
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
            users.ModifyUser(userId, newUser);
            var user = users.GetUser(userId);
            users.DeleteUserFromDatabase(userId);

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
