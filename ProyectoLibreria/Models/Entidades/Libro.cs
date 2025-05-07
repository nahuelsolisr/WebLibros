﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLibreria.Models.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campoo {0} es obligatorio. ")]
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "El Campoo {0} es obligatorio. ")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }
        [Display(Name = "Imagen")]
        public string URLImagen { get; set; }


    }
}
