using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Entities.DTOs;
using WebApplication3.Repositories.OwnerrRepository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        //includem repository in owner pt a-l putea folosi
        private readonly IOwnerRepository _repository;
        public OwnerController(IOwnerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _repository.GetAllOwners();

            var ownersToReturn = new List<OwnerDTO>();

            foreach (var owner in owners)
            {
                ownersToReturn.Add(new OwnerDTO(owner));
            }

            return Ok(ownersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _repository.GetById(id);

            return Ok(new OwnerDTO(author));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _repository.GetByIdAsync(id);

            if (owner == null)
            {
                return NotFound("Owner does not exist!");
            }

            _repository.Delete(owner);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateOwnerDTO dto)
        {
            Owner newOwner = new Owner();

            newOwner.FirstName = dto.FirstName;
            newOwner.LastName = dto.LastName;
            newOwner.Gender = dto.Gender;
            newOwner.Age = dto.Age;

            _repository.Create(newOwner);

            await _repository.SaveAsync();


            return Ok(new OwnerDTO(newOwner));
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] OwnerDTO dto)
        {
            _repository.Owner.UpdateOwner(id, dto);

            await _repository.SaveAsync();

            return Ok(dto);
        }





    }

}