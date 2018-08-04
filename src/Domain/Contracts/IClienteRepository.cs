using Domain.Models;

namespace Domain.Contracts
{
    public interface IClienteRepository
    {
        Cliente GetByCpf(string cpf);
    }
}
