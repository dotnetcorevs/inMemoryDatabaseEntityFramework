using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using inDb.Models;
namespace inDb.Models
{
    public class  user
    {
           public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<post> Posts { get; set; }
  
    }  
   
 }
