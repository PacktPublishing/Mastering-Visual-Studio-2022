using AutoMapper;
using CarApi.Data;
using CarApi.Data.Entities;
using CarApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController(Mapper _mapper, CarService _carService) : ControllerBase
    {
        /// <summary> 
        /// Get all the cars in the Database  
        /// </summary> 
        /// <param name="returnDeletedRecords">If true, the method will return all the records, including the ones that have been deleted</param> 
        /// <response code="200">Cars returned</response> 
        /// <response code="404">Specified Car not found</response> 
        /// <response code="500">An Internal Server Error prevented the request from being executed.</response> 
        [HttpPost]
        public async Task<ActionResult<Car>> Insert([FromBody] CarDto carAsDto)

        {

            try

            {

                if (carAsDto == null)

                {

                    return BadRequest("No car was provided");

                }



                var carToInsert = _mapper.Map<Car>(carAsDto);

                var insertedCar = await _carService.Insert(carToInsert);

                var insertedCarDto = _mapper.Map<CarDto>(insertedCar);

                var location = $"https://localhost:5001/car/{insertedCarDto.Id}";

                return Created(location, insertedCarDto);

            }

            catch (Exception e)

            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
    }
}
