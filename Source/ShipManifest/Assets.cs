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
using System;
using UnityEngine;

using Asset = KSPe.IO.Asset<ShipManifest.Startup>;
using IO = KSPe.IO.File<ShipManifest.Startup>.Asset;

namespace ShipManifest
{
	internal static class Assets
	{
		internal static class Textures
		{
			private static Texture2D _IconOff_128 = null;
			internal static Texture2D IconOff_128 => _IconOff_128 ?? ( _IconOff_128 = Asset.Texture2D.LoadFromFile("Textures", "IconOff_128") );
			private static Texture2D _IconOn_128 = null;
			internal static Texture2D IconOn_128 => _IconOn_128 ?? ( _IconOn_128 = Asset.Texture2D.LoadFromFile("Textures", "IconOn_128") );

			private static Texture2D _IconOff_24 = null;
			internal static Texture2D IconOff_24 => _IconOff_24 ?? ( _IconOff_24 = Asset.Texture2D.LoadFromFile("Textures", "IconOff_24") );
			private static Texture2D _IconOn_24 = null;
			internal static Texture2D IconOn_24 => _IconOn_24 ?? ( _IconOn_24 = Asset.Texture2D.LoadFromFile("Textures", "IconOn_24") );

			private static Texture2D _IconOff_38 = null;
			internal static Texture2D IconOff_38 => _IconOff_38 ?? ( _IconOff_38 = Asset.Texture2D.LoadFromFile("Textures", "IconOff_38") );
			private static Texture2D _IconOn_38 = null;
			internal static Texture2D IconOn_38 => _IconOn_38 ?? ( _IconOn_38 = Asset.Texture2D.LoadFromFile("Textures", "IconOn_38") );

			private static Texture2D _IconR_Off_128 = null;
			internal static Texture2D IconR_Off_128 => _IconR_Off_128 ?? ( _IconR_Off_128 = Asset.Texture2D.LoadFromFile("Textures", "IconR_Off_128") );
			private static Texture2D _IconR_On_128 = null;
			internal static Texture2D IconR_On_128 => _IconR_On_128 ?? ( _IconR_On_128 = Asset.Texture2D.LoadFromFile("Textures", "IconR_On_128") );

			private static Texture2D _IconR_Off_24 = null;
			internal static Texture2D IconR_Off_24 => _IconR_Off_24 ?? ( _IconR_Off_24 = Asset.Texture2D.LoadFromFile("Textures", "IconOff_24") );
			private static Texture2D _IconR_On_24 = null;
			internal static Texture2D IconR_On_24 => _IconR_On_24 ?? ( _IconR_On_24 = Asset.Texture2D.LoadFromFile("Textures", "IconOn_24") );

			private static Texture2D _IconR_Off_38 = null;
			internal static Texture2D IconR_Off_38 => _IconR_Off_38 ?? ( _IconR_Off_38 = Asset.Texture2D.LoadFromFile("Textures", "IconR_Off_38") );
			private static Texture2D _IconR_On_38 = null;
			internal static Texture2D IconR_On_38 => _IconR_On_38 ?? ( _IconR_On_38 = Asset.Texture2D.LoadFromFile("Textures", "IconR_On_38") );

			private static Texture2D _IconS_Off_128 = null;
			internal static Texture2D IconS_Off_128 => _IconS_Off_128 ?? ( _IconS_Off_128 = Asset.Texture2D.LoadFromFile("Textures", "IconS_Off_128") );
			private static Texture2D _IconS_On_128 = null;
			internal static Texture2D IconS_On_128 => _IconS_On_128 ?? ( _IconS_On_128 = Asset.Texture2D.LoadFromFile("Textures", "IconS_On_128") );

			private static Texture2D _IconS_Off_24 = null;
			internal static Texture2D IconS_Off_24 => _IconS_Off_24 ?? ( _IconS_Off_24 = Asset.Texture2D.LoadFromFile("Textures", "IconS_Off_24") );
			private static Texture2D _IconS_On_24 = null;
			internal static Texture2D IconS_On_24 => _IconS_On_24 ?? ( _IconS_On_24 = Asset.Texture2D.LoadFromFile("Textures", "IconS_On_24") );

			private static Texture2D _IconS_Off_38 = null;
			internal static Texture2D IconS_Off_38 => _IconS_Off_38 ?? ( _IconS_Off_38 = Asset.Texture2D.LoadFromFile("Textures", "IconS_Off_38") );
			private static Texture2D _IconS_On_38 = null;
			internal static Texture2D IconS_On_38 => _IconS_On_38 ?? ( _IconS_On_38 = Asset.Texture2D.LoadFromFile("Textures", "IconS_On_38") );
		}
	}
}
