using System.Collections.Generic    ;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Controller;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=mystudies.db"));

var app = builder.Build();

SubjectsController.MapSubjectRoutes(app);


app.Run();
                                                                                                       