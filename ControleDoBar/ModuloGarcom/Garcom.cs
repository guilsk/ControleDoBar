using Controle_do_Bar.Compartilhado;

namespace Controle_do_Bar.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string nome;

        public Garcom(){}

        public Garcom(string nome)
        {
            this.nome = nome;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcomAtualizado = (Garcom)registroAtualizado;

            nome = garcomAtualizado.nome;
                
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
