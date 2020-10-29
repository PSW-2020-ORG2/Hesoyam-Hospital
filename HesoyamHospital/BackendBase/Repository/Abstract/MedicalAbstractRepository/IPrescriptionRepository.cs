using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.Abstract.MedicalAbstractRepository
{
    public interface IPrescriptionRepository : IRepository<Prescription, long>
    {
    }
}
