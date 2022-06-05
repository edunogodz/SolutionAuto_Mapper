using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTarefaController : ControllerBase
    {
        public readonly IItemTarefa _IItemTarefa;       

        public ItemTarefaController(IItemTarefa IItemTarefa)
        {
            _IItemTarefa = IItemTarefa;           
        }

        [HttpPost("/AddItem")]
        public async Task AddItem(ItemTarefa itemTarefa)
        {            
            await _IItemTarefa.Add(itemTarefa);
        }

        [HttpPost("/UpdateItem")]
        public async Task UpdateItem(ItemTarefa itemTarefa)
        {
            await _IItemTarefa.Update(itemTarefa);
        }

        [HttpPost("/DeleteItem")]
        public async Task DeleteItem(int idTarefa)
        {
            await _IItemTarefa.Delete(new ItemTarefa { Id = idTarefa });
        }

        [HttpPost("/GetItemById")]
        public async Task<ItemTarefa> GetItemById(int idTarefa)
        {
            return await _IItemTarefa.GetById(idTarefa);
        }

        [HttpPost("/GetAll_Item")]
        public async Task<List<ItemTarefa>> GetAll_Item()
        {
            return await _IItemTarefa.GetAll();
        }


    }
}
