using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Kalori.Dtos;
using Kalori.Models;

namespace Kalori.Controllers.Api
{
    public class MembersController : ApiController
    {
        private ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/members
        public IHttpActionResult Get()
        {
            var memberDtos = _context.Members.ToList().Select(Mapper.Map<Member, MemberDto>);

            return Ok(memberDtos);
        }

        // GET /api/members/1
        public IHttpActionResult GetMember(int id)
        {
            var member = _context.Members.SingleOrDefault(c => c.Id == id);

            if (member == null)
                return NotFound();

            return Ok(Mapper.Map<Member, MemberDto>(member));
        }

        // POST /api/members
        [HttpPost]
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = Mapper.Map<MemberDto, Member>(memberDto);
            _context.Members.Add(member);
            _context.SaveChanges();

            memberDto.Id = member.Id;

            return Created(new Uri(Request.RequestUri + "/" + member.Id), memberDto);
        }

        // PUT /api/members/1
        [HttpPut]
        public IHttpActionResult UpdateMember(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var memberInDb = _context.Members.SingleOrDefault(c => c.Id == id);

            if(memberInDb == null)
                return NotFound();

            Mapper.Map(memberDto, memberInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/members/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var memberInDb = _context.Members.SingleOrDefault(c => c.Id == id);

            if (memberInDb == null)
                return NotFound();

            _context.Members.Remove(memberInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
