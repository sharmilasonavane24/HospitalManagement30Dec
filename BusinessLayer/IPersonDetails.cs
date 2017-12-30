

namespace BusinessLayer
{

    public interface IPersonDetails : IPerson, IContact
    {
      //Per  person { get; set; }

    PersonTypes personTypes { get; set; }
        
    //cotact { get; set; }
    }
}
