namespace Model.Entities
{
    public class Cidade : Base
    {
        public int IdEstado { get; set; }

        public Estado Estado { get; private set; }

        public string Nome { get; set; }
    }
}
