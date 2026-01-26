
namespace _4EPlatForm.Infrastructure.Context;
public class ContextSeedData
{
    private static DBContext _dbContext;

    public static void Seed(DBContext appDbContext)
    {
        _dbContext = appDbContext;
        _dbContext.Database.EnsureCreated();

        // call functions
        SeedRequestCategory();
        SeedRequestCategoryTypes();
        SeedRequestTemplate();
    }
    private static void SeedRequestCategory()
    {
        string CategoriesAsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "RequestCategory.json");

        var CategoriesMdels = JsonConvert.DeserializeObject<List<RequestCategory>>(CategoriesAsJson);
        if (!_dbContext.RequestCategories.Any())
        {
            _dbContext.RequestCategories.AddRange(CategoriesMdels);

            _dbContext.SaveChanges();
        }
        else
        {
            var data = _dbContext.RequestCategories.ToList();
            var dataSeed = data.Where(n => n.FromSeed == true).ToList();
            dataSeed.ForEach(n =>
            {
                if (!CategoriesMdels.Any(x => x.Id == n.Id))
                {
                    n.State = State.Deleted;
                }
            });
            var list = new List<RequestCategory>();
            CategoriesMdels.ForEach(n =>
            {
                if (!data.Any(x => x.Id == n.Id))
                {
                    list.Add(n);
                }
                else
                {
                    n.RowVersion = data.FirstOrDefault(x => x.Id == n.Id)?.RowVersion;
                    n.CreatedBy = data.FirstOrDefault(x => x.Id == n.Id).CreatedBy;
                    n.CreatedOn = data.FirstOrDefault(x => x.Id == n.Id).CreatedOn;

                }
            });
            CategoriesMdels.RemoveAll(n => list.Any(x => x.Id == n.Id));

            _dbContext.RequestCategories.AddRange(list);
            _dbContext.RequestCategories.UpdateRange(CategoriesMdels);
            _dbContext.SaveChanges();
        }
    }
    private static void SeedRequestTemplate()
    {
        string RequestTemplateAsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "RequestTemplete.json");

        var RequestTemplateMdels = JsonConvert.DeserializeObject<List<RequestTemplate>>(RequestTemplateAsJson);
        if (!_dbContext.RequestTemplates.Any(x => x.FromSeed == true))
        {

            _dbContext.RequestTemplates.AddRange(RequestTemplateMdels);

            _dbContext.SaveChanges();
        }
        //else
        //{
        //    var data = _dbContext.RequestTemplates.ToList();
        //    var dataSeed = data.Where(n => n.FromSeed == true).ToList();
        //    dataSeed.ForEach(n =>
        //    {
        //        if (!RequestTemplateMdels.Any(x => x.Id == n.Id))
        //        {
        //            n.State = State.Deleted;
        //        }
        //    });
        //    var list = new List<RequestTemplate>();
        //    RequestTemplateMdels.ForEach(n =>
        //    {
        //        if (!data.Any(x => x.Id == n.Id))
        //        {
        //            list.Add(n);
        //        }
        //        else
        //        {
        //            n.RowVersion = data.FirstOrDefault(x => x.Id == n.Id)?.RowVersion;
        //            n.CreatedBy = data.FirstOrDefault(x => x.Id == n.Id).CreatedBy;
        //            n.CreatedOn = data.FirstOrDefault(x => x.Id == n.Id).CreatedOn;

        //        }
        //    });
        //    RequestTemplateMdels.RemoveAll(n => list.Any(x => x.Id == n.Id));
        //    _dbContext.RequestTemplates.AddRange(list);
        //    _dbContext.RequestTemplates.UpdateRange(RequestTemplateMdels);
        //    _dbContext.SaveChanges();
        //}
    }

    private static void SeedRequestCategoryTypes()
    {
        string CategoriesAsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "RequestCategoryTypes.json");

        var CategoriesMdels = JsonConvert.DeserializeObject<List<RequestCategoryType>>(CategoriesAsJson);
        if (!_dbContext.RequestCategoryType.Any())
        {
            CategoriesMdels.ForEach(x =>
            {
                if (x.Name.Contains("طلب دوره غير  متاحة"))
                {
                    x.IsHide = true;
                }
            });
            _dbContext.RequestCategoryType.AddRange(CategoriesMdels);

            _dbContext.SaveChanges();
        }
        else
        {
            var data = _dbContext.RequestCategoryType.ToList();
            data.ForEach(x =>
            {
                if (x.Name.Contains("طلب دوره غير  متاحة") || x.Name.Contains("طلب دوره غير  متاحة"))
                {
                    x.IsHide = true;
                    _dbContext.RequestCategoryType.Update(x);
                    _dbContext.SaveChanges();
                }
            });
            var dataSeed = data.Where(n => n.FromSeed == true).ToList();
            dataSeed.ForEach(n =>
            {
                if (!CategoriesMdels.Any(x => x.Id == n.Id))
                {
                    n.State = State.Deleted;
                }
            });
            var list = new List<RequestCategoryType>();
            CategoriesMdels.ForEach(n =>
            {


                if (!data.Any(x => x.Id == n.Id))
                {
                    list.Add(n);
                }
            });

            _dbContext.RequestCategoryType.AddRange(list);
            _dbContext.SaveChanges();
        }
    }
}