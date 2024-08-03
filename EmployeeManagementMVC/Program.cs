using Microsoft.EntityFrameworkCore;
using EmployeeManagementMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using EmployeeManagementMVC.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<AppDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequiredLength = 10;
})
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditRolePolicy",
       policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

    options.AddPolicy("DeleteRolePolicy",
       policy => policy.RequireAssertion(context =>
            (context.User.IsInRole("Admin") &&
            context.User.HasClaim(claim => claim.Type == "Delete Role" && claim.Value == "true")) ||
            context.User.IsInRole("Super Admin")));

    options.AddPolicy("AdminRolePolicy",
       policy => policy.RequireRole("Admin"));
});

builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

builder.Services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();

builder.Services.AddSingleton<DataProtectionPurposeStrings>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
}
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
