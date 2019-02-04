using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using inDb.Models;
namespace inDb.Models
{

    public class post
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public user User { get; set; }

        public string Content { get; set; }
    }
    
}