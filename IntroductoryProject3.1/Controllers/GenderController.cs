using DTOlibrary;
using IntroductoryProject3._1.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IntroductoryProject3._1.Controllers
{
    public class GenderController : ApiController
    {
        public GenderController()
        {
        }


        [System.Web.Http.Route("api/Lawyer/GetGenders")]
        // GET: api/Genders
        public List<GenderDTO> GetGenders()
        {

            using (var ctx = new LawyerContext())
            {
                return (from l in ctx.Genders
                        select new GenderDTO
                        {
                            gender_id = l.gender_id,
                            Description = l.description
                        }).ToList();
            }
        }
    }
}
