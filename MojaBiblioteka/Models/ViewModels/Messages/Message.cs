namespace MojaBiblioteka.Models.ViewModels.Messages
{
    public class Message
    {
        public string MessageText { get; set; } = string.Empty;
        public int Type { get; set; } = (int) Types.Information;
    }

    public enum Types
    {
        Information,
        Error,
        Success,
        Warning
    }
}
