using Backend.Model.PharmacyModel;
using IntegrationAdapter.RabbitMQServiceSupport;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace IntegrationAdapterTests.Unit
{
    public class RabbitMQTests
    {
        [Fact]
        public void Check_if_received_object_contains_message()
        {
            List<ActionBenefit> receivedMessages = RegisteredPharmacyStubRepository.CreateIncomingActionsAndBenefits();
            AssertMessage(receivedMessages);
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
            List<ActionBenefit> receivedMessages = RegisteredPharmacyStubRepository.CreateIncomingActionsAndBenefits();
            i = Count_received_messages(i, receivedMessages);
            Assert.Equal(receivedMessages.Count, i);
        }

        private static int Count_received_messages(int i, List<ActionBenefit> receivedMessages)
        {
            foreach (ActionBenefit message in receivedMessages)
            {
                i += 1;
            }

            return i;
        }
        [Fact]
        public void Check_if_received_message_is_same_as_expected()
        {
            List<ActionBenefit> receivedMessages = RegisteredPharmacyStubRepository.CreateIncomingActionsAndBenefits();
            //Assert.Equal("Is", receivedMessages[1].Text);
            receivedMessages[1].Text.ShouldBe("Is");
        }
    }
}
