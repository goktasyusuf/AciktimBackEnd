using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IMenuDal:IEntityRepository<Menu>
    {
        List<MenuDetailsDto> GetMenusByRestaurantId(string restaurantId);
    }
}
