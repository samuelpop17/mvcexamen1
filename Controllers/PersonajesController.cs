using Microsoft.AspNetCore.Mvc;
using MvcExamenApi1.Models;
using MvcExamenApi1.Services;

namespace MvcExamenApi1.Controllers
{
    public class PersonajesController : Controller
    {
        private ServicePersonajes service;

        public PersonajesController(ServicePersonajes service)
        {
            this.service = service;
        }

        public async Task< IActionResult> Index()
        {
            List<PersonajeSerie> per = await this.service.GetPersonajesAsync();
            return View(per);
        }

        public async Task<IActionResult> Detail(int id)
        {
            PersonajeSerie per = await this.service.GetPersonajesIdAsync(id);
            return View(per);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeletePersonajeAsync(id);
            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonajeSerie per)
        {
            await this.service.InsertPersonajeAsync(per);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            PersonajeSerie per = await this.service.GetPersonajesIdAsync(id);
            return View(per);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PersonajeSerie per)
        {
            await this.service.UpdatePersonajeAsync(per);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PersonajesSeries()
        {
            ViewData["SERIES"] = await this.service.GetSeriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PersonajesSeries(string serie)
        {
            List<PersonajeSerie> per = await this.service.GetPersonajesSeriesAsync(serie);
            ViewData["SERIES"] = await this.service.GetSeriesAsync();
            return View(per);
        }

    }
}
