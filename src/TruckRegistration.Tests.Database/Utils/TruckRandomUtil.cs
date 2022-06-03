using System;
using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Tests.Database.Utils
{
    public static class TruckRandomUtil
    {
        public static EModel GetRandomModel()
        {
            var models = Enum.GetValues(typeof(EModel));

            var modelItem = (EModel)models
                .GetValue(new Random()
                .Next(models.Length));

            return modelItem;
        }

        public static string GetRandomRenavan()
        {
            return new Random().Next(10000000, 99999999)
                .ToString()
                .PadLeft(8, '0');
        }

        public static string GetRandomColor()
        {
            var models = new string[] { "White", "Blue", "Black" };

            return (string)models.GetValue(new Random().Next(models.Length));
        }

        public static int GetRandomModelYear()
        {
            var models = new int[]
            {
                DateTime.Now.Year,
                DateTime.Now.AddYears(1).Year
            };

            return (int)models.GetValue(new Random().Next(models.Length));
        }
    }
}
