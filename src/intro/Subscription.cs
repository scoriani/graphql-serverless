using HotChocolate;
using HotChocolate.Types;

namespace intro
{
    public class Subscription
    {
        [Subscribe]
        public Person PersonAdded([EventMessage] Person person) => person;
    }
}