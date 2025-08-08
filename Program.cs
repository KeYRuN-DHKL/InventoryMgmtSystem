using InventoryMgmtSystem.Data;
using InventoryMgmtSystem.Repository;
using InventoryMgmtSystem.Repository.Interface;
using InventoryMgmtSystem.Services;
using InventoryMgmtSystem.services.Interfaces;
using InventoryMgmtSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        
        PositionClass = ToastPositions.BottomRight,
        PreventDuplicates = true,
        CloseButton = true
    });
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IStakeHolderService, StakeHolderService>();
builder.Services.AddScoped<IStakeHolderRepository, StakeHolderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
    pattern: "{controller=StakeHolder}/{action=Index}/{id?}");

app.Run();