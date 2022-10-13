using AutoMapper;
using AutomapperInheritance.Input;
using defProduct = AutomapperInheritance.Models;
using inProduct = AutomapperInheritance.Models.IN;
using udProduct = AutomapperInheritance.Models.UD;

namespace AutomapperInheritance.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<InputProduct, defProduct.Product>()
                .ForMember(d => d.Id, s => s.MapFrom(r => r.Id))
                .ForMember(d => d.Name, s => s.MapFrom(r => r.Name))
                .ForMember(d => d.IsActive, s => s.MapFrom(r => r.IsActive))
                .ForMember(d => d.IsDeleted, s => s.MapFrom(r => !r.IsActive))
                .ForMember(d => d.Description, s => s.MapFrom(r => r.Description))
                .ForMember(d => d.Notes, s => s.MapFrom(r => GetMainNotes(r)));

            CreateMap<InputProduct, inProduct.Product>()
                .IncludeBase<InputProduct, defProduct.Product>()
                .ForMember(d => d.Notes, s => s.MapFrom(r => GetInNotes(r)));

            CreateMap<InputProduct, udProduct.Product>()
                .IncludeBase<InputProduct, defProduct.Product>()
                .ForMember(d => d.Notes, s => s.MapFrom(r => GetUdNotes(r)));
        }

        private IReadOnlyCollection<defProduct.Note> GetMainNotes(InputProduct source)
        {
            return new List<defProduct.Note>()
            {
                new defProduct.Note{NoteType = "Manufacturer", NoteDesc = source.Manufacturer },
                new defProduct.Note{ NoteType = "Vendor", NoteDesc = source.Vendor }
            };
        }

        private IReadOnlyCollection<inProduct.Note> GetInNotes(InputProduct source)
        {
            return new List<inProduct.Note>()
            {
                new inProduct.Note{NoteType = "Manufacturer", NoteDesc = source.Manufacturer },
                new inProduct.Note{ NoteType = "LocalVendor", NoteDesc = source.LocalVendor },
                new inProduct.Note{NoteType = "Storage", NoteDesc = source.Storage },
                new inProduct.Note{ NoteType = "Vendor", NoteDesc = source.Vendor },
            };
        }

        private IReadOnlyCollection<udProduct.Note> GetUdNotes(InputProduct source)
        {
            return new List<udProduct.Note>()
            {
                new udProduct.Note{NoteType = "Manufacturer", NoteDesc = source.Manufacturer }
            };
        }
    }
}
