using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioPratico.Services.API.Models
{
    public class ValidationErrorModel
    {
        public string PropertyName { get; set; }
        public List<string> Errors { get; set; }
    }
}
