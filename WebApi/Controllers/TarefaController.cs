using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        public readonly ITarefa _ITarefa;
        public readonly IMapper _IMapper;

        public TarefaController(ITarefa iTarefa, IMapper iMapper)
        {
            _ITarefa = iTarefa;
            _IMapper = iMapper;
        }

        [HttpPost("/AddTarefa")]
        public async Task AddTarefa(TarefaViewModel tarefa)
        {
            var tarefaMap = _IMapper.Map<Tarefa>(tarefa);
            await _ITarefa.AddTarefa(tarefaMap);
        }

        [HttpPost("/UpdateTarefa")]
        public async Task UpdateTarefa(ItemTarefa tarefa)
        {
            var tarefaMap = _IMapper.Map<Tarefa>(tarefa);
            await _ITarefa.Update(tarefaMap);
        }

        [HttpPost("/Delete")]
        public async Task Delete(int idTarefa)
        {
            await _ITarefa.Delete(new Tarefa { Id = idTarefa});
        }

        [HttpPost("/GetTarefaById")]
        public async Task<TarefaViewModel> GetTarefaById(int idTarefa)
        {
            var tarefa = await _ITarefa.GetTarefaById(idTarefa);
            var clienteMap = _IMapper.Map<TarefaViewModel>(tarefa);
            return clienteMap;
        }

        [HttpPost("/GetAll_Tarefa")]
        public async Task<List<TarefaViewModel>> GetAll_Tarefa()
        {
            var tarefa = await _ITarefa.GetAll_Tarefa();
            var clienteMap = _IMapper.Map<List<TarefaViewModel>>(tarefa);
            return clienteMap;
        }


    }
}
