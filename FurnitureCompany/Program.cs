using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Repository;
using FurnitureCompany.ServiceImplement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
    
});*/
//aaa
//builder.Services.AddSwaggerGen();
//
//config cho swagger
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid JWT beare token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme

        }
    };
    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[]{} }
    });
});
//add CORS
//c1
builder.Services.AddCors();
//c2
/*builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000/");
        });
});*/


builder.Services.AddDbContext<FurnitureCompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FurnitureCompanyDB"));
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>

    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServiceRepository,ServiceRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IServiceDetailRepository, ServiceDetailRepository>();
builder.Services.AddScoped<IEmployeeDayOffRepository, EmployeeDayOffRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IAssignRepository, AssignRepository>();
builder.Services.AddScoped<IOrderServiceRepository, OrderServiceRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IWorkingStatusRepository, WorkingStatusRepository>();


//service map
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<IEmployeeDayOffService, EmployeeDayOffServiceImpl>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyServiceImpl>();
builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<IManagerService, ManagerServiceImpl>();
builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
builder.Services.AddScoped<IAssignService, AssignServiceImpl>();
builder.Services.AddScoped<IOrderService, OrderServiceImpl>();
builder.Services.AddScoped<IRoleService, RoleServiceImpl>();
builder.Services.AddScoped<IFurnitureServiceService, FurnitureServiceServiceImpl>();
builder.Services.AddScoped<ICustomerAddressService, CustomerAddressServiceImpl>();
builder.Services.AddScoped<IAccountService, AccountServiceImpl>();
builder.Services.AddScoped<IWorkingStatusService, WorkingStatusServiceImpl>();

//configure security
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = "http://furniturecompany-001-site1.btempurl.com",
    //ValidAudience ko co s cuoi cung
    ValidAudience = "http://furniturecompany-001-site1.btempurl.com",
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloearththisismysecrectkeyforjwt123456789"))
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
      app.UseSwagger();
      app.UseSwaggerUI();
}
//khi nào lên production thì dùng cái này
/*if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {

        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
        c.RoutePrefix = string.Empty;
    });
}*/

//ADD CORS
//AllowAnyOrigin().
//c2 
app.UseCors(c => c.SetIsOriginAllowed(isOriginAllowed => true).AllowCredentials().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
