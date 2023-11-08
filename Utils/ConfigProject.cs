namespace ris_reporte_rest.Utils
{
    public class ConfigProject
    {
        private String DefaultConnection = "DefaultConnection";
        public IConfiguration configuration { get; }

        public ConfigProject(IConfiguration configuration) { 
            this.configuration = configuration;
        }

        public string getKey(string key)
        {

            String value = Environment.GetEnvironmentVariable(key);

            if (value == null)
            {
                value = configuration.GetConnectionString(key);
            }
            return value;
        }

        public String GetConnectionString() {
             
            String DDBB_SERVER = Environment.GetEnvironmentVariable("DDBB_SERVER");
            String DDBB_USER = Environment.GetEnvironmentVariable("DDBB_USER");
            String DDBB_PASS = Environment.GetEnvironmentVariable("DDBB_PASS");

            if (DDBB_SERVER == null)
            {
                DDBB_SERVER = configuration.GetConnectionString("DDBB_SERVER");
                DDBB_USER = configuration.GetConnectionString("DDBB_USER");
                DDBB_PASS = configuration.GetConnectionString("DDBB_PASS");
            }

            return string.Format(configuration.GetConnectionString(DefaultConnection), DDBB_SERVER, DDBB_USER, DDBB_PASS);
        }
    }
}
