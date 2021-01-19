using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraCurso1
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertOneBookWithBson().Wait();
            //InsertOneBook().Wait();
            //InsertManyBooks().Wait();
            //FindAll().Wait();
            //FindByAutor().Wait();
            //FindByAutorWithBuilders().Wait();
            //FindYearGteWithBuilders().Wait();
            //FindYearGteAndPagesGteWithBuilders().Wait();
            //FindSubjectWithBuilders().Wait();
            //FindAllSortByTitle().Wait();
            //FindAllLimit().Wait();
            //FindAndUpdate().Wait();
            //UpdateYear().Wait();
            //UpdateManyYearEq().Wait();
            DeleteMany().Wait();

            Console.ReadKey();
        }

        static async Task InsertOneBookWithBson()
        {
            Book book = new Book
            {
                Titulo = "Guerra dos Tronos",
                Autor = "George R R Martin",
                Ano = 1999,
                Paginas = 856,
                Assunto = new string [2]
                {
                    "Fantasia", "Ação"
                }
            };

            await new MongoDB().InsertOneBookWithBson(book);
            Console.WriteLine("Livro inserido");
        }

        static async Task InsertOneBook()
        {
            Book book = new Book
            {
                Titulo = "Sob a redoma",
                Autor = "Stepahn King",
                Ano = 2012,
                Paginas = 679,
                Assunto = new string[3]
                {
                    "Ficção Científica", "Terror", "Ação"
                }
            };

            await new MongoDB().InsertOneBook(book);
            Console.WriteLine($"Livro inserido: {book.ToJson<Book>()}");
        }

        static async Task InsertManyBooks()
        {
            Book[] books = new Book[15]
            {
                new Book("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia,Ação"),
                new Book("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia,Ação"),
                new Book("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"),
                new Book("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia,Ação"),
                new Book("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica,Ação"),
                new Book("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil,Literatura Brasileira, Didático"),
                new Book("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil,Literatura Brasileira"),
                new Book("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica,Ação"),
                new Book("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático,Infantil"),
                new Book("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária,Didático"),
                new Book("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem,Ação"),
                new Book("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem,Ação"),
                new Book("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia,Ação"),
                new Book("Star Wars Legends", "Timothy Zahn", 2010, 245, "Romance,Literatura Brasileira"),
                new Book("A Arte da Ficção", "David Lodge", 2002, 230, "Didático,Auto Ajuda")
            };

            await new MongoDB().InsertManyBooks(books);
            Console.WriteLine($"Livro inserido: {books.ToJson<IEnumerable<Book>>()}");
        }

        static async Task FindAll()
        {
            var books = await new MongoDB().FindAll();
            PrintBooks(books);            
        }

        static async Task FindByAutor()
        {
            var books = await new MongoDB().FindByAutor("Machado de Assis");
            PrintBooks(books);
        }

        static async Task FindByAutorWithBuilders()
        {
            var books = await new MongoDB().FindByAutorWithBuilders("Machado de Assis");
            PrintBooks(books);
        }

        static async Task FindYearGteWithBuilders()
        {
            var books = await new MongoDB().FindYearGteWithBuilders(1999);
            PrintBooks(books);
        }

        static async Task FindYearGteAndPagesGteWithBuilders()
        {
            var books = await new MongoDB().FindYearGteAndPagesGteWithBuilders(1999, 300);
            PrintBooks(books);
        }

        static async Task FindSubjectWithBuilders()
        {
            var books = await new MongoDB().FindSubjectWithBuilders("Ficção Científica");
            PrintBooks(books);
        }

        static async Task FindAllSortByTitle()
        {
            var books = await new MongoDB().FindAllSortByTitle();
            PrintBooks(books);
        }

        static async Task FindAllLimit()
        {
            var books = await new MongoDB().FindAllLimit(3);
            PrintBooks(books);
        }

        static async Task FindAndUpdate()
        {
            Book book = await new MongoDB().FindByTitle("Guerra dos Tronos");

            if (book != null)
            {
                book.Ano = 2000;
                book.Paginas = 900;

                await new MongoDB().UpdateOne(new BsonDocument { { nameof(Book.Titulo), "Guerra dos Tronos" } }, book);
            }
        }

        static async Task UpdateYear()
        {
            await new MongoDB().UpdateYear("Guerra dos Tronos", 2001);
        }

        static async Task UpdateManyYearEq()
        {
            await new MongoDB().UpdateManyYearEq(2002);
        }

        static async Task DeleteMany()
        {
            MongoDB db = new MongoDB();
            
            //Book book = new Book()
            //{
            //    Titulo = "Livro para ser excluido",
            //    Autor = "Teste",
            //    Ano = 3000,
            //    Paginas = 9999
            //};
            //await db.InsertOneBook(book);

            await db.DeleteMany(new BsonDocument
            {
                { nameof(Book.Autor), "Teste" }
            });
        }


        static void PrintBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Id: {book.Id}");
                Console.WriteLine($"Titulo: {book.Titulo}");
                Console.WriteLine($"Autor: {book.Autor}");
                Console.WriteLine($"Ano: {book.Ano}");
                Console.WriteLine($"Páginas: {book.Paginas}");
                Console.WriteLine($"Assuntos: {string.Join(",", book.Assunto)}");
                Console.WriteLine();
            }
        }
    }
}