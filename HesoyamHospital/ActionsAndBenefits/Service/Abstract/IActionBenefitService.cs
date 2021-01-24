using ActionsAndBenefits.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionsAndBenefits.Service.Abstract
{
    public interface IActionBenefitService : IService<ActionBenefit, long>
    {
        public IEnumerable<ActionBenefit> GetAllApprovedActionBenefits();
        public IEnumerable<ActionBenefit> GetAllUnapprovedActionBenefits();
        public IEnumerable<string> GetAllApprovedActionBenefitsText();
        public void Approve(ActionBenefit actionBenefit);
    }
}
