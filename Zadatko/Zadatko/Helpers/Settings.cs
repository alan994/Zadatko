// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Zadatko.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants
        
      private const string AcceptedKey = "accepted_key";
      private static readonly bool AcceptedDefault = false;

    #endregion


      public static bool Accepted
      {
          get { return AppSettings.GetValueOrDefault<bool>(AcceptedKey, AcceptedDefault); }
          set { AppSettings.AddOrUpdateValue<bool>(AcceptedKey, value); }
      }

  }
}