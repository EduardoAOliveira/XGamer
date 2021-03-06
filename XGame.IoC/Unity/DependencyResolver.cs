﻿using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Repositories.Base;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Services;
using XGame.Infrastructure.Persistence.Map;
using XGame.Infrastructure.Persistence.Repositories;
using XGame.Infrastructure.Persistence.Repositories.Base;
using XGame.Infrastructure.Transaction;

namespace XGame.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, XGameContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager()); // Identificação da interface com a classe concreta.
            container.RegisterType<IServiceJogo, ServiceJogo>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryJogo, RepositoryJogo>(new HierarchicalLifetimeManager());
                       
        }
    }
}
