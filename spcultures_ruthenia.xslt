<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output omit-xml-declaration="no" indent="yes" />
<xsl:template match="@*|node()">
<xsl:copy>
<xsl:apply-templates select="@*|node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'is_main_culture' or name() != 'color' or name() != 'color2' or name() != 'naval_factor' or name() != 'default_party_template' or name() != 'villager_party_template' or name() != 'bandit_boss_party_template' or name() != 'militia_party_template' or name() != 'rebels_party_template' or name() != 'vassal_reward_party_template' or name() != 'basic_troop' or name() != 'elite_basic_troop' or name() != 'melee_militia_troop' or name() != 'melee_elite_militia_troop' or name() != 'ranged_militia_troop' or name() != 'ranged_elite_militia_troop' or name() != 'tournament_master' or name() != 'caravan_master' or name() != 'caravan_guard' or name() != 'veteran_caravan_guard' or name() != 'prison_guard' or name() != 'guard' or name() != 'blacksmith' or name() != 'weaponsmith' or name() != 'townswoman' or name() != 'townswoman_infant' or name() != 'townswoman_child' or name() != 'townswoman_teenager' or name() != 'townsman' or name() != 'townsman_infant' or name() != 'townsman_child' or name() != 'townsman_teenager' or name() != 'villager' or name() != 'village_woman' or name() != 'villager_male_child' or name() != 'villager_male_teenager' or name() != 'villager_female_child' or name() != 'villager_female_teenager' or name() != 'ransom_broker' or name() != 'gangleader_bodyguard' or name() != 'merchant_notary' or name() != 'artisan_notary' or name() != 'preacher_notary' or name() != 'rural_notable_notary' or name() != 'shop_worker' or name() != 'tavernkeeper' or name() != 'taverngamehost' or name() != 'musician' or name() != 'tavern_wench' or name() != 'armorer' or name() != 'horseMerchant' or name() != 'barber' or name() != 'merchant' or name() != 'beggar' or name() != 'female_beggar' or name() != 'female_dancer' or name() != 'board_game_type' or name() != 'default_battle_equipment_roster' or name() != 'default_civilian_equipment_roster' or name() != 'duel_preset_equipment_roster' or name() != 'text' or name() != 'marriage_bride_equipment_roster' or name() != 'marriage_bride_equipment_roster' or name() != 'default_character_creation_body_property' or name() != 'start_point_position_x' or name() != 'start_point_position_y' or name() != 'shipwright']" />
<xsl:attribute name="is_main_culture">true</xsl:attribute>
<xsl:attribute name="color">FF800080</xsl:attribute>
<xsl:attribute name="color2">FF9932CC</xsl:attribute>
<xsl:attribute name="faction_banner_key">11.218.218.4345.4345.764.764.1.0.0.175.219.219.512.512.764.764.1.0.0</xsl:attribute>
<xsl:attribute name="encounter_background_mesh">encounter_sturgia</xsl:attribute>
<xsl:attribute name="naval_factor">2.2</xsl:attribute>
<xsl:attribute name="default_party_template">PartyTemplate.kingdom_hero_party_ruthenia_template</xsl:attribute>
<xsl:attribute name="villager_party_template">PartyTemplate.villager_ruthenia_template</xsl:attribute>
<xsl:attribute name="bandit_boss_party_template">PartyTemplate.sea_raiders_boss_party_template</xsl:attribute>
<xsl:attribute name="militia_party_template">PartyTemplate.militia_ruthenia_template</xsl:attribute>
<xsl:attribute name="rebels_party_template">PartyTemplate.rebels_ruthenia_template</xsl:attribute>
<xsl:attribute name="vassal_reward_party_template">PartyTemplate.vassal_reward_troops_ruthenia</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_level_1">PartyTemplate.patrol_party_ruthenia_template_level_1</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_level_2">PartyTemplate.patrol_party_ruthenia_template_level_2</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_level_3">PartyTemplate.patrol_party_ruthenia_template_level_3</xsl:attribute>
<xsl:attribute name="settlement_patrol_template_coastal">PartyTemplate.patrol_party_ruthenia_template_coastal</xsl:attribute>
<xsl:attribute name="basic_troop">NPCCharacter.ruthenia_recruit_tactical</xsl:attribute>
<xsl:attribute name="elite_basic_troop">NPCCharacter.ruthenia_warrior</xsl:attribute>
<xsl:attribute name="melee_militia_troop">NPCCharacter.ruthenia_militia_spearman</xsl:attribute>
<xsl:attribute name="melee_elite_militia_troop">NPCCharacter.ruthenia_militia_veteran_spearman</xsl:attribute>
<xsl:attribute name="ranged_militia_troop">NPCCharacter.ruthenia_militia_archer</xsl:attribute>
<xsl:attribute name="ranged_elite_militia_troop">NPCCharacter.ruthenia_militia_veteran_archer</xsl:attribute>
<xsl:attribute name="tournament_master">NPCCharacter.tournament_master_ruthenia</xsl:attribute>
<xsl:attribute name="caravan_master">NPCCharacter.caravan_master_ruthenia</xsl:attribute>
<xsl:attribute name="caravan_guard">NPCCharacter.caravan_guard_ruthenia</xsl:attribute>
<xsl:attribute name="veteran_caravan_guard">NPCCharacter.veteran_caravan_guard_ruthenia</xsl:attribute>
<xsl:attribute name="prison_guard">NPCCharacter.prison_guard_ruthenia</xsl:attribute>
<xsl:attribute name="guard">NPCCharacter.guard_ruthenia</xsl:attribute>
<xsl:attribute name="blacksmith">NPCCharacter.blacksmith_ruthenia</xsl:attribute>
<xsl:attribute name="weaponsmith">NPCCharacter.weaponsmith_ruthenia</xsl:attribute>
<xsl:attribute name="townswoman">NPCCharacter.townswoman_ruthenia</xsl:attribute>
<xsl:attribute name="townswoman_infant">NPCCharacter.townswoman_infant_ruthenia</xsl:attribute>
<xsl:attribute name="townswoman_child">NPCCharacter.townswoman_child_ruthenia</xsl:attribute>
<xsl:attribute name="townswoman_teenager">NPCCharacter.townswoman_teenager_ruthenia</xsl:attribute>
<xsl:attribute name="townsman">NPCCharacter.townsman_ruthenia</xsl:attribute>
<xsl:attribute name="townsman_infant">NPCCharacter.townsman_infant_ruthenia</xsl:attribute>
<xsl:attribute name="townsman_child">NPCCharacter.townsman_child_ruthenia</xsl:attribute>
<xsl:attribute name="townsman_teenager">NPCCharacter.townsman_teenager_ruthenia</xsl:attribute>
<xsl:attribute name="villager">NPCCharacter.villager_ruthenia</xsl:attribute>
<xsl:attribute name="village_woman">NPCCharacter.village_woman_ruthenia</xsl:attribute>
<xsl:attribute name="villager_male_child">NPCCharacter.villager_child_ruthenia</xsl:attribute>
<xsl:attribute name="villager_male_teenager">NPCCharacter.villager_teenager_ruthenia</xsl:attribute>
<xsl:attribute name="villager_female_child">NPCCharacter.village_woman_child_ruthenia</xsl:attribute>
<xsl:attribute name="villager_female_teenager">NPCCharacter.village_woman_teenager_ruthenia</xsl:attribute>
<xsl:attribute name="ransom_broker">NPCCharacter.ransom_broker_ruthenia</xsl:attribute>
<xsl:attribute name="gangleader_bodyguard">NPCCharacter.gangleader_bodyguard_ruthenia</xsl:attribute>
<xsl:attribute name="merchant_notary">NPCCharacter.merchant_notary_ruthenia</xsl:attribute>
<xsl:attribute name="artisan_notary">NPCCharacter.artisan_notary_ruthenia</xsl:attribute>
<xsl:attribute name="preacher_notary">NPCCharacter.preacher_notary_ruthenia</xsl:attribute>
<xsl:attribute name="rural_notable_notary">NPCCharacter.rural_notable_notary_ruthenia</xsl:attribute>
<xsl:attribute name="shop_worker">NPCCharacter.shop_worker_ruthenia</xsl:attribute>
<xsl:attribute name="tavernkeeper">NPCCharacter.tavernkeeper_ruthenia</xsl:attribute>
<xsl:attribute name="taverngamehost">NPCCharacter.taverngamehost_ruthenia</xsl:attribute>
<xsl:attribute name="musician">NPCCharacter.musician_ruthenia</xsl:attribute>
<xsl:attribute name="tavern_wench">NPCCharacter.tavern_wench_ruthenia</xsl:attribute>
<xsl:attribute name="armorer">NPCCharacter.armorer_ruthenia</xsl:attribute>
<xsl:attribute name="horseMerchant">NPCCharacter.horseMerchant_ruthenia</xsl:attribute>
<xsl:attribute name="barber">NPCCharacter.barber_ruthenia</xsl:attribute>
<xsl:attribute name="merchant">NPCCharacter.merchant_ruthenia</xsl:attribute>
<xsl:attribute name="beggar">NPCCharacter.beggar_ruthenia</xsl:attribute>
<xsl:attribute name="female_beggar">NPCCharacter.female_beggar_ruthenia</xsl:attribute>
<xsl:attribute name="female_dancer">NPCCharacter.female_dancer_ruthenia</xsl:attribute>
<xsl:attribute name="board_game_type">Chess</xsl:attribute>
<xsl:attribute name="default_battle_equipment_roster">EquipmentRoster.ruthenia_civ_template_default</xsl:attribute>
<xsl:attribute name="default_civilian_equipment_roster">EquipmentRoster.ruthenia_civ_template_default</xsl:attribute>
<xsl:attribute name="duel_preset_equipment_roster">EquipmentRoster.ruthenia_duel_preset_template</xsl:attribute>
<xsl:attribute name="text">{=bLTkig9T}The Ruthenians are an Eastern people inhabiting the lands between the Sturgian forests and the Aserai deserts. Their culture is a blend of steppe traditions and Slavic heritage, reflected in their warfare and shipbuilding. Ruthenian ships are sturdy river vessels, adapted for both commerce and defense along the great waterways of their homeland.</xsl:attribute>
<xsl:attribute name="marriage_bride_equipment_roster">EquipmentRoster.marriage_female_ruthenia_cutscene_template</xsl:attribute>
<xsl:attribute name="default_character_creation_body_property">BodyProperty.default_character_creation_body_property_ruthenia</xsl:attribute>
<xsl:attribute name="start_point_position_x">523</xsl:attribute>
<xsl:attribute name="start_point_position_y">603</xsl:attribute>
<xsl:attribute name="shipwright" namespace="">NPCCharacter.shipwright_ruthenia</xsl:attribute>
<xsl:attribute name="fishing_party_template" namespace="">PartyTemplate.fishing_party_template_ruthenia</xsl:attribute>
<xsl:element name="vassal_reward_items">
<xsl:element name="item">
<xsl:attribute name="id">Item.ruthenia_shield_tier_6_a</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="default_policies">
<xsl:element name="policy">
<xsl:attribute name="id">policy_coastal_guard_edict</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="clan_names">
<xsl:element name="name">
<xsl:attribute name="name">{=VyQz8p2R}Volodymyr</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=mR6cL3sP}Oleg</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=tK9aG2bE}Igor</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=pX7fD5qA}Sviatoslav</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=rB3nW8cT}Yaroslav</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=gH6mK1vF}Vladimir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=uZ9jL4wD}Mstislav</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=iC2pO7rN}Rurik</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=fY5sT3gK}Gleb</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=dA8uQ6bH}Boris</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=jE1vR9mP}Roman</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=kF4wC2nL}David</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=lG5xD8vM}Sergei</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=mH6yJ1qN}Ivan</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=nI7zK5pO}Petr</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="cultural_feats">
<xsl:element name="feat">
<xsl:attribute name="id">ruthenia_river_navigation_bonus</xsl:attribute>
</xsl:element>
<xsl:element name="feat">
<xsl:attribute name="id">ruthenia_cavalry_bonus_in_forest</xsl:attribute>
</xsl:element>
<xsl:element name="feat">
<xsl:attribute name="id">ruthenia_decreased_morale_loss</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="possible_clan_banner_icon_ids">
<xsl:element name="icon">
<xsl:attribute name="id">454</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">455</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">456</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">457</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">458</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">459</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">460</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">461</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">462</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">463</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">464</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">465</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">466</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">467</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">468</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">469</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">470</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">471</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">472</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">473</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">474</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">475</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">476</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">477</xsl:attribute>
</xsl:element>
<xsl:element name="icon">
<xsl:attribute name="id">478</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="notable_templates">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_0</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_0b</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_2b</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_3</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_3b</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_3c</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_4</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_5</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_6</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_7</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_8</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_9</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_notable_ruthenia_10</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_headman_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_headman_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_headman_3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="lord_templates">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_0</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="rebellion_hero_templates">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_0</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_ruthenia_leader_3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="tournament_team_templates_one_participant">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_one_participant_set_v1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_one_participant_set_v2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_one_participant_set_v3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="tournament_team_templates_two_participant">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_two_participant_set_v1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_two_participant_set_v2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_two_participant_set_v3</xsl:attribute>
</xsl:element>
</xsl:element>
<xsl:element name="tournament_team_templates_four_participant">
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_four_participant_set_v1</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_four_participant_set_v2</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_four_participant_set_v3</xsl:attribute>
</xsl:element>
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.tournament_template_ruthenia_four_participant_set_v4</xsl:attribute>
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
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/notable_and_wanderer_templates[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="template">
<xsl:attribute name="name">NPCCharacter.spc_wanderer_ruthenia_0n</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/caravan_party_templates[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="caravan_party_template">
<xsl:attribute name="id">PartyTemplate.naval_caravan_template_ruthenia</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/elite_caravan_party_templates[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="caravan_party_template">
<xsl:attribute name="id">PartyTemplate.elite_naval_caravan_template_ruthenia</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/male_names[1]/name[1]">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'name']" />
<xsl:attribute name="name">{=VyQz8p2R}Volodymyr</xsl:attribute>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/male_names[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="name">
<xsl:attribute name="name">{=mR6cL3sP}Oleg</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=tK9aG2bE}Igor</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=pX7fD5qA}Sviatoslav</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=rB3nW8cT}Yaroslav</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=gH6mK1vF}Vladimir</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=uZ9jL4wD}Mstislav</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=iC2pO7rN}Rurik</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=fY5sT3gK}Gleb</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=dA8uQ6bH}Boris</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=jE1vR9mP}Roman</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=kF4wC2nL}David</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=lG5xD8vM}Sergei</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=mH6yJ1qN}Ivan</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=nI7zK5pO}Petr</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=oJ8aL9qO}Anatoly</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=pK9bM2rP}Dmitri</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=qL1cN3sN}Fyodor</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=rM2dO4tO}Gennady</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=sN3eP5uP}Ilya</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=tO4fQ6vP}Konstantin</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=uP5gR7wP}Maxim</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=vQ6hS8xP}Nikolai</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=wR7iT9yP}Pavel</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=xS8jU0zP}Semyon</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=yT9kV1aP}Vasili</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=zU0lW2bP}Yakov</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/female_names[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="name">
<xsl:attribute name="name">{=hG3fK5nL}Olga</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=iH4gL6mM}Lyudmila</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=jI5hM7nN}Svetlana</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=kJ6iN8oO}Tatiana</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=lJ7jP9pP}Anastasia</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=mK8kQ0qQ}Daria</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=nL9lR1rR}Elena</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=oM2mS2sS}Irina</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=pN3nT3tT}Ksenia</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=qO4oU4uU}Maria</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=rP5pV5vV}Nadezhda</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=sQ6qW6wW}Natalia</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=tR7rX7xX}Oksana</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=uS8sY8yY}Polina</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=vT9tZ9zZ}Sofia</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=wU0u0aA}Valentina</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=xV1v1bB}Varvara</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=yW2w2cC}Vera</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=zX3x3dD}Yekaterina</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=aY4y4eE}Zinaida</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=bZ5z5fF}Anna</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=cA6a6gG}Bella</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=dB7b7hH}Clara</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=eC8c8iI}Diana</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=fD9d9jJ}Emma</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=gE0e0kK}Faith</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=hF1f1lL}Grace</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=iG2g2mM}Hope</xsl:attribute>
</xsl:element>
<xsl:element name="name">
<xsl:attribute name="name">{=jH3h3nN}Jill</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/female_names[1]/name[1]">
<xsl:copy>
<xsl:copy-of select="@*[name() != 'name']" />
<xsl:attribute name="name">{=hG3fK5nL}Olga</xsl:attribute>
<xsl:apply-templates select="node()" />
</xsl:copy>
</xsl:template>
<xsl:template match="/SPCultures[1]/Culture[@id='ruthenia']/available_ship_hulls[1]">
<xsl:copy>
<xsl:copy-of select="@*" />
<xsl:apply-templates select="node()" />
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.northern_medium_ship</xsl:attribute>
</xsl:element>
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.northern_light_ship</xsl:attribute>
</xsl:element>
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.sturgia_heavy_ship</xsl:attribute>
</xsl:element>
<xsl:element name="ship_hull">
<xsl:attribute name="id">ShipHull.northern_trade_ship</xsl:attribute>
</xsl:element>
</xsl:copy>
</xsl:template>
</xsl:stylesheet>