using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ErrorValidation
{
    public class register
    {
        [Required(ErrorMessage = "<script type = 'text/javascript' > alert('Message') </ script > ")]
        public string name { get; set; }
    }
}
