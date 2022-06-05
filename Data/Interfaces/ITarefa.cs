using Data.Entities;

namespace Data.Interfaces
{
    public interface ITarefa: IGeneric<Tarefa>
    {
        Task AddTarefa(Tarefa entity);    
        Task<Tarefa> GetTarefaById(int id);
        Task<List<Tarefa>> GetAll_Tarefa();
    }
}
