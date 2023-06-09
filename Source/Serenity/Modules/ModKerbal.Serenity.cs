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
  public partial class ModKerbalRealization
  {
    public ProtoCrewMember.KerbalSuit Suit;

    private ModKerbalRealization(ProtoCrewMember kerbal, bool isNew)
    {
      Kerbal = kerbal;
      Name = kerbal.name;
      Stupidity = kerbal.stupidity;
      Courage = kerbal.courage;
      Badass = kerbal.isBadass;
      Veteran = kerbal.veteran;
      Trait = kerbal.trait;
      Gender = kerbal.gender;
      Suit = kerbal.suit;
      IsNew = isNew;
    }

    public void SyncKerbal()
    {
      if (SMSettings.EnableKerbalRename)
      {
        Kerbal.ChangeName(Name);
        if (SMSettings.EnableChangeProfession)
          KerbalRoster.SetExperienceTrait(Kerbal, Trait);
      }
      Kerbal.gender = Gender;
      Kerbal.suit = Suit;
      Kerbal.stupidity = Stupidity;
      Kerbal.courage = Courage;
      Kerbal.isBadass = Badass;
      Kerbal.veteran = Veteran;
    }
  }
}
