using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.NewFolder1
{
    public class TablaIngreso
    {


        //Id = Product.Id,
        //Descripcion = Product.Descripcion,
        //Categoria = Product.Categoria,
        //Proveedor = Product.Proveedor,
        //Marca = Product.Marca,
        //Modelo = Product.Modelo,
        //Cantidad = Product.Cantidad,
        //PrecioUnitario = Product.PrecioUnitario



        public int Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Proveedor")]
        public string Proveedor { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Required]
        //[Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "PrecioUnitario")]
        public decimal? PrecioUnitario { get; set; }







        //[Required]
        //[Display(Name = "Nombre")]
        //public string Nombre { get; set; }
        //[Required]
        //[Display(Name = "Apellido")]
        //public string Apellido { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[Display(Name = "FechaNacimiento")]
        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}" , ApplyFormatInEditMode = true)]
        //public DateTime FechaNacimiento { get; set; }

    }
}