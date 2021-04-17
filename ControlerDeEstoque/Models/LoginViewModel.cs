﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlerDeEstoque.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o usuário")]
        [Display(Name="Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage ="Informe sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "LembrarMe")]
        public bool LembrarMe { get; set; }
    }
}