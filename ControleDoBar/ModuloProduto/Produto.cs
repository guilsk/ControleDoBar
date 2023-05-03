using Controle_do_Bar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_do_Bar.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public double preco;

        public Produto(){}

        public Produto(string nome, double preco)
        {
            this.nome = nome;
            this.preco = preco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            nome = produtoAtualizado.nome;
            preco = produtoAtualizado.preco;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");


            if (preco <= 0)
                erros.Add("O campo \"preco\" deve ser um número maior que 0");

            return erros;
        }
    }
}
