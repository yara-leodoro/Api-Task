namespace taskMenager.Data.Configurations
{
    public class DataConfig : IDataConfig
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}