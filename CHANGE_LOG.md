# ShipManifest :: Change Log

* 2015-0505: 4.2.0.1 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.2.0.1 - Release 04 May, 2015 - Transfers Expansion Edtion bug fixes.
		- Fixed:  When realism is off and override Stock crew Xfers is on, transfers cause a flickering portrait and do not complete.
		- Fixed:  In Roster, Gender is correctly displayed, but changing a Kerbal's Gender results in the opposite gender being saved.
* 2015-0504: 4.2.0.0 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.2.0.0 - Release 03 May, 2015 - Transfers Expansion Edtion. Multi-Resource & Multi-Part Xfers.
		- New: You can now "link" 2 resources together simply by clicking on a Second Resource.
		- New: You can now link multiple parts in the Transfer window, and move resources from 1:N, N:N and N:1 parts.
		- New: Added Kerbal Gender Management in Roster Window.
		- New: Added Revert profession renaming feature to Roster for removing the ascii "1"s from game save.  For mod compatibility.
		- New: Changed config file from xml to json style.  No more spamming the KSP debug log.
		- New: Cleaned up science transfers.  Target details now only shows container modules. No more transfer to an experiment module.
		- Fixed:  When  near debris, SM window sometimes fails to display when icon is clicked from either toolbar.
		- Fixed:  With CLS enabled, selected target part text displayed in Target Crew Color instead of Target Part color.
		- Fixed:  Opening/closing a hatch from the hatch control tab fails to update the CLS spaces.
		- Fixed:  When transferring science, Realism mode prevents moving science to a container in the same part.
		- Fixed:  Disabling Resources in Settings does not remove Resources from the selection list in the Manifest Window.
		- Fixed:  Portraits not properly updating after a crew move.  Bug introduced in 4.1.3 after revisions to actual crew move timing.
* 2015-0410: 4.1.4.4 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.1.4.4 - Release 10 Apr, 2015 - Bug fixes.
		- Fixed:  Crew transfers fail when Realism Mode is Off.
		- Fixed:  SM windows do not hide when the F2 key is toggled to hide UI.
		- Fixed:  SM window positions are not automatically saved between scenes.
		- Fixed:  Roster windows position incorrectly saving to settings window position.
		- Changed:  Altered Window Reposition behavior to be more intuitive.
			- Was:  Reset window to 0.0 when position exceeds the edge of the screen.
			- Now:  reposition window to edge of screen when position exceeds the edge of screen.
* 2015-0407: 4.1.4.3 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.1.4.3 - Release 06 Apr, 2015 - RT bug, External crew bug and control display fixes.
		- Fixed: When using RemoteTech, not all RemoteTech antennas would display in Control window list.
		- Fixed: Sometimes when displaying part info in Antennas, Solar Panels, hatches and Lights, a null exception would occur and "unknown" would be displayed in part parent info.
		- Fixed: Crew in external seats were not properly handled in SM. Attempts to transfer will generate unhanded errors, and could possibly corrupt the game save, requiring the vessel to be deleted.  Removed Crew members in external seats from xfer list.
* 2015-0329: 4.1.4.2 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.1.4.2 - Release 29 Mar, 2015 - Control Window Tweaks Edition.
		- New: Added part name to description for Antennas, Solar Panels, and Lights in Control Window.
		- Fixed: If CLS is not installed, or CLS is disabled, Control Button is grayed out and Manifest Window is stuck in one position on screen.
* 2015-0323: 0.90.0_4.1.4.1 (PapaJoesSoup) for KSP 0.90.0
	+ Version 0.90.0_4.1.4.1 - Release 22 Mar, 2015 - RT Antenna Integration Edition.
		- New:  Added Remote Tech (RT) Antenna control support.
		- Fixed:  Undeployable Solar panels incorrectly show up in Solar panel list and generate an unmanaged error when Extended or Retracted.
* 2015-0214: 0.90.0_4.0.2 (PapaJoesSoup) for KSP 0.90.0
	+ Version 0.90.0_4.0.2 - Release 13 Feb, 2015 - Bugs, Mod Refactoring and More Edition.
		- New:  Resource Transfer display and setup system refactored.  Added ability to stop a transfer in progress.
		- New:  Exposed Resource Transfer Flow Rate Slider min and max values. You can now change the min and max flow rate.
		- New:  Added a maximum run time in seconds. SM will use the lesser duration of Xfer amount / flow rate or max time.
		- New:  Added tool tips to  controls in the options section of the Settings Window.
		- Fixed:  When moving or transferring a kerbal, closing the transfer window, Manifest window or closing the manifest window from any toolbar while the action is in progress causes an error.
		- Fixed:  When closing the Transfer Window, internally resetting the selected resource causes an error.
* 2015-0115: 0.90.0_3.3.4 (PapaJoesSoup) for KSP 0.90.0
	+ Version 0.90.0_3.3.4 - 15 Jan, 2015 - Bugs, Mod Tweaks and More Edition.
		- New:  Added a Limited Highlighting switch.  When on, highlights only source and target parts.
			- Highlighting switch must be enabled to use.
		- New:  Added close buttons to upper right of most windows.  Cleaned up App launcher toggle button behavior, and synced with close buttons.
		- New:  Added detection for IVA. Hide Ship Manifest Window when in IVA.
		- New:  CLS highlightng returns.  Previous method replaced with new model. Livable parts only will be highlighted by SM.
			- To view passable parts, select the space from the CLS plugin menu.
		- Fixed:  Due to KSP 0.90.0 changes, when using Roster, changes to Kerbal names causes the role to change (bad).
				- Removed ability to edit name of existing Kerbals.
* 2014-1029: 0.25.0_3.3.2b (PapaJoesSoup) for KSP 0.24.0.
	+ Fix for disappearing Stock Toolbar.
* 2014-0928: 0.24.2_3.3.2 (PapaJoesSoup) for KSP 0.24.0.
	+ Version 0.24.2_3.3.2 - 28 Sep, 2014 - 0.24.2 and bug fixes edition
		- New:  Blizzy Toolbar is now optional.  If you install it, you can enable it.  Off by default.
		- New:  Removed auto enable of CLS.  CLS is now Off by default.  If CLS is installed, can be turned on in Settings.
		- New:  Bug fixes to correct crashing and errors on startup.
		- New:  Added Close button to Debug window.
		- New:  Revised Science transfer code to ensure compatibility with DMagic Parts (i hope).
		- Other Undocumented changes.  I was in the middle of other updates (bug fixes) when 0.24.2 hit.
* 2014-0718: 0.24.0.3.3.1 (PapaJoesSoup) for KSP 0.24.0.
	+ Version 0.24.0.3.3.1a - 28 Aug, 2014
		- Removed Toolbar from Distribution. No code changes.
	+ Version 0.24.0.3.3.1 - 17 Jul, 2014 - 0.24.0 Compatibility Edition.
		- New:  Now compatible with KSP 0.24.0. Squad reworked crew objects and namespace.
		- New:  Roster Window now shows vessel to which a kerbal is assigned.
		- New:  Add support for DMagic Science parts (IDataScienceContainer)
		- Bug:  SM Still doubling LS resource amounts.
			- http://forum.kerbalspaceprogram.com/threads/62270-0-23-5-Ship-Manifest-%28Crew-Science-Resources%29-v0-23-5-3-2-2-2-May-14?p=1136419&viewfull=1#post1136419
		- Known Issue:  SM & CLS Highlighting still problematic.
* 2014-0530: 0.23.5.3.3 (PapaJoesSoup) for KSP 0.23
	+ Version 0.23.5.3.3 - 29 May, 2014 - CLS is Optonal Edition.
		- New:  CLS is now a soft dependency.  if you install it, SM will configure for it's use.  If you do not install it, SM will automatically detect that and set Enable CLS Off.
* 2014-0227: 0.23.3.1.5 (PapaJoesSoup) for KSP 0.23
	+ Real time Crew transfers with sound.
	+ Resource transfer amount entry field.
	+ sounds and configs.
* 2014-0128: 0.23.3.0 (PapaJoesSoup) for KSP 0.23
	+ Add crew transfers.  Bug fixes and enhancements.
* 2014-0109: 0.23.2.0 (PapaJoesSoup) for KSP 0.23
	+ Ship Manifest takes Crew manifest's view of Crew and applies it to manage your ship's resources.
	+ Features:
		- Manifest Window. Select resource you want to manage
		- Setting Window. Configure Ship Manager. Changes sounds, realism mode, show/hide debugger
		- Transfer Window. Move resources between parts. In realism mode, initiates xfer pump, moves resource in real time, base on a configurable flow rate.
		- Debugger window. Troubleshoot issues with Ship Manifest.
