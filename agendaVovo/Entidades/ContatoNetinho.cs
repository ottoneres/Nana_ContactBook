using agendaVovo.EntidadeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaVovo.Entidades
{
    public class ContatoNetinho : ContatoBase
    {
        public string NomeNeto { get; set; }
        private string ApelidoNeto { get; set; }
        private string TelefoneNeto { get; set; }
        private string EmailNeto { get; set; }
        private bool PossuiWhatsApp { get; set; }
        private string NomeMaeNeto { get; set; }

        public ContatoNetinho(int id, string nomeNeto, string apelidoNeto, string telefoneNeto, string emailNeto, bool possuiWhatsApp, string nomeMaeNeto)
        {
            this.Id = id;
            this.NomeNeto = nomeNeto;
            this.ApelidoNeto = apelidoNeto;
            this.TelefoneNeto = telefoneNeto;
            this.EmailNeto = emailNeto;
            this.PossuiWhatsApp = possuiWhatsApp;
            this.NomeMaeNeto = nomeMaeNeto;
        }

        public override string ToString()
        { 
            string contatoNetoString = "";
            string possuiWhatsAppString = "";

            if (PossuiWhatsApp == true)
            {
                possuiWhatsAppString = "Sim";
            }
            else
            {
                possuiWhatsAppString = "Não";
            }

            contatoNetoString += $"{Id} | {NomeNeto} | {ApelidoNeto} | {EmailNeto} | {NomeMaeNeto} | {possuiWhatsAppString} | {TelefoneNeto}";
            return contatoNetoString;

        }

        public string RetornaNome()
        {
            return this.NomeNeto;
        }

    }
}
