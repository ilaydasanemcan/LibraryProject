using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.BussinessLayer.Concrete;
using LibraryProject.DataAccessLayer.Abstract;
using LibraryProject.DataAccessLayer.Concrete.DapperContext;
using LibraryProject.DataAccessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryDal, CategoryDal>();
builder.Services.AddTransient<IBookDal, BookDal>();
builder.Services.AddTransient<IAuthorDal, AuthorDal>();
builder.Services.AddTransient<ICategoryService, CategoryManager>();
builder.Services.AddTransient<IBookService, BookManager>();
builder.Services.AddTransient<IAuthorService, AuthorManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
