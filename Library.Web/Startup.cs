using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Library.DataAccessCommands.Books.Repositories;
using Library.DataAccessCommands.Commons;
using Library.DataAccessCommands.Context;
using Library.DataAccessQueries.Books.Repositories;
using Library.Domains.Books.Commands;
using Library.Domains.Books.Entities;
using Library.Domains.Books.Queries;
using Library.Domains.Books.Repositories;
using Library.Domains.Commons;
using Library.Services.Books.Queries.Behaviors;
using Library.Services.Books.Validators;
using Library.Services.PipelineBehaviors;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;

namespace Library.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region SeriLog

            Log.Logger = new LoggerConfiguration()

                .ReadFrom.Configuration(Configuration)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            #endregion
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            #region DbContext

            services.AddDbContext<LibraryContext>(option =>
                { option.UseSqlServer(Configuration["ConnectionStrings:CommandConnection"]); });

            #endregion

            #region Mapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("Library.Services");
            services.AddMediatR(assembly);

            #endregion


            #region Validator

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Book>, BookValidations>();
            services.AddTransient<IValidator<AddBookInfo>, AddBookInfoValidation>();


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehavior<,>));
            //   services.AddTransient(typeof(IPipelineBehavior<AddBookInfo, ResultStatusType>), typeof(AddBookInfoValid<AddBookInfo,ResultStatusType>));
            services.AddTransient(typeof(IPipelineBehavior<GetBookBySearch, List<Book>>), typeof(SearchBehavior<GetBookBySearch, List<Book>>));


            #endregion


            #region IOC

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepositoryCommand, BookRepositoryCommand>();
            services.AddScoped<IBookRepositoryQuery, BookRepositoryQuery>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //AdminPanel
                endpoints.MapAreaControllerRoute(
                    "AdminPanel",
                    "AdminPanel",
                    "AdminPanel/{Controller=BookManager}/{Action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
