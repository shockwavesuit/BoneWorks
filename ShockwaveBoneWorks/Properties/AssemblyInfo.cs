using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(ShockwaveBoneWorks.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(ShockwaveBoneWorks.BuildInfo.Company)]
[assembly: AssemblyProduct(ShockwaveBoneWorks.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + ShockwaveBoneWorks.BuildInfo.Author)]
[assembly: AssemblyTrademark(ShockwaveBoneWorks.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(ShockwaveBoneWorks.BuildInfo.Version)]
[assembly: AssemblyFileVersion(ShockwaveBoneWorks.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(ShockwaveBoneWorks.ShockwaveBoneWorks), ShockwaveBoneWorks.BuildInfo.Name, ShockwaveBoneWorks.BuildInfo.Version, ShockwaveBoneWorks.BuildInfo.Author, ShockwaveBoneWorks.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]