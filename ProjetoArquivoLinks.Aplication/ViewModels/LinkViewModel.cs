using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoArquivoLinks.Aplication.ViewModels
{
    public class LinkViewModel
    {
        public LinkViewModel()
        {
            IdLink = Guid.NewGuid();
        }

        [Key]
        public Guid IdLink { get; set; }

        [DisplayName("URL: *")]
        [DataType(DataType.Url, ErrorMessage = "URL inválida!")]
        [Required(ErrorMessage = "Preencha o campo URL!")]
        public string Url { get; set; }

        [DisplayName("Descrição: *")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Preencha o campo descrição!")]
        public string DescricaoLink { get; set; }

        [DisplayName("Comentário:")]
        [DataType(DataType.MultilineText)]
        public string ComentarioLink { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastroLink { get; set; }

        [ScaffoldColumn(false)]
        public bool StatusLink { get; set; }

        [ScaffoldColumn(false)]
        public int TotalPage { get; set; }
    }
}