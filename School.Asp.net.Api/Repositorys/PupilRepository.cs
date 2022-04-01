using Microsoft.EntityFrameworkCore;
using School.Asp.net.Api.Date;
using School.Asp.net.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Asp.net.Api.Repositorys
{
    public class PupilRepository : IPupilRepository
    {
        SchoolDbContext _context;
        public PupilRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async  Task<int> AddPupil(Pupil pupil)
        {
            await _context.Pupil.AddAsync(pupil);

            await _context.SaveChangesAsync();

            return pupil.Pupilid;
        }

        public async  Task<int> DeletePupil(int pupilid)
        {
            int result = 0;

            var pupil = await _context.Pupil.FirstOrDefaultAsync(x => x.Pupilid == pupilid);
           
            if(pupil!=null)
            {
                _context.Remove(pupil);

                _context.SaveChanges();

                result = await _context.SaveChangesAsync();
            }
                return result;            
        }

        public async  Task<List<Class>> GetClass()
        {
           if(_context!=null)
            {
                return await _context.Class.ToListAsync();
            }
            return null;
        }

        public async  Task<List<Pupil>> GetPupil()
        {
            if(_context!=null)
            {
                return await (from p in _context.Pupil
                              from c in _context.Class
                              where p.Classid == c.Classid
                              select new Pupil
                              {
                                  Pupilid = p.Pupilid,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  Address = p.Address,
                                  PhoneNumer = p.PhoneNumer,
                                  Classid = p.Classid
                              }).ToListAsync();
            }
            return null;
        }

        public async  Task<Pupil> GetPupilid(int pupilid)
        {
           if(_context!=null)
            {
                return await (from p in _context.Pupil
                              from c in _context.Class
                              where p.Pupilid == pupilid
                              select new Pupil
                              {
                                  Pupilid = p.Pupilid,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  Address = p.Address,
                                  PhoneNumer = p.PhoneNumer,
                                  Classid = p.Classid
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async  Task UpdatePupil(Pupil pupil)
        {
            if(_context!=null)
            {
                              
                    _context.Pupil.Update(pupil);
                    await _context.SaveChangesAsync();
                
            }
        }
    }
}
