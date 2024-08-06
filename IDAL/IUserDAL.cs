using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUserDAL 
    {
        public bool Add(UserDTO  entity);
        public UserDTO Get(int id);
        public List<UserDTO> GetAll();
        public bool Update(UserDTO entity);
        public bool Delete(int id);
    }
}
