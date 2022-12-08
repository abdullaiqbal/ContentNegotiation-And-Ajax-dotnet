using ContentNegotiationAndAjax.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddControllers(options =>
//{
//    options.RespectBrowserAcceptHeader = true;

//})
//.AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//});


//Localization
//builder.Services.AddLocalization(options => options.ResourcesPath = "Resource folder");

//Content Negotiation
builder.Services.AddMvc()
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters();



//// content negosiation 
//builder.Services.AddControllers(options =>
//{
//    options.RespectBrowserAcceptHeader = true;
//    options.ReturnHttpNotAcceptable = true;
//}).AddXmlSerializerFormatters();


//builder.Services.AddControllers(options =>
//{
//    options.InputFormatters.Insert(0, );
//    options.OutputFormatters.Insert(0, new VcardOutputFormatter());
//});

//.AddFormatterMappings();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
