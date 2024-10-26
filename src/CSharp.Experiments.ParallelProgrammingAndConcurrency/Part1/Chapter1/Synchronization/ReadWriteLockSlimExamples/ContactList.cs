namespace CSharp.Experiments.ParallelProgrammingAndConcurrency.Part1.Chapter1.Synchronization.ReadWriteLockSlimExamples;

public class ContactList
{
    private readonly List<Contact> contacts;

    private readonly ReaderWriterLockSlim contactLock = new();

    public ContactList(List<Contact> initialContacts)
    {
        this.contacts = initialContacts;
    }

    public void AddContact(Contact newContact)
    {
        try
        {
            this.contactLock.EnterWriteLock();
            this.contacts.Add(newContact);
        }
        finally
        {
            this.contactLock.ExitWriteLock();
        }
    }

    public Contact? GetContactByPhoneNumber(string phoneNumber)
    {
        try
        {
            this.contactLock.EnterReadLock();
            return this.contacts.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        }
        finally
        {
            this.contactLock.ExitReadLock();
        }
    }
}

public record Contact
{
    public string Name { get; init; } = Guid.NewGuid().ToString();
    public string? PhoneNumber { get; init; }
}
