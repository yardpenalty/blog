using Blog.Models.DTO;
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace BlogSite.DAL
{
    public class AccountRepository : IAccountRepository
    {
        private UsersContext context = new UsersContext();
        
        public IEnumerable<UserProfile> GetUsers()
        {
            return context.Users.ToList();
        }

         public UserProfile GetUserById(int userId)
        {
            UserProfile user = context.Users.Where<UserProfile>(p => p.UserId == userId).FirstOrDefault<UserProfile>();
            return user;
        }

         public UserProfile GetUserByName(string name)
         {
             UserProfile user = context.Users.Where<UserProfile>(p => p.UserName.ToLower() == name.ToLower()).FirstOrDefault<UserProfile>();
             return user;
         }

        public  void UpdateUser(UserProfile user)
        {
            context.Entry(user).State = EntityState.Modified;
            this.Save();
        }

        public void UploadImage(ImageDto dto)
        {
            var destinationFolder = System.Web.Hosting.HostingEnvironment.MapPath("~\\content\\Avatars");
            var postedFile = dto.Picture;
            if (postedFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(dto.ImageId + ".jpg");
                var path = Path.Combine(destinationFolder, fileName);
                postedFile.SaveAs(path);
            }
        }

        public void CreateUser(UserProfile user)
        {
            this.context.Users.Add(user);
            this.Save();
        }

        public bool UserExists(int userId)
        {
            UserProfile user = context.Users.Where<UserProfile>(p => p.UserId == userId).FirstOrDefault<UserProfile>();
            return user != null;
        }

        public void DeleteUser(UserProfile user)
        {
            UserProfile deletedUser = context.Users.Find(user.UserId);
            context.Users.Remove(deletedUser);
            this.Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}