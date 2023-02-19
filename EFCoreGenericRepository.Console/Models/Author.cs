namespace EFCoreGenericRepository.Console.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }
        public Author()
        {
            Books= new List<Book>();
            Name = string.Empty;
            Age = 0;
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
