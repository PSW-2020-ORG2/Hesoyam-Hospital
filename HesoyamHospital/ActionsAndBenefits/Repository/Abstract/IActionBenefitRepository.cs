using ActionsAndBenefits.Model;
using System.Collections.Generic;

namespace ActionsAndBenefits.Repository.Abstract
{
    public interface IActionBenefitRepository : IRepository<ActionBenefit, long>
    {
        IEnumerable<ActionBenefit> GetAllApprovedActionBenefits();
        IEnumerable<ActionBenefit> GetAllUnapprovedActionBenefits();
        IEnumerable<string> GetAllApprovedActionBenefitsText();
    }
}
