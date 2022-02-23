using AutoMapper;
using BusinessLayer;
using BusinessLayer.Repositories;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelBackEnd.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonelBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Personel> _repository;

        public PersonelController(IMapper mapper, IRepository<Personel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _all = await _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PersonelDto>>(_all));
            //return Ok(_all); // üsteki komutu kullanmamızın nedeni veritabanımızı doğrudan kullanıcıya açmamak.
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(PersonelDto personeldto)
        {
            Personel personel = new Personel
            {
                Name = personeldto.Name,
                Surname = personeldto.Surname,
                Department = personeldto.Department,
            };
            await _repository.AddAsync(personel);
            return Ok(_mapper.Map<Personel>(personel));
        }

        [HttpGet("GetId/{Id}")]
        public async Task<IActionResult> GetId(int Id)
        {
            var personel = await _repository.GetId(Id);
            return Ok(personel);
        }

        [HttpDelete("{Id}")]
         public void DeleteAsync(int Id)
         {
            var personelsil = _repository.GetId(Id).Result;
            _repository.DeleteAsync(personelsil);
         }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(PersonelDto personeldto)
        {
            Personel personel = new Personel
            {
                Id = personeldto.Id,
                Name = personeldto.Name,
                Surname = personeldto.Surname,
                Department = personeldto.Department,
            };
             _repository.UpdateAsync(personel);
            return Ok(personel);
        }
    }
}
