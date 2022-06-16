using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Constants;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.Business.ValidationRules;
using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResponse Register(RegisterDto user)
        {
            var validationResult = ValidationTool.Validate<RegisterValidator>(user);
            if (validationResult.Count>0)
            {
                return Response.Fail(Messages.RegistrationFailed,validationResult);
            }
            else
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                _userDal.Add(new User { Name = user.Name, Surname = user.Surname, Email = user.Email, PasswordHash = passwordHash, PasswordSalt = passwordSalt, SecurityQuestion = user.SecurityQuestion, SecurityQuestionAnswer = user.SecurityQuestionAnswer, Address = user.Address, IdentityNumber = user.IdentityNumber, PhoneNumber = user.PhoneNumber, RoleId = user.RoleId });
                return Response.Success(Messages.RegisterSuccesful);
            }


            
          
        }
        
        public IDataResponse<List<User>> GetUsers()
        {
             return Response<List<User>>.Success(_userDal.GetAll(x => x.UserId != LoginCache.User.UserId && x.State == true));
          
        }

        public IResponse LoginAsync(LoginDto user)
        {
           var validationResult =  ValidationTool.Validate<LoginValidator>(user);
            if (validationResult.Count > 0)
            {
               return Response.Fail(Messages.LoginFailed,validationResult);
            }

           var userForLogin =  CheckIfEmailExists(user.Email);
            if (userForLogin.IsSuccesful)
            {

                var result = HashingHelper.VerifyPasswordHash(user.Password, userForLogin.Data.PasswordHash, userForLogin.Data.PasswordSalt);
                if (result)
                {
                    return Response.Success(Messages.LoginSuccesful);
                }
                else
                {
                    return Response.Fail(Messages.LoginFailed);
                }
            }
            else
            {
                return Response.Fail(userForLogin.Errors);
            }



        }
        User user;
        private IDataResponse<User> CheckIfEmailExists(string email) 
        {
            
            var userForLogin =  _userDal.Get(u => u.Email.Equals(email) && u.State == true);
            if (userForLogin == null)
            {
                return Response<User>.Fail(null,new List<string> { "Email adresinizi kontrol ediniz" });
            }
            return Response<User>.Success(userForLogin);

        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.GetAsync(u => u.Email == email && u.State == true);
        }

        public IResponse Delete(User user)
        {
            _userDal.Delete(user);
            return Response.Success();
        }
       

        
        public IResponse ResetPassword(User user)
        {
            var userForReset = _userDal.Get(u=>u.Email == user.Email && u.SecurityQuestion == user.SecurityQuestion && u.SecurityQuestionAnswer == user.SecurityQuestionAnswer);
            if (userForReset == null)
            {
                return Response.Fail(new List<string> {Messages.UserNotFound});
            }
            else
            {
                byte[] passwordHash, passwordSalt;
                var random = RandomPassword();
                HashingHelper.CreatePasswordHash(random, out passwordHash, out passwordSalt);
                userForReset.PasswordHash = passwordHash;
                userForReset.PasswordSalt = passwordSalt;
                _userDal.Update(userForReset);
                MailHelper.SendMail(user.Email, "Şifre Sıfırlama", $"Şifreniz Başarı ile sıfırlanmıştır. Mail adresinizi kontrol edin {random}");
                // _userDal.SendMail(user.Email, random);
               return Response.Success(Messages.SuccesfullyReset);
            }

        }

        private string RandomPassword() 
        {
            int i = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder randomPassword = new StringBuilder();
            Random rnd = new Random();
            while (0 < i--)
            {
                randomPassword.Append(valid[rnd.Next(valid.Length)]);
            }
            return randomPassword.ToString();

        }

        public IResponse UpdatePassword(User user, string currentPassword, string newPassword)
        {
           var result= HashingHelper.VerifyPasswordHash(currentPassword, user.PasswordHash, user.PasswordSalt);
            if (result)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _userDal.Update(user);
                return Response.Success(Messages.SuccesfullyReset);

            }
            else
            {
                return Response.Fail(new List<string> {"hata oldu"});
            }
           

            

        }

        public IResponse Update(User user)
        {
            _userDal.Update(user);
            return Response.Success();
        }


      
        public IResponse Add(User user)
        {
            var validationResult = ValidationTool.Validate<UserValidator>(user);
            if (validationResult.Count > 0)
            {
                return Response.Fail(Messages.RegistrationFailed, validationResult);
            }
            else
            {
                byte[] passwordHash, passwordSalt;
                var random = RandomPassword();
                HashingHelper.CreatePasswordHash(random, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _userDal.Add(user);
                MailHelper.SendMail(user.Email, "Arac Kiralama Kayıt", $"Kaydınız başarı ile gerçekleşti. Şifreniz: {random}");
                return Response.Success(Messages.RegisterSuccesful);
            }
            

        }

        public IDataResponse<User> GetAdminUser()
        {
           return Response<User>.Success(_userDal.Get(u=>u.RoleId == 1));
        }

        public IDataResponse<User> GetUserById(int id)
        {
            return Response<User>.Success(_userDal.Get(u=>u.UserId == id));
        }

        public async Task<IDataResponse<User>> GetAdminUserAsync()
        {
            var result = await _userDal.GetAsync(u => u.RoleId == 1);
            return Response<User>.Success(result);
        }

        public IDataResponse<bool> CheckUserInfo(User user)
        {
            if (user.SecurityQuestion== null)
            {
                return Response<bool>.Fail(false, new List<string> {""});

            }
            return Response<bool>.Success(false,"");

        }

        public IDataResponse<List<UserInfoDto>> GetUsersInfo()
        {
            return Response<List<UserInfoDto>>.Success(_userDal.GetUsers());
        }
    }
}
