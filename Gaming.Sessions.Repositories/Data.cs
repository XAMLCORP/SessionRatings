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

            //-------------------------------------------------------
            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("88a4b287-a170-4a13-bb1e-91c4bdaa259c");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("a9b3b49f-a9d1-48f6-80cf-2378026841a9");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("a8ee8558-0b46-4f66-a391-559ec983b7ea");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("102c1d25-744b-4312-bba6-8c3f63693be2");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("ebe7dbbd-3ead-46e1-bfd0-443019870412");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("54baf005-173a-4565-acbb-5bd4753e49ec");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("3880d62d-725f-4200-b775-9aae16e4f7a6");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("35c45be8-1beb-40ff-9b98-fa31bbcf1042");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("985bdf7b-ce32-4568-9c32-53ac4af0e366");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("00eb33b5-5646-4292-98ef-f7419862b3de");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("a69672cb-f25e-4e67-83a1-75e3998706ed");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("b01288b6-e4a8-47a5-ac9d-d227ec46cf66");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("d86bad2c-839a-49bc-8f40-0d5601e412ec");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("4b1c0a78-129c-4d9e-b26f-c30b861191d6");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("1f74e4ac-6528-49e5-af75-fb74efec4ded");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("c6c71e94-6005-49f9-8bf1-d80cc2bdef00");
            AsyncHelper.RunSync(() => repository2.Save(entity2));

            entity2 = new SessionUser();
            entity2.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity2.UserId = Guid.Parse("bbbdbce2-4ae9-490c-8436-66df4e623d94");
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
