namespace taskMenager.Data.Configurations
{
    public interface IDataConfig
    {
        string DatabaseName  {get; set;}
        string ConnectionString  {get; set;}
    }
}