using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaiustHostel.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
	    public Student Student { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

		public DbSet<FoodItem> FoodItems { get; set; }
		public DbSet<FoodMenu> FoodMenus { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Meal> Meals { get; set; }
		public DbSet<StudentMeal> StudentMeals { get; set; }
		public DbSet<UserImage> UserImage { get; set; }
		public DbSet<ExtraMeal> ExtraMeals { get; set; }
		public DbSet<StudentsPay> StudentsPays { get; set; }
		public DbSet<Notice> Notics { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<UserNotification> UserNotifications { get; set; }
		public DbSet<Sit> Sits { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<MonthlyBill> MonthlyBills { get; set; }
		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<ApplicationUser>()
		        .HasOptional(a => a.Student)
		        .WithRequired(s => s.UserAccount);


		

	        base.OnModelCreating(modelBuilder);
        }
    }
}