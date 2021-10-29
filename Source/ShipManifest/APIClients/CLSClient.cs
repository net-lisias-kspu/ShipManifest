/*
	This file is part of Ship Manifest /L Unleashed
		© 2021 Lisias T : http://lisias.net <support@lisias.net>
		© 2020 micha (mwerle)
		© 2013-2018 PapaJoesSoup

		Ship Manifest /L Unleashed is licensed as follows:

		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using System;
using System.Linq;
using System.Reflection;

namespace ShipManifest.APIClients
{
  internal static class ClsClient
  {
    private static PropertyInfo _cls;

    static ClsClient()
    {
      try
      {
        // Original call.  deep dives into all assemblies...
        //Type cls_type = AssemblyLoader
        //  .loadedAssemblies
        //  .SelectMany(a => a.assembly.GetExportedTypes())
        //  .SingleOrDefault(t => t.FullName == "ConnectedLivingSpace.CLSAddon");

        // this replacement call attempts to filter dynamic assemblies...  Dot.Net 2.0 vs Dot.Net 4.0
        //Type newType = AssemblyLoader
        //  .loadedAssemblies.Where(a => a.assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder == false)
        //  .SelectMany(a => a.assembly.GetExportedTypes())
        //  .SingleOrDefault(t => t.FullName == "ConnectedLivingSpace.CLSAddon");

        // Lighter weight, and should not "dive into" assemblies unnecessarily.
        Type clsType =
          AssemblyLoader.loadedAssemblies.Where(a => a.name.Contains("ConnectedLivingSpace"))
            .SelectMany(a => a.assembly.GetExportedTypes())
            .SingleOrDefault(t => t.FullName == "ConnectedLivingSpace.CLSAddon");

        if (clsType != null) _cls = clsType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
      }
      catch (Exception ex)
      {
        Log.error(ex, "Cannot load CLS assembly");
      }
    }

    public static bool ClsInstalled()
    {
      return _cls != null;
    }

    public static ConnectedLivingSpace.ICLSAddon GetCls()
    {
      return (ConnectedLivingSpace.ICLSAddon) _cls?.GetValue(null, null);
    }
  }
}
