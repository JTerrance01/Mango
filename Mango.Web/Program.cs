using Mango.Web.Service.IService;
using Mango.Web.Service;
using Mango.Web.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Inject HttpContextAccessor and HttpClient
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

//Add related HttpClient Services
builder.Services.AddHttpClient<ICouponService, CouponService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();


//Define the ServiceUrls
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

//Add Scoped Services
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IAuthService, AuthService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
