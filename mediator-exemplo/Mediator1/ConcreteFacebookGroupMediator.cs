using System.Collections.Generic;

namespace Mediator1
{
    //ConcreteMediator
    public class ConcreteFacebookGroupMediator : FacebookGroupMediator
    {
        private List<User> usersList = new List<User>();
        public void RegisterUser(User user)
        {
            usersList.Add(user);
        }
        public void SendMessage(string message, User user)
        {
            foreach (var u in usersList)
            {
                // mensagem não sera recebida por quem a estiver enviando
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }
    }
}
