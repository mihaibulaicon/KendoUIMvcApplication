﻿using Infrastructure.Test;
using Infrastructure.Web;
using KendoUIMvcApplication;
using Northwind;
using Ploeh.AutoFixture;

namespace Test.Northwind.Integration
{
    public abstract class NorthwindControllerTests<TController, TEntity> : ControllerTests<TController, ProductServiceContext, TEntity>
        where TController : CrudController<ProductServiceContext, TEntity>, new()
        where TEntity : VersionedEntity
    {
        static NorthwindControllerTests()
        {
            KendoUIMvcApplication.StructureMap.Register();
            TestContextFactory<ProductServiceContext>.Initialize(SeedDatabase);
        }

        public static void SeedDatabase(ProductServiceContext context, IFixture fixture)
        {
            var categories = fixture.CreateMany<Category>();
            var suppliers = fixture.CreateMany<Supplier>();
            fixture.Customize<Region>(c => c.Without(r => r.Territories));
            var regions = fixture.CreateMany<Region>();
            fixture.Customize<Territory>(c => c.Without(r => r.Employees));
            var territories = fixture.CreateMany<Territory>();

            context.Categories.AddRange(categories);
            context.Suppliers.AddRange(suppliers);
            context.Regions.AddRange(regions);
            context.Territories.AddRange(territories);
        }
    }
}