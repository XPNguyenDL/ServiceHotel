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

#region Change category available status
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Change Category available status");
//var categoryAvailable = await categoryRepository.GetCategoriesDeletedAsync();
// sửa lại kết quả console


#endregion

