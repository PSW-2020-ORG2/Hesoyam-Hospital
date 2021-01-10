using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.MiscService
{
    public class ActionBenefitService : IService<ActionBenefit, long>
    {
        private IActionBenefitRepository _actionBenefitRepository;

        public ActionBenefitService(IActionBenefitRepository actionBenefitRepository)
        {
            _actionBenefitRepository = actionBenefitRepository;
        }

        public ActionBenefit Create(ActionBenefit entity)
        {
            Validate(entity);
            return _actionBenefitRepository.Create(entity);
        }

        public void Delete(ActionBenefit entity)
        {
            _actionBenefitRepository.Delete(entity);
        }

        public IEnumerable<ActionBenefit> GetAll()
        {
            return _actionBenefitRepository.GetAll();
        }

        public ActionBenefit GetByID(long id)
        {
            return _actionBenefitRepository.GetByID(id);
        }

        public void Update(ActionBenefit entity)
        {
            Validate(entity);
            _actionBenefitRepository.Update(entity);
        }

        public IEnumerable<ActionBenefit> GetAllApprovedActionBenefits()
        {
            return _actionBenefitRepository.GetAllApprovedActionBenefits();
        }

        public IEnumerable<string> GetAllApprovedActionBenefitsText()
        {
            return _actionBenefitRepository.GetAllApprovedActionBenefitsText();
        }

        public IEnumerable<ActionBenefit> GetAllUnapprovedActionBenefits()
        {
            return _actionBenefitRepository.GetAllUnapprovedActionBenefits();
        }

        public void Validate(ActionBenefit entity)
        {
            if (String.IsNullOrEmpty(entity.Text))
            {
                throw new EmptyStringException("String attribute cannot be empty.");
            }
            
        }
    }
}
