using AutoMapper;
using ProjetoAdocaoAnimais.Domain.Entities;
using ProjetoAdocaoAnimais.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSiteAdocaoAnimais.Models;

namespace WebSiteAdocaoAnimais.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalAppService _iAnimalAppService;
        private readonly IAnimalSexoAppService _iAnimalSexoAppService;
        private readonly IAdocaoAppService _iAdocaoAppService;

        public AnimalController(IAnimalAppService iAnimalAppService, 
                                IAnimalSexoAppService iAnimalSexoAppService,
                                IAdocaoAppService iAdocaoAppService)
        {
            _iAnimalAppService = iAnimalAppService;
            _iAnimalSexoAppService = iAnimalSexoAppService;
            _iAdocaoAppService = iAdocaoAppService;
        }

        private void DadosComboBox()
        {
            try
            {
                var sexo = Mapper.Map<IEnumerable<AnimalSexo>, IEnumerable<AnimalSexoViewModel>>(_iAnimalSexoAppService.GetAll());

                ViewBag.Sexo = new SelectList(sexo, "SexoId", "Sexo");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        // GET: Animal
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var listItem = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_iAnimalAppService.GetAll());
                return View(listItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Animal/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iAnimalAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Animal, AnimalViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Animal/Create
        [Authorize]
        public ActionResult Create()
        {
            DadosComboBox();

            return View();
        }

        // POST: Animal/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(AnimalViewModel animalViewModel)
        {
            try
            {
                DadosComboBox();

                if (animalViewModel.SexoId <= 0)
                    ModelState.AddModelError("", "É necessário informar o sexo do animal!");

                if (ModelState.IsValid)
                {
                    var item = Mapper.Map<AnimalViewModel, Animal>(animalViewModel);
                    _iAnimalAppService.Add(item);

                    return RedirectToAction("Index");
                }

                return View(animalViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Animal/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                DadosComboBox();

                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iAnimalAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Animal, AnimalViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: Animal/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(AnimalViewModel AnimalViewModel)
        {
            try
            {
                DadosComboBox();

                if (ModelState.IsValid)
                {

                    var item = Mapper.Map<AnimalViewModel, Animal>(AnimalViewModel);

                    _iAnimalAppService.Update(item);

                    return RedirectToAction("Index");
                }

                return View(AnimalViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Animal/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var encontrado = _iAnimalAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var item = Mapper.Map<Animal, AnimalViewModel>(encontrado);

                return View(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST: Animal/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var encontrado = _iAnimalAppService.GetById(id);

                if (encontrado == null)
                {
                    return HttpNotFound();
                }

                var permiteExclusao = _iAdocaoAppService.GetAll().Where(a => a.Animal.AnimalId == encontrado.AnimalId).FirstOrDefault();

                if(permiteExclusao != null && permiteExclusao.AdocaoId > 0)
                {
                    ModelState.AddModelError("", "Existe uma adoção cadastrada para este registro, é necessário exclui-la para prosseguir com a operação!");
                    var item = Mapper.Map<Animal, AnimalViewModel>(encontrado);
                    return View(item);
                }

                _iAnimalAppService.Remove(encontrado);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}