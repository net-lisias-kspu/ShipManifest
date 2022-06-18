/*
	This file is part of Ship Manifest /L Unleashed
		© 2021-2022 LisiasT : http://lisias.net <support@lisias.net>
		© 2020 micha (mwerle)
		© 2013-2018 PapaJoesSoup

		Ship Manifest /L Unleashed is licensed as follows:

		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
namespace ShipManifest.Modules
{
  internal class ModSolarPanel
  {
    internal ModSolarPanel()
    {
    }

    internal ModSolarPanel(PartModule pModule, Part iPart)
    {
      PanelModule = pModule;
      SPart = iPart;
    }

    internal PartModule PanelModule { get; set; }

    internal Part SPart { get; set; }

    internal ModuleDeployablePart.DeployState PanelState
    {
      get { return Module.deployState; }
    }

    internal string PanelStatus
    {
      get { return Module.deployState.ToString(); }
    }

    internal bool Retractable
    {
      get { return Module.retractable; }
    }

    internal bool CanBeRetracted
    {
      get
      {
        if (SMSettings.RealControl && !Retractable &&
            (PanelState == ModuleDeployablePart.DeployState.EXTENDED ||
             PanelState == ModuleDeployablePart.DeployState.EXTENDING))
          return false;
        return true;
      }
    }

    internal string Title
    {
      get
      {
        string title;
        try
        {
          title = $"{SPart.partInfo.title}\r\n {SmUtils.SmTags["#smloc_module_001"]} {SPart.parent.partInfo.title}";
        }
        catch
        {
          title = SPart.partInfo.title;
        }
        return title;
      }
    }

    private ModuleDeployableSolarPanel Module
    {
      get { return (ModuleDeployableSolarPanel) PanelModule; }
    }

    internal void ExtendPanel()
    {
      Module.Extend();
    }

    internal void RetractPanel()
    {
      Module.Retract();
    }
  }
}
