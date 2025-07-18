using LibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void SeedData(LibraryDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.Floors.Any())
                return;

            // Seed Floors
            var floors = new List<Floor>
            {
                new Floor { FloorNumber = 1, NumberOfBlocks = 6 },
                new Floor { FloorNumber = 2, NumberOfBlocks = 5 },
                new Floor { FloorNumber = 3, NumberOfBlocks = 7 },
                new Floor { FloorNumber = 4, NumberOfBlocks = 4 },
                new Floor { FloorNumber = 5, NumberOfBlocks = 8 }
            };
            context.Floors.AddRange(floors);
            context.SaveChanges();

            // Seed Employees
            var employees = new List<Employee>
            {
                new Employee
                {
                    Fname = "أحمد",
                    Lname = "محمد",
                    Email = "ahmed.mohamed@library.com",
                    Salary = 8500.00m,
                    DateOfBirth = new DateTime(1985, 3, 15),
                    Bonus = 1200.00m,
                    Address = "شارع النيل، القاهرة",
                    PhoneNumber = "01012345678",
                    FloorId = 1,
                    ManagedFloorId = 1,
                    HiringDate = new DateTime(2020, 1, 15)
                },
                new Employee
                {
                    Fname = "فاطمة",
                    Lname = "علي",
                    Email = "fatima.ali@library.com",
                    Salary = 7800.00m,
                    DateOfBirth = new DateTime(1990, 7, 22),
                    Bonus = 900.00m,
                    Address = "شارع المعادي، القاهرة",
                    PhoneNumber = "01023456789",
                    FloorId = 1,
                    SupervisorId = 1
                },
                new Employee
                {
                    Fname = "محمد",
                    Lname = "حسن",
                    Email = "mohamed.hassan@library.com",
                    Salary = 7500.00m,
                    DateOfBirth = new DateTime(1988, 11, 8),
                    Bonus = 800.00m,
                    Address = "شارع الزمالك، القاهرة",
                    PhoneNumber = "01034567890",
                    FloorId = 2,
                    ManagedFloorId = 2,
                    HiringDate = new DateTime(2021, 3, 10)
                },
                new Employee
                {
                    Fname = "سارة",
                    Lname = "أحمد",
                    Email = "sara.ahmed@library.com",
                    Salary = 7000.00m,
                    DateOfBirth = new DateTime(1992, 4, 12),
                    Bonus = 600.00m,
                    Address = "شارع مصر الجديدة، القاهرة",
                    PhoneNumber = "01045678901",
                    FloorId = 2,
                    SupervisorId = 3
                },
                new Employee
                {
                    Fname = "علي",
                    Lname = "محمود",
                    Email = "ali.mahmoud@library.com",
                    Salary = 9500.00m,
                    DateOfBirth = new DateTime(1983, 9, 25),
                    Bonus = 1500.00m,
                    Address = "شارع هليوبوليس، القاهرة",
                    PhoneNumber = "01056789012",
                    FloorId = 3,
                    ManagedFloorId = 3,
                    HiringDate = new DateTime(2019, 6, 20)
                },
                new Employee
                {
                    Fname = "نور",
                    Lname = "عمر",
                    Email = "nour.omar@library.com",
                    Salary = 6500.00m,
                    DateOfBirth = new DateTime(1995, 1, 30),
                    Bonus = 500.00m,
                    Address = "شارع المقطم، القاهرة",
                    PhoneNumber = "01067890123",
                    FloorId = 3,
                    SupervisorId = 5
                },
                new Employee
                {
                    Fname = "خالد",
                    Lname = "عبدالله",
                    Email = "khaled.abdullah@library.com",
                    Salary = 7200.00m,
                    DateOfBirth = new DateTime(1987, 5, 18),
                    Bonus = 700.00m,
                    Address = "شارع مدينة نصر، القاهرة",
                    PhoneNumber = "01078901234",
                    FloorId = 4,
                    ManagedFloorId = 4,
                    HiringDate = new DateTime(2022, 2, 1)
                },
                new Employee
                {
                    Fname = "ليلى",
                    Lname = "مصطفى",
                    Email = "layla.mostafa@library.com",
                    Salary = 6800.00m,
                    DateOfBirth = new DateTime(1993, 8, 14),
                    Bonus = 550.00m,
                    Address = "شارع المعادي الجديدة، القاهرة",
                    PhoneNumber = "01089012345",
                    FloorId = 4,
                    SupervisorId = 7
                },
                new Employee
                {
                    Fname = "يوسف",
                    Lname = "إبراهيم",
                    Email = "youssef.ibrahim@library.com",
                    Salary = 8800.00m,
                    DateOfBirth = new DateTime(1986, 12, 3),
                    Bonus = 1100.00m,
                    Address = "شارع التجمع الخامس، القاهرة",
                    PhoneNumber = "01090123456",
                    FloorId = 5,
                    ManagedFloorId = 5,
                    HiringDate = new DateTime(2020, 8, 10)
                },
                new Employee
                {
                    Fname = "رنا",
                    Lname = "سعيد",
                    Email = "rana.saeed@library.com",
                    Salary = 6200.00m,
                    DateOfBirth = new DateTime(1994, 6, 28),
                    Bonus = 450.00m,
                    Address = "شارع الشيخ زايد، القاهرة",
                    PhoneNumber = "01001234567",
                    FloorId = 5,
                    SupervisorId = 9
                }
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            // Seed Shelves
            var shelves = new List<Shelf>
            {
                new Shelf { Code = "A1", FloorNumber = 1 },
                new Shelf { Code = "A2", FloorNumber = 1 },
                new Shelf { Code = "A3", FloorNumber = 1 },
                new Shelf { Code = "A4", FloorNumber = 1 },
                new Shelf { Code = "A5", FloorNumber = 1 },
                new Shelf { Code = "A6", FloorNumber = 1 },
                new Shelf { Code = "B1", FloorNumber = 2 },
                new Shelf { Code = "B2", FloorNumber = 2 },
                new Shelf { Code = "B3", FloorNumber = 2 },
                new Shelf { Code = "B4", FloorNumber = 2 },
                new Shelf { Code = "B5", FloorNumber = 2 },
                new Shelf { Code = "C1", FloorNumber = 3 },
                new Shelf { Code = "C2", FloorNumber = 3 },
                new Shelf { Code = "C3", FloorNumber = 3 },
                new Shelf { Code = "C4", FloorNumber = 3 },
                new Shelf { Code = "C5", FloorNumber = 3 },
                new Shelf { Code = "C6", FloorNumber = 3 },
                new Shelf { Code = "C7", FloorNumber = 3 },
                new Shelf { Code = "D1", FloorNumber = 4 },
                new Shelf { Code = "D2", FloorNumber = 4 },
                new Shelf { Code = "D3", FloorNumber = 4 },
                new Shelf { Code = "D4", FloorNumber = 4 },
                new Shelf { Code = "E1", FloorNumber = 5 },
                new Shelf { Code = "E2", FloorNumber = 5 },
                new Shelf { Code = "E3", FloorNumber = 5 },
                new Shelf { Code = "E4", FloorNumber = 5 },
                new Shelf { Code = "E5", FloorNumber = 5 },
                new Shelf { Code = "E6", FloorNumber = 5 },
                new Shelf { Code = "E7", FloorNumber = 5 },
                new Shelf { Code = "E8", FloorNumber = 5 }
            };
            context.Shelves.AddRange(shelves);
            context.SaveChanges();

            // Seed Authors
            var authors = new List<Author>
            {
                new Author { Name = "نجيب محفوظ" },
                new Author { Name = "طه حسين" },
                new Author { Name = "توفيق الحكيم" },
                new Author { Name = "يوسف إدريس" },
                new Author { Name = "أحمد شوقي" },
                new Author { Name = "حافظ إبراهيم" },
                new Author { Name = "محمود درويش" },
                new Author { Name = "نزار قباني" },
                new Author { Name = "جلال الدين الرومي" },
                new Author { Name = "عمر الخيام" },
                new Author { Name = "أحمد زويل" },
                new Author { Name = "طه حسين" },
                new Author { Name = "عباس محمود العقاد" },
                new Author { Name = "مصطفى لطفي المنفلوطي" },
                new Author { Name = "أحمد أمين" },
                new Author { Name = "زكي نجيب محمود" },
                new Author { Name = "عبد الرحمن بدوي" },
                new Author { Name = "محمد حسين هيكل" },
                new Author { Name = "إبراهيم المازني" },
                new Author { Name = "عبد القادر المازني" }
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();

            // Seed Publishers
            var publishers = new List<Publisher>
            {
                new Publisher { Name = "دار الشروق" },
                new Publisher { Name = "دار المعارف" },
                new Publisher { Name = "مكتبة مصر" },
                new Publisher { Name = "دار الهلال" },
                new Publisher { Name = "مكتبة الأسرة" },
                new Publisher { Name = "دار الكتب المصرية" },
                new Publisher { Name = "دار نهضة مصر" },
                new Publisher { Name = "مكتبة الأنجلو المصرية" },
                new Publisher { Name = "دار الفكر العربي" },
                new Publisher { Name = "مكتبة مدبولي" },
                new Publisher { Name = "دار الثقافة للنشر" },
                new Publisher { Name = "مكتبة دار العلوم" }
            };
            context.Publishers.AddRange(publishers);
            context.SaveChanges();

            // Seed Categories
            var categories = new List<Category>
            {
                new Category { CatName = "الرواية العربية" },
                new Category { CatName = "الشعر العربي" },
                new Category { CatName = "التاريخ" },
                new Category { CatName = "الفلسفة" },
                new Category { CatName = "العلوم" },
                new Category { CatName = "الأدب العالمي" },
                new Category { CatName = "التربية والتعليم" },
                new Category { CatName = "الطب" },
                new Category { CatName = "الاقتصاد" },
                new Category { CatName = "السياسة" },
                new Category { CatName = "الجغرافيا" },
                new Category { CatName = "الرياضيات" },
                new Category { CatName = "الفيزياء" },
                new Category { CatName = "الكيمياء" },
                new Category { CatName = "الأحياء" },
                new Category { CatName = "الحاسوب" },
                new Category { CatName = "اللغات" },
                new Category { CatName = "الفنون" },
                new Category { CatName = "الرياضة" },
                new Category { CatName = "السفر والسياحة" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // Seed Books
            var books = new List<Book>
            {
                new Book
                {
                    Title = "الثلاثية",
                    PublisherId = 1,
                    CategoryId = 1,
                    ShelfCode = "A1"
                },
                new Book
                {
                    Title = "الأيام",
                    PublisherId = 2,
                    CategoryId = 1,
                    ShelfCode = "A1"
                },
                new Book
                {
                    Title = "عودة الروح",
                    PublisherId = 3,
                    CategoryId = 1,
                    ShelfCode = "A2"
                },
                new Book
                {
                    Title = "الحرام",
                    PublisherId = 4,
                    CategoryId = 1,
                    ShelfCode = "A2"
                },
                new Book
                {
                    Title = "زقاق المدق",
                    PublisherId = 1,
                    CategoryId = 1,
                    ShelfCode = "A3"
                },
                new Book
                {
                    Title = "بداية ونهاية",
                    PublisherId = 2,
                    CategoryId = 1,
                    ShelfCode = "A3"
                },
                new Book
                {
                    Title = "ديوان أحمد شوقي",
                    PublisherId = 5,
                    CategoryId = 2,
                    ShelfCode = "A4"
                },
                new Book
                {
                    Title = "ديوان حافظ إبراهيم",
                    PublisherId = 6,
                    CategoryId = 2,
                    ShelfCode = "A4"
                },
                new Book
                {
                    Title = "ديوان محمود درويش",
                    PublisherId = 7,
                    CategoryId = 2,
                    ShelfCode = "A5"
                },
                new Book
                {
                    Title = "ديوان نزار قباني",
                    PublisherId = 8,
                    CategoryId = 2,
                    ShelfCode = "A5"
                },
                new Book
                {
                    Title = "تاريخ مصر الحديث",
                    PublisherId = 2,
                    CategoryId = 3,
                    ShelfCode = "B1"
                },
                new Book
                {
                    Title = "تاريخ الإسلام",
                    PublisherId = 3,
                    CategoryId = 3,
                    ShelfCode = "B1"
                },
                new Book
                {
                    Title = "فلسفة الأخلاق",
                    PublisherId = 3,
                    CategoryId = 4,
                    ShelfCode = "B2"
                },
                new Book
                {
                    Title = "فلسفة العلم",
                    PublisherId = 4,
                    CategoryId = 4,
                    ShelfCode = "B2"
                },
                new Book
                {
                    Title = "مقدمة في الفيزياء",
                    PublisherId = 4,
                    CategoryId = 5,
                    ShelfCode = "B3"
                },
                new Book
                {
                    Title = "أساسيات الكيمياء",
                    PublisherId = 5,
                    CategoryId = 5,
                    ShelfCode = "B3"
                },
                new Book
                {
                    Title = "ألف ليلة وليلة",
                    PublisherId = 1,
                    CategoryId = 6,
                    ShelfCode = "C1"
                },
                new Book
                {
                    Title = "الإلياذة",
                    PublisherId = 2,
                    CategoryId = 6,
                    ShelfCode = "C1"
                },
                new Book
                {
                    Title = "طرق التدريس الحديثة",
                    PublisherId = 5,
                    CategoryId = 7,
                    ShelfCode = "C2"
                },
                new Book
                {
                    Title = "علم النفس التربوي",
                    PublisherId = 6,
                    CategoryId = 7,
                    ShelfCode = "C2"
                },
                new Book
                {
                    Title = "أساسيات الطب",
                    PublisherId = 6,
                    CategoryId = 8,
                    ShelfCode = "C3"
                },
                new Book
                {
                    Title = "تشريح جسم الإنسان",
                    PublisherId = 7,
                    CategoryId = 8,
                    ShelfCode = "C3"
                },
                new Book
                {
                    Title = "مبادئ الاقتصاد",
                    PublisherId = 8,
                    CategoryId = 9,
                    ShelfCode = "C4"
                },
                new Book
                {
                    Title = "الاقتصاد السياسي",
                    PublisherId = 9,
                    CategoryId = 9,
                    ShelfCode = "C4"
                },
                new Book
                {
                    Title = "جغرافيا مصر",
                    PublisherId = 10,
                    CategoryId = 11,
                    ShelfCode = "C5"
                },
                new Book
                {
                    Title = "جغرافيا العالم",
                    PublisherId = 11,
                    CategoryId = 11,
                    ShelfCode = "C5"
                },
                new Book
                {
                    Title = "الرياضيات للجامعة",
                    PublisherId = 12,
                    CategoryId = 12,
                    ShelfCode = "C6"
                },
                new Book
                {
                    Title = "الفيزياء الحديثة",
                    PublisherId = 1,
                    CategoryId = 13,
                    ShelfCode = "C7"
                },
                new Book
                {
                    Title = "الكيمياء العضوية",
                    PublisherId = 2,
                    CategoryId = 14,
                    ShelfCode = "D1"
                },
                new Book
                {
                    Title = "علم الأحياء",
                    PublisherId = 3,
                    CategoryId = 15,
                    ShelfCode = "D1"
                },
                new Book
                {
                    Title = "برمجة الحاسوب",
                    PublisherId = 4,
                    CategoryId = 16,
                    ShelfCode = "D2"
                },
                new Book
                {
                    Title = "قواعد اللغة العربية",
                    PublisherId = 5,
                    CategoryId = 17,
                    ShelfCode = "D2"
                },
                new Book
                {
                    Title = "تاريخ الفن",
                    PublisherId = 6,
                    CategoryId = 18,
                    ShelfCode = "D3"
                },
                new Book
                {
                    Title = "الرياضة والصحة",
                    PublisherId = 7,
                    CategoryId = 19,
                    ShelfCode = "D3"
                },
                new Book
                {
                    Title = "دليل السياحة في مصر",
                    PublisherId = 8,
                    CategoryId = 20,
                    ShelfCode = "D4"
                }
            };
            context.Books.AddRange(books);
            context.SaveChanges();

            // Seed BookAuthors (Many-to-Many relationship)
            var bookAuthors = new List<BookAuthor>
            {
                new BookAuthor { BookId = 1, AuthorId = 1 }, // الثلاثية - نجيب محفوظ
                new BookAuthor { BookId = 2, AuthorId = 2 }, // الأيام - طه حسين
                new BookAuthor { BookId = 3, AuthorId = 3 }, // عودة الروح - توفيق الحكيم
                new BookAuthor { BookId = 4, AuthorId = 4 }, // الحرام - يوسف إدريس
                new BookAuthor { BookId = 5, AuthorId = 1 }, // زقاق المدق - نجيب محفوظ
                new BookAuthor { BookId = 6, AuthorId = 1 }, // بداية ونهاية - نجيب محفوظ
                new BookAuthor { BookId = 7, AuthorId = 5 }, // ديوان أحمد شوقي
                new BookAuthor { BookId = 8, AuthorId = 6 }, // ديوان حافظ إبراهيم
                new BookAuthor { BookId = 9, AuthorId = 7 }, // ديوان محمود درويش
                new BookAuthor { BookId = 10, AuthorId = 8 }, // ديوان نزار قباني
                new BookAuthor { BookId = 11, AuthorId = 2 }, // تاريخ مصر الحديث - طه حسين
                new BookAuthor { BookId = 12, AuthorId = 13 }, // تاريخ الإسلام - عباس محمود العقاد
                new BookAuthor { BookId = 13, AuthorId = 3 }, // فلسفة الأخلاق - توفيق الحكيم
                new BookAuthor { BookId = 14, AuthorId = 16 }, // فلسفة العلم - زكي نجيب محمود
                new BookAuthor { BookId = 15, AuthorId = 11 }, // مقدمة في الفيزياء - أحمد زويل
                new BookAuthor { BookId = 16, AuthorId = 11 }, // أساسيات الكيمياء - أحمد زويل
                new BookAuthor { BookId = 17, AuthorId = 14 }, // ألف ليلة وليلة - مصطفى لطفي المنفلوطي
                new BookAuthor { BookId = 18, AuthorId = 15 }, // الإلياذة - أحمد أمين
                new BookAuthor { BookId = 19, AuthorId = 17 }, // طرق التدريس - عبد الرحمن بدوي
                new BookAuthor { BookId = 20, AuthorId = 18 }, // علم النفس التربوي - محمد حسين هيكل
                new BookAuthor { BookId = 21, AuthorId = 19 }, // أساسيات الطب - إبراهيم المازني
                new BookAuthor { BookId = 22, AuthorId = 20 }, // تشريح جسم الإنسان - عبد القادر المازني
                new BookAuthor { BookId = 23, AuthorId = 13 }, // مبادئ الاقتصاد - عباس محمود العقاد
                new BookAuthor { BookId = 24, AuthorId = 16 }, // الاقتصاد السياسي - زكي نجيب محمود
                new BookAuthor { BookId = 25, AuthorId = 15 }, // جغرافيا مصر - أحمد أمين
                new BookAuthor { BookId = 26, AuthorId = 17 }, // جغرافيا العالم - عبد الرحمن بدوي
                new BookAuthor { BookId = 27, AuthorId = 18 }, // الرياضيات للجامعة - محمد حسين هيكل
                new BookAuthor { BookId = 28, AuthorId = 11 }, // الفيزياء الحديثة - أحمد زويل
                new BookAuthor { BookId = 29, AuthorId = 11 }, // الكيمياء العضوية - أحمد زويل
                new BookAuthor { BookId = 30, AuthorId = 19 }, // علم الأحياء - إبراهيم المازني
                new BookAuthor { BookId = 31, AuthorId = 20 }, // برمجة الحاسوب - عبد القادر المازني
                new BookAuthor { BookId = 32, AuthorId = 14 }, // قواعد اللغة العربية - مصطفى لطفي المنفلوطي
                new BookAuthor { BookId = 33, AuthorId = 15 }, // تاريخ الفن - أحمد أمين
                new BookAuthor { BookId = 34, AuthorId = 16 }, // الرياضة والصحة - زكي نجيب محمود
                new BookAuthor { BookId = 35, AuthorId = 17 }  // دليل السياحة - عبد الرحمن بدوي
            };
            context.BookAuthors.AddRange(bookAuthors);
            context.SaveChanges();

            // Seed Users
            var users = new List<User>
            {
                new User
                {
                    SSN = "123456789012345",
                    Name = "عبدالله أحمد",
                    Email = "abdullah.ahmed@email.com",
                    Phone = "01112345678",
                    RegisteredByEmployeeId = 1
                },
                new User
                {
                    SSN = "234567890123456",
                    Name = "مريم محمد",
                    Email = "mariam.mohamed@email.com",
                    Phone = "01123456789",
                    RegisteredByEmployeeId = 2
                },
                new User
                {
                    SSN = "345678901234567",
                    Name = "عمر علي",
                    Email = "omar.ali@email.com",
                    Phone = "01134567890",
                    RegisteredByEmployeeId = 3
                },
                new User
                {
                    SSN = "456789012345678",
                    Name = "فاطمة حسن",
                    Email = "fatima.hassan@email.com",
                    Phone = "01145678901",
                    RegisteredByEmployeeId = 4
                },
                new User
                {
                    SSN = "567890123456789",
                    Name = "أحمد محمود",
                    Email = "ahmed.mahmoud@email.com",
                    Phone = "01156789012",
                    RegisteredByEmployeeId = 5
                },
                new User
                {
                    SSN = "678901234567890",
                    Name = "سارة عمر",
                    Email = "sara.omar@email.com",
                    Phone = "01167890123",
                    RegisteredByEmployeeId = 6
                },
                new User
                {
                    SSN = "789012345678901",
                    Name = "محمد أحمد",
                    Email = "mohamed.ahmed@email.com",
                    Phone = "01178901234",
                    RegisteredByEmployeeId = 1
                },
                new User
                {
                    SSN = "890123456789012",
                    Name = "نور محمد",
                    Email = "nour.mohamed@email.com",
                    Phone = "01189012345",
                    RegisteredByEmployeeId = 2
                },
                new User
                {
                    SSN = "901234567890123",
                    Name = "خالد عبدالله",
                    Email = "khaled.abdullah@email.com",
                    Phone = "01190123456",
                    RegisteredByEmployeeId = 7
                },
                new User
                {
                    SSN = "012345678901234",
                    Name = "ليلى مصطفى",
                    Email = "layla.mostafa@email.com",
                    Phone = "01101234567",
                    RegisteredByEmployeeId = 8
                },
                new User
                {
                    SSN = "111111111111111",
                    Name = "يوسف إبراهيم",
                    Email = "youssef.ibrahim@email.com",
                    Phone = "01111111111",
                    RegisteredByEmployeeId = 9
                },
                new User
                {
                    SSN = "222222222222222",
                    Name = "رنا سعيد",
                    Email = "rana.saeed@email.com",
                    Phone = "01122222222",
                    RegisteredByEmployeeId = 10
                },
                new User
                {
                    SSN = "333333333333333",
                    Name = "علي محمود",
                    Email = "ali.mahmoud@email.com",
                    Phone = "01133333333",
                    RegisteredByEmployeeId = 3
                },
                new User
                {
                    SSN = "444444444444444",
                    Name = "نادية أحمد",
                    Email = "nadia.ahmed@email.com",
                    Phone = "01144444444",
                    RegisteredByEmployeeId = 4
                },
                new User
                {
                    SSN = "555555555555555",
                    Name = "حسن علي",
                    Email = "hassan.ali@email.com",
                    Phone = "01155555555",
                    RegisteredByEmployeeId = 5
                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // Seed BookBorrows
            var bookBorrows = new List<BookBorrow>
            {
                new BookBorrow
                {
                    BookId = 1,
                    UserSSN = "123456789012345",
                    EmployeeId = 1,
                    DateBorrowed = DateTime.Now.AddDays(-30),
                    DueDate = DateTime.Now.AddDays(5),
                    AmountPaid = 25.00m
                },
                new BookBorrow
                {
                    BookId = 2,
                    UserSSN = "234567890123456",
                    EmployeeId = 2,
                    DateBorrowed = DateTime.Now.AddDays(-25),
                    DueDate = DateTime.Now.AddDays(10),
                    AmountPaid = 20.00m
                },
                new BookBorrow
                {
                    BookId = 3,
                    UserSSN = "345678901234567",
                    EmployeeId = 3,
                    DateBorrowed = DateTime.Now.AddDays(-40),
                    DueDate = DateTime.Now.AddDays(-5), // Overdue
                    AmountPaid = 30.00m
                },
                new BookBorrow
                {
                    BookId = 4,
                    UserSSN = "456789012345678",
                    EmployeeId = 4,
                    DateBorrowed = DateTime.Now.AddDays(-15),
                    DueDate = DateTime.Now.AddDays(15),
                    AmountPaid = 22.50m
                },
                new BookBorrow
                {
                    BookId = 5,
                    UserSSN = "567890123456789",
                    EmployeeId = 5,
                    DateBorrowed = DateTime.Now.AddDays(-20),
                    DueDate = DateTime.Now.AddDays(8),
                    AmountPaid = 18.00m
                },
                new BookBorrow
                {
                    BookId = 6,
                    UserSSN = "678901234567890",
                    EmployeeId = 6,
                    DateBorrowed = DateTime.Now.AddDays(-35),
                    DueDate = DateTime.Now.AddDays(-2), // Overdue
                    AmountPaid = 15.00m
                },
                new BookBorrow
                {
                    BookId = 7,
                    UserSSN = "789012345678901",
                    EmployeeId = 1,
                    DateBorrowed = DateTime.Now.AddDays(-10),
                    DueDate = DateTime.Now.AddDays(20),
                    AmountPaid = 35.00m
                },
                new BookBorrow
                {
                    BookId = 8,
                    UserSSN = "890123456789012",
                    EmployeeId = 2,
                    DateBorrowed = DateTime.Now.AddDays(-5),
                    DueDate = DateTime.Now.AddDays(25),
                    AmountPaid = 28.00m
                },
                new BookBorrow
                {
                    BookId = 9,
                    UserSSN = "123456789012345",
                    EmployeeId = 3,
                    DateBorrowed = DateTime.Now.AddDays(-45),
                    DueDate = DateTime.Now.AddDays(-10), // Overdue
                    AmountPaid = 40.00m
                },
                new BookBorrow
                {
                    BookId = 10,
                    UserSSN = "234567890123456",
                    EmployeeId = 4,
                    DateBorrowed = DateTime.Now.AddDays(-8),
                    DueDate = DateTime.Now.AddDays(22),
                    AmountPaid = 32.00m
                },
                new BookBorrow
                {
                    BookId = 11,
                    UserSSN = "901234567890123",
                    EmployeeId = 7,
                    DateBorrowed = DateTime.Now.AddDays(-12),
                    DueDate = DateTime.Now.AddDays(18),
                    AmountPaid = 27.00m
                },
                new BookBorrow
                {
                    BookId = 12,
                    UserSSN = "012345678901234",
                    EmployeeId = 8,
                    DateBorrowed = DateTime.Now.AddDays(-50),
                    DueDate = DateTime.Now.AddDays(-15), // Overdue
                    AmountPaid = 45.00m
                },
                new BookBorrow
                {
                    BookId = 13,
                    UserSSN = "111111111111111",
                    EmployeeId = 9,
                    DateBorrowed = DateTime.Now.AddDays(-3),
                    DueDate = DateTime.Now.AddDays(27),
                    AmountPaid = 33.00m
                },
                new BookBorrow
                {
                    BookId = 14,
                    UserSSN = "222222222222222",
                    EmployeeId = 10,
                    DateBorrowed = DateTime.Now.AddDays(-18),
                    DueDate = DateTime.Now.AddDays(12),
                    AmountPaid = 29.00m
                },
                new BookBorrow
                {
                    BookId = 15,
                    UserSSN = "333333333333333",
                    EmployeeId = 3,
                    DateBorrowed = DateTime.Now.AddDays(-60),
                    DueDate = DateTime.Now.AddDays(-25), // Overdue
                    AmountPaid = 50.00m
                },
                new BookBorrow
                {
                    BookId = 16,
                    UserSSN = "444444444444444",
                    EmployeeId = 4,
                    DateBorrowed = DateTime.Now.AddDays(-7),
                    DueDate = DateTime.Now.AddDays(23),
                    AmountPaid = 31.00m
                },
                new BookBorrow
                {
                    BookId = 17,
                    UserSSN = "555555555555555",
                    EmployeeId = 5,
                    DateBorrowed = DateTime.Now.AddDays(-22),
                    DueDate = DateTime.Now.AddDays(8),
                    AmountPaid = 26.00m
                },
                new BookBorrow
                {
                    BookId = 18,
                    UserSSN = "123456789012345",
                    EmployeeId = 6,
                    DateBorrowed = DateTime.Now.AddDays(-55),
                    DueDate = DateTime.Now.AddDays(-20), // Overdue
                    AmountPaid = 38.00m
                },
                new BookBorrow
                {
                    BookId = 19,
                    UserSSN = "234567890123456",
                    EmployeeId = 7,
                    DateBorrowed = DateTime.Now.AddDays(-14),
                    DueDate = DateTime.Now.AddDays(16),
                    AmountPaid = 24.00m
                },
                new BookBorrow
                {
                    BookId = 20,
                    UserSSN = "345678901234567",
                    EmployeeId = 8,
                    DateBorrowed = DateTime.Now.AddDays(-9),
                    DueDate = DateTime.Now.AddDays(21),
                    AmountPaid = 36.00m
                }
            };
            context.BookBorrows.AddRange(bookBorrows);
            context.SaveChanges();
        }
    }
} 