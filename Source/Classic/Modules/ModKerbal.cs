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
  public partial class ModKerbalRealization : ModKerbal
  {
    public string Name    { get; set; }
    public bool Badass    { get; set; }
    public bool Veteran   { get; set; }
    public float Courage  { get; set; }
    public float Stupidity { get; set; }
    public string Trait   { get; set; }

    public bool IsNew { get; set; }
    public ProtoCrewMember.Gender Gender { get; set; }
    public ProtoCrewMember Kerbal { get; set; }

    internal static ModKerbal Create(ProtoCrewMember kerbal, bool isNew)
    {
      return new ModKerbalRealization(kerbal, isNew);
    }

    public string SubmitChanges()
    {
      if (NameExists())
      {
        return SmUtils.SmTags["#smloc_module_002"]; // "That name is in use!";
      }

      SyncKerbal();

      if (IsNew)
      {
        // Add to roster.
        Kerbal.rosterStatus = ProtoCrewMember.RosterStatus.Available;
        HighLogic.CurrentGame.CrewRoster.AddCrewMember(Kerbal);
      }
      return string.Empty;
    }

    public static ModKerbal CreateKerbal(ProtoCrewMember.KerbalType kerbalType)
    {
      ProtoCrewMember kerbal = CrewGenerator.RandomCrewMemberPrototype(kerbalType);
      return new ModKerbalRealization(kerbal, true);
    }

    private bool NameExists()
    {
      if (IsNew || Kerbal.name != Name)
      {
        return HighLogic.CurrentGame.CrewRoster.Exists(Name);
      }

      return false;
    }
  }
}
