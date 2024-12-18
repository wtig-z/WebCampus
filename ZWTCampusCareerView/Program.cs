using ZWTCampusCareerView.BLL;
using ZWTCampusCareerView.DAL;
using Microsoft.Extensions.DependencyInjection;
using ZWTCampusCareerView.BLL.Interfaces;
using ZWTCampusCareerView.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ע�����
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

// ��ӿ�����֧��
builder.Services.AddControllers();

// ���� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// ���� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ������ܵ���ʹ�� CORS
app.UseCors("AllowAllOrigins");

// ���� HTTP ����ܵ�
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
