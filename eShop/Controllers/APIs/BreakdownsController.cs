using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eShop.DTOs;
using eShop.Models;

namespace eShop.Controllers.APIs
{
    public class BreakdownsController : ApiController
    {
        private ApplicationDbContext _context;

        public BreakdownsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/breakdowns
        public IHttpActionResult GetBreakdowns()
        {
            var breakdownDTOs = _context.Breakdowns
                .Include(b => b.PaymentType)
                .ToList()
                .Select(Mapper.Map<Breakdown, BreakdownDTO>);

            return Ok(breakdownDTOs);
        }

        // GET /api/breakdowns/1
        public IHttpActionResult GetBreakdown(int id)
        {
            var breakdown = _context.Breakdowns.SingleOrDefault(b => b.Id == id);

            if (breakdown == null)
                return NotFound();

            return Ok(Mapper.Map<Breakdown, BreakdownDTO>(breakdown));
        }
        
        // POST /api/breakdowns
        [HttpPost]
        public IHttpActionResult CreateBreakdown(BreakdownDTO breakdownDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var breakdown = Mapper.Map<BreakdownDTO, Breakdown>(breakdownDTO);

            _context.Breakdowns.Add(breakdown);
            _context.SaveChanges();

            breakdownDTO.Id = breakdown.Id;

            return Created(new Uri(Request.RequestUri + "" + breakdown.Id), breakdownDTO);
        }

        // PUT /api/breakdowns
        [HttpPut]
        public void UpdateBreakdown(int id, BreakdownDTO breakdownDTO)
        {
            //make sure model is valid
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //make sure customer exists
            var breakdownInDB = _context.Breakdowns.SingleOrDefault(b => b.Id == id);

            if (breakdownInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //set fields
            Mapper.Map(breakdownDTO, breakdownInDB);

            _context.SaveChanges();
        }

        // DELETE /api/breakdowns/1
        [HttpDelete]
        public void DeleteBreakdown(int id)
        {
            var breakdownInDB = _context.Breakdowns.SingleOrDefault(b => b.Id == id);

            if (breakdownInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Breakdowns.Remove(breakdownInDB);
            _context.SaveChanges();
        }
    }
}
