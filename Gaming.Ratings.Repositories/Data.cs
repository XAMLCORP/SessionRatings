using Gaming.Client.Entities;
using Gaming.Client.Interfaces.Entities;
using Gaming.Foundation.Async;
using Gaming.Foundation.DependencyInjection;
using Gaming.Ratings.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gaming.Ratings.Repositories
{
    public static class Data
    {
        public static void ScaffoldDatabase()
        {
            EnsureStorageTableExists();

            var repository = (RatingRepository)ServiceLocator.Instance.GetService<IRatingRepository>();

            var entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("88a4b287-a170-4a13-bb1e-91c4bdaa259c");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("a9b3b49f-a9d1-48f6-80cf-2378026841a9");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("a8ee8558-0b46-4f66-a391-559ec983b7ea");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("102c1d25-744b-4312-bba6-8c3f63693be2");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("ebe7dbbd-3ead-46e1-bfd0-443019870412");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("54baf005-173a-4565-acbb-5bd4753e49ec");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("3880d62d-725f-4200-b775-9aae16e4f7a6");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("35c45be8-1beb-40ff-9b98-fa31bbcf1042");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("985bdf7b-ce32-4568-9c32-53ac4af0e366");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("00eb33b5-5646-4292-98ef-f7419862b3de");
            entity.Value = RatingValue.Three;
            entity.Comment = "Was OK";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("a69672cb-f25e-4e67-83a1-75e3998706ed");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("b01288b6-e4a8-47a5-ac9d-d227ec46cf66");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("d86bad2c-839a-49bc-8f40-0d5601e412ec");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("4b1c0a78-129c-4d9e-b26f-c30b861191d6");
            entity.Value = RatingValue.One;
            entity.Comment = "Terribly Laggy";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("1f74e4ac-6528-49e5-af75-fb74efec4ded");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("c6c71e94-6005-49f9-8bf1-d80cc2bdef00");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));

            entity = new Rating();
            entity.SessionId = Guid.Parse("4541f77c-cf18-42a1-9c63-ba699dd1e3e1");
            entity.UserId = Guid.Parse("bbbdbce2-4ae9-490c-8436-66df4e623d94");
            entity.Value = RatingValue.Five;
            entity.Comment = "Super Smooth Gameplay";
            AsyncHelper.RunSync(() => repository.Save(entity));
        }

        private static void EnsureStorageTableExists()
        {
            var repository = ServiceLocator.Instance.GetService<IRatingRepository>();
            AsyncHelper.RunSync(() => repository.CreateTable());
        }
    }
}
