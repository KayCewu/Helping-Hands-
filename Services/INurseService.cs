﻿using Helping_Hands_2._0.Models;
using Helping_Hands_2._0.Models.ViewModels;

namespace Helping_Hands_2._0.Services
{
    public interface INurseService: IDisposable
    {
        List<Nurse> GetNurses();
        void CreateCareVisit(VisitInfo visit);
        List<CareContract> GetCareContracts();
        void UpdateNurse(NurseUpdate nurseUpdate, string Email);
        List<Suburb> GetSuburbs();
        List<CareContract> MyCareContracts(string email);
        string PatientName(int id);
        string PatientSurname(int id);
        string EmergencyPersonel(int id);
        string EmergencyContact(int id);
        string PatientNo(int id);

    }
}
