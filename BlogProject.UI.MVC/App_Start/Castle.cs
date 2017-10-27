using BlogProject.Model.Model;
using Castle.ActiveRecord.Framework;
using System.Configuration;

namespace BlogProject.UI.MVC
{
    public static class CastleFactory
    {
        public static void Initialize()
        {
            IConfigurationSource source = ConfigurationManager.GetSection("activeRecord") as IConfigurationSource;

            Castle.ActiveRecord.ActiveRecordStarter.Initialize(source, typeof(Post), typeof(Comment));
        }
    }
}