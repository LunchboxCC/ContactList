using AutoMapper;

namespace ContactList.Server.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactFormDTO, Contact>();
        }
    }
}
