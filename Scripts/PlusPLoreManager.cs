using Receiver2;
using HarmonyLib;
using Receiver2ModdingKit;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace PlusPRound
{
	public static class LoreManager
	{
		static Harmony harmony;

		static readonly string bear_load_subtitles = 
@"1
00:00:00,000 --> 00:00:03,342
When in the American wilderness,
it is advised for campers and hikers

2
00:00:03,342 --> 00:00:06,480
to be on the lookout for bears,
to learn bear safety techniques,

3
00:00:06,480 --> 00:00:08,438
and to carry bear spray at all times,

4
00:00:08,964 --> 00:00:11,722
in order to dissuade any would-be killer bears.

5
00:00:12,468 --> 00:00:15,337
But what if you were a cowboy 
riding through the open prairie

6
00:00:15,337 --> 00:00:19,285
and happened to be charged upon 
by a vicious, hungry grizzly bear?

7
00:00:19,553 --> 00:00:23,003
Fortunately for you, American ammunition 
manufacturers have considered this

8
00:00:23,003 --> 00:00:26,004
exact seemingly recurring problem before,

9
00:00:26,004 --> 00:00:29,281
and they've come up with the 
second best bear repellent there is:

10
00:00:29,281 --> 00:00:32,332
the .45 Long Colt Bear Load.

11
00:00:32,332 --> 00:00:36,222
Not only is the bullet twice as fast, 
it's also twice as heavy as

12
00:00:36,222 --> 00:00:39,246
the standard .45 Long Colt ""Cowboy Load"",

13
00:00:39,246 --> 00:00:41,436
making it approximately 4 to 5 times

14
00:00:41,436 --> 00:00:43,920
more effective at taking down game;

15
00:00:43,920 --> 00:00:46,451
enabling you to take down 
a single grizzly bear,

16
00:00:46,451 --> 00:00:49,324
or four to five cowboys 
if they stand in a line.";

		static readonly string fbi_load_subtitle = 
@"1
00:00:00,000 --> 00:00:03,092
In the 1950's and 60's, 
postwar America faced an

2
00:00:03,092 --> 00:00:06,068
increased number of 
violent crimes and armed confrontations

3
00:00:06,068 --> 00:00:08,428
between gangsters and police officers.

4
00:00:08,840 --> 00:00:12,638
Contemporary policemen were mainly 
firing sidearms chambered in .38 Special,

5
00:00:12,638 --> 00:00:17,318
with the standard load being a 
158-grain lead round-nose bullet,

6
00:00:17,361 --> 00:00:20,544
which had the.. annoying tendency 
to go through whatever

7
00:00:20,544 --> 00:00:21,431
or whoever

8
00:00:21,431 --> 00:00:24,035
it was fired at, and 
continue on through whatever

9
00:00:24,035 --> 00:00:25,062
or whoever

10
00:00:25,062 --> 00:00:27,422
happened to be standing 
behind, all the while

11
00:00:27,422 --> 00:00:30,433
failing to actually stop 
the intended target.

12
00:00:31,172 --> 00:00:34,002
Despite making numerous complaints, 
cries of police unions

13
00:00:34,002 --> 00:00:36,969
went largely unanswered, 
with a few agencies attempting to

14
00:00:36,969 --> 00:00:40,460
introduce new .38 Special loads 
to combat this problem,

15
00:00:40,460 --> 00:00:43,643
such as the 
200-grain blunt-nosed ""Super Police"" load,

16
00:00:43,643 --> 00:00:46,449
which faced the.. opposite problem.

17
00:00:47,073 --> 00:00:50,866
Sure, the bullet would cause 
Massive Internal Damage to whoever it hit,

18
00:00:50,866 --> 00:00:54,423
but bullets that missed had the 
annoying tendency to ricochet and

19
00:00:54,423 --> 00:00:58,071
hit whatever or whoever happened 
to be standing nearby.

20
00:00:59,042 --> 00:01:02,580
In 1972, the Federal Bureau of Investigation unveiled

21
00:01:02,580 --> 00:01:06,999
their new standard issue +P load, 
later dubbed the ""FBI Load"".

22
00:01:07,460 --> 00:01:11,260
This load contained more, 
and, more powerful gunpowder, as well as

23
00:01:11,260 --> 00:01:16,250
a 158-grain unjacketed all-lead 
semi-wadcutter hollow-point bullet.

24
00:01:17,213 --> 00:01:20,843
These improvements, when fired from 
a standard law enforcement revolver,

25
00:01:20,843 --> 00:01:24,444
allowed the .38 Special cartridge 
to effectively and consistently

26
00:01:24,444 --> 00:01:27,204
take down whatever or whoever 
it was fired at.

27
00:01:28,198 --> 00:01:32,510
This load was very quickly adopted by 
practically all American police departments,

28
00:01:32,510 --> 00:01:37,563
and remained the primary round in use 
by the FBI until the mid 1980's,

29
00:01:37,563 --> 00:01:41,134
when a slew of tragic and deadly 
shootouts proved the need to switch

30
00:01:41,134 --> 00:01:44,009
to higher capacity semi-automatic handguns.";

		static readonly string plus_p_load_subtitle = 
@"1
00:00:00,000 --> 00:00:04,224
The power of a round is determined by 
the mass and the velocity of its bullet,

2
00:00:04,224 --> 00:00:06,362
if you want your shots 
to hit with more force,

3
00:00:06,362 --> 00:00:10,283
you either need to upgrade to a 
bigger caliber, or switch to +P loads.

4
00:00:11,017 --> 00:00:15,980
Overpressure, or +P rounds, are rounds 
loaded with a higher concentration of gunpowder,

5
00:00:15,980 --> 00:00:18,920
which gives the fired 
bullet increased stopping power,

6
00:00:18,920 --> 00:00:22,855
basically guaranteeing that whatever 
you shoot down, will stay down

7
00:00:22,855 --> 00:00:25,579
at least long enough for you 
to safely neutralize your target.

8
00:00:26,457 --> 00:00:29,349
Advantages rarely come without disadvantages however,

9
00:00:29,349 --> 00:00:31,481
and +P rounds are no exception.

10
00:00:32,003 --> 00:00:33,948
If you're a novice shooter, 
the brighter flash and

11
00:00:33,948 --> 00:00:38,404
increased recoil might take you by 
surprise and cause you to flinch,

12
00:00:38,404 --> 00:00:40,963
or the added stress to the firearm's mechanics

13
00:00:40,963 --> 00:00:43,334
might prevent the gun from cycling properly,

14
00:00:43,334 --> 00:00:46,557
or the casing might expand too much 
and get stuck in the chamber,

15
00:00:46,557 --> 00:00:48,027
making it harder to extract.";

		internal static void Initialise()
		{
			harmony = Harmony.CreateAndPatchAll(typeof(LoreManager));
		}

		internal static void SetupTapes()
		{
			var plus_p_tape = PlusPLoader.assets.plus_p_tape;
			var fbi_load_tape = PlusPLoader.assets.fbi_load_tape;
			var bear_load_tape = PlusPLoader.assets.bear_load_tape;

			var picked_up_tapes = ReceiverCoreScript.Instance().PlayerData.picked_up_tape_ids_string;

			if (picked_up_tapes.Contains(plus_p_tape.tape_id_string))
			{
				plus_p_tape.tape_group_priority = int.MaxValue;
			}

			if (picked_up_tapes.Contains(bear_load_tape.tape_id_string))
			{
				bear_load_tape.tape_group_priority = int.MaxValue;
			}

			if (picked_up_tapes.Contains(fbi_load_tape.tape_id_string))
			{
				fbi_load_tape.tape_group_priority = int.MaxValue;
			}

			var mod_tapes = ReceiverCoreScript.Instance().tape_loadout_asset.GetModTapes();
			
			mod_tapes.Add(plus_p_tape);
			mod_tapes.Add(fbi_load_tape);
			mod_tapes.Add(bear_load_tape);

			var tape_prefabs_all = typeof(TapeManager).GetField("tape_prefabs_all", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as List<GameObject>;

			tape_prefabs_all.Add(plus_p_tape.gameObject);
			tape_prefabs_all.Add(fbi_load_tape.gameObject);
			tape_prefabs_all.Add(bear_load_tape.gameObject);

			var tape_id_dict = typeof(TapeManager).GetField("tape_id_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, TapeContent>;

			tape_id_dict.Add(plus_p_tape.tape_id_string, plus_p_tape);
			tape_id_dict.Add(fbi_load_tape.tape_id_string, fbi_load_tape);
			tape_id_dict.Add(bear_load_tape.tape_id_string, bear_load_tape);

			var tape_enum_id_dict = typeof(TapeManager).GetField("tape_enum_id_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, TapeContent>;

			tape_enum_id_dict.Add(plus_p_tape.tape_id, plus_p_tape);
			tape_enum_id_dict.Add(fbi_load_tape.tape_id, fbi_load_tape);
			tape_enum_id_dict.Add(bear_load_tape.tape_id, bear_load_tape);

			var tape_id_string_dict = typeof(TapeManager).GetField("tape_string_id_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, TapeContent>;

			tape_id_string_dict.Add(plus_p_tape.tape_id_string, plus_p_tape);
			tape_id_string_dict.Add(fbi_load_tape.tape_id_string, fbi_load_tape);
			tape_id_string_dict.Add(bear_load_tape.tape_id_string, bear_load_tape);

			var tape_priority_string_dict = typeof(TapeManager).GetField("tape_priority_string_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, int>;

			tape_priority_string_dict.Add(plus_p_tape.tape_id_string, plus_p_tape.tape_group_priority);
			tape_priority_string_dict.Add(fbi_load_tape.tape_id_string, fbi_load_tape.tape_group_priority);
			tape_priority_string_dict.Add(bear_load_tape.tape_id_string, bear_load_tape.tape_group_priority);

			var tape_priority_dict = typeof(TapeManager).GetField("tape_priority_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, int>;

			tape_priority_dict.Add(plus_p_tape.tape_id, plus_p_tape.tape_group_priority);
			tape_priority_dict.Add(fbi_load_tape.tape_id, fbi_load_tape.tape_group_priority);
			tape_priority_dict.Add(bear_load_tape.tape_id, bear_load_tape.tape_group_priority);

			var tape_type_dict = typeof(TapeManager).GetField("tape_type_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, TapeType>;

			tape_type_dict.Add(plus_p_tape.tape_id, plus_p_tape.tape_type);
			tape_type_dict.Add(fbi_load_tape.tape_id, fbi_load_tape.tape_type);
			tape_type_dict.Add(bear_load_tape.tape_id, bear_load_tape.tape_type);

			var tape_type_string_dict = typeof(TapeManager).GetField("tape_type_string_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, TapeType>;

			tape_type_string_dict.Add(plus_p_tape.tape_id_string, plus_p_tape.tape_type);
			tape_type_string_dict.Add(fbi_load_tape.tape_id_string, fbi_load_tape.tape_type);
			tape_type_string_dict.Add(bear_load_tape.tape_id_string, bear_load_tape.tape_type);

			var tape_group_dict = typeof(TapeManager).GetField("tape_group_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, TapeGroupID>;

			tape_group_dict.Add(plus_p_tape.tape_id, plus_p_tape.tape_group);
			tape_group_dict.Add(fbi_load_tape.tape_id, fbi_load_tape.tape_group);
			tape_group_dict.Add(bear_load_tape.tape_id, bear_load_tape.tape_group);

			var tape_group_string_dict = typeof(TapeManager).GetField("tape_group_string_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, TapeGroupID>;

			tape_group_string_dict.Add(plus_p_tape.tape_id_string, plus_p_tape.tape_group);
			tape_group_string_dict.Add(fbi_load_tape.tape_id_string, fbi_load_tape.tape_group);
			tape_group_string_dict.Add(bear_load_tape.tape_id_string, bear_load_tape.tape_group);

			foreach (var group in typeof(TapeManager).GetField("tape_group_prefabs_all", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as List<TapeManager.TapeGroupList>)
			{
				if (group.group == plus_p_tape.tape_group)
				{
					group.tapes_string.Add(plus_p_tape.tape_id_string);
				}
				else if (group.group == bear_load_tape.tape_group)
				{
					group.tapes_string.Add(bear_load_tape.tape_id_string);
				}
				else if (group.group == fbi_load_tape.tape_group)
				{
					group.tapes_string.Add(fbi_load_tape.tape_id_string);
				}
			}

			var current_location = typeof(PlusPLoader).Assembly.Location;

			plus_p_tape.audio_file_path = Path.Combine(Path.GetDirectoryName(current_location), plus_p_tape.audio_file_path);
			fbi_load_tape.audio_file_path = Path.Combine(Path.GetDirectoryName(current_location), fbi_load_tape.audio_file_path);
			bear_load_tape.audio_file_path = Path.Combine(Path.GetDirectoryName(current_location), bear_load_tape.audio_file_path);

			ReceiverEvents.StartListening(ReceiverEventTypeVoid.LocaleChange, SetupLocales);

			ReceiverEvents.StartListening(ReceiverEventTypeStr.ConsumedTape, OnConsumeTape);

			SetupLocales(0);
		}

		static void OnConsumeTape(ReceiverEventTypeStr _, string id)
		{
			var plus_p_tape = PlusPLoader.assets.plus_p_tape;
			var fbi_load_tape = PlusPLoader.assets.fbi_load_tape;
			var bear_load_tape = PlusPLoader.assets.bear_load_tape;

			//the tapes are in the Standard Tape Group, it's kinda uncommon, but if it gets rolled
			//those tapes should have priority over others in the group, until they get listened to by the player
			//that way, the player has a guaranteed chance to find these somewhat quickly
			//but when they've been "unlocked", they don't clog up the other tapes in the group
			if (id == plus_p_tape.tape_id_string)
			{
				plus_p_tape.tape_group_priority = int.MaxValue;

				var tape_priority_string_dict = typeof(TapeManager).GetField("tape_priority_string_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, int>;

				var tape_priority_dict = typeof(TapeManager).GetField("tape_priority_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, int>;

				tape_priority_string_dict[plus_p_tape.tape_id_string] = plus_p_tape.tape_group_priority;
				tape_priority_dict[plus_p_tape.tape_id] = plus_p_tape.tape_group_priority;
			}
			else if (id == fbi_load_tape.tape_id_string)
			{
				fbi_load_tape.tape_group_priority = int.MaxValue;

				var tape_priority_string_dict = typeof(TapeManager).GetField("tape_priority_string_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, int>;

				var tape_priority_dict = typeof(TapeManager).GetField("tape_priority_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, int>;

				tape_priority_string_dict[fbi_load_tape.tape_id_string] = fbi_load_tape.tape_group_priority;
				tape_priority_dict[fbi_load_tape.tape_id] = fbi_load_tape.tape_group_priority;
			}
			else if (id == bear_load_tape.tape_id_string)
			{
				bear_load_tape.tape_group_priority = int.MaxValue;

				var tape_priority_string_dict = typeof(TapeManager).GetField("tape_priority_string_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<string, int>;

				var tape_priority_dict = typeof(TapeManager).GetField("tape_priority_dict", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(ReceiverCoreScript.Instance().tape_loadout_asset) as Dictionary<TapeID, int>;
			
				tape_priority_string_dict[bear_load_tape.tape_id_string] = bear_load_tape.tape_group_priority;
				tape_priority_dict[bear_load_tape.tape_id] = bear_load_tape.tape_group_priority;
			}
		}

		static void SetupLocales(ReceiverEventTypeVoid _)
		{
			var current_locale_id = Locale.active_meta_locale.isoid;

			string plus_p_subtitle_path = Path.Combine(Application.streamingAssetsPath, "TapeSubtitles", current_locale_id, PlusPLoader.assets.plus_p_tape.tape_id_string + ".srt");
			string fbi_load_subtitle_path = Path.Combine(Application.streamingAssetsPath, "TapeSubtitles", current_locale_id, PlusPLoader.assets.fbi_load_tape.tape_id_string + ".srt");
			string bear_load_subtitle_path = Path.Combine(Application.streamingAssetsPath, "TapeSubtitles", current_locale_id, PlusPLoader.assets.bear_load_tape.tape_id_string + ".srt");

			using (var sm = File.CreateText(plus_p_subtitle_path))
			{
				sm.AutoFlush = false;
				sm.Write(plus_p_load_subtitle);
				sm.Flush();
				sm.Close();
			}

			using (var sm = File.CreateText(fbi_load_subtitle_path))
			{
				sm.AutoFlush = false;
				sm.WriteLine(fbi_load_subtitle);
				sm.Flush();
				sm.Close();
			}

			using (var sm = File.CreateText(bear_load_subtitle_path))
			{
				sm.AutoFlush = false;
				sm.WriteLine(bear_load_subtitles);
				sm.Flush();
				sm.Close();
			}

			var plus_p_tape = PlusPLoader.assets.plus_p_tape;
			var fbi_load_tape = PlusPLoader.assets.fbi_load_tape;
			var bear_load_tape = PlusPLoader.assets.bear_load_tape;

			LocaleTapeMenuEntry menu_entry;

			menu_entry = new LocaleTapeMenuEntry()
			{
				id_string = plus_p_tape.tape_id_string,
				description = plus_p_tape.text,
				name = "Invalid",
				title = plus_p_tape.title
			};

			Locale.active_locale_tape_menu_entries_string.Add(plus_p_tape.tape_id_string, menu_entry);

			menu_entry = new LocaleTapeMenuEntry()
			{
				id_string = bear_load_tape.tape_id_string,
				description = bear_load_tape.text,
				name = "Invalid",
				title = bear_load_tape.title
			};

			Locale.active_locale_tape_menu_entries_string.Add(bear_load_tape.tape_id_string, menu_entry);

			menu_entry = new LocaleTapeMenuEntry()
			{
				id_string = fbi_load_tape.tape_id_string,
				description = fbi_load_tape.text,
				name = "Invalid",
				title = fbi_load_tape.title
			};

			Locale.active_locale_tape_menu_entries_string.Add(fbi_load_tape.tape_id_string, menu_entry);
		}

		[HarmonyPatch(typeof(ShellCasingScript), nameof(ShellCasingScript.Consume))]
		[HarmonyPostfix]
		private static void OnShellPickedUp(ShellCasingScript __instance)
		{
			if (__instance.cartridge_type == CartridgeSpec.Preset._9mm_plus_p || __instance.cartridge_type == CartridgeSpec.Preset._38_special_FBI_load || __instance.cartridge_type == PlusPLoader.k_45_acp_plus_p || __instance.cartridge_type == PlusPLoader.k_45_lc_plus_p || __instance.cartridge_type == PlusPLoader.k_50_ae_plus_p)
			{
				HelpUnlockManager.Instance.Unlock(PlusPLoader.assets.plus_p_rounds_entry.name);
			}

			if (__instance.cartridge_type == PlusPLoader.k_9mm_competition || __instance.cartridge_type == PlusPLoader.k_45_acp_competition || __instance.cartridge_type == PlusPLoader.k_50_ae_competition)
			{
				HelpUnlockManager.Instance.Unlock(PlusPLoader.assets.competition_rounds_entry.name);
			}
		}
	}
}