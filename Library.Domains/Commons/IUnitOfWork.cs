using System.Threading.Tasks;
using Library.Domains.Books.Repositories;

namespace Library.Domains.Commons
{
    public interface IUnitOfWork
    {

        IBookRepositoryCommand BookRepositoryCommand { get; }

        Task Save();
    }
}