using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaVovo.Interfaces
{
    public interface IDocumento
    {
        void CriaAgenda();
        void AbrirAgenda(string nomeAgenda);
        string ExcluiAgenda(string nomeAgenda);
    }
}
