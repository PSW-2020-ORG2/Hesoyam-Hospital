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
        [Fact]
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
        [Fact]
        public void Check_if_n_messages_arrived()
        {
            int i = 0;
            ActionBenefitService receivedMessages = new ActionBenefitService(PharmacyIntegrationStubRepository.CreateIncomingActionsAndBenefits());
            var all_messages = receivedMessages.GetAll();
            i = Count_all_messages(i, all_messages);
            Assert.Equal(all_messages.Count(), i);
        }

        private static int Count_all_messages(int i, IEnumerable<ActionBenefit> all_messages)
        {
            foreach (ActionBenefit message in all_messages)
            {
                i += 1;
            }

            return i;
        }

        [Fact]
        public void Check_if_received_message_is_same_as_expected()
        {
            ActionBenefitService receivedMessages = new ActionBenefitService(PharmacyIntegrationStubRepository.CreateIncomingActionsAndBenefits());
            Assert.Equal("Is", receivedMessages.GetAll().ToList()[1].Text);
        }
    }
}
