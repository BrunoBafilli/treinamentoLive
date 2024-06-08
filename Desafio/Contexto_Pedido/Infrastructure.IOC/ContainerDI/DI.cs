﻿using Infrastructure.Database.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.ArchPatterns.UnitOfWork;

namespace Infrastructure.IOC.ContainerDI
{
    public class DI
    {
        private static IServiceProvider _serviceProvider;

        static DI()
        {
            var services = new ServiceCollection();
            RegisterServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUnitOfWork, UnityOfWork>();

            //services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}