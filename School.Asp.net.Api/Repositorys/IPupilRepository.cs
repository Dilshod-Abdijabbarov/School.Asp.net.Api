using School.Asp.net.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Asp.net.Api.Repositorys
{
    public interface IPupilRepository
    {
        Task<List<Class>> GetClass();

        Task<List<Pupil>> GetPupil();

        Task<Pupil> GetPupilid(int pupilid);

        Task<int> AddPupil(Pupil pupil);

        Task<int> DeletePupil(int pupilid);

        Task UpdatePupil(Pupil pupil);
    }
}
