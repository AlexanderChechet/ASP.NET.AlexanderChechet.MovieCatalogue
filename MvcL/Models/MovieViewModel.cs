using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace MvcL.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Display(Name="Название")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Год")]
        public int Year { get; set; }

        [Display(Name = "Длительность")]
        public int Length { get; set; }

        [Display(Name = "Оценка пользователей")]
        public float Mark { get; set; }

        [Display(Name = "Бюджет")]
        public int Budget { get; set; }

        [Display(Name = "Режиссер")]
        public string Producer { get; set; }

        public string PistureString { get; set; }

        public HttpPostedFileBase Picture { get; set; }

        public HttpPostedFileBase Data { get; set; }
    }
}