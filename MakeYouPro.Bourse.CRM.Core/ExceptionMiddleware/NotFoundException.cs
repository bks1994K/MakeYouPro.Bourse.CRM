﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYouPro.Bourse.CRM.Core.ExceptionMiddleware
{
    public class NotFoundException : Exception
    {
        public int Id { get; set; }

        public string EntityName { get; set; }

        public NotFoundException(int id, string entityName) : base($"{entityName} with Id {id} is not found in dataBase")
        {
            Id = id;
            EntityName = entityName;
        }
    }
}
