using DTOlibrary;
using IntroductoryProject3._1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroductoryProject3._1.Controllers
{
    public class TitleController : ApiController
    {
        public TitleController()
        {
        }

        [System.Web.Http.Route("api/Lawyer/GetTitles")]
        // GET: api/Titles
        public List<TitleDTO> GetTitles()
        {

            using (var ctx = new LawyerContext())
            {
                return (from l in ctx.Titles
                        select new TitleDTO
                        {
                            title_id = l.title_id,
                            description = l.description
                        }).ToList();
            }
        }
    }
}
