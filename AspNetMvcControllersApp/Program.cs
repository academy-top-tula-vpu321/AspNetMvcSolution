var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();


public interface ITimeService
{
    string GetTime { get; }
}

public class ShortTimeService : ITimeService
{
    public string GetTime => DateTime.Now.ToShortTimeString();
}
