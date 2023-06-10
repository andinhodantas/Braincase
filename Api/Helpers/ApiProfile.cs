using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dto.Institution;
using Api.Dto.Subject;
using Api.Dto.Tag;
using Api.Models;
using AutoMapper;

namespace Api.Helpers
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            // mapper das instituições
            CreateMap<Institution, ResponseInstitutionDTO>();
            CreateMap<InstitutionDTO, Institution>();

            // mapper das tags
            CreateMap<Tag, ResponseTagDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));
            CreateMap<UpdateTagDTO, Tag>()
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember, destMember) =>
                    {
                        if (srcMember == null)
                            return false;

                        if (srcMember is Guid guidValue)
                            return guidValue != Guid.Empty;

                        return true;
                    });
                });
            CreateMap<CreateTagDTO, Tag>();

            // mapper de subject
            CreateMap<Subject, ResponseSubjectDTO>();
            CreateMap<SubjectDTO, Subject>();
        }
    }
}