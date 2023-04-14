namespace HealthCare.DAL
{
    public class DAL_Helper
    {
        #region dalbase connection string
        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionStrings");
        #endregion
    }
}
