using Microsoft.AspNetCore.Mvc;
using School.Asp.net.Api.Date;
using School.Asp.net.Api.Models;
using School.Asp.net.Api.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Asp.net.Api.Controllers
{
    [Route("[controller]/")]
    public class PupilController:ControllerBase
    {
        IPupilRepository _pupilRepository;
        public PupilController(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }
      
        [HttpGet("GetClass")]
        public async Task<IActionResult> GetClass()
        {
            var getclass = await _pupilRepository.GetClass();

            if(getclass==null)
            {
                return NotFound();
            }

            return Ok(getclass);
        }
        [HttpGet("GetPupil")]
        public async  Task<IActionResult> GetPupil()
        {
            var getpupil = await _pupilRepository.GetPupil();

            if(getpupil==null)
            {
                return NotFound();
            }

            return Ok(getpupil);
        }

        [HttpGet("Getpupil/{pupilid}")]
        public async  Task <IActionResult> GetPupilid(int pupilid)
        {
            var pupil = await _pupilRepository.GetPupilid(pupilid);

            if(pupil==null)
            {
                return NotFound();
            }
            return Ok(pupil);

        }

        [HttpPost]
        public async Task<IActionResult> AddPupil([FromBody] Pupil pupil)
        {

                var pupilid = await _pupilRepository.AddPupil(pupil);
                              
                return Ok(pupilid);
                     
        }

        [HttpDelete("{pupilid}")]
        public async Task<IActionResult>DeletePupil(int pupilid)
        {
            int result = 0;
           
            result= await _pupilRepository.DeletePupil(pupilid);
                       

            return Ok();
        }
        [HttpPut("{id}")]
        public async  Task<IActionResult>UpdatePupil(int id,[FromBody] Pupil pupil)
        {
            if (id == pupil.Pupilid)
            {
               if(ModelState.IsValid)
                {
                    await _pupilRepository.UpdatePupil(pupil);
                }
            return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
