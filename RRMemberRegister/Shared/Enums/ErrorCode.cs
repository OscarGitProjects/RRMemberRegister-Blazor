namespace RRMemberRegister.Shared.Enums
{
    /// <summary>
    /// enum för att ange om det blev något fel när användaren skpade ny medlem, uppdaterade en medlem eller raderade en medlem
    /// Används av respektive component för att visa felmeddelande för användaren
    /// </summary>
    public enum ErrorCode
    {
        NONE = 0,
        CREATED = 1,
        UPDATED = 2,
        DELETED = 3,
        NOTFOUND = 4
    }
}