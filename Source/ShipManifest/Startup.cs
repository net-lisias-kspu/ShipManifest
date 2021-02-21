using System;
using UnityEngine;

namespace ShipManifest
{
  [KSPAddon(KSPAddon.Startup.Instantly, true)]
  internal class Startup : MonoBehaviour
  {
    private void Start()
    {
      Log.force("Version {0}", Version.Text);

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
