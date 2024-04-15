using CrudAluno.Data;
using CrudAluno.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAluno.Controllers
{
    [Route("/")]
    public class AlunoController : Controller
    {
        private readonly CrudAlunoContext _context;

        public AlunoController(CrudAlunoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Aluno> alunos = _context.Aluno.ToList();
            return View(alunos);
        }

        [Route("/cadastro-aluno")]
        public IActionResult CadastroAluno()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("Name,Email,Curso")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("CadastroAluno");
        }

        [Route("/Editar")]
        public IActionResult EditarAluno(int id)
        {
            var aluno = _context.Aluno.FirstOrDefault(a => a.Id == id);
            return View(aluno);
        }

        [Route("/alterar")]
        [HttpPost]
        public IActionResult Alterar([Bind("Id,Name,Email,Curso")] Aluno aluno)
        {
            var AlunoPreUpdate = _context.Aluno.FirstOrDefault(a => a.Id == aluno.Id);
            AlunoPreUpdate.Name = aluno.Name;
            AlunoPreUpdate.Email = aluno.Email;
            AlunoPreUpdate.Curso = aluno.Curso;

            var alunoUpdated = _context.Aluno.Update(AlunoPreUpdate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("/Deletar")]
        public IActionResult Delete(long id)
        {
            var aluno = _context.Aluno.FirstOrDefault(a => a.Id == id);
            _context.Remove(aluno);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
