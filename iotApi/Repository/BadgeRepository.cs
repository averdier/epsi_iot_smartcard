using iotApi.Context;
using iotApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iotApi.Repository
{
    public class BadgeRepository:  IBadgeRepository
    {
        private IotContext _ctx;

        public BadgeRepository(IotContext ctx)
        {
            this._ctx = ctx;
        }

        public Badge Get(string id)
        {
            return _ctx.Badges.Find(id);
        } 

        public List<Badge> GetAll()
        {
            return _ctx.Badges.ToList();
        }

        public async Task<bool> Delete(string id)
        {
            var ent = _ctx.Badges.Find(id);
            if (ent != null)
            {
                _ctx.Badges.Remove(ent);
                return await _ctx.SaveChangesAsync() > 0;
            } else
            {
                throw new Exception("User doesn't exist");
            }
        }

        public async Task<bool> Create(Badge entity)
        {
            _ctx.Badges.Add(entity);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Badge entity)
        {
            var ent = _ctx.Badges.Find(entity.Id);
            if (ent != null)
            {
                ent.IdSkype = entity.IdSkype;
                ent.Mail = entity.Mail;
                ent.Nom = entity.Nom;
                ent.Img = entity.Img;
                ent.Prenom = entity.Prenom;
                _ctx.Badges.Update(ent);
                return await _ctx.SaveChangesAsync() > 0;
            } else
            {
                throw new Exception("User doesn't exist");
            }
        }
    }
}
