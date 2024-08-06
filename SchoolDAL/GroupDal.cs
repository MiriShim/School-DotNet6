using SchoolDAL.Model;
using IDAL;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataTransferObjects;
using AutoMapper;

namespace SchoolDAL
{
    
    public class GroupDal : IGroupDal
    {
        
       // private readonly DbContext dbContext;
        


        //public GroupDal(DbContext _dbContext )
        //{
        //       // dbContext= _dbContext;  
        //}

        public bool Add(DataTransferObjects.GroupDTO  entity)
        {
            using Model.UserGittyDbContext ctx = new();

            Mapper.Initialize(
                cnf =>
                    cnf.CreateMap<GroupDTO, UserGroup>()

                    .ReverseMap()
                    .ForMember(m => m.NumberOfMembers, fm => fm.MapFrom(a => a.UserGroupMemberships.Count()))
                
                );
            Model.UserGroup u = Mapper.Map<Model.UserGroup>(entity);

            ctx.UserGroups.Add(u);

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public GroupDTO Get(int id)
        {

            return null;//  ((UserGittyDbContext)dbContext).UserGroups.Find(id);
              //
            //using UserGittyDbContext ctx = new UserGittyDbContext();
            //return ctx.UserGroups.Find(id);
        }

        public List<object> GetAll()
        {
            try
            {
                using UserGittyDbContext ctx = new UserGittyDbContext();
                //גם זה תקין::
                // return ctx.UserGroups.Cast<object >().ToList();  
                //או באמצעות פונקציית לינק פשוטה
                return ctx.UserGroups.Select(a => (object)a).ToList();
            }
            catch { return null; }
        }

        public List<DataTransferObjects.WithMembercGroupDTO> GetAllGroupsWithMembersCounter()
        {
            throw new NotImplementedException();
        }

        public bool Update(object entity)
        {
            throw new NotImplementedException();
        }
    }

    //internal class GroupDal : IDAL.IGeneralDAL<Model.UserGroup>
    //{
    //    public bool Add(UserGroup entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public UserGroup Get(int id)
    //    {
    //         throw new NotImplementedException();
    //    }

    //    public List<UserGroup> GetAll()
    //    {
    //       try
    //        {
    //           using  Model.UserGittyDbContext ctx = new();
    //            return ctx.UserGroups.Include(a=>a.UserGroupMemberships).ToList();

    //        }
    //        catch { return null; }
    //    }
    //    public List<object > GetAllGroupsWithMembersCounter()
    //    {
    //        try
    //        {
    //            using Model.UserGittyDbContext ctx = new();
    //            return ctx.UserGroups.Select(g=>(object)new {g.GroupId,g.GroupName,Counter=g.UserGroupMemberships.Count  }).ToList();

    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public bool Update(UserGroup entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
