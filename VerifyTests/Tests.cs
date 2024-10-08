using Argon;

namespace TestProject1;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
    public List<string> Hobbies { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}

public class Tests
{
    public Tests()
    {
        VerifierSettings.AddExtraSettings(jsonSerializerSettings=>
        {
            jsonSerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Include;
        });
    }
    
    public static List<Person> GetSamplePeople()
    {
        return new List<Person>
        {
            new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Age = 30,
                Email = "jan.kowalski@example.com",
                PhoneNumber = "123-456-789",
                Address = new Address
                {
                    Street = "ul. Zielona 1",
                    City = "Warszawa",
                    ZipCode = "00-001"
                },
                Hobbies = new List<string> { "Piłka nożna", "Gotowanie" }
            },
            new Person
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Age = 25,
                Email = "anna.nowak@example.com",
                PhoneNumber = "987-654-321",
                Address = new Address
                {
                    Street = "ul. Kwiatowa 5",
                    City = "Kraków",
                    ZipCode = "30-002"
                },
                Hobbies = new List<string> { "Czytanie", "Podróże" }
            }
        };
    }
        
    public class PersonTests
    {
        [Fact]
        public void TestPersonListWithClassicAssertions()
        {
            // Arrange
            var people = GetSamplePeople();

            // Assert
            Assert.Equal(2, people.Count);

            var person1 = people[0];
            Assert.Equal("Jan", person1.FirstName);
            Assert.Equal("Kowalski", person1.LastName);
            Assert.Equal(30, person1.Age);
            Assert.Equal("jan.kowalski@example.com", person1.Email);
            Assert.Equal("123-456-789", person1.PhoneNumber);
            Assert.Equal("ul. Zielona 1", person1.Address.Street);
            Assert.Equal("Warszawa", person1.Address.City);
            Assert.Equal("00-001", person1.Address.ZipCode);
            Assert.Contains("Piłka nożna", person1.Hobbies);
            Assert.Contains("Gotowanie", person1.Hobbies);

            var person2 = people[1];
            Assert.Equal("Anna", person2.FirstName);
            Assert.Equal("Nowak", person2.LastName);
            Assert.Equal(25, person2.Age);
            Assert.Equal("anna.nowak@example.com", person2.Email);
            Assert.Equal("987-654-321", person2.PhoneNumber);
            Assert.Equal("ul. Kwiatowa 5", person2.Address.Street);
            Assert.Equal("Kraków", person2.Address.City);
            Assert.Equal("30-002", person2.Address.ZipCode);
            Assert.Contains("Czytanie", person2.Hobbies);
            Assert.Contains("Podróże", person2.Hobbies);
        }
            
        [Fact]
        public Task TestPersonListWithVerify()
        {
            // Arrange
            var people = GetSamplePeople();

            // Assert
            return Verify(people);
        }
    }
}