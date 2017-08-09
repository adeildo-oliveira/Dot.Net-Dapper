using System;

namespace ProjetoArquivoLinks.Domain.Entities
{
    public class Link //: ISelfValidation
    {
        public Link()
        {
            IdLink = Guid.NewGuid();
        }

        public Guid IdLink { get; set; }
        public string Url { get; set; }
        public string DescricaoLink { get; set; }
        public string ComentarioLink { get; set; }
        public DateTime DataCadastroLink { get; set; }
        public bool StatusLink { get; set; }

        public int TotalPage { get; set; }
        /*
        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            var fiscal = new CategoriaValidadoParaCadastro();
            ResultadoValidacao = fiscal.Validar(this);

            return ResultadoValidacao.IsValid;
        }*/
    }
}