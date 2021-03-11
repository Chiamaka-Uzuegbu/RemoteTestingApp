using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.DTOs.Response;
using RemoteTestingApp.Core.Entities;
using RemoteTestingApp.Infrastructure.Extensions;
namespace RemoteTestingApp.Infrastructure.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PersonalDetailsRequestDTO, PersonalDetails>().ReverseMap();
            CreateMap<RegisterRequestDTO, Register>();
            CreateMap<ReviewCompanyDocumentRequest, ReviewCompanyDocument>().ReverseMap();
            CreateMap<UploadCertificatesRequestDTO, UploadedDocument>()
                .ForMember(dest => dest.WaecCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToByteArray(src.WaecCertificate)))
                .ForMember(dest => dest.NyscCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToByteArray(src.NyscCertificate)))
                .ForMember(dest => dest.ProfessionalCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToByteArray(src.ProfessionalCertificate)))
                .ForMember(dest => dest.UniversityCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToByteArray(src.UniversityCertificate))
                );
            CreateMap<UploadedDocument, UploadedDocumentResponseDTO>()
                .ForMember(dest => dest.WaecCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToBase64(src.WaecCertificate)))
                .ForMember(dest => dest.NyscCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToBase64(src.NyscCertificate)))
                .ForMember(dest => dest.ProfessionalCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToBase64(src.ProfessionalCertificate)))
                .ForMember(dest => dest.UniversityCertificate, options => options.MapFrom(src => UploaderExtensions.ConvertToBase64(src.UniversityCertificate))
                );

        }
    }
}
