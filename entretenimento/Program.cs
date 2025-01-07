using infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);



//builder
//    .Services
//        .ConfigureApplicationCookie(config =>
//        {
//            config.LoginPath = "/login";
//            config.AccessDeniedPath = "/";
//        });

//builder
//    .Services
//        .AddAuthorization(options =>
//        {
//            options.AddPolicy("private", policy =>
//            {
//                policy.RequireAuthenticatedUser();
//            });
//        });
//builder
//    .Services
//        .AddMvc()
//        .AddRazorPagesOptions(options =>
//        {
//            options
//                .RootDirectory = "/Pages";
//            options
//                .Conventions.AddPageRoute("/Test", "peooples/{handler?}");
//            options
//                .Conventions
//                    .AuthorizeFolder("/")
//                    .AllowAnonymousToPage("/login");
//        });

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();
