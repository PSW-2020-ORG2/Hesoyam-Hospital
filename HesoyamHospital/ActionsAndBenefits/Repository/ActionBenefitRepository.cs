using ActionsAndBenefits.Model;
using ActionsAndBenefits.Repository.Abstract;
using ActionsAndBenefits.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class ActionBenefitRepository : SQLRepository<ActionBenefit, long>, IActionBenefitRepository
    {
        public ActionBenefitRepository(SQLStream<ActionBenefit> stream) : base(stream)
        {
        }

        public IEnumerable<ActionBenefit> GetAllApprovedActionBenefits()
            => GetAll().Where(action => action.Approved);
        public IEnumerable<ActionBenefit> GetAllUnapprovedActionBenefits()
            => GetAll().Where(action => !action.Approved);
        public IEnumerable<string> GetAllApprovedActionBenefitsText()
        {
            List<ActionBenefit> actionBenefits = GetAllApprovedActionBenefits().ToList();
            List<string> actionBenefitsText = new List<string>();
            foreach (ActionBenefit actionBenefit in actionBenefits)
            {
                actionBenefitsText.Add(actionBenefit.Text);
                if (actionBenefitsText.Count >= 5) break;
            }
            return actionBenefitsText;
        } 
    }
}
