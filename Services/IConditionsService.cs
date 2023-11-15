using Helping_Hands_2._0.Models;

namespace Helping_Hands_2._0.Services
{
    public interface IConditionsService:IDisposable
    {
        void AddCondition(ChronicCondition condition);
        List<ChronicCondition> GetConditions();
        void Delete(int ID);
        IEnumerable<PatientChronicCon> MyChronicConditions(string Email);

    }
}
