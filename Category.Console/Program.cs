using ServiceManagement.Core.Entities;
using ServiceManagement.Data.Contexts;
using ServiceManagement.Data.Seeders;
using ServiceManagement.Services.ServiceHotel;
using System.Text;

var context = new ServiceDbContext();

ICategoryRepository categoryRepository = new CategoryRepository(context);
Console.OutputEncoding = Encoding.UTF8;

var seeder = new DataSeeder(context);
seeder.Initialize();

#region Get All Categories
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("All Categories");
//var categories = await categoryRepository.GetCategoriesAsync();
//foreach (var category in categories)
//{
//	Console.WriteLine("{0,-4}\t{1,-30}{2,-30}{3,12}", category.Name, category.Description, category.IsDeleted, category.ServicesCount);
//}
#endregion

#region Add Categories
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Add Category");
//var newCat = new Category()
//{
//    Name = "New Category",
//    Description = "Description",
//    IsDeleted = false,
//};
//var addCat = await categoryRepository.AddOrUpdateAsync(newCat);
//if (addCat)
//    Console.WriteLine("Thêm thành công");
//else
//    Console.WriteLine("failed.");
//Console.WriteLine("".PadRight(80, '-'));
#endregion

#region UpdateCategory(Nhớ thay cái id)
//var newCat = new Category()
//{
//	//id  Category muốn thay đổi
//	Id = 1,
//	Name = "New Category",
//	Description = "Description",
//	IsDeleted = false,
//};
//var updateCat = await categoryRepository.AddOrUpdateAsync(newCat);
//if (updateCat)
//	Console.WriteLine("Sửa thành công");
//else
//	Console.WriteLine("failed.");
//Console.WriteLine("".PadRight(80, '-'));
#endregion

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
//var categoryAvailable = await categoryRepository.GetDeletedCategoryAsync();

//Console.WriteLine("{0,-5}{1,-10}{2,40}",
//    "Id", "Name", "Description");

//foreach (var item in categoryAvailable)
//{
//    Console.WriteLine("{0,-5}{1,-10}{2,40}",
//        item.Id, item.Name, item.Description);
//}
#endregion

#region DeleteCategory(Xóa vĩnh viễn!)
//Console.WriteLine("".PadRight(80, '-'));
//Console.WriteLine("Delete Category");
//var categoryDelete = await categoryRepository.DeleteCategory(2);
//if (categoryDelete)
//    Console.WriteLine("Delete successfully.");
//else
//    Console.WriteLine(" failed.");
//Console.WriteLine("".PadRight(80, '-'));
#endregion
