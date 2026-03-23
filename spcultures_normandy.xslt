<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output omit-xml-declaration="no" indent="yes" />
<xsl:template match="@*|node()">
<xsl:copy>
<xsl:apply-templates select="@*|node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'is_main_culture' or name() != 'color' or name() != 'color2' or name() != 'naval_factor' or name() != 'default_party_template' or name() != 'villager_party_template' or name() != 'bandit_boss_party_template' or name() != 'militia_party_template' or name() != 'rebels_party_template' or name() != 'vassal_reward_party_template' or name() != 'basic_troop' or name() != 'elite_basic_troop' or name() != 'melee_militia_troop' or name() != 'melee_elite_militia_troop' or name() != 'ranged_militia_troop' or name() != 'ranged_elite_militia_troop' or name() != 'tournament_master' or name() != 'caravan_master' or name() != 'caravan_guard' or name() != 'veteran_caravan_guard' or name() != 'prison_guard' or name() != 'guard' or name() != 'blacksmith' or name() != 'weaponsmith' or name() != 'townswoman' or name() != 'townswoman_infant' or name() != 'townswoman_child' or name() != 'townswoman_teenager' or name() != 'townsman' or name() != 'townsman_infant' or name() != 'townsman_child' or name() != 'townsman_teenager' or name() != 'villager' or name() != 'village_woman' or name() != 'villager_male_child' or name() != 'villager_male_teenager' or name() != 'villager_female_child' or name() != 'villager_female_teenager' or name() != 'ransom_broker' or name() != 'gangleader_bodyguard' or name() != 'merchant_notary' or name() != 'artisan_notary' or name() != 'preacher_notary' or name() != 'rural_notable_notary' or name() != 'shop_worker' or name() != 'tavernkeeper' or name() != 'taverngamehost' or name() != 'musician' or name() != 'tavern_wench' or name() != 'armorer' or name() != 'horseMerchant' or name() != 'barber' or name() != 'merchant' or name() != 'beggar' or name() != 'female_beggar' or name() != 'female_dancer' or name() != 'board_game_type' or name() != 'default_battle_equipment_roster' or name() != 'default_civilian_equipment_roster' or name() != 'duel_preset_equipment_roster' or name() != 'text' or name() != 'marriage_bride_equipment_roster' or name() != 'marriage_bride_equipment_roster' or name() != 'default_character_creation_body_property' or name() != 'start_point_position_x' or name() != 'start_point_position_y' or name() != 'shipwright']" />
<xsl:attribute name="is_main_culture">true</xsl:attribute>
<xsl:attribute name="color">FF8B4513</xsl:attribute>
<xsl:attribute name="color2">FFD2691E</xsl:attribute>
<xsl:attribute name="faction_banner_key">11.218.218.4345.4345.764.764.1.0.0.175.219.219.512.512.764.764.1.0.0</xsl:attribute>
<xsl:attribute name="encounter_background_mesh">encounter_nord</xsl:attribute>
<xsl:attribute name="naval_factor">2.4</xsl:attribute>
<xsl:attribute name="default_party_template">PartyTemplate.kingdom_hero_party_normandy_template</xsl:attribute>
<xsl:attribute name="villager_party_template">PartyTemplate.villager_normandy_template</xsl:attribute>
<xsl:attribute name="bandit_boss_party_template">PartyTemplate.sea_raiders_boss_party_template</xsl:attribute>
<xsl:attribute name="militia_party_template">PartyTemplate.militia_normandy_template</xsl:attribute>
<xsl:attribute name="rebels_party_template">PartyTemplate.rebels_normandy_template</xsl:attribute>
<xsl:attribute name="vassal_reward_party_template">PartyTemplate.vassal_reward_troops_normandy</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_level_1">PartyTemplate.patrol_party_normandy_template_level_1</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_level_2">PartyTemplate.patrol_party_normandy_template_level_2</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_level_3">PartyTemplate.patrol_party_normandy_template_level_3</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_coastal">PartyTemplate.patrol_party_normandy_template_coastal</xsl:attribute>
<xsl:attribute name="basic_troop">NPCCharacter.normandy_recruit_tactical</xsl:attribute>
<xsl:attribute name="elite_basic_troop">NPCCharacter.normandy_warrior</xsl:attribute>
<xsl:attribute name="melee_militia_troop">NPCCharacter.normandy_militia_spearman</xsl:attribute>
<xsl:attribute name="melee_elite_militia_troop">NPCCharacter.normandy_militia_veteran_spearman</xsl:attribute>
<xsl:attribute name="ranged_militia_troop">NPCCharacter.normandy_militia_archer</xsl:attribute>
<xsl:attribute name="ranged_elite_militia_troop">NPCCharacter.normandy_militia_veteran_archer</xsl:attribute>
<xsl:attribute name="tournament_master">NPCCharacter.tournament_master_normandy</xsl:attribute>
<xsl:attribute name="caravan_master">NPCCharacter.caravan_master_normandy</xsl:attribute>
<xsl:attribute name="caravan_guard">NPCCharacter.caravan_guard_normandy</xsl:attribute>
<xsl:attribute name="veteran_caravan_guard">NPCCharacter.veteran_caravan_guard_normandy</xsl:attribute>
<xsl:attribute name="prison_guard">NPCCharacter.prison_guard_normandy</xsl:attribute>
<xsl:attribute name="guard">NPCCharacter.guard_normandy</xsl:attribute>
<xsl:attribute name="blacksmith">NPCCharacter.blacksmith_normandy</xsl:attribute>
<xsl:attribute name="weaponsmith">NPCCharacter.weaponsmith_normandy</xsl:attribute>
<xsl:attribute name="townswoman">NPCCharacter.townswoman_normandy</xsl:attribute>
<xsl:attribute name="townswoman_infant">NPCCharacter.townswoman_infant_normandy</xsl:attribute>
<xsl:attribute name="townswoman_child">NPCCharacter.townswoman_child_normandy</xsl:attribute>
<xsl:attribute name="townswoman_teenager">NPCCharacter.townswoman_teenager_normandy</xsl:attribute>
<xsl:attribute name="townsman">NPCCharacter.townsman_normandy</xsl:attribute>
<xsl:attribute name="townsman_infant">NPCCharacter.townsman_infant_normandy</xsl:attribute>
<xsl:attribute name="townsman_child">NPCCharacter.townsman_child_normandy</xsl:attribute>
<xsl:attribute name="townsman_teenager">NPCCharacter.townsman_teenager_normandy</xsl:attribute>
<xsl:attribute name="villager">NPCCharacter.villager_normandy</xsl:attribute>
<xsl:attribute name="village_woman">NPCCharacter.village_woman_normandy</xsl:attribute>
<xsl:attribute name="villager_male_child">NPCCharacter.villager_child_normandy</xsl:attribute>
<xsl:attribute name="villager_male_teenager">NPCCharacter.villager_teenager_normandy</xsl:attribute>
<xsl:attribute name="villager_female_child">NPCCharacter.village_woman_child_normandy</xsl:attribute>
<xsl:attribute name="villager_female_teenager">NPCCharacter.village_woman_teenager_normandy</xsl:attribute>
<xsl:attribute name="ransom_broker">NPCCharacter.ransom_broker_normandy</xsl:attribute>
<xsl:attribute name="gangleader_bodyguard">NPCCharacter.gangleader_bodyguard_normandy</xsl:attribute>
<xsl:attribute name="merchant_notary">NPCCharacter.merchant_notary_normandy</xsl:attribute>
<xsl:attribute name="artisan_notary">NPCCharacter.artisan_notary_normandy</xsl:attribute>
<xsl:attribute name="preacher_notary">NPCCharacter.preacher_notary_normandy</xsl:attribute>
<xsl:attribute name="rural_notable_notary">NPCCharacter.rural_notable_notary_normandy</xsl:attribute>
<xsl:attribute name="shop_worker">NPCCharacter.shop_worker_normandy</xsl:attribute>
<xsl:attribute name="tavernkeeper">NPCCharacter.tavernkeeper_normandy</xsl:attribute>
<xsl:attribute name="taverngamehost">NPCCharacter.taverngamehost_normandy</xsl:attribute>
<xsl:attribute name="musician">NPCCharacter.musician_normandy</xsl:attribute>
<xsl:attribute name="tavern_wench">NPCCharacter.tavern_wench_normandy</xsl:attribute>
<xsl:attribute name="armorer">NPCCharacter.armorer_normandy</xsl:attribute>
<xsl:attribute name="horseMerchant">NPCCharacter.horseMerchant_normandy</xsl:attribute>
<xsl:attribute name="barber">NPCCharacter.barber_normandy</xsl:attribute>
<xsl:attribute name="merchant">NPCCharacter.merchant_normandy</xsl:attribute>
<xsl:attribute name="beggar">NPCCharacter.beggar_normandy</xsl:attribute>
<xsl:attribute name="female_beggar">NPCCharacter.female_beggar_normandy</xsl:attribute>
<xsl:attribute name="female_dancer">NPCCharacter.female_dancer_normandy</xsl:attribute>
<xsl:attribute name="board_game_type">Konane</xsl:attribute>
<xsl:attribute name="default_battle_equipment_roster">EquipmentRoster.normandy_civ_template_default</xsl:attribute>
<xsl:attribute name="default_civilian_equipment_roster">EquipmentRoster.normandy_civ_template_default</xsl:attribute>
<xsl:attribute name="duel_preset_equipment_roster">EquipmentRoster.normandy_duel_preset_template</xsl:attribute>
<xsl:attribute name="text">{=bLTkig9T}The Normans are a seafaring people originating from the lands of Normandy in northern Francia. Renowned for their maritime prowess, they have established settlements across the Mediterranean and beyond. Their ships are swift and sturdy, capable of both trade and warfare, reflecting their dual heritage as both Scandinavian raiders and Frankish nobles.</xsl:attribute>
<xsl:attribute name="marriage_bride_equipment_roster">EquipmentRoster.marriage_female_normandy_cutscene_template</xsl:attribute>
<xsl:attribute name="default_character_creation_body_property">BodyProperty.default_character_creation_body_property_normandy</xsl:attribute>
<xsl:attribute name="start_point_position_x">725</xsl:attribute>
<xsl:attribute name="start_point_position_y">811</xsl:attribute>
<xsl:attribute name="shipwright" namespace="">NPCCharacter.shipwright_normandy</xsl:attribute>
<xsl:attribute name="fishing_party_template" namespace="">PartyTemplate.fishing_party_template_normandy</xsl:attribute>
<xsl:element name="vassal_reward_items">
<xsl:element name="item">
<xsl:attribute name="id">Item.normandy_shield_tier_6_a</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="default_policies">
<xsl:element name="policy">
<xsl:attribute name="id">policy_lawspeakers</xsl:attribute>
</xsl:element>
<xsl:element name="policy">
<xsl:attribute name="id">policy_precarial_land_tenure</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="clan_names">
<xsl:element name="name">
<xsl:attribute name="name">{=gxVFrAeB}Aeralding</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=lPawN1SA}Bjulsing</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=RYfJBt0i}Erking</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=XchQmB3I}Froring</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=GalY0PDs}Gisalding</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=HgEWXVtd}Gutviding</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=VHCZzWcs}Hravalding</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=TbW9YbK2}Knalring</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=C5J5zymb}Lyffing</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=qYuwCoyc}Mjalnoring</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=qq24oTjG}Njarthing</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=ZAdbpTo1}Surthuring</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=0sawS3aZ}Thulgrimming</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=KXP0b8ra}Torving</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Odcn2awi}Vulstaning</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="cultural_feats">
<xsl:element name="feat">
<xsl:attribute name="id">normandy_hostile_action_bonus</xsl:attribute>
</xsl:element>
<xsl:element name="feat">
<xsl:attribute name="id">normandy_ship_movemenet_increase</xsl:attribute>
</xsl:element>
<xsl:element name="feat">
<xsl:attribute name="id">normandy_decreased_cohesion_rate</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="possible_clan_banner_icon_ids">
<xsl:element name="icon">
<xsl:attribute name="id">166</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">167</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">168</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">169</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">170</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">171</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">172</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">173</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">174</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">165</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">307</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">331</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">407</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">408</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">409</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">410</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">439</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">440</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">441</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">442</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">443</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">444</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">445</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="notable_templates">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_0</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_0b</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_2b</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_3</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_3b</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_3c</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_4</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_5</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_6</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_7</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_8</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_9</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_normandy_10</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_headman_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_headman_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_headman_3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="lord_templates">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_0</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="rebellion_hero_templates">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_0</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_normandy_leader_3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="tournament_team_templates_one_participant">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_one_participant_set_v1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_one_participant_set_v2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_one_participant_set_v3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="tournament_team_templates_two_participant">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_two_participant_set_v1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_two_participant_set_v2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_two_participant_set_v3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="tournament_team_templates_four_participant">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_four_participant_set_v1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_four_participant_set_v2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_four_participant_set_v3</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_normandy_four_participant_set_v4</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="basic_mercenary_troops">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.eastern_mercenary</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.western_mercenary</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.sword_sisters_sister_t3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/elite_caravan_party_templates[1]/caravan_party_template[@id='PartyTemplate.elite_caravan_template_sturgia']">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'id']" />
<xsl:attribute name="id">PartyTemplate.elite_caravan_template_normandy</xsl:attribute>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/elite_caravan_party_templates[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="caravan_party_template">
<xsl:attribute name="id">PartyTemplate.elite_naval_caravan_template_normandy</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/caravan_party_templates[1]/caravan_party_template[@id='PartyTemplate.caravan_template_sturgia']">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'id']" />
<xsl:attribute name="id">PartyTemplate.caravan_template_normandy</xsl:attribute>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/caravan_party_templates[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="caravan_party_template">
<xsl:attribute name="id">PartyTemplate.naval_caravan_template_normandy</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/male_names[1]/name[1]">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'name']" />
<xsl:attribute name="name">{=lE9vlMwr}Aegi</xsl:attribute>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/male_names[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="name">
<xsl:attribute name="name">{=QmvYbULE}Aerik</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=OtScbguN}Amgerth</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=WBrR78En}Asgorm</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=mzDpvxNA}Aspak</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=VtreHayJ}Bjalgrim</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=xWpfDjQG}Bortur</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=LtbEKVEg}Falgorm</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=I0SgDITW}Futhar</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=baHOn5Co}Garmi</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=KYEaokG2}Grymnir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=XbbIYI1B}Gylf</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=HiacQwwr}Jafnir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=ibI9H8rk}Juvi</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=o6ZTF2zJ}Hakbard</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Ow4S9sfW}Heimskir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=VG4Lab2h}Hrani</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Wb63SFUB}Hrothnir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=uWpLuEaw}Kjali</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=ae0wJXAI}Knudir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=MmIbejjj}Larstan</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=o0XfetGR}Mjol</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=8QJmjfbg}Nidir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=r5FwkIaa}Odegar</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Lji5jAcG}Odric</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=I7omeVkn}Opp</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=gD0MUJD0}Rorbrek</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=j4OpVFsR}Skorin</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=fh44cZPt}Slegnir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=3EKsU4b7}Svalnar</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Rnebm5O3}Svothir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=N909bEs7}Thunnar</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=P3hWUrrN}Thunror</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=5Jav7tBV}Tholrik</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=i1Piod4t}Tolgar</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=yqFprtrA}Ufeig</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=aa1o7C9b}Ulsten</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=nauYyavs}Ulvi</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=5oRLxphw}Vimi</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=I7uCc76p}Vorstan</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=rfjPgbCn}Vulgrim</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Gm6XjCp6}Vuljotur</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=oopPIDGs}Ynggorm</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=Oe9jSa71}Yngvald</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/female_names[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="name">
<xsl:attribute name="name">{=shLxv6uI}Aeldy</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=VQHZ69xp}Aenessa</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=56ofZNUm}Angeyja</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=ixINPixr}Ariberga</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=5BxEEMjj}Arnvula</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=RDDq3etN}Asgotha</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=0wD3iaxo}Brigun</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=6WuwYvaT}Brynja</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=waXbK1m1}Daghild</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=IgfKAjP9}Drina</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=0hHaefoK}Dyfa</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=nsDeLrqW}Elfhild</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=rVhI3WHq}Elga</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=eg6BLG4B}Faerdra</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=AsZjJoaH}Fridrun</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=BiKFG6f0}Frija</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=8KbcYume}Gerdja</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=XE0EKbtC}Gerthra</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=pxmnfgp4}Gjora</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=MBZbVWGy}Gulta</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=q5qcIN0c}Haera</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=QmM9jC0j}Haelgun</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=0yFuZkjJ}Hlara</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=FOPx95OQ}Inselva</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=voZQF1Nx}Istrid</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=5A7IiaEK}Ithrun</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=aKiCqLT1}Kari</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=dzBk0kLY}Kjalsa</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=TJlbtlmQ}Ljana</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=L4PqcH0Q}Lyn</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=tRVxmxrE}Menja</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=GaiApS01}Mjarigun</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=YszOCJEx}Olofun</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=BDGIbnou}Ota</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=gb6TnWOr}Nima</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=bqOz0ZFW}Revna</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=TdFyTaRe}Saxa</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=R6rl7535}Siv</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=sULixbMX}Sylla</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=33RMewcs}Thuril</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=vNbhkiTB}Thyrsif</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=eOEHTqYc}Tyfa</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=0l06BiHb}Vanra</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=BrOc2noV}Vesna</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=7w9qPxzl}Vulfrid</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=A7VyyEdR}Urisif</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=sImhAXHZ}Yfka</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=QIHg9Ucq}Yngun</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/female_names[1]/name[1]">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'name']" />
<xsl:attribute name="name">{=sg74oONo}Aelba</xsl:attribute>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='normandy']/available_ship_hulls[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.northern_light_ship</xsl:attribute>
</xsl:element>
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.northern_medium_ship</xsl:attribute>
</xsl:element>
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.nord_medium_ship</xsl:attribute>
</xsl:element>
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.northern_trade_ship</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
</xsl:stylesheet>