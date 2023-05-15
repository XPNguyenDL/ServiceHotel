using ServiceManagement.Data.Contexts;
using ServiceManagement.Data.Seeders;
using ServiceManagement.Services.ServiceHotel;

var context = new ServiceDbContext();

ICategoryRepository categoryRepository = new CategoryRepository(context);


var seeder = new DataSeeder(context);
seeder.Initialize();

#region Change category delete status
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Change Category delete status");
//var categoryDelete = await categoryRepository.ChangeCategoryDeleteStatusAsync(2);
//if (categoryDelete)
//    Console.WriteLine("Change successfully.");
//else
//    Console.WriteLine("Change failed.");
//Console.WriteLine("".PadRight(80, '-'));
#endregion

#region Get Deleted Categories

//var deletedCate = await categoryRepository.GetDeletedCategoryAsync();

//Console.WriteLine("{0,-5}{1,-10}{2,40}",
//    "Id", "Name", "Description");

//foreach (var item in deletedCate)
//{
//    Console.WriteLine("{0,-5}{1,-10}{2,40}",
//        item.Id, item.Name, item.Description);
//}
#endregion

