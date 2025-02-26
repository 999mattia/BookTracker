using BookTracker.Core.Models;
using BookTracker.Infrastructure.Database;

namespace BookTracker.Infrastructure.Seeding;

public static class Seeder
{
	public static void Seed(DataContext context)
	{
		if (!context.Books.Any())
		{
			context.Books.AddRange(
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Great Gatsby",
		Author = "F. Scott Fitzgerald",
		Description = "A novel set in the Jazz Age."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "1984",
		Author = "George Orwell",
		Description = "A dystopian novel about totalitarianism."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "To Kill a Mockingbird",
		Author = "Harper Lee",
		Description = "A novel about racial injustice in the Deep South."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Pride and Prejudice",
		Author = "Jane Austen"
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Moby-Dick",
		Author = "Herman Melville",
		Description = "A story about the quest to capture a giant white whale."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Catcher in the Rye",
		Author = "J.D. Salinger"
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Hobbit",
		Author = "J.R.R. Tolkien",
		Description = "A fantasy novel about Bilbo Baggins' adventure."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Brave New World",
		Author = "Aldous Huxley",
		Description = "A dystopian novel exploring a futuristic society."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Lord of the Rings",
		Author = "J.R.R. Tolkien"
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Alchemist",
		Author = "Paulo Coelho",
		Description = "A philosophical novel about following your dreams."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Crime and Punishment",
		Author = "Fyodor Dostoevsky",
		Description = "A psychological novel about guilt and redemption."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "War and Peace",
		Author = "Leo Tolstoy"
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Odyssey",
		Author = "Homer",
		Description = "An epic poem about Odysseus' journey home."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Divine Comedy",
		Author = "Dante Alighieri"
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Frankenstein",
		Author = "Mary Shelley",
		Description = "A gothic novel about the creation of a monster."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Picture of Dorian Gray",
		Author = "Oscar Wilde"
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Don Quixote",
		Author = "Miguel de Cervantes",
		Description = "A story about a man who becomes a knight-errant."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "The Brothers Karamazov",
		Author = "Fyodor Dostoevsky",
		Description = "A philosophical novel about faith, doubt, and morality."
	},
	new Book
	{
		Id = Guid.NewGuid(),
		Title = "Anna Karenina",
		Author = "Leo Tolstoy"
	}
);

			context.SaveChanges();
		}
	}
}
