namespace Dev.UAA3.Backend.Domain.BusinessExceptions
{
    public class MemberException : Exception
    {
        public MemberException(string? message)
            : base(message) { }
    }

    public class MemberBadCredentialException : MemberException
    {
        public MemberBadCredentialException()
            : base("Bad credential !") { }
    }

    public class MemberAlreadyExistsException : MemberException
    {
        public MemberAlreadyExistsException()
            : base("Member already exists !") { }
    }
}
