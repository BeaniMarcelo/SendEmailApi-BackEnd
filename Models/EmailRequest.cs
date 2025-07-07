public class EmailRequest
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool Anonymous { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
}