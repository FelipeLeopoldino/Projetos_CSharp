using ClosedXML.Excel;
using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimos = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimos == null)
            {
                return NotFound();
            }

            return View(emprestimos);
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {

            if (ModelState.IsValid)
            {
                emprestimos.DataEmprestimo = DateTime.UtcNow;

                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoDb = _db.Emprestimos.Find(emprestimo.Id);

                emprestimoDb.Fornecedor = emprestimo.Fornecedor;
                emprestimoDb.Recebedor = emprestimo.Recebedor;
                emprestimoDb.LivroEmprestado = emprestimo.LivroEmprestado;

                _db.Emprestimos.Update(emprestimoDb);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";


            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimos)
        {
            if(emprestimos == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimos);
            TempData["MensagemSucesso"] = "Remoção realizado com sucesso!";
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados,"Dados Empréstimo");

                using (MemoryStream ms =  new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(),"application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Emprestimo.xls");
                }
            }
        }

        private  DataTable GetDados()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados empréstimos";
            dataTable.Columns.Add("Recebedor", typeof(string));
            dataTable.Columns.Add("Fornecedor",typeof(string));
            dataTable.Columns.Add("Livro", typeof (string));
            dataTable.Columns.Add("Data empréstimo", typeof(DateTime));

            var dados = _db.Emprestimos.ToList();

            if(dados.Count > 0)
            {
                dados.ForEach(emprestimo => {
                    dataTable.Rows
                    .Add(emprestimo.Recebedor,
                    emprestimo.Fornecedor,
                    emprestimo.LivroEmprestado,
                    emprestimo.DataEmprestimo);
                });
            }

            return dataTable;
        }
    }
}
