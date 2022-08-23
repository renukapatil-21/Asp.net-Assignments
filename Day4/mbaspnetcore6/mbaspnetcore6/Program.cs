// WebApplication: The Web ENvironment that is common for
// Razor Views, MVC, and APIs
// Build and Initialize the HTTP Pipeline for
// 1. Registeing all Dependencies as Service
// 2. Middlewares
var builder = WebApplication.CreateBuilder(args);

// The builder is a WebApplicationBuilder class
// THis is used to Provide the 'Dependency Container'
// This provides the ApplicationBuilder

// Add services to the container.
// The 'Services' is of the type 'IServiceCollection' which is DI Container
// to register all Services
// The DI For the MVC COntroller and View


// Registration of the Data Access Lyer in The DI Container Provided
// by ASP.NET Core

// Registered the DepartmentDataAcess
// The class which will be injected using IDataAccess<Department,int>
// will be actually injected usign an Instance of DepartmentDataAccess class
// because the DI Container is already registered using
// the DepartmentDataAccess
builder.Services.AddScoped<IDataAccess<Department,int>, DepartmentDataAccess>();
builder.Services.AddScoped<IDataAccess<Employee, int>, EmployeeDataAccess>();


// Also Register all Repositoiry services in DI Container
builder.Services.AddScoped<IServiceRepository<Department, int>, DepartmentRepository>();

builder.Services.AddScoped<IServiceRepository<Employee, int>, EmployeeRepository>();


// Adding Session Service
// Tell Server that Session will be stored
// in the Memory of the Hosting Env.
builder.Services.AddDistributedMemoryCache();
// The Session Condiguration
// The Session will be closed if
// After the First Request to Server
// the Server does not receive any request for next 20 mins
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(20);

});


// Service registered for Request Processing for MVC and API Controller and MVC Views
// Lets Configure the Action Filter for the MVC COntrollers
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new LogFilterAttribute());
});


// Application Builder for Registering Middlewares for
// HTTP Pipelie
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Redirect HTTP Request to HTTPS while production
app.UseHttpsRedirection();
// Read all Static files for Download/Upload Operations 
app.UseStaticFiles();
// Contains a Route Table
app.UseRouting();

// COnfigure the Session Middleware
// THis will use Configuration for session
// from Session Service from DI COntainer
app.UseSession();


// For Role Based Security
app.UseAuthorization();
// Pass the Request to MVC Controllers
// That matches with the ControllerName in Route Table
// Default is HomeController class and its method is Index
// The 'id' is an Optional Parameter, used in case of Edit and Delete
// Or Whichever an action method that accepts an 'id' parameter
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

