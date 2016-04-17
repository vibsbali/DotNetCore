﻿using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        [Required, DataType((DataType.Password))]
        public string Password { get; set; }

        [Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
