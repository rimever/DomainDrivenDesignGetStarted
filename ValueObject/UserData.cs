using System.Net.Mail;

namespace ValueObject
{
    /// <summary>
    /// ドメインオブジェクトを外部後悔しないためのDTO(Data Transfer Object)
    /// </summary>
    public class UserData
    {
        public UserData(User user)
        {
            Id = user.Id.Value;
            Name = user.Name.Value;
            MailAddress = user.MailAdress.Value;
        }

        public string MailAddress { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}