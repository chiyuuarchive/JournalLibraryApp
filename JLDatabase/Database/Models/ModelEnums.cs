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

    public class UserFieldTypes
    {
        public enum Registration
        {
            IsAdmin,
            FirstName,
            LastName,
            Email,
            Password
        }

        public enum Login
        {
            Email,
            Password
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
