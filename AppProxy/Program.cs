using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddReverseProxy()
        .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddHttpClient("Dev_Client", c =>
{
    c.BaseAddress = new Uri("https://api-dev.hotaimotor.com.tw/service/SRLAPP/api/SRLAPP");
});
builder.Services.AddHttpClient("Prod_Client", c =>
{
    c.BaseAddress = new Uri("https://api.hotaimotor.com.tw/service/SRLAPP/api/SRLAPP");
});
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetPreflightMaxAge(TimeSpan.FromDays(1)))//.AllowAnyMethod())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapReverseProxy();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseCors();

app.MapGet("/api", () => "Hello World");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Values}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS001_S00}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS001_S01}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS001_S02}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS001_S03}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS002_S01}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS002_S02}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS002_S03}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS002_S04}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS003_S01}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS003_S02}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS003_S03}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS003_S04}/{action}/{id?}");


app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS004_S01}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS004_S02}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS004_S03}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS004_S04}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS005_S01}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS005_S02}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S01}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S02}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S03}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S04}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S05}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S06}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS006_S07}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S01}/{actio}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S02}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S03}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S04}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S05}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S06}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS007_S07}/{action}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS008_S01}/{action}/{id?}");
app.MapControllerRoute(
    name: "test",
    pattern: "{controller=SRLMBS008_S02}/{action}/{id?}");
app.Run();
