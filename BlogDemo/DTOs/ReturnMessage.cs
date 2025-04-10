namespace BlogDemo.DTOs
{
    public class ReturnMessage
    {
        public string Message { get; set; } = string.Empty;
        public bool? ConfirmRequired { get; set; } = null;

        public static ReturnMessage Parse(string message)
        {
            return new ReturnMessage() { Message = message};

        }          
        public static ReturnMessage Parse(string message, bool confirmRequired)
        {
            return new ReturnMessage() { Message = message, ConfirmRequired = confirmRequired };

        }          
    }
}
