using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ItemTarefa")]
    public class ItemTarefa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        [ForeignKey("Tarefa")]
        [Column(Order = 1)]
        public int IdTarefa { get; set; }
        //public virtual Tarefa Tarefa { get; set; }
    }
}
