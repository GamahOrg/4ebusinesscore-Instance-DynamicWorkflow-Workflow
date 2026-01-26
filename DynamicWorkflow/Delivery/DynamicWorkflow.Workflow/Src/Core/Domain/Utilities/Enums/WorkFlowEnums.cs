namespace _4EPlatform.Domain.Utilities.Enums
{
    [Flags]
    public enum ActionOptions
    {
        Aprove = 1,
        Reject = 2,
        Edit = 4,
        redirection = 8,
        Send = 16,
        Cancel = 32,
        AcppetDuplication = 64
    }

    public enum ActionTakerTypes
    {
        Employee,
        Organization,
        Committee,
        Customized
    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
        RequireEdit,
        Redirected,
        Cancel,
        ExceptionApprove
    }
    public enum AssginRequestStatus
    {
        Pending,
        Save,
        Send,
    }

    public enum SlaStatus
    {
        Important = 1,
        Urgent = 2,
        Normal = 3,
        Summary = 4
    }
    public enum DeterminExceptionActionTacker
    {

        ExceptionActionTacker = 0,
        NoExceptionActionTacker = 1,
    }

}
