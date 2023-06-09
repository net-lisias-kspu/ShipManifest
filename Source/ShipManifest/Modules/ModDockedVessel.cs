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
using System.Collections.Generic;
using System.Linq;

namespace ShipManifest.Modules
{
  internal class ModDockedVessel
  {
    private List<Part> _vesselParts;

    // used during display in control window for selecting vessels to combine
    internal bool Combine = false;

    private Part _rootPart;
    private Part _dockingPort;
    internal bool IsDocked;
    internal bool IsEditing = false;
    internal string RenameVessel = null;
    internal VesselType ReClassifyVessel;

    internal ModDockedVessel()
    {
    }

    internal ModDockedVessel(ModuleDockingNode dockingNode)
    {
      _dockingPort = dockingNode.part;
      VesselInfo = dockingNode.vesselInfo;
      _vesselParts = SMAddon.SmVessel.GetDockedVesselParts(dockingNode);
    }

    internal DockedVesselInfo VesselInfo { get; set; }

    internal Part Rootpart
    {
      get
      {
        return _rootPart ??
               (_rootPart =
                 (from p in SMAddon.SmVessel.Vessel.parts where p.flightID == VesselInfo.rootPartUId select p)
                   .SingleOrDefault());
      }
      set { _rootPart = value; }
    }

    internal uint LaunchId
    {
      get { return Rootpart != null ? Rootpart.launchID : 0; }
    }

    internal string VesselName
    {
      get { return VesselInfo.name; }
      set { VesselInfo.name = value; }
    }

    internal VesselType VesselClassification
    {
      get { return VesselInfo.vesselType; }
      set { VesselInfo.vesselType = value; }
    }

    internal List<Part> VesselParts
    {
      get { return _vesselParts; }
      set { _vesselParts = value; }
    }
  }
}
