using Flunt.Notifications;
using Flunt.Validations;

namespace MinimalApi.ViewModels
{
    public class CreateClassViewModel : Notifiable<Notification>
    {
        public string MyString { get; set; }

        public MyClass MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(MyString, "Informe um texto qualquer")
                .IsGreaterThan(MyString, 2, "Seu texto deve conter mais de 2 caracteres"));

            return new MyClass(Guid.NewGuid(), MyString);
        }
    }
}