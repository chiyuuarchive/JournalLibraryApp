namespace JLDatabase.Database.Models
{
    public enum IEEECategory
    {
        Aerospace,
        Bioengineering,
        Communication_Networking_BroadcastTechnologies,
        Components_Circuits_Devices_Systems,
        Computing_Processing,
        EngineeredMaterials_Dielectrics_Plasmas,
        Engineering_Profession,
        Field_Waves_Electromagnetics,
        Math_Science_Engineering,
        Geoscience,
        Nuclear_Engineering,
        Photonics_ElectroOptics,
        Power_Energy_IndustryApplications,
        Robotics_ControlSystems,
        SignalProcessing_Analysis,
        Transportation
    }

    public enum ProjectStatus
    {
        Active,
        Completed,
        Cancelled,
        OnHold
    }

    public enum InvalidInputFieldStatus
    {
        None,

        // User validation states
        IsAdmin,
        FirstName,
        LastName,
        Email,
        Password,

        // Article validation states
        IEEECategory,
        Author,
        ArticleTitle,
        Abstract,
        JournalTitle,
        YearOfPublication,
        Hyperlink,
    }

    public enum InvalidAuthenticationStatus
    {
        None,

        // User authentication states
        EmailAlreadyRegistered,
        UserDoesntExist,
        UserNotVerified,

        // Article authentication states
        HyperlinkAlreadyRegistered,
    }

    public class UserFieldTypes
    {
        /// <summary>
        /// Number indicates the order if validation
        /// </summary>
        public enum Registration
        {
            IsAdmin = 0,
            FirstName = 4,
            LastName = 3,
            Email = 2, 
            Password = 1,
        }

        public enum Login
        {
            Email = 1,
            Password = 0,
        }      
    }

    public class ArticleFieldTypes
    {
        public enum Registration
        {
            IEEECategory,
            Author,
            ArticleTitle,
            Abstract,
            JournalTitle,
            YearOfPublication,
            Hyperlink,
        }
    }
}
