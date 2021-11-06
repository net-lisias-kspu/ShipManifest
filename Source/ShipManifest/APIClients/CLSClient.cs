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
using System.Reflection;
using TypeFinder = KSPe.Util.SystemTools.TypeFinder;
namespace ShipManifest.APIClients
{
  internal static class ClsClient
  {
    private static PropertyInfo _cls;

    static ClsClient()
    {
      try
      {
        if(!TypeFinder.ExistsByQualifiedName("ConnectedLivingSpace.CLSAddon")) return;
        Type clsType = TypeFinder.FindByQualifiedName("ConnectedLivingSpace.CLSAddon");
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
