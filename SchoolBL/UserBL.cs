﻿ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.ComponentModel;
using System.Reflection;
using DataTransferObjects;

namespace SchoolBL
{
    public class UserBL : IBL.IUserBL
    {
        private readonly IDAL.IUserDAL iUserDal;

        public UserBL(IUserDAL dal)
        {
            iUserDal = dal;
        }

        public int AddNew(UserDTO user)
        {

            iUserDal.Add(user);
            /////////////
            Type entityType = user.GetType();

            PropertyInfo pi = entityType.GetProperty("Id");
            if (pi != null)
                return (int)pi.GetValue(user);

            return 0;
        }

        public List<UserDTO> GetAll()
        {
            return iUserDal .GetAll().Select(a=>(UserDTO)a).ToList() ;
        }

        //public User Get(int id)
        //{
        //    if (id != 0)
        //    {
        //        return   iUserDal .Get(id);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public List<User> GetAll()
        //{
        //    return new UserDal().GetAll();
        //}

        //public bool Add(User user)
        //{
        //    return new UserDal().Add(user);
        //}

        //public bool Delete(int id)
        //{
        //    return new UserDal().Delete(id);
        //}

        //public bool Update(User user)
        //{
        //    return new UserDal().Update(user);
        //}
    }
}