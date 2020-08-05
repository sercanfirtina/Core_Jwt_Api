using Business.Interfaces;
using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.CustomFilters
{
    public class ValidId<T> : IActionFilter where T:class,ITable,new()
    {
       private readonly IGenericService<T> _genericService;

        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }
        //action çalışması bittikten sonra 
        public void OnActionExecuted(ActionExecutedContext context) { }
               //action başlamadan önce
        public void OnActionExecuting(ActionExecutingContext context)
        {
          var dictionary=context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();
           var checkedId = (int)dictionary.Value;

            var entity =_genericService.GetById(checkedId).Result;

            if (entity == null)
                context.Result = new NotFoundObjectResult($"{checkedId} idli nesne bulunamadı.");
            
        }
    }
}
