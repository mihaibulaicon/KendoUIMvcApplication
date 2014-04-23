using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using System.Diagnostics;

namespace KendoUIMvcApplication.Controllers
{
    public class EmployeeController : NorthwindController<Employee>
    {
        protected override void Add(Employee entity)
        {
            entity.Territories.Set(Context);
            base.Add(entity);
        }

        protected override void Modify(Employee entity)
        {
            var existingEntity = Context.Employees.GetWithInclude(entity.Id, e => e.Territories);
            SetRowVersion(entity, existingEntity);
            Mapper.Map(entity, existingEntity);
            existingEntity.Territories.Set(Context);
        }
    }
}