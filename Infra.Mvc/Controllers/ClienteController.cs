using Infra.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Infra.Mvc.Controllers
{
    public class ClienteController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<ClienteModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cliente").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<ClienteModel>>().Result;
            return View(empList);
        }

        public ActionResult IndexFazendo()
        {
            IEnumerable<ClienteModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cliente").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<ClienteModel>>().Result;
            return View(empList);
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ClienteModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Cliente/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ClienteModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ClienteModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Cliente", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Cliente/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Cliente/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
