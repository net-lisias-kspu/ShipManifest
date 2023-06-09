/*
	This file is part of Ship Manifest /L Unleashed
		© 2021-2023 LisiasT : http://lisias.net <support@lisias.net>
		© 2020 micha (mwerle)
		© 2013-2018 PapaJoesSoup

		Ship Manifest /L Unleashed is licensed as follows:

		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using UnityEngine;

namespace ShipManifest
{
  [KSPAddon(KSPAddon.Startup.Instantly, true)]
  internal class Startup : MonoBehaviour
  {
    private void Start()
    {
      Log.force("Version {0}", Version.Text);

      try     // Check for critical artefacts first!
      {
        using (KSPe.Util.SystemTools.Assembly.Loader<Startup> a = new KSPe.Util.SystemTools.Assembly.Loader<Startup>())
        {
          if (KSPe.Util.KSP.Version.Current < KSPe.Util.KSP.Version.GetVersion(1, 7, 1))
            a.LoadAndStartup("ShipManifest.Classic");
          else
            a.LoadAndStartup("ShipManifest.Serenity");
        }

        // Check if the needed Classes are available...
        KSPe.Util.SystemTools.Type.Find.ByQualifiedName("ShipManifest.Windows.WindowRosterRealization");
      }
      catch (System.Exception e)
      {
        Log.error(e.ToString());
        MSG.MissingDLLAlertBox.Show(e.Message);
      }

      try
      {
        KSPe.Util.Installation.Check<Startup>();
      }
      catch (KSPe.Util.InstallmentException e)
      {
        Log.error(e.ToShortMessage());
        KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
      }
    }
  }
}
