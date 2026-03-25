namespace Mediator1
{
    //Mediator
    public interface FacebookGroupMediator
    {
        void SendMessage(string msg, User user);
        void RegisterUser(User user);
    }
}
