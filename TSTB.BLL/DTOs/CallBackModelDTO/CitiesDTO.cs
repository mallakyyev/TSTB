using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSTB.BLL.DTOs.CallBackModelDTO
{
    public class CitiesDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
    }
}
