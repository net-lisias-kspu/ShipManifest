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
namespace ShipManifest.InternalObjects
{
  internal static class SMPart
  {

    internal static bool IsSelected(Part part)
    {
      return SMAddon.SmVessel.SelectedResourcesParts.Contains(part);
    }

    internal static bool IsCrew(Part part)
    {
      return IsSelected(part) && SMAddon.SmVessel.SelectedResources.Contains(SMConditions.ResourceType.Crew.ToString());
    }

    internal static bool IsSource(Part part)
    {
      return SMAddon.SmVessel.SelectedPartsSource.Contains(part);
    }

    internal static bool IsTarget(Part part)
    {
      return SMAddon.SmVessel.SelectedPartsTarget.Contains(part);
    }

    internal static bool IsClsSource(Part part)
    {
      return SMAddon.SmVessel.ClsPartSource.Part == part;
    }

    internal static bool IsClsTarget(Part part)
    {
      return SMAddon.SmVessel.ClsPartTarget.Part == part;
    }

  }
}
