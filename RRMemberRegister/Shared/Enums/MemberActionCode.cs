namespace RRMemberRegister.Shared.Enums
{
    /// <summary>
    /// enum som anger vad en användare har utför för någon action dvs. skapat en ny medlem, uppdaterat en medlem eller raderat en medlem
    /// Används överst i memberList componenten för att visa rätt meddelande till användaren
    /// </summary>
    public enum MemberActionCode
    {
        NONE = 0,
        CREATED = 1,
        UPDATED = 2,
        DELETED = 3
    }
}
