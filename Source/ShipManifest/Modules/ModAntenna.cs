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
using ShipManifest.APIClients;

namespace ShipManifest.Modules
{
  internal class ModAntenna
  {
    internal ModAntenna()
    {
    }

    internal ModAntenna(PartModule xModule, PartModule pModule, Part iPart)
    {
      XmitterModule = xModule;
      AnimateModule = pModule;
      SPart = iPart;
    }

    internal PartModule XmitterModule { get; set; }

    internal PartModule AnimateModule { get; set; }

    internal Part SPart { get; set; }

    internal bool IsRtModule
    {
      get
      {
        return XmitterModule.moduleName == "ModuleRTAntenna";
      }
    }

    internal bool Extended
    {
      get
      {
        if (IsRtModule)
          return XmitterModule.Events["EventClose"].active;
        return Module.deployState == ModuleDeployablePart.DeployState.EXTENDED;
      }
    }

    internal string AntennaStatus
    {
      get
      {
        // RT support:
        if (IsRtModule)
          return XmitterModule.Events["EventClose"].active ? "Activated" : "Deactivated";
        return Module.deployState == ModuleDeployablePart.DeployState.EXTENDED ? "Extended" : "Retracted";
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

    private ModuleDeployableAntenna Module
    {
      get { return (ModuleDeployableAntenna) AnimateModule; }
    }

    internal void ExtendAntenna()
    {
      // RT support:
      if (IsRtModule)
      {
        if (InstalledMods.IsRtInstalled)
        {
          //if (RemoteTech.API.API.HasFlightComputer(SmAddon.vessel.id))
          //{
          //    ConfigNode configNode = new ConfigNode();
          //    configNode.AddValue("GUIDString", SmAddon.vessel.id);
          //    configNode.AddValue("Executor", "ShipManifest");
          //    configNode.AddValue("ReflectionType", "ShipManifest");
          //    RemoteTech.API.API.QueueCommandToFlightComputer(configNode);
          //}
          //else
          XmitterModule.Events["EventOpen"].Invoke();
        }
        else
          XmitterModule.Events["EventOpen"].Invoke();
      }
      else if (Module.deployState == ModuleDeployablePart.DeployState.RETRACTED)
        Module.Extend();
    }

    internal void RetractAntenna()
    {
      // RT support:
      if (IsRtModule)
        XmitterModule.Events["EventClose"].Invoke();
      else if (Module.deployState == ModuleDeployablePart.DeployState.EXTENDED)
        Module.Retract();
    }
  }
}
