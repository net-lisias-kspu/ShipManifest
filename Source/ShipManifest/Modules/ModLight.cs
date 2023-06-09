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
namespace ShipManifest.Modules
{
  internal class ModLight
  {
    internal ModLight()
    {
    }

    internal ModLight(PartModule pModule, Part iPart)
    {
      LightModule = pModule;
      SPart = iPart;
    }

    internal PartModule LightModule { get; set; }

    internal Part SPart { get; set; }

    internal string Title
    {
      get
      {
        string title;
        try
        {
          title = $"{SPart.partInfo.title}\r\n {SmUtils.SmTags["#smloc_module_001"]} {Module.part.parent.partInfo.title}";
        }
        catch
        {
          title = SPart.partInfo.title;
        }
        return title;
      }
    }

    internal bool IsOn
    {
      get { return Module.isOn; }
    }

    internal string Status
    {
      get
      {
        if (Module.isOn)
          return "ON";
        return "OFF";
      }
    }

    private ModuleLight Module
    {
      get { return (ModuleLight) LightModule; }
    }

    internal void TurnOnLight()
    {
      Module.LightsOn();
    }

    internal void TurnOffLight()
    {
      Module.LightsOff();
    }
  }
}
