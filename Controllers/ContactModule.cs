using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using System.Threading.Tasks;

namespace contact_holder
{
    public class ContactModule : NancyModule
    {
        private PersonsRepo repo = new PersonsRepo();
        public ContactModule() : base("/person")
        {


            Before += context => {
                var ctx = context.Request.Headers.UserAgent;
                Console.WriteLine($"Before:!!! {ctx}");
                return null;
            };


            Get("/{name}", parameters => {
                var person = repo.GetPerson(parameters.name);
                if(person == null){
                    throw new Exception($"Person with the name '{person.name}' does not exists");
                }

                return Response.AsJson(person as Person, HttpStatusCode.OK);
            });

            Get("/browse", _ => Response.AsJson(repo.BrowserPerson(), HttpStatusCode.OK));

            Get("/async", async _ => {
                await Task.Delay(5000);
                return "Delayed by 5 sec";
            });

            Post("/update", parameters => {
                var person = this.Bind<Person>();
                return Response.AsJson(person, HttpStatusCode.OK);
            });
        }
    }

    class PersonsRepo
    {
        private IEnumerable<Person> persons;
        public PersonsRepo()
        {
            persons = new List<Person>{ 
                new Person{ name = "Adam"},
                new Person{ name = "Evee"},
                new Person{ name = "Pikachu"},
                new Person{ name = "Erik"}
            };
        }

        public IEnumerable<Person> BrowserPerson()
            => persons;

        public Person GetPerson(string name)
            => persons.FirstOrDefault(x => x.name == name);
    }

    class Person
    {
        public string name { get; set; }
    }
}