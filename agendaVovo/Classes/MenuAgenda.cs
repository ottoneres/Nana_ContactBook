using agendaVovo.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaVovo.Classes
{
    public class MenuAgenda
    {
        static NetinhosRepositorio repoNetinho = new NetinhosRepositorio();
        string inputUsuario;
        public MenuAgenda()
        {
            Console.WriteLine("Iniciando Menu da Agenda");
        }

        public void IniciaMenu()
        {

            do
            {
                var dirAgendas = DeterminaDiretorio();
                Console.WriteLine();
                Console.WriteLine("Ei Vovó! Essa é a sua agenda de Netinhos");
                Console.WriteLine();
                Console.WriteLine("Digite o número ou letra da opção correspondente para fazer o que você quer");
                Console.WriteLine();
                Console.WriteLine("1 - Abrir Agenda");
                Console.WriteLine("2 - Criar uma Agenda nova");
                Console.WriteLine("3 - Excluir uma Agenda");
                Console.WriteLine("X - Sair do Programa");

                inputUsuario = Console.ReadLine().Trim();

                switch(inputUsuario)
                {
                    case "1":
                        IniciaMenuAgendaAberta(dirAgendas);
                        break;
                    case "2":
                        CriaNovaAgenda(dirAgendas);
                        break;
                    case "3":
                        ExcluirAgenda(dirAgendas);
                        break;
                    default:
                        Console.WriteLine("Escolha alguma das opções");
                        break;
                }


            } while (inputUsuario.ToUpper() != "X");

            Console.WriteLine("Até mais, Vovó!");

        }

        private void ExcluirAgenda(string dirAgendas)
        {
            //Listar Agendas;
        }

        private string DeterminaDiretorio()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            string dirAgendas = Directory.CreateDirectory($"C:\\Users\\{userName}\\Desktop\\Agendas").ToString();
            return dirAgendas;
        }

        private void CriaNovaAgenda(string dirAgendas)
        {
            Console.WriteLine("Digite o nome da Agenda: ");
            string nomeAgenda = Console.ReadLine().Trim();

            string pathAgenda = dirAgendas + $"\\{nomeAgenda}.txt";

            if (!File.Exists(pathAgenda))
            {
                FileStream agendaFile = File.Create(pathAgenda);
                agendaFile.Close();
                StreamWriter fs = File.CreateText(pathAgenda);
                fs.WriteLine("ID | Nome Neto | Apelido | Email do Neto | Nome da Mãe | Tem WhatsApp? | Telefone do Neto");
                fs.Close();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Essa agenda já existe. Quer abri-la?");
                Console.WriteLine();
                var decisaoUsuario = Console.ReadLine().Trim();

                if (decisaoUsuario.Contains("S"))
                {
                    ManipulaAgenda(pathAgenda);
                }
                else
                {
                    IniciaMenu();
                }
            }
        }

        public string IniciaMenuAgendaAberta(string dirAgendas)
        {
            List<string> agendas = new List<string>();

            string dirAgendaEscolhida;

            agendas = Directory.GetFiles(dirAgendas).ToList<string>();
            int idAgenda = 1;
            string agendaEscolhidaInput = "";
            int agendaEscolhida;

            if (agendas.Count() == 0)
            {
                Console.WriteLine($"\nNenhuma agenda encontrada!\n");
            }
            else
            {
                Console.WriteLine("Qual Agenda você deseja abrir?");
                foreach (string entry in agendas)
                {
                    Console.WriteLine($"{idAgenda} - {entry}");
                    idAgenda++;
                }

                agendaEscolhidaInput = Console.ReadLine().Trim();

                try
                {
                    agendaEscolhida = Convert.ToInt32(agendaEscolhidaInput);
                }
                catch (FormatException)
                {
                    throw new FormatException("Inserido texto ao invés de número");
                }

                dirAgendaEscolhida = agendas[agendaEscolhida - 1];
                Console.WriteLine($"Abrindo {dirAgendaEscolhida}");

                ManipulaAgenda(dirAgendaEscolhida);
                return dirAgendaEscolhida;
            }

            return null;
        }

        public void ManipulaAgenda(string diretorioAgenda)
        {
            string decisaoUsuario = "";
            do
            { 

                Console.WriteLine("O que você deseja?");
                Console.WriteLine();
                Console.WriteLine("1 - Inserir Contato");
                Console.WriteLine("2 - Excluir Contato");
                Console.WriteLine("3 - Listar Contatos");
                Console.WriteLine("S - Sair");
                Console.WriteLine();

                decisaoUsuario = Console.ReadLine().Trim().ToUpper();

                switch (decisaoUsuario)
                {
                    case "1":
                        InsereNetinho(diretorioAgenda);
                        break;
                    case "2":
                        ExcluirNetinho(diretorioAgenda);
                        break;
                    case "3":
                        ListarNetinhos(diretorioAgenda);
                        break;
                    case "S":
                        GravaArquivo(diretorioAgenda);
                        break;
                    default:
                        break;
                }
            } while (decisaoUsuario != "S");


        }

        private void ExcluirNetinho(string diretorioAgenda)
        {
            Console.WriteLine();
            ListarNetinhos(diretorioAgenda);
            Console.WriteLine();

            var listaContatosParaExcluir = File.ReadLines(diretorioAgenda).ToList();

            var registrosRepo = repoNetinho.Lista();

            foreach (var neto in registrosRepo)
            {
                listaContatosParaExcluir.Add(neto.ToString());
            }

            Console.Write("Digite o ID do contato que deseja excluir: ");
            string inputExclusao = Console.ReadLine().Trim();

            var fs = File.CreateText(diretorioAgenda);

            foreach (var contato in listaContatosParaExcluir)
            {
                if (int.TryParse(contato.Split()[0], out int resultado))
                {
                    if (resultado == Convert.ToInt32(inputExclusao))
                    {
                        continue;
                    }
                    else
                    {
                        var registro = contato;

                        fs.WriteLine(contato);
                    }
                }
                else
                {
                    fs.WriteLine(contato);
                    continue;
                }
            }

            fs.Close();


        }

        private void ListarNetinhos(string diretorioAgenda)
        {
            var text = File.ReadAllText(diretorioAgenda);

            if (repoNetinho.Lista().Count() > 0)
            {
                var registros = repoNetinho.Lista();

                foreach(var registro in registros)
                {
                text += $"\n{registro}\n";
                }
            }

            Console.WriteLine($"\n{text}\n");
        }

        public string InsereNetinho(string diretorioAgenda)
        {

            Console.Write("Nome do Netinho: ");
            string nomeNetoInput = Console.ReadLine().Trim();
            Console.Write("Apelido do Netinho: ");
            string apelidoNetoInput = Console.ReadLine().Trim();
            Console.Write("Telefone do Netinho: ");
            string telNetoInput = Console.ReadLine().Trim();
            Console.Write("Email do Netinho: ");
            string emailNetoInput = Console.ReadLine().Trim();

            Console.Write("Netinho tem WhatsApp? Sim ou Não? ");
            string whatsAppNetoInput = Console.ReadLine().Trim();
            bool whatsAppBool = false;

            if (whatsAppNetoInput.ToUpper().Contains("S"))
            {
                whatsAppBool = true;
            }

            Console.Write("Mãe do Netinho: ");
            string maeNetoInput = Console.ReadLine().Trim();

            var listaAgenda = File.ReadLines(diretorioAgenda).ToList();
            string ultimoID = "0";

            if (listaAgenda.Count() > 0)
            {
                ultimoID = listaAgenda[listaAgenda.Count() - 1].Split()[0];
                if (int.TryParse(ultimoID, out int resultado))
                {
                    ultimoID = resultado.ToString();
                }
                else
                {
                    ultimoID = "0";
                }
            }

            ContatoNetinho contatoNeto = new ContatoNetinho(id: repoNetinho.ProximoId() + Convert.ToInt32(ultimoID),
                                                            nomeNeto: nomeNetoInput,
                                                            apelidoNeto: apelidoNetoInput,
                                                            telefoneNeto: telNetoInput,
                                                            emailNeto: emailNetoInput,
                                                            possuiWhatsApp: whatsAppBool,
                                                            nomeMaeNeto: maeNetoInput);

            repoNetinho.InsereContato(contatoNeto);
            string nomeNeto = contatoNeto.RetornaNome();
            return nomeNeto;
        }
        
        public void GravaArquivo(string diretorioAgenda)
        {
            var fs = File.AppendText(diretorioAgenda);
            var registros = repoNetinho.Lista();

            foreach(var registro in registros)
            {
                fs.Write($"{registro}\n");
            }

            repoNetinho.LimpaDados();

            fs.Close();
        }

    }
}
