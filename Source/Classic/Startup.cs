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
using KSPe.Annotations;

namespace ShipManifest.Classic
{
	public class Startup
	{
		[UsedImplicitly]
		private void Start()
		{
			Log.force("Support for KSP 1.3.0 to 1.7.0 Version {0}", Version.Text);
		}
	}
}
