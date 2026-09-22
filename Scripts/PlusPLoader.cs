using BepInEx;
using System.IO;
using Receiver2;
using Receiver2ModdingKit;
using UnityEngine;
using Receiver2ModdingKit.CustomRounds;

namespace PlusPRound
{
	[BepInDependency("pl.szikaka.receiver_2_modding_kit", BepInDependency.DependencyFlags.HardDependency)]
	[BepInPlugin(k_GUID, k_PluginName, k_Version)]
	public class PlusPLoader : BaseUnityPlugin
	{
		const string k_GUID = "CiarenceW.PlusPRounds";
		const string k_PluginName = "+P Rounds";
		const string k_Version = "1.0.0";

		internal const CartridgeSpec.Preset k_45_acp_plus_p = (CartridgeSpec.Preset)(-(int)CartridgeSpec.Preset._45_acp);
		internal const CartridgeSpec.Preset k_45_acp_competition = k_45_acp_plus_p - 100_000;
		internal const CartridgeSpec.Preset k_50_ae_plus_p = (CartridgeSpec.Preset)(-(int)CartridgeSpec.Preset._50_AE);
		internal const CartridgeSpec.Preset k_50_ae_competition = k_50_ae_plus_p - 100_000;
		internal const CartridgeSpec.Preset k_45_lc_plus_p = (CartridgeSpec.Preset)(-(int)CartridgeSpec.Preset._45_LC);
		internal const CartridgeSpec.Preset k_9mm_competition = (CartridgeSpec.Preset)(-(int)CartridgeSpec.Preset._9mm_plus_p);

		internal static PlusPAssets assets;

		void Awake()
		{
			Logger.LogInfo($"Loaded {k_PluginName} version {k_Version}");

			ModdingKitEvents.AddTaskAtCoreStartup(InitialisePrefabs);

			PlusPSettingsManager.InitialiseConfig(Config);

			LoreManager.Initialise();
		}

		void InitialisePrefabs()
		{
			if (Receiver2ModdingKit.Helpers.AssetHelper.FindAssetBundle(Path.GetDirectoryName(Info.Location), out assets))
			{
				DuplicatePrefab(CartridgeSpec.Preset._9mm, CartridgeSpec.Preset._9mm_plus_p, assets._9mm_plus_p_tex, assets._9mm_casing_plus_p_tex, assets._9mm_tracer_plus_p_tex, "9mm_plus_p_round_prefab", null);

				CustomRoundTypes.RegisterCustomRound(assets._9mm_plus_p_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._38_special, CartridgeSpec.Preset._38_special_FBI_load, assets._9mm_plus_p_tex, assets._9mm_casing_plus_p_tex, assets._9mm_tracer_plus_p_tex, "38_special_plus_p_round_object", null);

				CustomRoundTypes.RegisterCustomRound(assets._38_special_plus_p_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._45_acp, k_45_acp_plus_p, assets._45_acp_plus_p_tex, assets._45_acp_case_plus_p_tex, assets._45_acp_tracer_plus_p_tex, "45_acp_plus_p_round_object", new CartridgeSpec()
				{
					extra_mass = 6f,
					mass = 16.52f,
					speed = 282f,
					diameter = 0.0115f,
					density = 11340f,
					cylinder_length = (16.52f / 1000f / 11340f) / (Mathf.PI * Mathf.Pow((0.0115f * 0.5f), 2)),
				});

				CustomRoundTypes.RegisterCustomRound(assets._45_acp_plus_p_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._45_LC, k_45_lc_plus_p, assets._45_lc_plus_p_tex, assets._45_lc_case_plus_p_tex, assets._45_acp_tracer_plus_p_tex, "45_lc_plus_p_round_object", new CartridgeSpec()
				{
					//this is real, fucking "330 Grain +P Bear Defense"
					extra_mass = 8f,
					mass = 21.38f,
					speed = 413f,
					diameter = 0.0115f,
					density = 11340f,
					cylinder_length = (21.38f / 1000f / 11340f) / (Mathf.PI * Mathf.Pow((0.0115f * 0.5f), 2)),
				});

				CustomRoundTypes.RegisterCustomRound(assets._45_lc_plus_p_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._50_AE, k_50_ae_plus_p, assets._45_acp_plus_p_tex, assets._45_acp_case_plus_p_tex, assets._45_acp_tracer_plus_p_tex, "50_ae_plus_p_round_object", new CartridgeSpec()
				{
					extra_mass = 24f,
					mass = 24.62f,
					speed = 550f,
					diameter = 0.013f,
					density = 11340f,
					cylinder_length = (24.62f / 1000f / 11340f) / (Mathf.PI * Mathf.Pow((0.013f * 0.5f), 2)),
				});

				CustomRoundTypes.RegisterCustomRound(assets._50_ae_plus_p_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._9mm, k_9mm_competition, assets._9mm_comp_tex, assets._9mm_comp_case_tex, assets._9mm_comp_tracer_tex, "9mm_competition_round_prefab", new CartridgeSpec()
				{
					extra_mass = 4.2f,
					mass = 3.239f,
					speed = 304.8f,
					diameter = 0.00901f,
					density = 11340f,
					cylinder_length = (3.239f / 1000f / 11340f) / (Mathf.PI * Mathf.Pow((0.00901f * 0.5f), 2)),
				});

				CustomRoundTypes.RegisterCustomRound(assets._9mm_competition_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._50_AE, k_50_ae_competition, assets._45_acp_comp_tex, assets._45_acp_comp_case_tex, assets._45_acp_comp_tracer_tex, "50_ae_competition_round_object", new CartridgeSpec()
				{
					extra_mass = 24f,
					mass = 17.8f,
					speed = 396.24f,
					diameter = 0.013f,
					density = 11340f,
					cylinder_length = (17.8f / 1000f / 11340f) / (Mathf.PI * Mathf.Pow((0.013f * 0.5f), 2)),
				});

				CustomRoundTypes.RegisterCustomRound(assets._50_ae_competition_round_def);

				DuplicatePrefab(CartridgeSpec.Preset._45_acp, k_45_acp_competition, assets._45_acp_comp_tex, assets._45_acp_comp_case_tex, assets._45_acp_comp_tracer_tex, "45_acp_competition_round_object", new CartridgeSpec()
				{
					extra_mass = 6f,
					mass = 11.98f,
					speed = 228.6f,
					diameter = 0.0115f,
					density = 11340f,
					cylinder_length = (11.98f / 1000f / 11340f) / (Mathf.PI * Mathf.Pow((0.0115f * 0.5f), 2)),
				});

				CustomRoundTypes.RegisterCustomRound(assets._45_acp_competition_round_def);

				ModHelpEntryManager.entries.Add(assets.plus_p_rounds_entry.name, assets.plus_p_rounds_entry);

				ModHelpEntryManager.entries.Add(assets.competition_rounds_entry.name, assets.competition_rounds_entry);

				LoreManager.SetupTapes();
			}
			else
			{
				Logger.LogError("Failed to find PlusPAssets assetbundle!!");
			}
		}

		static void DuplicatePrefab(CartridgeSpec.Preset original, CartridgeSpec.Preset cartridge_type, Texture2D roundTex, Texture2D casingTex, Texture2D tracerTex, string newInternalName, CartridgeSpec? cartridgeSpec = null)
		{
			var prefab = ModdingKitCorePlugin.GetRoundPrefab(original);

			var plus_p_prefab = Instantiate(prefab, Vector3.one * float.NaN, Quaternion.identity);

			plus_p_prefab.SetInternalName("ciarencew." + newInternalName);
			plus_p_prefab.cartridge_type = cartridge_type;
			plus_p_prefab.name = newInternalName;


			plus_p_prefab.go_round.sharedMaterial = new Material(plus_p_prefab.go_round.sharedMaterial)
			{
				mainTexture = roundTex
			};

			plus_p_prefab.go_casing.sharedMaterial = new Material(plus_p_prefab.go_casing.sharedMaterial)
			{
				mainTexture = casingTex
			};

			plus_p_prefab.tracer_model.sharedMaterial = new Material(plus_p_prefab.tracer_model.sharedMaterial)
			{
				mainTexture = tracerTex
			};

			if (cartridgeSpec != null) {
				ModdingKitCorePlugin.AddNewCartridgePreset(cartridge_type, cartridgeSpec.Value);
			}

			ModdingKitCorePlugin.AddShellCasingScriptPrefab(plus_p_prefab);
		}
	}
}
