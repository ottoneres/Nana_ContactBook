using System;
using agendaVovo.Classes;

namespace agendaVovo
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Para Casa:


            Eu como Vovó, gostaria de ter uma lista telefônica com os contatos dos meus netinhos. 
            Essa lista deverá conter, Nome, Apelido, Telefone, e-mail, zapzap e nome da mãe.
            A lista deverá ser gravada na minha área de trabalho para fácil acesso, com o nome ListaTelefonicaNetinhos.docx


            Como desafio:

            Ao iniciar o programa, deverá ser perguntado se o usuário deseja criar uma nova lista ou incluir contados na lista existente.
            */
            MenuAgenda agenda = new MenuAgenda();
            agenda.IniciaMenu();
        }
    }
}
