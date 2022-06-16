using CarRentalSystem.Business.Responses;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Abstract
{
    public interface IUserService
    {
        IResponse Register(RegisterDto user);
        IResponse LoginAsync(LoginDto user);
        IDataResponse<List<User>> GetUsers();
        Task<User> GetByMail(string email);
        IResponse Delete(User user);
        IResponse ResetPassword(User user);
        IResponse UpdatePassword(User user,string currentPassword, string newPassword);
        IResponse Update(User user);    
        IResponse Add(User user);
        IDataResponse<User> GetAdminUser();
        IDataResponse<User> GetUserById(int id);
        Task<IDataResponse<User>> GetAdminUserAsync();
        IDataResponse<bool> CheckUserInfo(User user);
        IDataResponse<List<UserInfoDto>> GetUsersInfo();
   
    }
}
