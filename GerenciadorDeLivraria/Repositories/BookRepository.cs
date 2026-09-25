using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Repositories;

public static class BookRepository
{
    public static List<Book> Books { get; } = new();
}
