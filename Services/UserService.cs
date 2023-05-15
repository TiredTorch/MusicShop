using MusicShopc.Models;

namespace MusicShopc.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        DateOfBirth = new DateTime(1990, 5, 15),
        Password = "pass123",
        LastLoginDate = DateTime.Now.AddDays(-7),
        FailedLoginAttempts = 0
    },
    new User
    {
        FirstName = "Jane",
        LastName = "Smith",
        Email = "jane.smith@example.com",
        DateOfBirth = new DateTime(1985, 12, 10),
        Password = "password123",
        LastLoginDate = DateTime.Now.AddDays(-3),
        FailedLoginAttempts = 2
    },
    new User
    {
        FirstName = "Mike",
        LastName = "Johnson",
        Email = "mike.johnson@example.com",
        DateOfBirth = new DateTime(1992, 8, 22),
        Password = "securepass",
        LastLoginDate = DateTime.Now.AddDays(-1),
        FailedLoginAttempts = 0
    },
    new User
    {
        FirstName = "Emily",
        LastName = "Brown",
        Email = "emily.brown@example.com",
        DateOfBirth = new DateTime(1998, 4, 5),
        Password = "test123",
        LastLoginDate = DateTime.Now.AddDays(-4),
        FailedLoginAttempts = 1
    },
    new User
    {
        FirstName = "Michael",
        LastName = "Wilson",
        Email = "michael.wilson@example.com",
        DateOfBirth = new DateTime(1987, 9, 18),
        Password = "mypass",
        LastLoginDate = DateTime.Now.AddDays(-2),
        FailedLoginAttempts = 0
    },
    new User
    {
        FirstName = "Sophia",
        LastName = "Taylor",
        Email = "sophia.taylor@example.com",
        DateOfBirth = new DateTime(1993, 6, 30),
        Password = "password456",
        LastLoginDate = DateTime.Now.AddDays(-6),
        FailedLoginAttempts = 0
    },
    new User
    {
        FirstName = "David",
        LastName = "Anderson",
        Email = "david.anderson@example.com",
        DateOfBirth = new DateTime(1989, 3, 12),
        Password = "pass321",
        LastLoginDate = DateTime.Now.AddDays(-5),
        FailedLoginAttempts = 3
    },
    new User
    {
        FirstName = "Olivia",
        LastName = "Clark",
        Email = "olivia.clark@example.com",
        DateOfBirth = new DateTime(1995, 11, 25),
        Password = "securepass456",
        LastLoginDate = DateTime.Now.AddDays(-2),
        FailedLoginAttempts = 0
    },
    new User
    {
        FirstName = "Daniel",
        LastName = "Martin",
        Email = "daniel.martin@example.com",
        DateOfBirth = new DateTime(1991, 2, 8),
        Password = "mypassword",
        LastLoginDate = DateTime.Now.AddDays(-3),
        FailedLoginAttempts = 0
    },
            };
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.Find(user => user.Id == id);
        }

        public User CreateUser(User user)
        {
            user.Id = GenerateUniqueId();
            _users.Add(user);
            return user;
        }

        public void UpdateUser(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
                _users[index] = user;
        }

        public void DeleteUser(int id)
        {
            _users.RemoveAll(user => user.Id == id);
        }

        private int GenerateUniqueId()
        {
            return _users.Count + 1;
        }
    }


}
