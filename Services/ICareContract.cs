using Helping_Hands_2._0.Models;

namespace Helping_Hands_2._0.Services
{
    public interface ICareContract
    {
        void CreateContract(CareContract careContract, string Email);
        void CreateCareVisit(VisitInfo vi);
        void updateVisit(int VisitId, VisitInfo vi);
        List<CareContract> MyClosedContracts(string email);
    }
}
