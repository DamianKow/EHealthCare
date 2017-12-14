using EHealthCare.DataLayer;
using EHealthCare.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EHealthCare.Web
{
    public class DoctorApiController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public DoctorApiController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/DoctorApi
        public List<Term> Get()
        {
            var terms = _context.Terms.Include("Doctor").ToList();
            return terms;
        }

        //// GET: api/DoctorApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/DoctorApi
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/DoctorApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/DoctorApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
