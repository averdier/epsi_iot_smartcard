using iotApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iotApi.Repository
{
    public interface IBadgeRepository
    {
        Badge Get(string id);

        List<Badge> GetAll();

        Task<bool> Delete(string id);

        Task<bool> Create(Badge entity);

        Task<bool> Update(Badge entity);
    }
}
