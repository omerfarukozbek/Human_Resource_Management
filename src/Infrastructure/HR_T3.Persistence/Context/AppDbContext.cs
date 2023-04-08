using HR_T3.Application.Helpers;
using HR_T3.Domain.Entities;
using HR_T3.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_T3.Context.Persistence;

public class AppDbContext : IdentityDbContext<Person, Role, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>().HasOne(x => x.Company).WithMany(x => x.Employees).HasForeignKey(x => x.CompanyId);
        builder.Entity<Person>().HasMany(x => x.Costs).WithOne(x => x.Person).HasForeignKey(x => x.PersonId);

        var company = new Company()
        {
            Id = 1,
            Name = "Bilge Adam Boost Team 3",
            Address = "Bilge Adam Ankara",
        };
        builder.Entity<Company>().HasData(company);

        string[] roles = new string[] { "Administrator", "Project Manager", "Employee" };

        Role administratorRole = new()
        {
            Id = "admin",
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        };
        Role projectManagerRole = new()
        {
            Id = "projectmanager",
            Name = "Project Manager",
            NormalizedName = "PROJECT MANAGER"
        };
        Role employeeRole = new()
        {
            Id = "employee",
            Name = "Employee",
            NormalizedName = "EMPLOYEE"
        };
        builder.Entity<Role>().HasData(administratorRole, projectManagerRole, employeeRole);
        var hasher = new PasswordHasher<IdentityUser>();

        Person projectManager = new()
        {
            CompanyId = 1,
            Id = "59323082791",
            Name = "Fatma",
            Surname = "Yılmaz",
            MiddleName = "Şenay",
            LastSurName = "Çiftçi",
            Photo = "assets/images/PersonImages/3ff4d788-306e-401b-bb2e-5c61d6b6e5b6.png",
            Birthday = DateTime.Parse("08/12/1989"),
            PhoneNumber = "12345678901",
            Address = "adres kısmı",
            Graduation = Graduation.Masters,
            Title = Title.ProjectManager,
            Department = Department.BT,
            StartDateOfWork = DateTime.Now.AddYears(-5),
            AnnualPermit = 20,
            Salary = 25000,
            PasswordHash = hasher.HashPassword(null, "deneme123"),
            UserName = "fciftci",
            NormalizedUserName = "FCIFTCI",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            IsActive = true
        };
        projectManager.Email = MailHelper.GenerateMailAddress(projectManager.Name,
                                                              projectManager.MiddleName,
                                                              projectManager.Surname,
                                                              projectManager.LastSurName);

        Person employee = new()
        {
            CompanyId = 1,
            Id = "59323082792",
            Name = "Yüksel",
            Surname = "Güzel",
            MiddleName = "",
            LastSurName = "",
            Photo = "assets/images/PersonImages/3ff4d788-306e-401b-bb2e-5c61d6b6e5b6.png",
            Birthday = DateTime.Parse("08/12/1989"),
            PhoneNumber = "05065385385",
            Address = "adres kısmı",
            Graduation = Graduation.Masters,
            Title = Title.ProjectManager,
            Department = Department.BT,
            StartDateOfWork = DateTime.Now.AddYears(-5),
            AnnualPermit = 20,
            Salary = 25000,
            PasswordHash = hasher.HashPassword(null, "deneme123"),
            UserName = "yguzel",
            NormalizedUserName = "YGUZEL",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            IsActive = true
        };
        employee.Email = MailHelper.GenerateMailAddress(employee.Name,
                                                      employee.MiddleName,
                                                      employee.Surname,
                                                      employee.LastSurName);

        builder.Entity<Person>().HasData(projectManager, employee);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = projectManager.Id,
                RoleId = projectManagerRole.Id
            },
            new IdentityUserRole<string>
            {
                UserId = employee.Id,
                RoleId = employeeRole.Id
            });
        builder.Entity<Cost>().HasData(
            new Cost
            {
                Id = 1,
                TypeOfCost = TypeOfCost.Taksi,
                Damage = 500,
                ResponseDate = DateTime.Now.AddDays(-1),
                ReplyDate = null,
                ApprovalStatus = ApprovalStatus.Bekleyen,
                File = null,
                PersonId = employee.Id
            },
            new Cost
            {
                Id = 2,
                TypeOfCost = TypeOfCost.Konaklama,
                Damage = 1.000,
                ResponseDate = DateTime.Now.AddYears(-1),
                ReplyDate = DateTime.Now,
                ApprovalStatus = ApprovalStatus.Onaylandı,
                File = null,
                PersonId = employee.Id
            }
            );


        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Cost> Costs { get; set; }

}
