using Microsoft.AspNetCore.Mvc;
using MVCCrudDoctores.Models;
using MVCCrudDoctores.Repositories;
using System.Diagnostics;

namespace MVCCrudDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController()
        {
            repo = new RepositoryDoctores();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctors();
            return View(doctores);
        }

        public IActionResult Details(int id)
        {
            Doctor doctor = this.repo.FindDoctor(id);
            return View(doctor);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            Doctor doctor = this.repo.FindDoctor(id);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            this.repo.InsertDoctor(doctor.DOCTOR_NO, doctor.HOSPITAL_COD, doctor.APELLIDO, doctor.ESPECIALIDAD, doctor.SALARIO);
            ViewData["MENSAJE"] = "Departamento insertado";
            /*return View("Index");*/
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.DeleteDoctor(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            this.repo.UpdateDoctor(doctor.DOCTOR_NO, doctor.HOSPITAL_COD, doctor.APELLIDO, doctor.ESPECIALIDAD, doctor.SALARIO);
            ViewData["MENSAJE"] = "Departamento actualizado";
            return RedirectToAction("Index");
        }
    }
}