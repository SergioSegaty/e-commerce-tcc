using System.Collections.Generic;

namespace Model.Entities
{
    public class Estado : Base
    {
        public string Nome { get; set; }

        public string Sigla { get; set; }

        public ICollection<Cidade> Cidade { get; private set; }
    }
}