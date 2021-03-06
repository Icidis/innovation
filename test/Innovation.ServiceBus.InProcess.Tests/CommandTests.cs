﻿namespace Innovation.ServiceBus.InProcess.Tests
{
    using System.Threading.Tasks;

    using Xunit;

    using Innovation.ApiSample.Customers.Commands;

    public class CommandTests : TestBase
    {
        [Fact]
        public void Can_Handle_Insert_Customer()
        {
            // Arrange
            var insertCustomerCommand = new InsertCustomer("Innovation", "somecrazynamethatdoesnotexistyet");

            // Act
            var dispatcher = this.GetDispatcher();
            var canCommand = dispatcher.CanCommand(insertCustomerCommand);

            // Assert
            Assert.True(canCommand);
        }

        [Fact]
        public async Task Can_Insert_Customer()
        {
            // Arrange
            var insertCustomerCommand = new InsertCustomer("Innovation", "somecrazynamethatdoesnotexistyet");

            // Act
            var dispatcher = this.GetDispatcher();
            var insertCustomerCommandResult = await dispatcher.Command(insertCustomerCommand, false);

            // Assert
            Assert.True(insertCustomerCommandResult.Success);
        }
    }
}
