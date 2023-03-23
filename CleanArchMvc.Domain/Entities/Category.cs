using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),"Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Minimum 3 characters");

            this.Name = name;
        }
 
        public Category(int id, string name) 
        {
            DomainExceptionValidation.When(id < 0 , "Invalid Id value");
            this.Id = id;

            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }


        public ICollection<Product> Products { get; set;}
    }
}
