﻿using DTOlibrary;
using IntroductoryProject3._1.DAL;
using IntroductoryProject3._1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace IntroductoryProject3._1.Controllers
{
    public class LawyerController : ApiController
    {
        LawyerContext context = new LawyerContext();
        ILawyerRepository rep;
        public LawyerController()
        {

        }
        public LawyerController(LawyerContext _context)
        {
            context = _context;
        }

        List<Lawyer> lawyers = new List<Lawyer>();
        private Lawyer lawyer;

        public LawyerController(List<Lawyer> lawyers)
        {
            this.lawyers = lawyers;
        }

        public LawyerController(List<LawyerDTO> lawyersdto)
        {
            this.lawyers = lawyers;
        }

        public LawyerController(Lawyer lawyer)
        {
            this.lawyer = lawyer;
        }
        public LawyerController(ILawyerRepository _rep)
        {
            rep = _rep;
        }


        //Get action methods of the previous section
        [ResponseType(typeof(LawyerDTO))]
        public IHttpActionResult PostNewLawyer(Lawyer lawyer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new LawyerContext())
            {
                ctx.Lawyers.Add(new Lawyer()
                {
                    Id = lawyer.Id,
                    Name = lawyer.Name,
                    Surname = lawyer.Surname,
                    Initials = lawyer.Initials,
                    DateOfBirth = lawyer.DateOfBirth,
                    Email = lawyer.Email,
                    Gender_id = lawyer.Gender_id,
                    Title_id = lawyer.Title_id
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public object PostNewLawyer(object testLawyer)
        {
            throw new NotImplementedException();
        }

        [System.Web.Http.Route("api/Lawyer/GetAllLawyers")]
        [System.Web.Http.HttpGet]
        public List<LawyerDTO> GetAllLawyers()
        {

            using (var ctx = new LawyerContext())
            {
                return (from l in ctx.Lawyers
                        select new LawyerDTO
                        {
                            Id = l.Id,
                            Name = l.Name,
                            Surname = l.Surname,
                            Initials = l.Initials,
                            DateOfBirth = l.DateOfBirth,
                            Email = l.Email,
                            Gender_id = (short)l.Gender_id,
                            Title_id = (short)l.Title_id,
                            Genders = ctx.Genders.Select(x => new SelectListItem
                            {
                                Value = x.gender_id.ToString(),
                                Text = x.description
                            })
                        }).ToList();
            }

        }

        [System.Web.Http.Route("api/Lawyer/GetAllLawyersByID")]
        public IHttpActionResult GetAllLawyersByID(int lid)
        {
            LawyerDTO lawyer = null;

            using (var ctx = new LawyerContext())
            {
                lawyer = ctx.Lawyers.Include("Name")
                    .Where(l => l.Id == lid)
                    .Select(l => new LawyerDTO()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender_id = (short)l.Gender_id,
                        Title_id = (short)l.Title_id
                    }).FirstOrDefault<LawyerDTO>();
            }

            if (lawyer == null)
            {
                return NotFound();
            }

            return Ok(lawyer);
        }



        public IHttpActionResult GetAllLawyers(string name, string surname)
        {
            IList<LawyerDTO> lawyers = null;

            using (var ctx = new LawyerContext())
            {
                lawyers = ctx.Lawyers.Include("Name").Include("Surname")
                    .Where(l => l.Name.ToLower() == name.ToLower() && l.Surname.ToLower() == surname.ToLower())
                    .Select(l => new LawyerDTO()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender_id = (short)l.Gender_id,
                        Title_id = (short)l.Title_id

                    }).ToList<LawyerDTO>();
            }

            if (lawyers.Count == 0)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }

        public IHttpActionResult GetByName(string name)
        {
            IList<LawyerDTO> lawyers = null;

            using (var ctx = new LawyerContext())
            {
                lawyers = ctx.Lawyers.Include("Name")
                    .Where(l => l.Name.ToLower() == name.ToLower())
                    .Select(l => new LawyerDTO()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender_id = (short)l.Gender_id,
                        Title_id = (short)l.Title_id

                    }).ToList<LawyerDTO>();
            }

            if (lawyers.Count == 0)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }


        public IHttpActionResult GetBySurname(string surname)
        {
            IList<LawyerDTO> lawyers = null;

            using (var ctx = new LawyerContext())
            {
                lawyers = ctx.Lawyers.Include("Surname")
                    .Where(l => l.Surname.ToLower() == surname.ToLower())
                    .Select(l => new LawyerDTO()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Initials = l.Initials,
                        DateOfBirth = l.DateOfBirth,
                        Email = l.Email,
                        Gender_id = (short)l.Gender_id,
                        Title_id = (short)l.Title_id

                    }).ToList<LawyerDTO>();
            }

            if (lawyers.Count == 0)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }


        public IHttpActionResult Put(LawyerDTO lawyer)
        {


            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new LawyerContext())
            {

                var existingLawyer = ctx.Lawyers.Where(l => l.Id == lawyer.Id)
                                                        .FirstOrDefault<Lawyer>();

                if (existingLawyer != null)
                {




                    existingLawyer.Name = lawyer.Name;
                    existingLawyer.Surname = lawyer.Surname;
                    existingLawyer.Initials = lawyer.Initials;
                    existingLawyer.DateOfBirth = lawyer.DateOfBirth;
                    existingLawyer.Email = lawyer.Email;
                    existingLawyer.Gender_id = lawyer.Gender_id;
                    existingLawyer.Title_id = lawyer.Title_id;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid lawyer id");

            using (var ctx = new LawyerContext())
            {
                var lawyer = ctx.Lawyers
                    .Where(l => l.Id == id)
                    .FirstOrDefault();

                ctx.Entry(lawyer).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }


    }



}


