using Backend.Model.PharmacyModel;
using Backend.Service.MiscService;
using IntegrationAdapter.RabbitMQServiceSupport;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IntegrationAdapterTests.Unit
{
    public class RabbitMQTests
    {
        [IgnoreOnDevelopmentFact]
        public void Check_if_received_object_contains_message()
        {
            ActionBenefitService receivedMessages = new ActionBenefitService(PharmacyIntegrationStubRepository.CreateIncomingActionsAndBenefits());
            AssertMessage((List<ActionBenefit>)receivedMessages.GetAll());
        }

        private static void AssertMessage(List<ActionBenefit> receivedMessages)
        {
            foreach (ActionBenefit message in receivedMessages)
            {
                message.Text.ShouldNotBeNull();
                message.Text.ShouldNotBeEmpty();
            }
        }
        [IgnoreOnDevelopmentFact]
        public void Check_if_n_messages_arrived()
        {
            int i = 0;
            ActionBenefitService receivedMessages = new ActionBenefitService(PharmacyIntegrationStubRepository.CreateIncomingActionsAndBenefits());
            var all_messages = receivedMessages.GetAll();
            i = CountAllMessages(i, all_messages);
            Assert.Equal(all_messages.Count(), i);
        }

        private static int CountAllMessages(int i, IEnumerable<ActionBenefit> all_messages)
        {
            foreach (ActionBenefit message in all_messages)
            {
                i += 1;
            }

            return i;
        }

        [IgnoreOnDevelopmentFact]
        public void Check_if_received_message_is_same_as_expected()
        {
            ActionBenefitService receivedMessages = new ActionBenefitService(PharmacyIntegrationStubRepository.CreateIncomingActionsAndBenefits());
            Assert.Equal("Is", receivedMessages.GetAll().ToList()[1].Text);
        }
    }
}
