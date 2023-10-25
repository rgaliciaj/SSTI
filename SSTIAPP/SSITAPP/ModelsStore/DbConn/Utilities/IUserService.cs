using ModelsStore.DTO.Models;
using ModelsStore.DTO.PARAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsStore.DbConn.Utilities
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest request);
    }
}
