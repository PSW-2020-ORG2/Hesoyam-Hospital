using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.MySQLRepository.MiscRepository
{
    public class ActionBenefitRepository : MySQLRepository<ActionBenefit, long>, IActionBenefitRepository
    {
        private const string ENTITY_NAME = "ActionBenefit";

        public ActionBenefitRepository(IMySQLStream<ActionBenefit> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<ActionBenefit>())
        {
        }

        public IEnumerable<ActionBenefit> GetAllApprovedActionBenefits()
            => GetAll().Where(action => action.Approved == true);

        public IEnumerable<ActionBenefit> GetAllUnapprovedActionBenefits()
            => GetAll().Where(action => action.Approved == false);
    }
}
