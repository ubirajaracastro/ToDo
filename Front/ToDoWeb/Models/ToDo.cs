namespace ToDoWeb.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Detalhe { get; set; }
        public DateTime Data { get; set; }
        public bool Finalizada { get; set; }

    }
}
