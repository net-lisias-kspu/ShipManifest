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
using ConnectedLivingSpace;

namespace ShipManifest.Modules
{
  internal class ModHatch
  {
    internal ModHatch()
    {
    }

    internal ModHatch(PartModule pModule, ICLSPart iPart)
    {
      HatchModule = pModule;
      ClsPart = iPart;
    }

    internal PartModule HatchModule { get; set; }

    internal ICLSPart ClsPart { get; set; }

    internal bool HatchOpen
    {
      get { return Module.HatchOpen; }
      set { Module.HatchOpen = value; }
    }

    internal string HatchStatus
    {
      get { return Module.HatchStatus; }
    }

    internal bool IsDocked
    {
      get { return Module.IsDocked; }
    }

    internal string Title
    {
      get
      {
        string title;
        try
        {
          title = null != ClsPart.Part.parent ? ClsPart.Part.parent.partInfo.title : ClsPart.Part.partInfo.title;
        }
        catch
        {
          title = SmUtils.SmTags["#smloc_module_003"]; //"Unknown";
        }
        return title;
      }
    }

    private IModuleDockingHatch Module
    {
      // ReSharper disable once SuspiciousTypeConversion.Global
      get { return (IModuleDockingHatch) HatchModule; }
    }

    internal void OpenHatch(bool fireEvent = false)
    {
      Module.HatchEvents["CloseHatch"].active = true;
      Module.HatchEvents["OpenHatch"].active = false;
      Module.HatchOpen = true;
      if (fireEvent)
        SMAddon.FireEventTriggers();
    }

    internal void CloseHatch(bool fireEvent = false)
    {
      Module.HatchEvents["CloseHatch"].active = false;
      Module.HatchEvents["OpenHatch"].active = true;
      Module.HatchOpen = false;
      if (fireEvent)
        SMAddon.FireEventTriggers();
    }
  }
}
