using MemberRegister.Models;
using MemberRegister.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace RRMemberRegister.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        /// <summary>
        /// Reference till MemberRegisterService layer
        /// </summary>
        public IMemberRegisterService Service { get; }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service">Reference till MemberRegisterService</param>
        public MemberController(IMemberRegisterService service)
        {
            Service = service;
        }


        // GET: api/<MemberController>
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var members = Service.GetMembers();
            return Ok(members);
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var member = Service.GetMember(id);
            if(member != null)
                return Ok(member);

            return NotFound();
        }

        // POST api/<MemberController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Member mem)
        {
            try
            {
                Member newMember = Service.CreateMember(mem);
                if (newMember != null)
                    return Ok(newMember);
            }
            catch (Exception) 
            {// Vill bara fånga exception
            }

            return BadRequest();
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Member mem)
        {
            try
            {
                int iMemberId = Service.UpdateMember(mem);
                if(iMemberId > 0)
                    return Ok(iMemberId);
            }
            catch (Exception)
            {// Vill bara fånga exception
            }

            return NotFound();
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int iMemberId = Service.DeleteMember(id);
                if(iMemberId > 0)
                    return Ok(iMemberId);
            }
            catch (Exception) 
            { // Vill bara fånga exception
            }

            return NotFound();
        }
    }
}
