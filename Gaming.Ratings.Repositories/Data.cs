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
            entity.UserId = Guid.Parse("a8ee8558-0b46-4f66-a391-559ec983b7ea");
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
