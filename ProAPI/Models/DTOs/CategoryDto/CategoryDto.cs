﻿using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.CategoryDto
{

    public class CategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
