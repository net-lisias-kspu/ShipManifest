using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Ship Manifest /L Unleashed :: Serenity")]
[assembly: AssemblyDescription("Serenity KSP support for Shio Manifest /L Unleashed")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(ShipManifest.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(ShipManifest.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(ShipManifest.LegalMamboJambo.Copyright)]
[assembly: AssemblyTrademark(ShipManifest.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

//[assembly: AssemblyVersion("1.0.*")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
[assembly: AssemblyVersion(ShipManifest.Version.Number)]
[assembly: AssemblyFileVersion(ShipManifest.Version.Number)]
[assembly: KSPAssembly("ShipManifest.Serenity", ShipManifest.Version.major, ShipManifest.Version.minor)]

[assembly: KSPAssemblyDependency("KSPe", 2, 5)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 5)]
