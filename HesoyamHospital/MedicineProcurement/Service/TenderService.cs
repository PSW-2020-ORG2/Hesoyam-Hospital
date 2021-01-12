using MedicineProcurement.Exceptions;
using MedicineProcurement.Model;
using MedicineProcurement.Repository.Abstract;
using MedicineProcurement.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly ITenderOfferRepository _tenderOfferRepository;
        public TenderService(ITenderRepository tenderRepository, ITenderOfferRepository tenderOfferRepository)
        {
            _tenderRepository = tenderRepository;
            _tenderOfferRepository = tenderOfferRepository;
        }
        public void ConcludeTender(long tenderId, long winnerOfferId, List<string> allEmails)
        {
            Tender tender = GetByID(tenderId);
            if (tender.IsActive())
            {
                throw new TenderStillActiveException("Tender cannot be concluded since it is still active!");
            }
            tender.Conclude(winnerOfferId);
            Update(tender);
            string winnerEmail = _tenderOfferRepository.GetByID(winnerOfferId).Email;
            Console.WriteLine(winnerEmail);
            NotifyParticipants(winnerEmail, allEmails);
        }

        private void NotifyParticipants(string winnerEmail, List<string> allEmails)
        {
            string from = Environment.GetEnvironmentVariable("HospitalEmail");
            string password = Environment.GetEnvironmentVariable("HospitalEmailPassword");
            string subject;
            string body;

            foreach (string email in allEmails)
            {
                if (email.Equals(winnerEmail))
                {
                    subject = "Tender offer accepted";
                    body = "Congratulations, your tender offer has been accepted! You will be contacted for further details.";
                }
                else
                {
                    subject = "Tender offer refused";
                    body = "We are sorry to inform you that your tender offer has been rejected.";
                }

                SMTPNotificationSender.SendMessage(from, password, email, subject, body);
            }
        }

        public Tender Create(Tender entity)
        {
            Validate(entity);
            return _tenderRepository.Create(entity);
        }

        public void Delete(Tender entity)
        {
            _tenderRepository.Delete(entity);
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public IEnumerable<Tender> GetAllActiveTenders()
        {
            return _tenderRepository.GetAllActiveTenders();
        }

        public IEnumerable<Tender> GetAllUnconcludedTenders()
        {
            return _tenderRepository.GetAllUnconcludedTenders();
        }

        public Tender GetByID(long id)
        {
            return _tenderRepository.GetByID(id);
        }

        public void Update(Tender entity)
        {
            _tenderRepository.Update(entity);
        }

        public void Validate(Tender entity)
        {
            if (entity.EndDate < DateTime.Now)
            {
                throw new InvalidDateException("Tender end date must be in the future!");
            }
            if (entity.TenderListings.Count == 0 || entity.TenderListings == null)
            {
                throw new TenderListingsEmptyException("Tender must contain listings!");
            }
        }
    }
}
