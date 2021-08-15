using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Dto
{
    public class ChangePasswordDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
