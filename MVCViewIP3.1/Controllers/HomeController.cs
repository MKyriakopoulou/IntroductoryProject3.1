using MVCViewIP3._1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using IntroductoryProject3._1.Models;
using IntroductoryProject3._1.DAL;

namespace MVCViewIP3._1.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = " https://localhost:44372/";



        public async Task<ActionResult> Index(string searchStringname, string searchStringsurname)
        {
            List<LawyerViewModel> EmpInfo = new List<LawyerViewModel>();

            using (var client = new HttpClient())
            {
                if (!String.IsNullOrEmpty(searchStringname) && !String.IsNullOrEmpty(searchStringsurname))
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/lawyer?Name=" + searchStringname + "&&Surname=" + searchStringsurname);

                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<List<LawyerViewModel>>(EmpResponse);

                    }
                    //returning the employee list to view
                    return View(EmpInfo);
                }
                else if (!String.IsNullOrEmpty(searchStringname) && String.IsNullOrEmpty(searchStringsurname))
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/lawyer?Name=" + searchStringname);

                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<List<LawyerViewModel>>(EmpResponse);

                    }
                    //returning the employee list to view
                    return View(EmpInfo);
                }
                else if (String.IsNullOrEmpty(searchStringname) && !String.IsNullOrEmpty(searchStringsurname))
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/lawyer?Surname=" + searchStringsurname);

                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<List<LawyerViewModel>>(EmpResponse);

                    }
                    //returning the employee list to view
                    return View(EmpInfo);
                }
                else
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/Lawyer/GetAllLawyers");

                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<List<LawyerViewModel>>(EmpResponse);

                    }
                    //returning the employee list to view
                    return View(EmpInfo);
                }

            }
        }

        public ActionResult Create()
        {

            List<GenderViewModel> GenderInfo = new List<GenderViewModel>();
            List<TitleViewModel> TitleInfo = new List<TitleViewModel>();

            using (var client = new HttpClient())
            {

                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                var Res = client.GetAsync("api/Lawyer/GetGenders");
                var result = Res.Result;
                //Checking the response is successful or not which is sent using HttpClient
                if (result.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var GenderResponse = result.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    GenderInfo = JsonConvert.DeserializeObject<List<GenderViewModel>>(GenderResponse);
                    ViewBag.genders = GenderInfo;
                }

                var ResTitle = client.GetAsync("api/Lawyer/GetTitles");
                var resultTitle = ResTitle.Result;
                //Checking the response is successful or not which is sent using HttpClient
                if (resultTitle.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var TitleResponse = resultTitle.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    TitleInfo = JsonConvert.DeserializeObject<List<TitleViewModel>>(TitleResponse);
                    ViewBag.titles = TitleInfo;
                }
            }

            return View();


        }


        [HttpPost]
        public ActionResult Create(LawyerViewModel lawyer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/lawyer");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<LawyerViewModel>("lawyer", lawyer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(lawyer);
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult Details(int id)
        {
            LawyerViewModel lawyer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Lawyer/GetAllLawyersByID?lid=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LawyerViewModel>();
                    readTask.Wait();

                    lawyer = readTask.Result;
                }
            }

            return View(lawyer);
        }

        public ActionResult Edit(int id)
        {

            LawyerViewModel lawyer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Lawyer/GetAllLawyersByID?lid=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LawyerViewModel>();
                    readTask.Wait();

                    lawyer = readTask.Result;
                }
            }

            return View(lawyer);
        }

        [HttpPost]
        public ActionResult Edit(LawyerViewModel lawyer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/Lawyer");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<LawyerViewModel>("lawyer", lawyer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(lawyer);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Lawyer/GetAllLawyersByID?lid=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }



    }

}
