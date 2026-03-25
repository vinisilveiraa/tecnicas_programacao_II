using Mediator1;
using System;

FacebookGroupMediator facebookMediator =
new ConcreteFacebookGroupMediator();

User maria = new ConcreteUser(facebookMediator, "Maria");
User miriam = new ConcreteUser(facebookMediator, "Miriam");
User jessica = new ConcreteUser(facebookMediator, "Jessica");
User yuri = new ConcreteUser(facebookMediator, "Yuri");

facebookMediator.RegisterUser(maria);
facebookMediator.RegisterUser(miriam);
facebookMediator.RegisterUser(jessica);
facebookMediator.RegisterUser(yuri);

maria.Send("Estou enviando uma mensagem");
Console.WriteLine("");

yuri.Send("Mensagem");
Console.WriteLine("");

maria.Send("aaaaaaaaaaaaa!!!!");
Console.WriteLine("");

Console.Read();
