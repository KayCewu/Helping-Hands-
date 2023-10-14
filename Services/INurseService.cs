using Helping_Hands_2._0.Models;

namespace Helping_Hands_2._0.Services
{
    public interface INurseService: IDisposable
    {
        List<Nurse> GetNurses();
        void CreateCareVisit(VisitInfo visit);
        List<CareContract> GetCareContracts();
    }
}
