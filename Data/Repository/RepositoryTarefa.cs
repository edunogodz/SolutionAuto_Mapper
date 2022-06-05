using Data.Config;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository
{
    public class RepositoryTarefa : RepositoryGeneric<Tarefa>, ITarefa
    {
        private readonly DbContextOptions<ContextBase1> _optionsBulder;

        public RepositoryTarefa()
        {
            _optionsBulder = new DbContextOptions<ContextBase1>();
        }

        public async Task AddTarefa(Tarefa entity)
        {
            using (var data = new ContextBase1(_optionsBulder))
            {
                await data.Set<Tarefa>().AddAsync(entity);
                await data.SaveChangesAsync();

                if (entity.ItensTarefa.Any())
                {
                    entity.ItensTarefa.ForEach(a => a.IdTarefa = entity.Id);

                    await data.Set<ItemTarefa>().AddRangeAsync(entity.ItensTarefa);
                    await data.SaveChangesAsync();
                }
            }
        }
        public async Task<Tarefa> GetTarefaById(int Id)
        {
            using (var data = new ContextBase1(_optionsBulder))
            {
                var tarefa = await data.Tarefa.FindAsync(Id);
                if (tarefa != null)
                {
                    var itensTarefa = await data.ItemTarefa.Where(a => a.IdTarefa.Equals(Id)).ToListAsync();

                    if (itensTarefa.Any())
                        tarefa.ItensTarefa = itensTarefa;

                    return tarefa;
                }
                else return null;
            }
        }
        public async Task<List<Tarefa>> GetAll_Tarefa()
        {
            var listaTarefas = new List<Tarefa>();

            using (var data = new ContextBase1(_optionsBulder))
            {
                var tarefaComItens = await (from TA in data.Tarefa
                                            join ITA in data.ItemTarefa on TA.Id equals ITA.IdTarefa
                                            select new
                                            {
                                                Id = TA.Id,
                                                Name = TA.Name,
                                                IdItemTarefa = ITA.Id,
                                                ItemTarefaNome = ITA.Name,
                                                ITA.IdTarefa,
                                                ITA.Notes
                                            }).ToListAsync();

                var lista = tarefaComItens.Select(a => new { Id = a.Id, Name = a.Name }).Distinct().ToList();

                var listaCompleta = lista.Select(a => new Tarefa
                {
                    Id = a.Id,
                    Name = a.Name,
                    ItensTarefa =
        tarefaComItens.Where(x => x.IdTarefa == a.Id)
        .Select(x => new ItemTarefa { Id = x.IdItemTarefa, Name = x.ItemTarefaNome, IdTarefa = x.IdTarefa, Notes = x.Notes }).ToList()
                });

                if (listaCompleta.Any())
                    listaTarefas.AddRange(listaCompleta);
            }

            return listaTarefas;
        }
    }
}

