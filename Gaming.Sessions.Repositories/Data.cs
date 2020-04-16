using Gaming.Client.Entities;
using Gaming.Foundation.Async;
using Gaming.Foundation.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gaming.Sessions.Repositories
{
    public static class Data
    {
        public static void ScaffoldDatabase()
        {
            EnsureStorageTableExists();

            var repository = (SessionRepository)ServiceLocator.Instance.GetService<ISessionRepository>();
            var repository2 = (SessionUserRepository)ServiceLocator.Instance.GetService<ISessionUserRepository>();

            var entity = new Session();
            entity.Id = Guid.Parse("6bf64e3a-6d0b-4049-a96e-cd3caf6ecc5a");
            entity.Start = DateTime.Parse("2020-01-01 14:30:00");
            entity.End = DateTime.Parse("2020-01-01 17:00:00");
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Session();
            entity.Id = Guid.Parse("a1d321a9-cf44-42e5-8d7d-318285549c2f");
            entity.Start = DateTime.Parse("2020-01-01 14:10:00");
            entity.End = DateTime.Parse("2020-01-01 15:00:00");
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Session();
            entity.Id = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.Start = DateTime.Parse("2020-01-01 14:00:00");
            entity.End = DateTime.Parse("2020-01-01 16:00:00");
            AsyncHelper.RunSync(() => repository.Save(entity));

            var entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("6bf64e3a-6d0b-4049-a96e-cd3caf6ecc5a");
            entity2.UserId = Guid.Parse("88a4b287-a170-4a13-bb1e-91c4bdaa259c");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("6bf64e3a-6d0b-4049-a96e-cd3caf6ecc5a");
            entity2.UserId = Guid.Parse("a9b3b49f-a9d1-48f6-80cf-2378026841a9");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("a1d321a9-cf44-42e5-8d7d-318285549c2f");
            entity2.UserId = Guid.Parse("a9b3b49f-a9d1-48f6-80cf-2378026841a9");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("a8ee8558-0b46-4f66-a391-559ec983b7ea");
            AsyncHelper.RunSync(() => repository2.Save(entity2));
        }

        private static void EnsureStorageTableExists()
        {
            var repository = ServiceLocator.Instance.GetService<ISessionRepository>();
            AsyncHelper.RunSync(() => repository.CreateTable());

            var repository2 = ServiceLocator.Instance.GetService<ISessionUserRepository>();
            AsyncHelper.RunSync(() => repository2.CreateTableAsync());
        }
    }
}
