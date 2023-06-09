/*
	This file is part of Ship Manifest /L Unleashed
		© 2021-2023 LisiasT : http://lisias.net <support@lisias.net>

	Ship Manifest /L Unleashed is licensed as follows:
		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using UnityEngine;

namespace ShipManifest.MSG
{
	internal static class MissingDLLAlertBox
	{
		private static readonly string MSG = @"Unfortunately Ship Manifest /L didn't found needed DLLs.

There's no safe way to proceed, without the support DLLs Ship Manifest /L will not work properly!!

Missing Class: {0}";

		private static readonly string AMSG = @"reinstall Ship Manifest /L from a trusted Distribution Channel (KSP will close).";

		internal static void Show(string msg) {
			KSPe.Common.Dialogs.ShowStopperAlertBox.Show(
				string.Format(MSG, msg),
				AMSG,
				() => { Application.Quit(); }
			);
			Log.force("\"Houston, we have a Problem!\" about Missing DLLs was displayed");
		}
	}
}