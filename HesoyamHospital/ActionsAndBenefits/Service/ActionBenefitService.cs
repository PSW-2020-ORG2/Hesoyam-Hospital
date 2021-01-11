using ActionsAndBenefits.Exceptions;
using ActionsAndBenefits.Model;
using ActionsAndBenefits.Repository.Abstract;
using ActionsAndBenefits.Service.Abstract;
using System;
using System.Collections.Generic;

namespace ActionsAndBenefits.Service
{
    public class ActionBenefitService : IActionBenefitService
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
            if (string.IsNullOrEmpty(entity.Text))
            {
                throw new EmptyStringException("String attribute cannot be empty.");
            }
            
        }

        public void Approve(ActionBenefit actionBenefit)
        {
            actionBenefit.Approve();
            Update(actionBenefit);
        }
    }
}
