using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  
using DataTransferObjects;

namespace IBL
{
    public interface  IUserBL
    {
        int AddNew(UserDTO entity);
        List<UserDTO> GetAll();
    }
}
