using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlerDeEstoque.Models
{
    public class GrupoProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatorio!")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }




        public static List<GrupoProdutoModel> RecuperarLista()
        {
            var result =  new List<GrupoProdutoModel>();
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; ;
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from grupo_produto order by nome";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new GrupoProdutoModel { 
                            Id =    (int)reader["id"],
                            Nome =  (string)reader["nome"],
                            Ativo = (bool)reader["ativo"]
                        }); 
                    }
                }
            }
            return result;
        }

        public static GrupoProdutoModel RecuperarPeloId(int id)
        {
            GrupoProdutoModel result = null;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; ;
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select * from grupo_produto where (id ={0})", id);
                    var reader = comando.ExecuteReader();
                   if (reader.Read())
                    {
                        result = new GrupoProdutoModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Ativo = (bool)reader["ativo"]
                        };
                    }
                }
            }
            return result;
        }

        public static bool ExcluirPeloId(int id)
        {
            var result =false;
            if (RecuperarPeloId(id) != null)
            {
                using (var conexao = new SqlConnection())
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString; ;
                    conexao.Open();

                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = string.Format("delete from grupo_produto where (id ={0})", id);
                        result = (comando.ExecuteNonQuery() > 0);
                    }
                }
            }
            return result;
        }

        public  int Salvar()
        {
            var result = 0;
            var grupo = RecuperarPeloId(this.Id);
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    if (grupo == null)
                    {
                        comando.CommandText = string.Format("insert into  grupo_produto  (nome, ativo) values ('{0}', {1}); select convert(int, scope_identity())", this.Nome, this.Ativo ? 1 : 0);
                        result = (int)comando.ExecuteScalar();
                    }
                    else
                    {
                        comando.CommandText = string.Format("update grupo_produto set  nome ='{1}', ativo ={2} where id ={0}", 
                                                            this.Id, this.Nome, this.Ativo ? 1 : 0);

                       if (comando.ExecuteNonQuery() > 0)
                        {
                            result = this.Id;
                        }
                    }
                }

            }
            return result;
        }




    }
}