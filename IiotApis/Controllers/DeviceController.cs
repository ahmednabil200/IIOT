using System;
using System.Collections.Generic;
using IiotApi.Helpers;
using IiotApi.Models;
using IiotApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace IiotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

        private IDeviceService deviceService;
        public DeviceController(IDeviceService _deviceService)
        {
            deviceService = _deviceService;
        }

        //GET:      api/devices
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Device>> GetAll()
        {
            IEnumerable<Device> devices = deviceService.GetAll();
            return Ok(devices);
        }

        //GET:      api/devices/n
        [HttpGet("{id}")]
        public ActionResult<Device> GetDevice(int id)
        {
            Device device = deviceService.GetDevice(id);
            if (device == null)
                return NotFound();
            else
                return Ok(device);
        }

        //POST:     api/devices
        [HttpPost]
        public ActionResult<Device> PostDevice(Device_Request device)
        {
            try
            {
                Device result = deviceService.AddDevice(device);
                return Created(new Uri(Url.Link("", new {  id = result.ID })), result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT:      api/devices/n
        [HttpPut("{id}")]
        public IActionResult UpdateDeviceData(int id,[FromBody] Device device )
        {
            //Device device = null;
            if (id != device.ID)
            {
                return BadRequest();
            }
            else
                try
                {
                    device = deviceService.UpdateDevice(id,device);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            return Ok(device);
        }

        //DELETE:   api/devices/n
        [HttpDelete("{id}")]
        public ActionResult<Device> DeleteDevice(int id)
        {
            Device device = null;

            if (device == null)
            {
                return NotFound();
            }

            return null;
        }
    }
}
