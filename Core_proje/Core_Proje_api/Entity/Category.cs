using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace Core_Proje_api.Entity
{
   
	public class Category
	{ 
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
