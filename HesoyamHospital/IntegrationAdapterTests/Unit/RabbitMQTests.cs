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

    }
}
