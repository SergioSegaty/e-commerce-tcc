using System.Collections.Generic;

namespace Model.Entities
{
    public class Cidade : Base
    {
        public int IdEstado { get; set; }

        public Estado Estado { get; private set; }

        public string Nome { get; set; }

        public ICollection<Endereco> Endereco { get; set; }
    }
}
