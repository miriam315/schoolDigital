using SchoolDigital.Core.Repositories;
using SchoolDigital.Core.Service;
using SchoolDigital.Data.Repositories;
using SchoolDigital.Service.Service;
using SchoolDigital.Data; // וודא שזה ה-Namespace של ה-DataContext שלך
using SchoolDigital;

var builder = WebApplication.CreateBuilder(args);

// הוספת השירותים למיכל (Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- רישום שכבת הנתונים ---
// רישום ה-DataContext לניהול הגישה למסד הנתונים
builder.Services.AddDbContext<DataContext>();

// רישום ה-Repository Manager שמנהל את כל ה-Repositories
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

// --- רישום שכבת הלוגיקה (Services) ---
// כל שירות נרשם עם הממשק שלו כדי לאפשר גמישות בבדיקות
builder.Services.AddScoped<ILessonsService, LessonsService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// הגדרת ה-Pipeline של הבקשות
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();