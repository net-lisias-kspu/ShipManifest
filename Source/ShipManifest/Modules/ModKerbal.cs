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
    public interface ModKerbal
    {
      string Name    { get; set; }
      bool Badass    { get; set; }
      bool Veteran   { get; set; }
      float Courage  { get; set; }
      float Stupidity { get; set; }
      string Trait   { get; set; }

      bool IsNew { get; set; }
      ProtoCrewMember.Gender Gender { get; set; }
      ProtoCrewMember Kerbal { get; set; }

      string SubmitChanges();
    }
}
