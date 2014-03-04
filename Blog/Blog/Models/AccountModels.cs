using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using WebMatrix.WebData;

namespace BlogSite.Models
{

    [Table("UserProfile")]
    public class UserProfile
    {
        //ctor
        public UserProfile()
        {
            Random rnd = new Random();
            int pic = rnd.Next(1, 6); 

            DateJoined = DateTime.Now;
            UserLevel = 4;
            ImageUrl = "/Content/Avatars/Samples/sample" + pic + ".jpg"; // or append &#46;jpg which == .jpg
        }

        public UserProfile(string name, string url)
        {
            UserName = name;
            DateJoined = DateTime.Now;
            UserLevel = 4;
            ImageUrl = url;
            Email = "your@email.com";
        }

        public UserProfile(string name, string url, string email)
        {
            Random rnd = new Random();
            int pic = rnd.Next(1, 6);
            UserName = name;
            DateJoined = DateTime.Now;
            UserLevel = 4;
            ImageUrl = "/Content/Avatars/sample" + pic + ".jpg"; // or append &#46;jpg which == .jpg
            Email = email;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(ErrorMessage="*Username is required."), RegularExpression(@"^[\p{L} \p{Nd}_]+$")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long and no bigger than {1} characters.", MinimumLength = 5), MinLength(5,ErrorMessage="Not enough characters!")]
        public string UserName { get; set; }
        [Required(ErrorMessage="*Email is required."), EmailAddress, RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [ScaffoldColumn(false),Required]
        public string ImageUrl { get; set; }
        [DisplayFormat(DataFormatString = "{0}")] //{0:d} or {0:D}
        [DataType(DataType.DateTime), Timestamp, ScaffoldColumn(false)]
        public DateTime DateJoined { get; set; }
        [Range(1, 6), ScaffoldColumn(false)]
        public int UserLevel { get; set; }
        [ScaffoldColumn(false)]
        public int? TotalRepPoints { get; set; }
        // int = CategoryId, int = TotalPointsByCat
        [ScaffoldColumn(false)]
        public virtual IDictionary<int, int> TotalPointsByCat { get; set; }
        // int = CategoryId, int = UserRank
        public virtual IDictionary<int, int> Rankings { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
         //ctor
        public RegisterModel()
        {
            DateJoined = DateTime.Now;
            ImageUrl = "/Content/Avatars/" + this.UserName;
            UserLevel = 1;
        }

        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long and no bigger than {1} characters.", MinimumLength = 5)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required, EmailAddress, RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public string ImageUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0}")] //{0:d} or {0:D}
        [DataType(DataType.DateTime), Timestamp]
        [ScaffoldColumn(false)]
        public DateTime DateJoined { get; set; }
        [Range(1, 6), ScaffoldColumn(false)]
        public int UserLevel { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    //[Table("webpages_Membership")]
    //public class Membership : MembershipUser
    //{
    //    public Membership()
    //    {
    //        Roles = new List<Role>();
    //        OAuthMemberships = new List<OAuthMembership>();
    //        CreateDate = DateTime.Now;
    //    }

    //    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int UserId { get; set; }
    //    public DateTime? CreateDate { get; set; }
    //    [StringLength(128)]
    //    public string ConfirmationToken { get; set; }
    //    public bool? IsConfirmed { get; set; }
    //    public DateTime? LastPasswordFailureDate { get; set; }
    //    public int PasswordFailuresSinceLastSuccess { get; set; }
    //    [Required, StringLength(128)]
    //    public string Password { get; set; }
    //    public DateTime? PasswordChangedDate { get; set; }
    //    [Required, StringLength(128)]
    //    public string PasswordSalt { get; set; }
    //    [StringLength(128)]
    //    public string PasswordVerificationToken { get; set; }
    //    public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

    //    public ICollection<Role> Roles { get; set; }

    //    [ForeignKey("UserId")]
    //    public ICollection<OAuthMembership> OAuthMemberships { get; set; }
    //}

    //[Table("webpages_OAuthMembership")]
    //public class OAuthMembership
    //{
    //    [Key, Column(Order = 0), StringLength(30)]
    //    public string Provider { get; set; }

    //    [Key, Column(Order = 1), StringLength(100)]
    //    public string ProviderUserId { get; set; }

    //    public int UserId { get; set; }

    //    [Column("UserId"), InverseProperty("OAuthMemberships")]
    //    public Membership User { get; set; }
    //}

    //[Table("webpages_Roles")]
    //public class Role
    //{
    //    public Role()
    //    {
    //        Members = new List<Membership>();
    //    }

    //    [Key]
    //    public int RoleId { get; set; }
    //    [StringLength(256)]
    //    public string RoleName { get; set; }

    //    public ICollection<Membership> Members { get; set; }
    //}

  
}
