using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models.Entities.DTOs;
using WebApplication3.Repositories.CarrRepository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;
        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _repository.GetAllCars();

            var carsToReturn = new List<CarDTO>();

            foreach (var car in cars)
            {
                carsToReturn.Add(new CarDTO(car));
            }

            return Ok(carsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _repository.GetById(id);

            return Ok(new CarDTO(car));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _repository.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound("Car does not exist!");
            }

            _repository.Delete(car);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDTO dto)
        {
            Car newCar = new Car();

            newCar.Brand = dto.Brand;
            newCar.Model = dto.Model;
            newCar.Plates = dto.Plates;
            newCar.SerialNumber = dto.SerialNumber;
            newCar.OwnerId = dto.OwnerId;
            newCar.CubicCap = dto.CubicCap;
     

            _repository.Create(newCar);

            await _repository.SaveAsync();


            return Ok(new CarDTO(newCar));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCar(int id, [FromBody] CreateCarDTO dto)
        {
            Car newCar = new Car();
            newCar.Id = id;
            newCar.Brand = dto.Brand;
            newCar.Model = dto.Model;
            newCar.Plates = dto.Plates;
            newCar.SerialNumber = dto.SerialNumber;
            newCar.OwnerId = dto.OwnerId;
            newCar.CubicCap = dto.CubicCap;


            _repository.Update(newCar);

            await _repository.SaveAsync();


            return Ok(new CarDTO(newCar));
        }
    }
}
