using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.HospitalManagementRepository
{
    public class TenderOfferRepository : MySQLRepository<TenderOffer, long>, ITenderOfferRepository
    {
        private const string ENTITY_NAME = "TenderOffer";
        public TenderOfferRepository(IMySQLStream<TenderOffer> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<TenderOffer>())
        {
        }

        public IEnumerable<string> GetAllOfferEmails(long id)
            => GetAll().Where(tenderOffer => tenderOffer.TenderId == id).Select(offer => offer.Email);

        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id)
            => GetAll().Where(tenderOffer => id == tenderOffer.TenderId);
    }
}
