namespace ValueObject
{
    public class UserUpdateCommand
    {
        public UserUpdateCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string MailAddress { get; set; }
    }
}