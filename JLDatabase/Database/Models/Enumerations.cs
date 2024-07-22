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
        IsAdmin,
        FirstName,
        LastName,
        Email,
        Password,
        IEEECategory,
        Author,
        ArticleTitle,
        Abstract,
        JournalTitle,
        Hyperlink,
    }

    public enum InvalidAuthenticationStatus
    {
        None,
        EmailAlreadyRegistered,
        UserDoesntExist,
        UserNotVerified,
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
            Hyperlink,
        }
    }
}
