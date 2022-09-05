using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models.Entities.DTOs;
using WebApplication3.Repositories.InsurancesRepository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceRepository _repository;
        public InsuranceController(IInsuranceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInsurances()
        {
            var insurances = await _repository.GetAllInsurances();

            var insurancesToReturn = new List<InsuranceDTO>();

            foreach (var insurance in insurances)
            {
                insurancesToReturn.Add(new InsuranceDTO(insurance));
            }

            return Ok(insurancesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceById(int id)
        {
            var Insurance = await _repository.GetById(id);

            return Ok(new InsuranceDTO(Insurance));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var insurance = await _repository.GetByIdAsync(id);

            if (insurance == null)
            {
                return NotFound("Insurance does not exist!");
            }

            _repository.Delete(insurance);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsurance(CreateInsuranceDTO dto)
        {
            Insurance newInsurance = new Insurance();

            newInsurance.Company = dto.Company;
            newInsurance.Price = dto.Price;
            newInsurance.PaymentType = dto.PaymentType;
            newInsurance.CarId = dto.CarId;


            _repository.Create(newInsurance);

            await _repository.SaveAsync();


            return Ok(new InsuranceDTO(newInsurance));
        }
        [HttpPut("{id}")]
    
        public async Task<IActionResult> UpdateInsurance(int id, [FromBody] CreateInsuranceDTO dto)
        {
            Insurance newInsurance = new Insurance();

            newInsurance.Id = id;
            newInsurance.Company = dto.Company;
            newInsurance.Price = dto.Price;
            newInsurance.PaymentType = dto.PaymentType;
            newInsurance.CarId = dto.CarId;


            _repository.Update(newInsurance);

            await _repository.SaveAsync();


            return Ok(new InsuranceDTO(newInsurance));
        }
    }
}
