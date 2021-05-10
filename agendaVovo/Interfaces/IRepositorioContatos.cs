using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaVovo.Interfaces
{
    public interface IRepositorioContatos<T>
    {
        List<T> Lista();
        string InsereContato(T contato);
        void ExcluiContato(int id);
    }
}
