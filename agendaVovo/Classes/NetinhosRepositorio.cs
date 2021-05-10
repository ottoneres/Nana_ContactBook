using agendaVovo.Entidades;
using agendaVovo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaVovo.Classes
{
    public class NetinhosRepositorio : IRepositorioContatos<ContatoNetinho>
    {
        private List<ContatoNetinho> listaNetinho = new List<ContatoNetinho>();
        public void ExcluiContato(int id)
        {
            ContatoNetinho netinhoExcluir = listaNetinho.Find(n => n.Id == id);
            listaNetinho.Remove(netinhoExcluir);
        }

        public string InsereContato(ContatoNetinho contato)
        {
            listaNetinho.Add(contato);
            return contato.RetornaNome();
        }

        public List<ContatoNetinho> Lista()
        {
            return listaNetinho;
        }

        public int ProximoId()
        {
            return listaNetinho.Count() + 1;
        }

        public void LimpaDados()
        {
            listaNetinho.Clear();
        }
    }
}
