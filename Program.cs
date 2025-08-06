using HelpDesk_Benedict.Components;
using HelpDesk_Benedict.Data;
using HelpDesk_Benedict.Models;
using HelpDesk_Benedict.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<UserDataService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<TicketCommentService>();

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.AccessDeniedPath = "/denied";
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddBlazorBootstrap();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

var app = builder.Build();


using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var dbContextFactory = services.GetRequiredService<ApplicationDbContext>();
    await SeedAdmin.SeedRolesAndAdminAsync(services);
    await SeedRoom.SeedRoomsAsync(dbContextFactory);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment()) {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorPages();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<TicketCommentHub>("/ticketCommentHub");

app.Run();