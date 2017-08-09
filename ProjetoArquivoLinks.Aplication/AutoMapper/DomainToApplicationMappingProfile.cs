using AutoMapper;

namespace ProjetoArquivoLinks.Aplication.AutoMapper
{
    public class DomainToApplicationMappingProfile : Profile
    {
        public override string ProfileName => "DomainToApplicationMapping";
        
        protected override void Configure()
        {
            //Mapper.CreateMap<ValidationError, ValidationAppError>();
            //Mapper.CreateMap<ValidationResult, ValidationAppResult>();
        }
    }
}