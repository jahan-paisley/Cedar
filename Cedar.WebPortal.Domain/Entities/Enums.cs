namespace Cedar.WebPortal.Domain.Enums
{
    public enum Gender
    {
        None,
        Male,
        Female
    }

    public enum HabitaionType
    {
        None,
        Rented,
        Owned,
    }

    public enum MilitaryServiceStatus
    {
        None,
        Done,
        NotDone,
        Ongoing,
        Exempted
    }

    public enum EducationLevel
    {
        None,
        UnderDiploma,
        Diploma,
        College,
        Bachelor,
        Master,
        PhD
    }

    public enum OpratorName
    {
        Mci,
        Irancell,
        Taliya
    }

    public enum ProductType
    {
        Physical,
        ECharge,
        All
    }

    public enum CompanyForm
    {
        PublicJointStock,
        LLP,
        Cooperative,
        PrivateJointStock,
        Other
    }

    public enum DistributionType
    {
        Retail,
        Wholesale,
        Both
    }

    public enum Facility
    {
        None,
        Website,
        VendingMachine,
        MobileSales,
        Other
    }
    public enum ContractType
    {
        PartTime,
        FullTime,
        Project,
        Cunsultance,
        Other
    }
    public enum TrainingUnitType
    {
        State,
        Free,
        PayamNoor,
        NonProfit,
        Other
    }
    public enum SkillLevel
    {
        Perfect,
        Good,
        Average,
        Poor
    }
    public enum AcquaintanceWay
    {
        PaperAdvertisement,
        InternetAdvertisement,
        RecruitmentAgency,
        People,
        Other
    }
    public enum FamilyRelation
    {
        Father,
        Mother,
        Brother,
        Sister,
        Couple,
        Child
    }

    public enum PreferredPickPointSimCard
    {
        Tehran,
        Karaj
    }

    public enum PreferredModeOfCommunication
    {
        Email,
        Post
    }

    public enum State
    {
        Exist,
        Hold,
        Sold,
        NotExist,
        Held
    }
    public enum Language
    {
        En,
        Fa
    }

    public enum ServiceType
    {
        Data,

        Smartphone
    }

    public enum PaymentType
    {
        Postpaid,

        Prepaid
    }
    public enum JobCategory
    {
        Government,

        Industry,

        Training,

        Commercial,

        Agriculture,

        Service,

        Health,

        Other,
    }

    public enum MaritalStatus
    {
        None,
        Married,
        Single,
        Other
    }
    public enum IssueType
    {
        None = 0,
        SMS = 401,
        MMS = 402,
        Internet = 403,
        VoiceCall = 404,
        VideoCall = 405,
        VAS = 406,
        RBT = 407,
        MBanking = 408,
        EPayment = 409,
        Roaming = 410,
        GoldenList = 411,
        MissedCallAlert = 412,
        OnlineMobileRecharging = 413,
        PylonAntenna = 427
    }
    public enum SimType
    {
        None,
        Postpaid,
        Prepaid,
        Data
    }
    public enum IssueStatus
    {
        Followup,
        Finish,
        Invalid
    }

    public enum TenderType
    {
        Tender,
        Bid,
        Call
    }

    public enum TenderStep
    {
        OneStep,
        TwoStep
    }

    public enum ApplicantSalesShopType
    {
        Sales,
        Shop
    }
    public enum Ownership
    {
        Owner,
        Leased
    }
    public enum InstallationPanel
    {
        Permitted,
        NotFeasible
    }

    public enum FileType
    {
        None,
        Picture,
        Document,
        CV
    }
}