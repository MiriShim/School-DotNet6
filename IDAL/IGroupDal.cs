using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public  interface IGroupDal   
    {
        public bool Add(GroupDTO  entity);
        public GroupDTO  Get(int id);


        List<DataTransferObjects.WithMembercGroupDTO> GetAllGroupsWithMembersCounter();
    }
}
