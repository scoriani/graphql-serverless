using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;

namespace intro
{
    public class Mutation
    {
        public async Task<Person> AddPerson(string name, int age, [Service] ITopicEventSender sender)
        {

            Person p = new Person(name,age);
            await sender.SendAsync("PersonAdded", p);

            // to do: persist new entity in a proper database
            return p;            
        }
    }
}