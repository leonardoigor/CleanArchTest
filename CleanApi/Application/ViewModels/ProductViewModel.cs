using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanApi.Application.ViewModels
{
    public class ProductViewModel
    {    
        public int Id { get; set; }

        [Required(ErrorMessage = "required_name")]
        [MinLength(3, ErrorMessage = "min_lengt|3")]
        [MaxLength(100, ErrorMessage = "max_length|100")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "required_name")]
        [MinLength(5, ErrorMessage = "min_lengt|5")]
        [MaxLength(200, ErrorMessage = "max_length|200")]
        [DisplayName("Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "required_name")]
        [Range(1, 9999.99, ErrorMessage = "range_1|99999.99")]
        [DisplayName("Price")]
        public string Price { get; set; }
    }
}
