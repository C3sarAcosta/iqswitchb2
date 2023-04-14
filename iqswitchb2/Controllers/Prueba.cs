using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

namespace iqswitchb2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Prueba : Controller
    {

       [HttpGet("on")]
        public IActionResult TurnOn()
        {
            // Conexión a la Raspberry Pi
            using (var ssh = new SshClient("192.168.100.31", "cesar", "nada123"))
            {
                ssh.Connect();

                // Encender el LED
                ssh.RunCommand("gpio -g mode 17 out");
                ssh.RunCommand("gpio -g write 17 1");
            }

            return Ok();
        }

        [HttpGet("off")]
        public IActionResult TurnOff()
        {
            // Conexión a la Raspberry Pi
            using (var ssh = new SshClient("192.168.100.31", "cesar", "nada123"))
            {
                ssh.Connect();

                // Apagar el LED
                ssh.RunCommand("gpio -g write 17 0");
            }

            return Ok();
        }
    }
}
