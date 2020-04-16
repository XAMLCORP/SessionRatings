using Gaming.Client.Entities;
using Gaming.Foundation.Async;
using Gaming.Foundation.DependencyInjection;
using Gaming.Users.Interfaces.Repositores;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gaming.Users.Repositories
{
    public static class Data
    {
        public static void ScaffoldDatabase()
        {
            EnsureStorageTableExists();

            var repository = (UserRepository)ServiceLocator.Instance.GetService<IUserRepository>();

            var entity = new User();
            entity.Id = Guid.Parse("88a4b287-a170-4a13-bb1e-91c4bdaa259c");
            entity.FirstName = "Sherlock";
            entity.LastName = "Holmes";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new User();
            entity.Id = Guid.Parse("a9b3b49f-a9d1-48f6-80cf-2378026841a9");
            entity.FirstName = "Jean-Luc";
            entity.LastName = "Picard";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new User();
            entity.Id = Guid.Parse("a8ee8558-0b46-4f66-a391-559ec983b7ea");
            entity.FirstName = "Homer";
            entity.LastName = "Simpson";
            AsyncHelper.RunSync(() => repository.Save(entity));
        }

        private static void EnsureStorageTableExists()
        {
            var repository = ServiceLocator.Instance.GetService<IUserRepository>();
            AsyncHelper.RunSync(() => repository.CreateTable());
        }
    }
}
