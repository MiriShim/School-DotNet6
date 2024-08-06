using AutoMapper;
using AutoMapper.XpressionMapper.Extensions;
using DataTransferObjects;
using IDAL;
using Microsoft.Data.SqlClient;
using SchoolDAL.Model;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolDAL
{
    public class UserDal :  IDAL.IUserDAL 
    {
        //   public bool Add(User user)
        //   {
        //       try {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           ctx.Users.Add(user);
        ////האם יש הבדל???           ctx.Add(user);
        //           ctx.SaveChanges();
        //           return true;
        //       }
        //       catch {
        //           return false;
        //       }

        //   }

        //   public List<User> GetAll()
        //   {
        //       try
        //       {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           List<User> users = new List<User>();
        //           users.AddRange(ctx.Users);
        //           return users;
        //       }
        //       catch
        //       {
        //           return null;
        //       }
        //   }

        //   public User Get(int id)
        //   {

        //       try {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //            User user = ctx.Users.Find(id);
        //           return user;
        //       }
        //       catch {
        //           return null;
        //       }
        //       throw new NotImplementedException();
        //   }

        //   public bool Delete(int id)
        //   {
        //       try
        //       {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           User user = ctx.Users.Find(id);
        //           ctx.Users.Remove(user);
        //           ctx.SaveChanges();
        //           return true;
        //       }

        //       catch
        //       {
        //           return false;
        //       }

        //   }
        //   public bool Update(User user)
        //   {
        //       try
        //       {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           int id = user.UserId;
        //           User oldUser = ctx.Users.Find(id);
        //           //
        //           oldUser = ctx.Users.Find(id);
        //          // ctx.Users.FindUpdate.Find(id)(user);
        //           //
        //           ctx.SaveChanges();
        //           return true;
        //       }

        //       catch
        //       {
        //           return false;
        //       }
        //   }        
         

        public bool Add(UserDTO entity)
        {
            try
            {
                using Model.UserGittyDbContext ctx = new();
                 
                Mapper.Initialize(
                    cnf =>
                        cnf.CreateMap<UserDTO, User>()
                        .ForMember(m => m.PasswordHash,
                                p => p.MapFrom(a => a.Password))
                        .ReverseMap()
                        .ForMember(m=>m.YearCreated,
                                p=>p.MapFrom(a=>a.CreatedAt.Value.Year ))                      
                    );
                Model.User u = Mapper.Map<Model.User>(entity);

                ctx.Users.Add(u);
                return true;
            }
             catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO Get(int id)
        {
            try
            {
                using Model.UserGittyDbContext ctx = new();
                MapperConfiguration configuration = new MapperConfiguration
                    (
                    cnf => cnf.CreateMap<User, UserDTO>()
                    );
                UserDTO u = Mapper.Map<UserDTO>(ctx.Users.Find(id));

                return u;
            } 
           
            catch (SqlException sqlEx)
            {
                throw;
            }
            catch (AutoMapper.AutoMapperConfigurationException) { throw; }
            catch (AutoMapper.AutoMapperMappingException) { throw; }
            catch (Exception e)
            {
                throw new Exception($"ארעה שגיאה ב- {typeof(UserDal)}", e);
            }
        }
     

        public List<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
