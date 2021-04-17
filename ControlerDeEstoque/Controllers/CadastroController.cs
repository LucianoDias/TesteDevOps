using ControlerDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlerDeEstoque.Controllers
{
   
    public class CadastroController : Controller
    {

        private static List<GrupoProdutoModel> _listaGrupoProduto = new List<GrupoProdutoModel>()
    {
        new GrupoProdutoModel() { Id=1, Nome="Livro 1", Ativo= true},
        new GrupoProdutoModel() { Id=2, Nome="Livro 2", Ativo= true},
        new GrupoProdutoModel() { Id=3, Nome="Livro 3", Ativo= false},
        new GrupoProdutoModel() {  Id=4, Nome="Livro41", Ativo= false}
    };

       [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(GrupoProdutoModel.RecuperarLista());
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(GrupoProdutoModel.RecuperarPeloId(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel grupo)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var id = grupo.Salvar();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERROR";
                    }

                }
                catch (Exception ex)
                {
                    resultado = "ERROR";
                }
            }
            return Json( new { Resultado =resultado, Mensagens =mensagens, IdSalvo =idSalvo });
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            return Json(GrupoProdutoModel.ExcluirPeloId(id));
        }


        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }
        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }
        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }
        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }
        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }
        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }
        [Authorize]
        public ActionResult Cidade()
        {
            return View();

        }
        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();

        }
        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();

        }
        [Authorize]
        public ActionResult Usuario()
        {
            return View();

        }
    }
}