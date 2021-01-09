using Backend.Model.PharmacyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Abstract.MiscAbstractRepository
{
    public interface IActionBenefitRepository : IRepository<ActionBenefit, long>
    {
        IEnumerable<ActionBenefit> GetAllApprovedActionBenefits();
        IEnumerable<ActionBenefit> GetAllUnapprovedActionBenefits();
        IEnumerable<string> GetAllApprovedActionBenefitsText();
    }
}
