namespace EFCoreGenericRepository.Console.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Author Author { get; set; }


        public override string ToString()
        {
            return $"{Name} {Age}";
        }
        public Book()
        {
            Name = string.Empty ;
            Author = new();
        }
    }
}
