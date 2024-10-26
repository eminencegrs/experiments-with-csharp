using CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.ReadWriteLockSlimExamples;
using FluentAssertions;
using FluentAssertions.Execution;
using Shouldly;
using Xunit;

namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.UnitTests.Part1.Chapter1.Synchronization.ReadWriteLockSlimExamples;

public class ContactListTests
{
    [Fact]
    public void GivenMultipleThreads_WhenAddingContacts_ThenAllContactsShouldBeAdded()
    {
        var initialContacts = new List<Contact>();
        var contactList = new ContactList(initialContacts);
        var newContacts = new List<Contact>
        {
            new() { PhoneNumber = "12345" },
            new() { PhoneNumber = "67890" },
            new() { PhoneNumber = "54321" },
            new() { PhoneNumber = "98765" }
        };

        var threads = new List<Thread>();
        foreach (var contact in newContacts)
        {
            var thread = new Thread(() => contactList.AddContact(contact));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        using (new AssertionScope())
        {
            initialContacts.Count.ShouldBe(newContacts.Count);
            initialContacts.Should().BeEquivalentTo(newContacts);
        }
    }

    [Fact]
    public void GivenMultipleThreads_WhenReadingContacts_ThenContactsShouldBeReturnedCorrectly()
    {
        var phoneNumberToFind = "12345";
        var initialContacts = new List<Contact>
        {
            new() { PhoneNumber = "12345" },
            new() { PhoneNumber = "67890" },
            new() { PhoneNumber = "54321" }
        };

        var contactList = new ContactList(initialContacts);

        Contact? foundContact = null;
        var thread = new Thread(() => foundContact = contactList.GetContactByPhoneNumber(phoneNumberToFind));
        thread.Start();
        thread.Join();

        using (new AssertionScope())
        {
            foundContact.Should().NotBeNull();
            foundContact!.PhoneNumber.ShouldBe(phoneNumberToFind);
        }
    }

    [Fact]
    public void GivenMultipleThreads_WhenSimultaneousReadAndWrite_ThenReadsAreConsistent()
    {
        var phoneNumberToFind = "67890";
        var initialContacts = new List<Contact>
        {
            new() { PhoneNumber = "12345" },
            new() { PhoneNumber = "67890" }
        };

        var contactList = new ContactList(initialContacts);
        var newContact = new Contact { PhoneNumber = "54321" };

        var writeThread = new Thread(() => contactList.AddContact(newContact));

        Contact? foundContact = null;
        var readThread = new Thread(() => foundContact = contactList.GetContactByPhoneNumber(phoneNumberToFind));

        writeThread.Start();
        readThread.Start();

        writeThread.Join();
        readThread.Join();

        using (new AssertionScope())
        {
            initialContacts.Should().Contain(newContact);
            foundContact.Should().NotBeNull();
            foundContact!.PhoneNumber.ShouldBe(phoneNumberToFind);
        }
    }
}
