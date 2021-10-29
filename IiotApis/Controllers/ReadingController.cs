using System;
using System.Collections.Generic;
using IiotApplication.Repositories;
using IiotContract.Requests;
using IiotDomain;
using Microsoft.AspNetCore.Mvc;

namespace IiotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private IReadingService readingService;
        public ReadingController(IReadingService _readingService)
        {
            readingService = _readingService;
        }
        //GET:      api/reading/device?id=
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Reading>> GetReadingFromDevice(int id)
        {
            IEnumerable<Reading> readings;
            try
            {
               readings = readingService.GetReadingByDevice(id,null,null);

            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(readings);
        }

        [HttpGet("{id}/{startDate}")]
        public ActionResult<IEnumerable<Reading>> GetReadingFromDevice(int id, int? startDate)
        {
            IEnumerable<Reading> readings;
            try
            {
                readings = readingService.GetReadingByDevice(id, startDate, null);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(readings);
        }

        [HttpGet("{id}/{startDate}/{endDate}")]
        public ActionResult<IEnumerable<Reading>> GetReadingFromDevice(int id, int? startDate, int? endDate)
        {
            IEnumerable<Reading> readings;
            try
            {
                readings = readingService.GetReadingByDevice(id, startDate, endDate);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(readings);
        }

        [HttpPost]
        public ActionResult<Device> PostDevice([FromBody]Reading_Request reading)
        {
            try
            {
                Reading result = readingService.InsertReading(reading);
                return Created(new Uri(Url.Link("", new { id = result.ID })), result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
