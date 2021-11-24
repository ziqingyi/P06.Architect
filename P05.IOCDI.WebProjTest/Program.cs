using P05.IOCDI.Service;
using P05.IOCDI.ServiceInterface;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region

builder.Services.AddTransient<ITestServiceA,TestServiceA>();
   builder.Services.AddScoped<ITestServiceB, TestServiceB>();
builder.Services.AddTransient<ITestServiceC, TestServiceC>();
builder.Services.AddSingleton<ITestServiceD, TestServiceD>();
builder.Services.AddTransient<ITestServiceE, TestServiceE>();

#endregion



WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
