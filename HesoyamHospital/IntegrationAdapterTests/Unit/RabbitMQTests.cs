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
            List<NewsMessage> receivedMessages = RegisteredPharmacyStubRepository.CreateIncomingActionsAndBenefits();
            AssertMessage(receivedMessages);
        }

        private static void AssertMessage(List<NewsMessage> receivedMessages)
        {
            foreach (NewsMessage message in receivedMessages)
            {
                message.Text.ShouldNotBeNull();
                message.Text.ShouldNotBeEmpty();
            }
        }
        [Fact]
        public void Check_if_n_messages_arrived()
        {
            int i = 0;
            List<NewsMessage> receivedMessages = RegisteredPharmacyStubRepository.CreateIncomingActionsAndBenefits();
            i = Count_received_messages(i, receivedMessages);
            Assert.Equal(receivedMessages.Count, i);
        }

        private static int Count_received_messages(int i, List<NewsMessage> receivedMessages)
        {
            foreach (NewsMessage message in receivedMessages)
            {
                i += 1;
            }

            return i;
        }
        [Fact]
        public void Check_if_received_message_is_same_as_expected()
        {
            List<NewsMessage> receivedMessages = RegisteredPharmacyStubRepository.CreateIncomingActionsAndBenefits();
            //Assert.Equal("Is", receivedMessages[1].Text);
            receivedMessages[1].Text.ShouldBe("Is");
        }
    }
}
