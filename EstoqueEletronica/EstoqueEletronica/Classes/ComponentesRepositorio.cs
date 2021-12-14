using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueEletronica.Interface;

namespace EstoqueEletronica
{
    public class ComponentesRepositorio : IRepositorio<Componentes>
    {
        private List<Componentes> listaComponentes = new List<Componentes> { };

        public void Atualiza(int id, Componentes entidade)
        {
            listaComponentes[id] = entidade;
        }

        public void Exclui(int id)
        {
            //_listaComponentes[id].Excluir();
        }

        public void Insere(Componentes entidade)
        {
            listaComponentes.Add(entidade);
        }

        public List<Componentes> Lista()
        {
            return listaComponentes;
        }

        public int ProximoId()
        {
            return listaComponentes.Count;
        }

        public Componentes RetornaPorId(int id)
        {
            return listaComponentes[id];
        }
    }
}
