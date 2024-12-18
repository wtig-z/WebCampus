using ZWTCampusCareerView.BLL;
using ZWTCampusCareerView.DAL;
using Microsoft.Extensions.DependencyInjection;
using ZWTCampusCareerView.BLL.Interfaces;
using ZWTCampusCareerView.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 注册服务
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

// 添加控制器支持
builder.Services.AddControllers();

// 配置 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// 配置 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 在请求管道中使用 CORS
app.UseCors("AllowAllOrigins");

// 配置 HTTP 请求管道
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
