namespace academia.Domain.Entities.EmailConfig
{
    public class EntidadeEmailConfiguracoes
    {
        public int Id { get; set; }
        public string? Smtp { get; set; }
        public int Port { get; set; }
        public string? EmailUser { get; set; }
    }
}
