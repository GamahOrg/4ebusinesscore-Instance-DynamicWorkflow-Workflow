namespace Domain.Enums
{
    public enum State
    {
        NotDeleted,
        Deleted
    }
    public enum StatusEnum
    {
        FailedToSave,
        SavedSuccessfully,
        Exception,
        Success,
        Failed,
        FailedToFindTheObject,
        AlreadyExisting
    }
    public enum UserType
    {
        Local,
        Domain
    }
    public enum ActionNameEnum
    {
        Get,
        Post,
        Put,
        Delete,
    }
    public enum UserGender
    {
        Male,
        Female
    }
    public enum UserKind
    {
        Manager,
        Employee
    }
    public enum KafkaEvent
    {
        Post,
        Put,
        Delete
    }
    public enum MaritalStatus
    {
        Single,
        married
    }
    public enum NoteTypeId
    {
        SubSystem,
        Component,
        Part
    }
    public enum Color
    {
        Red,
        Green,
        Yellow,
    }
    public enum Table
    {
        User,
        Job,
        Card,
        Role
    }

    public enum TableColumn
    {
        UserTypeId = 1,
        JobDegreeId = 2,
        CardSetting = 3,
        CategoryRoleId = 4,
        UserJobTitle = 5,
        JobPositionId = 6

    }
    public enum JobTime
    {

        Basic, Responsible
    }

    public enum Priority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum CategoryStatus
    {
        Status1 = 1,
        Status2 = 2,
    }

    public enum Effect
    {
        None = 1,
    }

    public enum PriorityLevel
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum ServiceType
    {
        All = 1,
        RequestService = 2,
        ReportService = 3,
        Committee = 4,
        Pmo_Chnages = 5,
        Pmo_CloseProject = 6,
        Pmo_FeasabilityStudyRequest = 7,
        Pmo_HoldRequest = 8,
        Pmo_CancelRequest = 9,
        Pmo_BidRequest = 10,
        AvaliableCoureses = 11,
        UnavaliableCoureses = 12,
        IdentifyRisk = 13,
        InherentRisk = 14,
        RegulatoryControl = 15,
        RemainRisk = 16,
        ProcessingPlan = 17
    }

    public enum ActionAssgin
    {
        User = 1,
        Group = 2
    }

    public enum ActionOptionsAssgin
    {
        Save = 1,
        Send = 2
    }
}