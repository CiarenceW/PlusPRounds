using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Receiver2;
using UnityEngine;

namespace PlusPRound
{
	public static class PlusPSettingsManager
	{
		static ConfigEntry<bool> EnableInClassicMode { get; set; }

		internal static void InitialiseConfig(ConfigFile config)
		{
			EnableInClassicMode = config.Bind("General", "enableInClassicMode", true, "Whether or not to spawn the rounds in Classic mode.");

			ReceiverEvents.StartListening(ReceiverEventTypeVoid.PlayerFadeInStart, OnPlayerFadeIn);
		}
		
		static void OnPlayerFadeIn(ReceiverEventTypeVoid _)
		{
			Debug.Log(ReceiverCoreScript.Instance().game_mode.GetGameMode());

			var assets = PlusPLoader.assets;

			if (!EnableInClassicMode.Value && ReceiverCoreScript.Instance().game_mode.GetGameMode() == GameMode.Classic)
			{
				assets._9mm_competition_round_def.spawn_chance = 0;
				assets._9mm_plus_p_round_def.spawn_chance = 0;
				assets._45_acp_competition_round_def.spawn_chance = 0;
				assets._45_acp_plus_p_round_def.spawn_chance = 0;
				assets._45_lc_plus_p_round_def.spawn_chance = 0;
				assets._38_special_plus_p_round_def.spawn_chance = 0;
				assets._50_ae_competition_round_def.spawn_chance = 0;
				assets._50_ae_plus_p_round_def.spawn_chance = 0;
			}
			else
			{
				if (assets._9mm_competition_round_def.spawn_chance == 0)
				{
					assets._9mm_competition_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._9mm_plus_p_round_def.spawn_chance == 0)
				{
					assets._9mm_plus_p_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._45_acp_competition_round_def.spawn_chance == 0)
				{
					assets._45_acp_competition_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._45_acp_plus_p_round_def.spawn_chance == 0)
				{
					assets._45_acp_plus_p_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._45_lc_plus_p_round_def.spawn_chance == 0)
				{
					assets._45_lc_plus_p_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._38_special_plus_p_round_def.spawn_chance == 0)
				{
					assets._38_special_plus_p_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._50_ae_competition_round_def.spawn_chance == 0)
				{
					assets._50_ae_competition_round_def.spawn_chance = 0.25f;
				}
				
				if (assets._50_ae_plus_p_round_def.spawn_chance == 0)
				{
					assets._50_ae_plus_p_round_def.spawn_chance = 0.25f;
				}
			}
		}
	}
}