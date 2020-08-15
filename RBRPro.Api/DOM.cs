using System;
using System.Collections.Generic;

/// <summary>
/// RBRPro Domain Object Model
/// Still work in progress
/// </summary>
namespace RbrPro.API
{
    public interface IDriver
    {
        int Number { get; }
        
        string Name { get; }
        string NickName { get; }
        string Email { get; }
        int YearOfBirth { get; }
        string Country { get; }
        string Category { get; }
        bool IsWRC { get; }
        bool IsDriver { get; }
        bool IsEngineer { get; }
        bool IsSupport { get; }
        bool IsManager { get; }
        bool IsRookie { get; }
       
        int Cups { get; }
        int Stars { get; }
        int Golds { get; }
        int Silvers { get; }
        int Bronzes { get; }
        int EngineerPoints { get; }
        int Reputation { get; }

        bool IsDonator { get; }
        bool IsProDonator { get; }

        ITeam Team { get; }
    }

    public interface ITeam
    {
        string Name { get; }     
        string Email { get; }        
        string Country { get; }        
        int Cups { get; }
        int Stars { get; }
        int Golds { get; }
        int Silvers { get; }
        int Bronzes { get; }
        int EngineerPoints { get; }
        int Reputation { get; }
        string AllowedCategories { get; }

        int NumMembers { get; }
        int NumEngineers { get; }
        int NumDrivers { get; }
        int NumSupports { get; }
        int NumManagers { get; }
        int NumRookies { get; }
                        
        List<IDriver> Members { get; }
    }

    public interface IStage
    {
        string StageName { get; }
        string Country { get; }
        string OptionPackType { get; }
        int Length { get; }
        int Difficulty { get; }
        int TrackCodeNormal { get; }
        int TrackCodeGravel { get; }
        int TrackCodeGravelReversed { get; }
        int TrackCodeReversed { get; }
        int TrackCodeSnow { get; }
        int TrackCodeSnowReversed { get; }
        int Surface { get; }
        string ParticlesNormal { get; }
        string ParticlesSnow { get; }
        string SplashScreen { get; }
        string SplashScreenReversed { get; }
        string SplashScreenSnow { get; }
        string SplashScreenSnowReversed { get; }
        string Author { get; }
        string Notes { get; }
        string Link { get; }

        string ReleasedVersion { get; }
        string Key { get; }
        bool IsOriginalStage { get; }
        bool IsOptionPack { get; }
        bool RequireNightPlugin { get; }
        bool IsHeavy { get; }
        bool IsBuggy { get; }
        string OptionKey { get; }
        string LinkOff { get; }
        bool DonatorsOnly { get; }
        string DocLink { get; }
        bool HasDocLink { get; }
        bool HasAnUpdate { get; }
        bool IsInstalled { get; }
        bool CanSelect { get; }
    }

    public interface ICar
    {
        string Key { get; }
        string Name { get; }
        string Physics { get; }
        string Category { get; }
        string Group { get; }
        string IniFile { get; }
        string Folder { get; }
        string Year { get; }
        int Weight { get; }
        int WheelBase { get; }
        string Power { get; }
        string Transmission { get; }
        string Gears { get; }
        string LinkSpecs { get; }
        string LinkWiki { get; }
        int ForceFeedbackSensitivityTarmac { get; }
        int ForceFeedbackSensitivityGravel { get; }
        int ForceFeedbackSensitivitySnow { get; }
        double Cam_xOff { get; }
        double Cam_yOff { get; }
        double Cam_zOff { get; }
        string ReleasedModelVersion { get; }
        string ReleasedPhysicsVersion { get; }
        string ReleasedEngineVersion { get; }
        string Engine { get; }
        string FmodEngine { get; }
        string ProEngine { get; }
        bool SupportsNgp5Only { get; }
        bool SupportsNgp6Only { get; }
        bool IsInstalled { get; }
        bool HasAnUpdate { get; }
        int LightsOption { get; }
        bool IsInList { get; }
        int Slot { get; }

        void SelectSkin(string carSkin);
    }

    public interface IStageList
    {
        List<string> Countries { get; }
        List<string> OptionPackTypes { get; }        
        IEnumerable<IStage> GetStages();
        IEnumerable<IStage> GetOptionPacks();
        IEnumerable<IStage> GetOriginalStages();
        IStage GetStageByCode(int code);
    }

    public interface ICarList
    {
        List<string> Categories { get; }        
        IEnumerable<ICar> GetCars();
        IEnumerable<ICar> GetCarsInGroup(string group);
    }

    public interface ICoDriver
    {
        string Id { get; }
        string Language { get; }
        string Name { get; }        
        int Quality { get; }
        string Notes { get; }
        bool PacenotePlugin { get; }
        string PacenotePluginLanguage { get; }
        string SoundsDirectory { get; }
        string ReleasedVersion { get; }       
        string TargetLanguage { get; }
        string Author { get; }
        DateTime DateInstalled { get; }
        bool DonatorsOnly { get; }
        string Archive { get; }
        bool IsEnglish { get; }
        string Description { get; }
        string InstalledVersion { get; }
        bool HasAnUpdate { get; }
    }

    public interface ICoDriverList
    {
        List<string> Languages { get; }        
        IEnumerable<ICoDriver> GetCoDrivers();
        IEnumerable<ICoDriver> GetCoDriversByLanguage(string language);        
    }
}
