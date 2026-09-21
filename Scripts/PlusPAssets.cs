using System;
using Receiver2;
using Receiver2ModdingKit;
using Receiver2ModdingKit.CustomRounds;
using Receiver2ModdingKit.Editor;
using UnityEngine;

namespace PlusPRound 
{
	public class PlusPAssets : MonoBehaviour, ISerializationCallbackReceiver
	{
		public ModHelpEntry plus_p_rounds_entry;

		public ModHelpEntry competition_rounds_entry;

		public Texture2D srab_tex;
		public Texture2D srab_comp_tex;

		public TapeContent plus_p_tape;
		public TapeContent fbi_load_tape;
		public TapeContent bear_load_tape;

		[SerializeField, HideInInspector] string _help_entry_name;
		[SerializeField, HideInInspector] Sprite _help_entry_info_sprite = null;
		[SerializeField, HideInInspector] string _help_entry_title;
		[SerializeField, HideInInspector] string _help_entry_description;

		[SerializeField, HideInInspector] string _competition_help_entry_name;
		[SerializeField, HideInInspector] Sprite _competition_help_entry_info_sprite = null;
		[SerializeField, HideInInspector] string _competition_help_entry_title;
		[SerializeField, HideInInspector] string _competition_help_entry_description;

		public Texture2D _9mm_plus_p_tex;
		public Texture2D _9mm_casing_plus_p_tex;
		public Texture2D _9mm_tracer_plus_p_tex;

		public CustomRoundDefinition _9mm_plus_p_round_def;

		public CustomRoundDefinition _38_special_plus_p_round_def;

		[SerializeField, HideInInspector] float _9mm_extra_rotation_x;
		[SerializeField, HideInInspector] float _9mm_extra_rotation_y;
		[SerializeField, HideInInspector] float _9mm_extra_recoil_x;
		[SerializeField, HideInInspector] float _9mm_extra_recoil_y;
		[SerializeField, HideInInspector] float _9mm_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _9mm_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _9mm_extra_ftf_chance;
		[SerializeField, HideInInspector] float _9mm_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _9mm_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _9mm_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _9mm_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _9mm_extra_wedged_amount;
		[SerializeField, HideInInspector] float _9mm_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _9mm_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _9mm_cartridge;
		[SerializeField, HideInInspector] string _9mm_clean_name;

		[SerializeField, HideInInspector] float _38_special_extra_rotation_x;
		[SerializeField, HideInInspector] float _38_special_extra_rotation_y;
		[SerializeField, HideInInspector] float _38_special_extra_recoil_x;
		[SerializeField, HideInInspector] float _38_special_extra_recoil_y;
		[SerializeField, HideInInspector] float _38_special_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _38_special_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _38_special_extra_ftf_chance;
		[SerializeField, HideInInspector] float _38_special_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _38_special_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _38_special_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _38_special_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _38_special_extra_wedged_amount;
		[SerializeField, HideInInspector] float _38_special_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _38_special_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _38_special_cartridge;
		[SerializeField, HideInInspector] string _38_special_clean_name;

		public Texture2D _45_acp_plus_p_tex;
		public Texture2D _45_acp_case_plus_p_tex;
		public Texture2D _45_acp_tracer_plus_p_tex;

		public Texture2D _45_lc_plus_p_tex;
		public Texture2D _45_lc_case_plus_p_tex;

		public CustomRoundDefinition _45_acp_plus_p_round_def;
		public CustomRoundDefinition _45_lc_plus_p_round_def;
		public CustomRoundDefinition _50_ae_plus_p_round_def;

		[SerializeField, HideInInspector] float _45_acp_extra_rotation_x;
		[SerializeField, HideInInspector] float _45_acp_extra_rotation_y;
		[SerializeField, HideInInspector] float _45_acp_extra_recoil_x;
		[SerializeField, HideInInspector] float _45_acp_extra_recoil_y;
		[SerializeField, HideInInspector] float _45_acp_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _45_acp_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _45_acp_extra_ftf_chance;
		[SerializeField, HideInInspector] float _45_acp_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _45_acp_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _45_acp_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _45_acp_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _45_acp_extra_wedged_amount;
		[SerializeField, HideInInspector] float _45_acp_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _45_acp_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _45_acp_cartridge;
		[SerializeField, HideInInspector] string _45_acp_clean_name;

		[SerializeField, HideInInspector] float _45_lc_extra_rotation_x;
		[SerializeField, HideInInspector] float _45_lc_extra_rotation_y;
		[SerializeField, HideInInspector] float _45_lc_extra_recoil_x;
		[SerializeField, HideInInspector] float _45_lc_extra_recoil_y;
		[SerializeField, HideInInspector] float _45_lc_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _45_lc_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _45_lc_extra_ftf_chance;
		[SerializeField, HideInInspector] float _45_lc_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _45_lc_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _45_lc_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _45_lc_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _45_lc_extra_wedged_amount;
		[SerializeField, HideInInspector] float _45_lc_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _45_lc_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _45_lc_cartridge;
		[SerializeField, HideInInspector] string _45_lc_clean_name;
		
		[SerializeField, HideInInspector] float _50_ae_extra_rotation_x;
		[SerializeField, HideInInspector] float _50_ae_extra_rotation_y;
		[SerializeField, HideInInspector] float _50_ae_extra_recoil_x;
		[SerializeField, HideInInspector] float _50_ae_extra_recoil_y;
		[SerializeField, HideInInspector] float _50_ae_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _50_ae_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _50_ae_extra_ftf_chance;
		[SerializeField, HideInInspector] float _50_ae_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _50_ae_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _50_ae_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _50_ae_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _50_ae_extra_wedged_amount;
		[SerializeField, HideInInspector] float _50_ae_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _50_ae_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _50_ae_cartridge;
		[SerializeField, HideInInspector] string _50_ae_clean_name;

		public CustomRoundDefinition _9mm_competition_round_def;

		[SerializeField, HideInInspector] float _9mm_comp_extra_rotation_x;
		[SerializeField, HideInInspector] float _9mm_comp_extra_rotation_y;
		[SerializeField, HideInInspector] float _9mm_comp_extra_recoil_x;
		[SerializeField, HideInInspector] float _9mm_comp_extra_recoil_y;
		[SerializeField, HideInInspector] float _9mm_comp_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _9mm_comp_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _9mm_comp_extra_ftf_chance;
		[SerializeField, HideInInspector] float _9mm_comp_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _9mm_comp_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _9mm_comp_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _9mm_comp_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _9mm_comp_extra_wedged_amount;
		[SerializeField, HideInInspector] float _9mm_comp_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _9mm_comp_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _9mm_comp_cartridge;
		[SerializeField, HideInInspector] string _9mm_comp_clean_name;

		public Texture2D _9mm_comp_tex;
		public Texture2D _9mm_comp_tracer_tex;
		public Texture2D _9mm_comp_case_tex;

		public CustomRoundDefinition _45_acp_competition_round_def;

		[SerializeField, HideInInspector] float _45_acp_comp_extra_rotation_x;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_rotation_y;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_recoil_x;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_recoil_y;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_ftf_chance;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _45_acp_comp_extra_wedged_amount;
		[SerializeField, HideInInspector] float _45_acp_comp_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _45_acp_comp_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _45_acp_comp_cartridge;
		[SerializeField, HideInInspector] string _45_acp_comp_clean_name;

		public Texture2D _45_acp_comp_tex;
		public Texture2D _45_acp_comp_tracer_tex;
		public Texture2D _45_acp_comp_case_tex;

		public CustomRoundDefinition _50_ae_competition_round_def;

		[SerializeField, HideInInspector] float _50_ae_comp_extra_rotation_x;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_rotation_y;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_recoil_x;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_recoil_y;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_stovepipe_chance;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_doublefeed_chance;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_ftf_chance;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_wrongly_seated_mag_chance;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_out_of_battery_chance;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_slamfire_chance;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_slide_fire_speed;
		[SerializeField, HideInInspector] float _50_ae_comp_extra_wedged_amount;
		[SerializeField, HideInInspector] float _50_ae_comp_spawn_chance;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _50_ae_comp_baseVariant;
		[SerializeField, HideInInspector] CartridgeSpec.Preset _50_ae_comp_cartridge;
		[SerializeField, HideInInspector] string _50_ae_comp_clean_name;

		public void OnAfterDeserialize()
		{
			if (plus_p_rounds_entry == null)
			{
				plus_p_rounds_entry = new ModHelpEntry(_help_entry_name)
				{
					title = _help_entry_title,
					description = _help_entry_description,
					info_sprite = _help_entry_info_sprite,
					menu_entry_category = MenuEntryCategories.Items,
					locked_default = true
				};
			}

			if (competition_rounds_entry == null)
			{
				competition_rounds_entry = new ModHelpEntry(_competition_help_entry_name)
				{
					title = _competition_help_entry_title,
					description = _competition_help_entry_description,
					info_sprite = _competition_help_entry_info_sprite,
					menu_entry_category = MenuEntryCategories.Items,
					locked_default = true
				};
			}

			if (_9mm_plus_p_round_def == null) 
			{
				_9mm_plus_p_round_def = new CustomRoundDefinition
				{
					extra_rotation_x = _9mm_extra_rotation_x,
					extra_rotation_y = _9mm_extra_rotation_y,
					extra_recoil_x = _9mm_extra_recoil_x,
					extra_recoil_y = _9mm_extra_recoil_y,
					extra_stovepipe_chance = _9mm_extra_stovepipe_chance,
					extra_doublefeed_chance = _9mm_extra_doublefeed_chance,
					extra_ftf_chance = _9mm_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _9mm_extra_wrongly_seated_mag_chance,
					extra_slide_fire_speed = _9mm_extra_slide_fire_speed,
					extra_out_of_battery_chance = _9mm_extra_out_of_battery_chance,
					extra_slamfire_chance = _9mm_extra_slamfire_chance,
					extra_wedged_amount = _9mm_extra_wedged_amount,
					spawn_chance = _9mm_spawn_chance,
					baseVariant = _9mm_baseVariant,
					cartridge = _9mm_cartridge,
					clean_name = _9mm_clean_name,
					shootingRangeAmmoBoxTexture = srab_tex
				};
			}

			if (_9mm_competition_round_def == null) 
			{
				_9mm_competition_round_def = new CustomRoundDefinition
				{
					extra_rotation_x = _9mm_comp_extra_rotation_x,
					extra_rotation_y = _9mm_comp_extra_rotation_y,
					extra_recoil_x = _9mm_comp_extra_recoil_x,
					extra_recoil_y = _9mm_comp_extra_recoil_y,
					extra_stovepipe_chance = _9mm_comp_extra_stovepipe_chance,
					extra_doublefeed_chance = _9mm_comp_extra_doublefeed_chance,
					extra_ftf_chance = _9mm_comp_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _9mm_comp_extra_wrongly_seated_mag_chance,
					extra_slide_fire_speed = _9mm_comp_extra_slide_fire_speed,
					extra_out_of_battery_chance = _9mm_comp_extra_out_of_battery_chance,
					extra_slamfire_chance = _9mm_comp_extra_slamfire_chance,
					extra_wedged_amount = _9mm_comp_extra_wedged_amount,
					spawn_chance = _9mm_comp_spawn_chance,
					baseVariant = _9mm_comp_baseVariant,
					cartridge = _9mm_comp_cartridge,
					clean_name = _9mm_comp_clean_name,
					shootingRangeAmmoBoxTexture = srab_comp_tex
				};
			}

			if (_38_special_plus_p_round_def == null) 
			{
				_38_special_plus_p_round_def = new CustomRoundDefinition
				{
					extra_rotation_x = _38_special_extra_rotation_x,
					extra_rotation_y = _38_special_extra_rotation_y,
					extra_recoil_x = _38_special_extra_recoil_x,
					extra_recoil_y = _38_special_extra_recoil_y,
					extra_stovepipe_chance = _38_special_extra_stovepipe_chance,
					extra_doublefeed_chance = _38_special_extra_doublefeed_chance,
					extra_ftf_chance = _38_special_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _38_special_extra_wrongly_seated_mag_chance,
					extra_out_of_battery_chance = _38_special_extra_out_of_battery_chance,
					extra_slamfire_chance = _38_special_extra_slamfire_chance,
					extra_slide_fire_speed = _38_special_extra_slide_fire_speed,
					extra_wedged_amount = _38_special_extra_wedged_amount,
					spawn_chance = _38_special_spawn_chance,
					baseVariant = _38_special_baseVariant,
					cartridge = _38_special_cartridge,
					clean_name = _38_special_clean_name,
					shootingRangeAmmoBoxTexture = srab_tex
				};
			}

			if (_45_acp_plus_p_round_def == null) 
			{
				_45_acp_plus_p_round_def = new CustomRoundDefinition
				{
					extra_rotation_x = _45_acp_extra_rotation_x,
					extra_rotation_y = _45_acp_extra_rotation_y,
					extra_recoil_x = _45_acp_extra_recoil_x,
					extra_recoil_y = _45_acp_extra_recoil_y,
					extra_stovepipe_chance = _45_acp_extra_stovepipe_chance,
					extra_doublefeed_chance = _45_acp_extra_doublefeed_chance,
					extra_ftf_chance = _45_acp_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _45_acp_extra_wrongly_seated_mag_chance,
					extra_out_of_battery_chance = _45_acp_extra_out_of_battery_chance,
					extra_slamfire_chance = _45_acp_extra_slamfire_chance,
					extra_slide_fire_speed = _45_acp_extra_slide_fire_speed,
					extra_wedged_amount = _45_acp_extra_wedged_amount,
					spawn_chance = _45_acp_spawn_chance,
					baseVariant = _45_acp_baseVariant,
					cartridge = _45_acp_cartridge,
					clean_name = _45_acp_clean_name,
					shootingRangeAmmoBoxTexture = srab_tex
				};
			}

			if (_45_acp_competition_round_def == null) 
			{
				_45_acp_competition_round_def = new CustomRoundDefinition
				{
					extra_rotation_x = _45_acp_comp_extra_rotation_x,
					extra_rotation_y = _45_acp_comp_extra_rotation_y,
					extra_recoil_x = _45_acp_comp_extra_recoil_x,
					extra_recoil_y = _45_acp_comp_extra_recoil_y,
					extra_stovepipe_chance = _45_acp_comp_extra_stovepipe_chance,
					extra_doublefeed_chance = _45_acp_comp_extra_doublefeed_chance,
					extra_ftf_chance = _45_acp_comp_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _45_acp_comp_extra_wrongly_seated_mag_chance,
					extra_out_of_battery_chance = _45_acp_comp_extra_out_of_battery_chance,
					extra_slamfire_chance = _45_acp_comp_extra_slamfire_chance,
					extra_slide_fire_speed = _45_acp_comp_extra_slide_fire_speed,
					extra_wedged_amount = _45_acp_comp_extra_wedged_amount,
					spawn_chance = _45_acp_comp_spawn_chance,
					baseVariant = _45_acp_comp_baseVariant,
					cartridge = _45_acp_comp_cartridge,
					clean_name = _45_acp_comp_clean_name,
					shootingRangeAmmoBoxTexture = srab_comp_tex
				};
			}

			if (_45_lc_plus_p_round_def == null) 
			{
				_45_lc_plus_p_round_def = new CustomRoundDefinition 
				{
					extra_rotation_x = _45_lc_extra_rotation_x,
					extra_rotation_y = _45_lc_extra_rotation_y,
					extra_recoil_x = _45_lc_extra_recoil_x,
					extra_recoil_y = _45_lc_extra_recoil_y,
					extra_stovepipe_chance = _45_lc_extra_stovepipe_chance,
					extra_doublefeed_chance = _45_lc_extra_doublefeed_chance,
					extra_ftf_chance = _45_lc_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _45_lc_extra_wrongly_seated_mag_chance,
					extra_out_of_battery_chance = _45_lc_extra_out_of_battery_chance,
					extra_slamfire_chance = _45_lc_extra_slamfire_chance,
					extra_slide_fire_speed = _45_lc_extra_slide_fire_speed,
					extra_wedged_amount = _45_lc_extra_wedged_amount,
					spawn_chance = _45_lc_spawn_chance,
					baseVariant = _45_lc_baseVariant,
					cartridge = _45_lc_cartridge,
					clean_name = _45_lc_clean_name,
					checkUnlockCondition = HasUnlockedBearLoad,
					shootingRangeAmmoBoxTexture = srab_tex
				};
			}

			if (_50_ae_plus_p_round_def == null) 
			{
				_50_ae_plus_p_round_def = new CustomRoundDefinition 
				{
					extra_rotation_x = _50_ae_extra_rotation_x,
					extra_rotation_y = _50_ae_extra_rotation_y,
					extra_recoil_x = _50_ae_extra_recoil_x,
					extra_recoil_y = _50_ae_extra_recoil_y,
					extra_stovepipe_chance = _50_ae_extra_stovepipe_chance,
					extra_doublefeed_chance = _50_ae_extra_doublefeed_chance,
					extra_ftf_chance = _50_ae_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _50_ae_extra_wrongly_seated_mag_chance,
					extra_out_of_battery_chance = _50_ae_extra_out_of_battery_chance,
					extra_slamfire_chance = _50_ae_extra_slamfire_chance,
					extra_slide_fire_speed = _50_ae_extra_slide_fire_speed,
					extra_wedged_amount = _50_ae_extra_wedged_amount,
					spawn_chance = _50_ae_spawn_chance,
					baseVariant = _50_ae_baseVariant,
					cartridge = _50_ae_cartridge,
					clean_name = _50_ae_clean_name,
					shootingRangeAmmoBoxTexture = srab_tex
				};
			}

			if (_50_ae_competition_round_def == null) 
			{
				_50_ae_competition_round_def = new CustomRoundDefinition 
				{
					extra_rotation_x = _50_ae_comp_extra_rotation_x,
					extra_rotation_y = _50_ae_comp_extra_rotation_y,
					extra_recoil_x = _50_ae_comp_extra_recoil_x,
					extra_recoil_y = _50_ae_comp_extra_recoil_y,
					extra_stovepipe_chance = _50_ae_comp_extra_stovepipe_chance,
					extra_doublefeed_chance = _50_ae_comp_extra_doublefeed_chance,
					extra_ftf_chance = _50_ae_comp_extra_ftf_chance,
					extra_wrongly_seated_mag_chance = _50_ae_comp_extra_wrongly_seated_mag_chance,
					extra_out_of_battery_chance = _50_ae_comp_extra_out_of_battery_chance,
					extra_slamfire_chance = _50_ae_comp_extra_slamfire_chance,
					extra_slide_fire_speed = _50_ae_comp_extra_slide_fire_speed,
					extra_wedged_amount = _50_ae_comp_extra_wedged_amount,
					spawn_chance = _50_ae_comp_spawn_chance,
					baseVariant = _50_ae_comp_baseVariant,
					cartridge = _50_ae_comp_cartridge,
					clean_name = _50_ae_comp_clean_name,
					shootingRangeAmmoBoxTexture = srab_comp_tex
				};
			}
		}

		public void OnBeforeSerialize()
		{
			if (plus_p_rounds_entry != null) {
				_help_entry_description = plus_p_rounds_entry.description;
				_help_entry_info_sprite = plus_p_rounds_entry.info_sprite;
				_help_entry_name = plus_p_rounds_entry.name;
				_help_entry_title = plus_p_rounds_entry.title;
			}

			if (competition_rounds_entry != null) {
				_competition_help_entry_description = competition_rounds_entry.description;
				_competition_help_entry_info_sprite = competition_rounds_entry.info_sprite;
				_competition_help_entry_name = competition_rounds_entry.name;
				_competition_help_entry_title = competition_rounds_entry.title;
			}

			if (_9mm_plus_p_round_def != null) 
			{
				_9mm_extra_rotation_x = _9mm_plus_p_round_def.extra_rotation_x;
				_9mm_extra_rotation_y = _9mm_plus_p_round_def.extra_rotation_y;
				_9mm_extra_recoil_x = _9mm_plus_p_round_def.extra_recoil_x;
				_9mm_extra_recoil_y = _9mm_plus_p_round_def.extra_recoil_y;
				_9mm_extra_stovepipe_chance = _9mm_plus_p_round_def.extra_stovepipe_chance;
				_9mm_extra_doublefeed_chance = _9mm_plus_p_round_def.extra_doublefeed_chance;
				_9mm_extra_ftf_chance = _9mm_plus_p_round_def.extra_ftf_chance;
				_9mm_extra_wrongly_seated_mag_chance = _9mm_plus_p_round_def.extra_wrongly_seated_mag_chance;
				_9mm_extra_slide_fire_speed = _9mm_plus_p_round_def.extra_slide_fire_speed;
				_9mm_extra_out_of_battery_chance = _9mm_plus_p_round_def.extra_out_of_battery_chance;
				_9mm_extra_slamfire_chance = _9mm_plus_p_round_def.extra_slamfire_chance;
				_9mm_extra_wedged_amount = _9mm_plus_p_round_def.extra_wedged_amount;
				_9mm_spawn_chance = _9mm_plus_p_round_def.spawn_chance;
				_9mm_baseVariant = _9mm_plus_p_round_def.baseVariant;
				_9mm_cartridge = _9mm_plus_p_round_def.cartridge;
				_9mm_clean_name = _9mm_plus_p_round_def.clean_name;
			}

			if (_9mm_competition_round_def != null) 
			{
				_9mm_comp_extra_rotation_x = _9mm_competition_round_def.extra_rotation_x;
				_9mm_comp_extra_rotation_y = _9mm_competition_round_def.extra_rotation_y;
				_9mm_comp_extra_recoil_x = _9mm_competition_round_def.extra_recoil_x;
				_9mm_comp_extra_recoil_y = _9mm_competition_round_def.extra_recoil_y;
				_9mm_comp_extra_stovepipe_chance = _9mm_competition_round_def.extra_stovepipe_chance;
				_9mm_comp_extra_doublefeed_chance = _9mm_competition_round_def.extra_doublefeed_chance;
				_9mm_comp_extra_ftf_chance = _9mm_competition_round_def.extra_ftf_chance;
				_9mm_comp_extra_wrongly_seated_mag_chance = _9mm_competition_round_def.extra_wrongly_seated_mag_chance;
				_9mm_comp_extra_slide_fire_speed = _9mm_competition_round_def.extra_slide_fire_speed;
				_9mm_comp_extra_out_of_battery_chance = _9mm_competition_round_def.extra_out_of_battery_chance;
				_9mm_comp_extra_slamfire_chance = _9mm_competition_round_def.extra_slamfire_chance;
				_9mm_comp_extra_wedged_amount = _9mm_competition_round_def.extra_wedged_amount;
				_9mm_comp_spawn_chance = _9mm_competition_round_def.spawn_chance;
				_9mm_comp_baseVariant = _9mm_competition_round_def.baseVariant;
				_9mm_comp_cartridge = _9mm_competition_round_def.cartridge;
				_9mm_comp_clean_name = _9mm_competition_round_def.clean_name;
			}

			if (_38_special_plus_p_round_def != null) 
			{
				_38_special_extra_rotation_x = _38_special_plus_p_round_def.extra_rotation_x;
				_38_special_extra_rotation_y = _38_special_plus_p_round_def.extra_rotation_y;
				_38_special_extra_recoil_x = _38_special_plus_p_round_def.extra_recoil_x;
				_38_special_extra_recoil_y = _38_special_plus_p_round_def.extra_recoil_y;
				_38_special_extra_stovepipe_chance = _38_special_plus_p_round_def.extra_stovepipe_chance;
				_38_special_extra_doublefeed_chance = _38_special_plus_p_round_def.extra_doublefeed_chance;
				_38_special_extra_ftf_chance = _38_special_plus_p_round_def.extra_ftf_chance;
				_38_special_extra_wrongly_seated_mag_chance = _38_special_plus_p_round_def.extra_wrongly_seated_mag_chance;
				_38_special_extra_out_of_battery_chance = _38_special_plus_p_round_def.extra_out_of_battery_chance;
				_38_special_extra_slamfire_chance = _38_special_plus_p_round_def.extra_slamfire_chance;
				_38_special_extra_slide_fire_speed = _38_special_plus_p_round_def.extra_slide_fire_speed;
				_38_special_extra_wedged_amount = _38_special_plus_p_round_def.extra_wedged_amount;
				_38_special_spawn_chance = _38_special_plus_p_round_def.spawn_chance;
				_38_special_baseVariant = _38_special_plus_p_round_def.baseVariant;
				_38_special_cartridge = _38_special_plus_p_round_def.cartridge;
				_38_special_clean_name = _38_special_plus_p_round_def.clean_name;
			}

			if (_45_acp_plus_p_round_def != null) 
			{
				_45_acp_extra_rotation_x = _45_acp_plus_p_round_def.extra_rotation_x;
				_45_acp_extra_rotation_y = _45_acp_plus_p_round_def.extra_rotation_y;
				_45_acp_extra_recoil_x = _45_acp_plus_p_round_def.extra_recoil_x;
				_45_acp_extra_recoil_y = _45_acp_plus_p_round_def.extra_recoil_y;
				_45_acp_extra_stovepipe_chance = _45_acp_plus_p_round_def.extra_stovepipe_chance;
				_45_acp_extra_doublefeed_chance = _45_acp_plus_p_round_def.extra_doublefeed_chance;
				_45_acp_extra_ftf_chance = _45_acp_plus_p_round_def.extra_ftf_chance;
				_45_acp_extra_wrongly_seated_mag_chance = _45_acp_plus_p_round_def.extra_wrongly_seated_mag_chance;
				_45_acp_extra_out_of_battery_chance = _45_acp_plus_p_round_def.extra_out_of_battery_chance;
				_45_acp_extra_slamfire_chance = _45_acp_plus_p_round_def.extra_slamfire_chance;
				_45_acp_extra_slide_fire_speed = _45_acp_plus_p_round_def.extra_slide_fire_speed;
				_45_acp_extra_wedged_amount = _45_acp_plus_p_round_def.extra_wedged_amount;
				_45_acp_spawn_chance = _45_acp_plus_p_round_def.spawn_chance;
				_45_acp_baseVariant = _45_acp_plus_p_round_def.baseVariant;
				_45_acp_cartridge = _45_acp_plus_p_round_def.cartridge;
				_45_acp_clean_name = _45_acp_plus_p_round_def.clean_name;
			}

			if (_45_acp_competition_round_def != null) 
			{
				_45_acp_comp_extra_rotation_x = _45_acp_competition_round_def.extra_rotation_x;
				_45_acp_comp_extra_rotation_y = _45_acp_competition_round_def.extra_rotation_y;
				_45_acp_comp_extra_recoil_x = _45_acp_competition_round_def.extra_recoil_x;
				_45_acp_comp_extra_recoil_y = _45_acp_competition_round_def.extra_recoil_y;
				_45_acp_comp_extra_stovepipe_chance = _45_acp_competition_round_def.extra_stovepipe_chance;
				_45_acp_comp_extra_doublefeed_chance = _45_acp_competition_round_def.extra_doublefeed_chance;
				_45_acp_comp_extra_ftf_chance = _45_acp_competition_round_def.extra_ftf_chance;
				_45_acp_comp_extra_wrongly_seated_mag_chance = _45_acp_competition_round_def.extra_wrongly_seated_mag_chance;
				_45_acp_comp_extra_out_of_battery_chance = _45_acp_competition_round_def.extra_out_of_battery_chance;
				_45_acp_comp_extra_slamfire_chance = _45_acp_competition_round_def.extra_slamfire_chance;
				_45_acp_comp_extra_slide_fire_speed = _45_acp_competition_round_def.extra_slide_fire_speed;
				_45_acp_comp_extra_wedged_amount = _45_acp_competition_round_def.extra_wedged_amount;
				_45_acp_comp_spawn_chance = _45_acp_competition_round_def.spawn_chance;
				_45_acp_comp_baseVariant = _45_acp_competition_round_def.baseVariant;
				_45_acp_comp_cartridge = _45_acp_competition_round_def.cartridge;
				_45_acp_comp_clean_name = _45_acp_competition_round_def.clean_name;
			}

			if (_45_lc_plus_p_round_def != null)
			{
				_45_lc_extra_rotation_x = _45_lc_plus_p_round_def.extra_rotation_x;
				_45_lc_extra_rotation_y = _45_lc_plus_p_round_def.extra_rotation_y;
				_45_lc_extra_recoil_x = _45_lc_plus_p_round_def.extra_recoil_x;
				_45_lc_extra_recoil_y = _45_lc_plus_p_round_def.extra_recoil_y;
				_45_lc_extra_stovepipe_chance = _45_lc_plus_p_round_def.extra_stovepipe_chance;
				_45_lc_extra_doublefeed_chance = _45_lc_plus_p_round_def.extra_doublefeed_chance;
				_45_lc_extra_ftf_chance = _45_lc_plus_p_round_def.extra_ftf_chance;
				_45_lc_extra_wrongly_seated_mag_chance = _45_lc_plus_p_round_def.extra_wrongly_seated_mag_chance;
				_45_lc_extra_out_of_battery_chance = _45_lc_plus_p_round_def.extra_out_of_battery_chance;
				_45_lc_extra_slamfire_chance = _45_lc_plus_p_round_def.extra_slamfire_chance;
				_45_lc_extra_slide_fire_speed = _45_lc_plus_p_round_def.extra_slide_fire_speed;
				_45_lc_extra_wedged_amount = _45_lc_plus_p_round_def.extra_wedged_amount;
				_45_lc_spawn_chance = _45_lc_plus_p_round_def.spawn_chance;
				_45_lc_baseVariant = _45_lc_plus_p_round_def.baseVariant;
				_45_lc_cartridge = _45_lc_plus_p_round_def.cartridge;
				_45_lc_clean_name = _45_lc_plus_p_round_def.clean_name;
			}

			if (_50_ae_plus_p_round_def != null)
			{
				_50_ae_extra_rotation_x = _50_ae_plus_p_round_def.extra_rotation_x;
				_50_ae_extra_rotation_y = _50_ae_plus_p_round_def.extra_rotation_y;
				_50_ae_extra_recoil_x = _50_ae_plus_p_round_def.extra_recoil_x;
				_50_ae_extra_recoil_y = _50_ae_plus_p_round_def.extra_recoil_y;
				_50_ae_extra_stovepipe_chance = _50_ae_plus_p_round_def.extra_stovepipe_chance;
				_50_ae_extra_doublefeed_chance = _50_ae_plus_p_round_def.extra_doublefeed_chance;
				_50_ae_extra_ftf_chance = _50_ae_plus_p_round_def.extra_ftf_chance;
				_50_ae_extra_wrongly_seated_mag_chance = _50_ae_plus_p_round_def.extra_wrongly_seated_mag_chance;
				_50_ae_extra_out_of_battery_chance = _50_ae_plus_p_round_def.extra_out_of_battery_chance;
				_50_ae_extra_slamfire_chance = _50_ae_plus_p_round_def.extra_slamfire_chance;
				_50_ae_extra_slide_fire_speed = _50_ae_plus_p_round_def.extra_slide_fire_speed;
				_50_ae_extra_wedged_amount = _50_ae_plus_p_round_def.extra_wedged_amount;
				_50_ae_spawn_chance = _50_ae_plus_p_round_def.spawn_chance;
				_50_ae_baseVariant = _50_ae_plus_p_round_def.baseVariant;
				_50_ae_cartridge = _50_ae_plus_p_round_def.cartridge;
				_50_ae_clean_name = _50_ae_plus_p_round_def.clean_name;
			}

			if (_50_ae_competition_round_def != null)
			{
				_50_ae_comp_extra_rotation_x = _50_ae_competition_round_def.extra_rotation_x;
				_50_ae_comp_extra_rotation_y = _50_ae_competition_round_def.extra_rotation_y;
				_50_ae_comp_extra_recoil_x = _50_ae_competition_round_def.extra_recoil_x;
				_50_ae_comp_extra_recoil_y = _50_ae_competition_round_def.extra_recoil_y;
				_50_ae_comp_extra_stovepipe_chance = _50_ae_competition_round_def.extra_stovepipe_chance;
				_50_ae_comp_extra_doublefeed_chance = _50_ae_competition_round_def.extra_doublefeed_chance;
				_50_ae_comp_extra_ftf_chance = _50_ae_competition_round_def.extra_ftf_chance;
				_50_ae_comp_extra_wrongly_seated_mag_chance = _50_ae_competition_round_def.extra_wrongly_seated_mag_chance;
				_50_ae_comp_extra_out_of_battery_chance = _50_ae_competition_round_def.extra_out_of_battery_chance;
				_50_ae_comp_extra_slamfire_chance = _50_ae_competition_round_def.extra_slamfire_chance;
				_50_ae_comp_extra_slide_fire_speed = _50_ae_competition_round_def.extra_slide_fire_speed;
				_50_ae_comp_extra_wedged_amount = _50_ae_competition_round_def.extra_wedged_amount;
				_50_ae_comp_spawn_chance = _50_ae_competition_round_def.spawn_chance;
				_50_ae_comp_baseVariant = _50_ae_competition_round_def.baseVariant;
				_50_ae_comp_cartridge = _50_ae_competition_round_def.cartridge;
				_50_ae_comp_clean_name = _50_ae_competition_round_def.clean_name;
			}
		}

		public static bool HasUnlockedBearLoad() {
			return ReceiverCoreScript.Instance().PlayerData.win_count > 0;
		}
	}
}