﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.Compartilhado
{
    public abstract class TelaBase
    {
        public string nomeEntidadeSingular;
        public string nomeEntidadePlural;

        protected RepositorioBase repositorioBase = null;

        protected TelaBase(RepositorioBase repositorioBase)
        {
            this.repositorioBase = repositorioBase;
        }

        public void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo + "\n");

            Console.WriteLine(subtitulo + "\n");
        }

        public void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();

            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidadePlural}\n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidadeSingular}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidadePlural}");
            Console.WriteLine($"Digite 3 para Editar {nomeEntidadePlural}");
            Console.WriteLine($"Digite 4 para Excluir {nomeEntidadePlural}\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void InserirNovoRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Inserindo um novo registro...");

            EntidadeBase registro = ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro(); //chamada recursiva

                return;
            }

            repositorioBase.Inserir(registro);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public virtual void VisualizarRegistros(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Visualizando registros já cadastrados...");

            ArrayList registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
            }

            MostrarTabela(registros);
        }

        public virtual void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            EntidadeBase registro = EncontrarRegistro("Digite o id do registro: ");

            EntidadeBase registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(registro, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public virtual void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidadePlural}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            EntidadeBase registro = EncontrarRegistro("Digite o id do registro: ");

            repositorioBase.Excluir(registro);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
        }

        public virtual EntidadeBase EncontrarRegistro(string textoCampo)
        {
            bool idInvalido;
            EntidadeBase registroSelecionado = null;

            do
            {
                idInvalido = false;
                Console.Write("\n" + textoCampo);
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());

                    registroSelecionado = repositorioBase.SelecionarPorId(id);

                    if (registroSelecionado == null)
                        idInvalido = true;
                }
                catch (FormatException)
                {
                    idInvalido = true;
                }

                if (idInvalido)
                    MostrarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return registroSelecionado;
        }

        protected bool TemErrosDeValidacao(EntidadeBase registro)
        {
            bool temErros = false;

            ArrayList erros = registro.Validar();

            if (erros.Count > 0)
            {
                temErros = true;
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }

                Console.ResetColor();

                Console.ReadLine();
            }

            return temErros;
        }

        protected abstract EntidadeBase ObterRegistro();

        protected abstract void MostrarTabela(ArrayList registros);

    }
}
