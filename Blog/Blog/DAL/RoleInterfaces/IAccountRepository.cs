using Blog.Models.DTO;
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSite.DAL
{
    public interface IAccountRepository
    {
        IEnumerable<UserProfile> GetUsers();
        UserProfile GetUserById(int userId);
        UserProfile GetUserByName(string username);
        bool UserExists(int userId);
        void CreateUser(UserProfile user);
        void UpdateUser(UserProfile user);
        void DeleteUser(UserProfile user);
        void UploadImage(ImageDto dto);
    }
}
