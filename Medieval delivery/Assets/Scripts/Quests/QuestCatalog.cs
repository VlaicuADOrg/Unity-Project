using System.Collections.Generic;
using UnityEngine;

public static class QuestCatalog
{
    public static List<Quest> BuildPool(string giverKey)
    {
        switch (giverKey)
        {
            case "Coin": return AlienPool();
            case "StarCoin": return PriestessPool();
            case "Star": return WitchStarPool();
            case "Diamando": return WitchDiamandoPool();

            case "Trophy": return CavemanPool();

            case "Diamando 1": return FarmerManPool();
            case "Thunder1": return FarmerWomanPool();
            case "Heart": return PeasantWomanPool();

            case "DoubleDiamond": return SilkJadePool();

            case "Thunder": return RangerHunterPool();

            case "Skull": return AssassinPool();
            case "StarGem3": return Assassin2Pool();

            case "SpeedChevRed": return SoldierPool();
            case "Hexagon": return Soldier2Pool();

            case "StarGem1": return PiratePool();

            case "SpeedChevYellow": return SmithWarriorPool();

            case "SpeedChevBlue": return SmallGirlPool();
            case "SphereGem": return SmallBoyPool();

            case "Time": return GnomePool();

            case "SpeedChevYellow 1": return WizardPool();

            default: return CommonPool(giverKey);
        }
    }

    

    public static string BuildGiveQuestText(string giverKey, string displayName, Quest q)
    {
        if (giverKey == "Coin")
        {
            return
                "⟟⟒⟟… ϞϞϞ… zra’keth ul-mora… ⟊⟊⟊\n" +
                "⟊⟒⟟⟟ ᚦᚱᚨ… vuu’ra kesh’nai… ⟟⟟⟟\n" +
                "⟒⟒⟒… shii’toor… kraa’ven… ⟊⟊⟊\n" +
                "⟟⟊⟟… raa’thuul… ⟒⟟⟟⟟… Ϟ…\n" +
                "⟊⟊⟊… (it keeps repeating the same gestures, faster and faster)\n\n" +
                $"REQUIREMENT: {q.itemCount}x {q.itemName} (tag: {q.itemTag})\n" +
                $"You can find those {q.findHint}\n\n" +
                "⟟⟟⟟… ⟒⟒⟒… ⟊⟊⟊…\n" +
                "Press any key/click to close.";
        }

        string intro = giverKey switch
        {
            "StarCoin" => "She speaks with calm authority, like a noble blessing the common folk.",
            "Star" => "She smiles like she already knows what you’ll say, and her potion bottles clink softly.",
            "Diamando" => "Her charms and crystals sway as she studies you like a specimen.",
            "Trophy" => "He grins wide and thumps his chest like it’s a war drum.",
            "Skull" or "StarGem3" => "He keeps his voice low, eyes scanning the shadows behind you.",
            "StarGem1" => "A salty laugh, a coin flip, and a look that says ‘profit’.",
            "SpeedChevYellow" => "Hot iron, soot, and a serious stare—this one lives by the forge.",
            "SpeedChevRed" or "Hexagon" => "Straight posture. Short words. Military patience.",
            "Thunder" => "A hunter’s gaze—measuring tracks, wind, and your worth.",
            "Heart" => "Tired eyes, kind voice. She looks like she’s had a hard week.",
            "Diamando 1" or "Thunder1" => "Hands rough from work. They speak like every minute matters.",
            "Time" => "A tiny figure with a big attitude, speaking like a master craftsman.",
            "SpeedChevBlue" or "SphereGem" => "Excited, bouncing, like it’s a game… but they mean it.",
            "SpeedChevYellow 1" => "A hooded mage, careful with words and even more careful with secrets.",
            "DoubleDiamond" => "Elegant and precise, like every request is a small ceremony.",
            _ => "They step closer, clearly needing something."
        };

        return
            $"{displayName}:\n{intro}\n\n" +
            $"{q.text}\n\n" +
            $"REQUIREMENT: {q.itemCount}x {q.itemName} (tag: {q.itemTag})\n" +
            $"You can find those {q.findHint}\n\n" +
            "Press any key/click to close.";
    }

    public static string BuildBusyText(string giverKey, string displayName, Quest q)
    {
        if (giverKey == "Coin")
        {
            return
                "⟊⟒⟒… Ϟ… Ϟ… ⟟⟟⟟\n" +
                "⟒⟟⟟⟊… shaa’keth… shaa’keth… ⟊⟊⟊\n" +
                "⟟⟊⟟… (it points at you, then makes a sharp ‘bring it’ motion)\n\n" +
                $"Still missing: {q.itemCount}x {q.itemName}\n" +
                $"You can find those {q.findHint}";
        }

        string line = giverKey switch
        {
            "StarCoin" => "Not yet. Fulfill the vow you took first.",
            "Star" or "Diamando" => "Don’t waste my time. Bring what I asked for—then we talk.",
            "Trophy" => "NO. First you finish what I told you. Then we do more!",
            "Skull" or "StarGem3" => "First the job. Then the conversation.",
            "StarGem1" => "Don’t drift, sailor. Finish the deal you started.",
            "SpeedChevRed" or "Hexagon" => "Order stands. Complete it before requesting another.",
            "SpeedChevYellow" => "Forge waits for no one. Bring the parts.",
            "Thunder" => "Tracks go cold. Come back with what I asked for.",
            _ => "Finish the other quest first."
        };

        return
            $"{displayName}:\n{line}\n\n" +
            $"Still missing: {q.itemCount}x {q.itemName} (tag: {q.itemTag})\n" +
            $"You can find those {q.findHint}";
    }

    public static string BuildTurnInText(string giverKey, string displayName, Quest q)
    {
        if (giverKey == "Coin")
            return "⟟⟟⟟… ⟒⟟⟒… ϞϞ… (it seems satisfied)";

        string line = giverKey switch
        {
            "StarCoin" => "Well done. The town will remember this service.",
            "Star" or "Diamando" => "Perfect… exactly what I needed. Magic doesn’t wait.",
            "Trophy" => "YES! That’s how it’s done! Strong work!",
            "Skull" or "StarGem3" => "Clean. Quiet. Good.",
            "StarGem1" => "Heh… you’re useful. Come back when you want real treasure.",
            "SpeedChevRed" or "Hexagon" => "Turn-in confirmed. Good work.",
            "SpeedChevYellow" => "Good. This will hold. This will last.",
            "Thunder" => "Excellent. Now I can move on to the next trail.",
            "Heart" => "Thank you… truly.",
            _ => "Quest completed."
        };

        return $"{displayName}:\n{line}";
    }

    public static string BuildNoQuestText(string giverKey, string displayName)
    {
        if (giverKey == "Coin")
        {
            return
                "⟟⟟⟟… ⟟⟟…\n" +
                "⟒⟒⟒… Ϟ… Ϟ…\n" +
                "⟊⟊⟊… (it stares into the distance, then slowly stops moving)\n" +
                "⟟⟊⟟… ul-mora… (no more requests… for now)";
        }

        string line = giverKey switch
        {
            "StarCoin" => "For now, I have nothing else for you.",
            "Star" or "Diamando" => "No more. Come back later… or don’t.",
            "Trophy" => "DONE! Nothing new today. Go eat. Rest.",
            "Skull" or "StarGem3" => "Not today.",
            "StarGem1" => "Out of work. Rare problem for me.",
            "SpeedChevRed" or "Hexagon" => "No new orders.",
            "SpeedChevYellow" => "Forge is quiet. For now.",
            "Thunder" => "No more leads right now.",
            _ => "I have no more quests."
        };

        return $"{displayName}:\n{line}";
    }

    

    public static List<Quest> PickRandomSubset(List<Quest> pool, int min, int max)
    {
        var copy = Clone(pool);

        int minClamped = Mathf.Clamp(min, 1, copy.Count);
        int maxClamped = Mathf.Clamp(max, minClamped, copy.Count);

        int take = Random.Range(minClamped, maxClamped + 1);

        for (int i = 0; i < copy.Count; i++)
        {
            int j = Random.Range(i, copy.Count);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }

        copy.RemoveRange(take, copy.Count - take);
        return copy;
    }

    private static List<Quest> Clone(List<Quest> src)
    {
        var list = new List<Quest>(src.Count);
        foreach (var q in src)
        {
            list.Add(new Quest
            {
                text = q.text,
                findHint = q.findHint,
                itemTag = q.itemTag,
                itemName = q.itemName,
                itemCount = q.itemCount,
                isActive = false,
                isCompleted = false
            });
        }
        return list;
    }

    
    private static Quest Q(string request, string hint, string tag, string name, int count)
        => new Quest { text = request, findHint = hint, itemTag = tag, itemName = name, itemCount = count };

    

    private static List<Quest> AlienPool() => new()
    { 
    Q(
        "⟊⟒⟟⟟… vruu’keth… ⟟⟟⟟ ϞϞϞ\n" +
        "⟒⟒⟒… raa’thuul… shii’toor… ⟊⟊⟊\n" +
        "⟟⟊⟟… (it taps your chest twice, then points at the ground and makes a ‘collect’ motion)\n" +
        "⟊⟊⟊… ul-mora… ul-mora… ⟟⟟⟟",
        "somewhere in the forest near a few wells, and around the supply crates in the Isolated Village.",
        "AncientCoin", "Old Coins", 5),

    Q(
        "⟒⟟⟟⟊… sha’nair… ⟊⟊⟊ ϞϞϞ\n" +
        "⟟⟊⟟… (it rubs two stones together like it wants them to ‘sing’)\n" +
        "⟒⟒⟒… kraa’ven… kraa’ven… ⟟⟟⟟",
        "along the riverbank gravel, on rocky paths outside the village, and inside nearby caves.",
        "PrettyStone", "Shiny Stones", 4),

    Q(
        "⟟⟊⟟… kesh’kesh… ⟒⟒⟒\n" +
        "⟊⟊⟊… (it makes a wing-flap gesture, then points at black feathers like they’re important)\n" +
        "⟟⟟⟟… vuu’ra… ⟊⟊⟊",
        "around dead trees at the forest edge, and in the part of the village closest to the treeline.",
        "Feather", "Feathers", 6),

      // harder / rarer
    Q(
        "ϞϞ… ⟒⟒⟒… dra’kesh… ⟊⟊⟊\n" +
        "⟟⟊⟟… (it draws a symbol in the air and looks annoyed when you don’t understand)\n" +
        "⟒⟒⟒… ul-mora… ⟟⟟⟟",
        "in the Isolated Village beyond the mountains, inside the mountain cave, and near the old stone circle in the woods or the narrow canyon.",
        "RelicFragment", "Strange Relic Fragment", 1),
    };


    private static List<Quest> PriestessPool() => new()
    {
    Q(
        "The shrine must not go dark tonight. People will come seeking comfort, and I won’t have them praying in shadows.\n" +
        "Bring me enough candles to last the evening service.",
        "in the chapel storage, on the tavern counter, and at market stalls near the town square.",
        "Candle", "Candles", 5),

    Q(
        "An incense burner is required for the morning rite. If the smoke does not rise, the blessing will not carry.\n" +
        "Do not return empty-handed.",
        "in village taverns, on the apothecary shelves, and in a shop in the noble quarter.",
        "IncenseBurner", "Incense Burner", 3),

    Q(
        "Royal parchments require proper seal wax. Cheap wax cracks, and broken seals invite scandal.\n" +
        "Bring me two solid blocks—no crumbs.",
        "at the Wizard's Tower, in the tavern in the Fishermen’s Village, or in the castle.",
        "RoyalSealWax", "Seal Wax", 1),

    // harder
    Q(
        "A silver chalice was borrowed for the holy table and never returned. I need a replacement before the next ceremony.\n" +
        "Find a proper silver cup—no tin pretending to be noble.",
        "in the Central Village tavern's storage, or deep inside the Crystal Cave.",
        "SilverChalice", "Silver Chalice", 2),

    Q(
        "One of our prayer bead strings snapped and scattered. I need a full set again—every bead matters.\n" +
        "Bring them carefully, and make sure none are missing.",
        "on the benches around the village square, at the Wizard's Tower, or in the castle.",
        "PrayerBeads", "Prayer Beads", 1),
    };



    private static List<Quest> WitchStarPool() => new()
    {
    Q(
        "Bring me forest mushrooms—ones that grow in the shade. I need them for a brew that keeps nightmares away.\n" +
        "Don’t crush them. I’ll know.",
        "under fallen logs in the forest, near the damp mouths of Dragon’s Cave, and behind the old houses near the Dwarves’ Village.",
        "Mushroom", "Forest Mushrooms", 4),

    Q(
        "Empty vials. Magic doesn’t travel in your hands.\n" +
        "Bring sturdy ones—thin glass cracks under pressure.",
        "at the Wizard's Tower, in tavern storage crates, and around the ruins outside the village.",
        "EmptyVial", "Empty Vials", 3),

    // harder
    Q(
        "Mandrake root. A real one. If it screams, you found it.\n" +
        "Handle it with cloth, not bare skin.",
        "in the dark forest patch beyond the farms, in the mountains where the air feels cold, and near the old stone circle.",
        "MandrakeRoot", "Mandrake Root", 1),

    Q(
        "I need a drop of toad-eye jelly. Disgusting, yes. Effective, also yes.\n" +
        "Bring me two.",
        "on the small island in the middle of the lake, under wet river rocks, and near the swampy pools outside the village.",
        "ToadEye", "Toad Eyes", 2),
    };

    private static List<Quest> WitchDiamandoPool() => new()
    {
    Q(
        "Mint leaves. They smell lovely, but they’re even better in potions.\n" +
        "Bring enough for a clean infusion.",
        "on a small grassy patch near the lake’s shore, around flat stones by the water, and along the riverside path.",
        "MintLeaves", "Mint Leaves", 3),

    Q(
        "Two black candles. The circle won’t draw itself.\n" +
        "Do not bring ordinary candles dyed with soot—those are useless.",
        "at a shady market stall, on the witch hut shelves, and at the campfires in the River Village.",
        "BlackCandle", "Black Candles", 2),

    // harder
    Q(
        "A moonstone. Small is fine, but it must be real—cold to the touch and bright in the dark.\n" +
        "It’s for a warding charm.",
        "inside the Crystal Cave outside the village, and sometimes near rocky river bends at night.",
        "Moonstone", "Moonstone", 1),
    };


    private static List<Quest> CavemanPool() => new()
    {
    Q(
        "HIDES! Thick hides! Make strong armor!\n" +
        "You bring hides, I make you proud!",
        "near the butcher’s shed, along forest hunting trails on the Island in the lake, and around wolf territory at the forest edge.",
        "Hide", "Animal Hides", 4),

    Q(
        "WOLF TEETH! Look scary! Look strong!\n" +
        "Need more teeth for necklace!",
        "inside wolf dens in the forest, near the hunter’s camp, and along the rocky trail by the mountain pass.",
        "WolfTooth", "Wolf Teeth", 3),

    Q(
        "CHEST KEY! Key for treasure!\n" +
        "Find key, bring key, we celebrate!",
        "in bandit camp crates, behind the tavern counter, and on the guardhouse desk.",
        "ChestKey", "Rusty Keys", 1),

    // harder
    Q(
        "BOAR TUSKS! Sharp! Good trophy!\n" +
        "Bring two special tusks!",
        "near muddy forest paths, close to farm fences outside the village, and around boar dens deep in the woods.",
        "BoarTusk", "Boar Tusks", 2),
    Q(
        "CHEST! BIG CHEST! Big treasure!\n" +
        "Find chest, bring chest, we celebrate!",
        "in bandit camp crates, or in the Dragon's cave",
        "DragonChest", "Dragon Chest", 1),
    };

    private static List<Quest> FarmerManPool() => new()
    {
    Q(
        "Someone stole our best pumpkin… and the harvest festival is coming.\n" +
        "Bring me the biggest pumpkin you can find, or we’ll be the laughing stock of the next village.",
        "in farm fields,behind houses in villages, and along wagon routes near the village.",
        "GiantPumpkin", "Giant Pumpkin", 1),

    Q(
        "We lost horseshoes on the road. The cart can’t move right and the horse is limping.\n" +
        "Bring three—proper iron ones.",
        "at the stables, in the blacksmith area, and on the muddy road outside the village gate.",
        "Horseshoe", "Horseshoes", 3),

    Q(
        "Eggs for the fair—careful not to crack them.\n" +
        "We need enough to bake for the whole street.",
        "in chicken coops, in farm yards, and in baskets near the tavern kitchen.",
        "Egg", "Eggs", 7),
    };


    private static List<Quest> FarmerWomanPool() => new()
    {
    Q(
        "Bring fresh milk—children are hungry.\n" +
        "If it’s sour, don’t bother coming back with it.",
        "near cow pens, inside farmhouses, and in the taverns in villages.",
        "Milk", "Milk Jars", 2),

    Q(
        "Hay bales for the stable. The animals are restless when the straw runs out.\n" +
        "Bring enough so I can stack it high.",
        "inside barns, along field edges, and stacked on carts near the farm road.",
        "HayBale", "Hay Bales", 3),

    Q(
        "Apples for pies—good ones.\n" +
        "No bruised fruit. I’m not feeding bruises to my family.",
        "in orchards near the village, in market crates in the Mountains Village, and on carts near the entrance road.",
        "AppleBasket", "Apples", 1),

    // harder
    Q(
        "Goat cheese. Proper aged cheese—not watery curds.\n" +
        "Bring one wheel and don’t let it melt in your pack.",
        "in farm pantries, at market dairy stalls, and sometimes in the tavern kitchen storage.",
        "GoatCheese", "Goat Cheese", 1),

    Q(
        "A jar of honey. The kind that still smells like flowers.\n" +
        "We’ll use it for remedies and for sweet bread.",
        "near beehives outside the village, at market sweet stalls, and in the tavern pantry.",
        "HoneyJar", "Honey Jar", 1),
    };


    private static List<Quest> PeasantWomanPool() => new()
    {
    Q(
        "Please… bring bread. Just a little.\n" +
        "We’ve been stretching meals for days and the kids can tell.",
        "in the tavern kitchen, at a bakery stall, and in crates near the market square.",
        "Bread", "Bread", 2),

    Q(
        "Soap… we need soap.\n" +
        "The river helps, but not enough. People talk.",
        "by the wash areas in the villages, on apothecary shelves, and in market baskets.",
        "Soap", "Soap", 2),

    Q(
        "Cloth for clothing repairs. Winter is coming.\n" +
        "If the seams split again, we won’t make it through the cold.",
        "around the villages on crates, and in the wash area in the villages ",
        "Cloth", "Cloth", 4),

    // harder-ish
    Q(
        "A warm blanket. One. Just one.\n" +
        "If you find it in a chest somewhere… I won’t ask questions.",
        "inside abandoned houses, in the tavern, and sometimes in the guardhouse spare supplies.",
        "WarmBlanket", "Warm Blanket", 1),

    Q(
        "Candles for the evening. The dark makes everything feel worse.\n" +
        "Bring a couple, please.",
        "in the chapel, on the tavern counter, and at market stalls or at some campfires.",
        "Candle", "Candles", 3),
    };


    private static List<Quest> SilkJadePool() => new()
    {
    Q(
        "Mint tea leaves for honored guests.\n" +
        "If the aroma is weak, the whole ceremony suffers.",
        "on tavern tables, at spice stalls in the market, and near herb patches along the forest path.",
        "MintTeaLeaves", "Mint Tea Leaves", 3),

    Q(
        "Lantern oil. The nights are long, and the streets are not forgiving.\n" +
        "One bottle is enough—if it’s clean oil.",
        "in tavern storage, in the blacksmith’s supply room, and on merchant carts by the road.",
        "LanternOil", "Lantern Oil", 1),

    // harder
    Q(
        "A porcelain vase—intact. Not chipped, not cracked.\n" +
        "It’s for a proper table display.",
        "in the Pirate Village, inside well-kept homes, and in locked chests near the market square.",
        "PorcelainVase", "Porcelain Vase", 1),

    Q(
        "Two hairpin—small, elegant, and real.\n" +
        "Bring it discreetly.A golden and a silver one please",
        "at a high-end market stall, in noble drawers, and sometimes around the village.",
        "Hairpin", "Hairpin", 2),
    };

    private static List<Quest> RangerHunterPool() => new()
    {
    Q(
        "Arrowheads. I won’t hunt with dull points.\n" +
        "Bring enough for a full day on the trail.",
        "at the blacksmith, in the guardhouse supply rack, and around the Mountain Village.",
        "Arrowhead", "Arrowheads", 8),

    Q(
        "Feathers for fletching. Plenty.\n" +
        "If the arrows wobble, you die.",
        "in chicken coops, near forest nests, and around the hunting lodge or under the trees.",
        "Feather", "Feathers", 7),

    Q(
        "Bandages. Even a scratch can kill.\n" +
        "Bring clean ones—not muddy rags.",
        "at the apothecary, in the guardhouse, and in village taverns (near storage crates).",
        "Bandage", "Bandages", 5),

    // harder
    Q(
        "Trap parts—springs, jaws, anything usable.\n" +
        "I’m setting a line of snares near the pass.",
        "near the blacksmith’s workshop, inside hunter caches in the forest, and in bandit camp tool piles.",
        "TrapParts", "Trap Parts", 2),

    Q(
        "Antlers. Two. The good kind.\n" +
        "I’ll carve them into grips.",
        "near deer trails in the woods, by rocky clearings, and around the hunting lodge outskirts.",
        "Antler", "Antlers", 2),

    Q(
        "Expedition gear. It’s crucial for survival.\n" +
        "Rope, tools, spare string—anything that keeps a hunter alive when the weather turns.",
        "at the hunter’s lodge on the sea island, inside the lodge’s storage chests, and in supply crates near the island docks.",
        "Equipment", "Expedition Gear", 1),

    Q(
        "A backpack for long treks.\n" +
        "Leather, sturdy straps, strong stitching—no flimsy sacks.",
        "at the hunter’s lodge on the sea island, at the island’s small leatherwork shed, and on merchant crates arriving at the docks.",
        "Backpack", "Backpack", 1),

    };

    private static List<Quest> AssassinPool() => new()
    {
    Q(
        "A sealed letter. Don’t open it.\n" +
        "If the seal is broken, the job is ruined.",
        "on the courthouse desk, inside a noble mailbox, or hidden in a quiet tavern.",
        "SealedLetter", "Sealed Letter", 1),

    Q(
        "A small workbench for preparing smoke powder.\n" +
        "Keep it intact, and keep it hidden.",
        "at the wizard tower, in the Isolated Village, or inside a few houses in the River Village.",
        "PowderWorkbench", "Smoke Powder Workbench", 1),

    // harder
    Q(
        "Caltrops. One bag.\n" +
        "They stop pursuit. Fast.",
        "at a shady market vendor, inside bandit supplies, and sometimes in sealed crates near the road.",
        "Caltrops", "Caltrops", 1),

    Q(
        "A small poison vial.\n" +
        "Do not smell it. Do not spill it.",
        "in witch huts, at the apothecary, and in a hidden cave stash near the village.",
        "PoisonVial", "Poison Vial", 1),

    Q(
        "A lockpick set. Quiet hands need quiet tools.\n" +
        "Don’t bring me bent junk—bring the kind kept in a black pouch.",
        "in thief hideouts, in tavern upstairs rooms, and at the market alley vendor.",
        "LockpickMaster", "Lockpick Master Set", 1),
    };

    private static List<Quest> Assassin2Pool() => new()
    {
    Q(
        "A lockpick set. Quiet hands need quiet tools.\n" +
        "Don’t bring me bent junk.",
        "in thief hideouts, inside the tavern’s upstairs chest, and at the market alley vendor or at some campfiers in the Gnome's Village.",
        "Lockpick", "Lockpick Set", 1),

    Q(
        "Leather straps for sheaths.\n" +
        "Thin, strong, and clean.",
        "in the blacksmith yard, at the stables, and in leather bundles stored in barns and sheds.",
        "LeatherStrap", "Leather Straps", 3),

    };

    private static List<Quest> SoldierPool() => new()
    {
    Q(
        "Arrow bundles for the watch.\n" +
        "Night patrol is short on supplies—don’t keep us waiting.",
        "on the guardhouse rack, in the blacksmith’s supply crates, and at the training yard.",
        "ArrowBundle", "Arrow Bundles", 1),

    Q(
        "Horseshoes for the garrison horses.\n" +
        "If a horse goes down, the whole patrol slows.",
        "at the stables, near the blacksmith’s work area, and on the muddy road outside the gate.",
        "Horseshoe", "Horseshoes", 3),

    // harder
    Q(
        "Weapon oil. One bottle.\n" +
        "Rust is the enemy that never sleeps.",
        "in blacksmith storage, in the guardhouse supply chest, and on merchant carts or taverns near the road.",
        "WeaponOil", "Weapon Oil", 1),

    Q(
        "Apple pies. Enough for a shift.\n" +
        "Hot food keeps morale up—bring three.",
        "in tavern storage, in the guardhouse supplies, and in market food crates.",
        "ApplePie", "Apple Pies", 3),
    };

    private static List<Quest> Soldier2Pool() => new()
    {
    Q(
        "Spearheads. We’re short.\n" +
        "Bring solid steel, not brittle scrap.",
        "on the blacksmith bench, in barracks storage, and in caravan weapon crates.",
        "Spearhead", "Spearheads", 2),

    Q(
        "Shield straps. They snap too easily.\n" +
        "I need them reinforced.",
        "at the leatherworker stall, in barracks gear piles, and in the blacksmith yard.",
        "ShieldStrap", "Shield Straps", 3),

    Q(
        "Bandages for the wounded. Lots.\n" +
        "Clean ones. I’m not sewing dirt into people.",
        "at the apothecary, in the guardhouse, and near the tavern’s first-aid box.",
        "Bandage", "Bandages", 6),

    // harder
    Q(
        "Chain links. A handful.\n" +
        "We’re repairing a gate lock and it needs real iron chain.",
        "near blacksmith scrap bins, in construction crates, and sometimes in bandit loot piles.",
        "ChainLinks", "Chain Links", 4),
    };


    private static List<Quest> PiratePool() => new()
    {
    Q(
        "Map fragments. Treasure doesn’t find itself.\n" +
        "Bring me enough pieces and I’ll stitch the route together.",
        "on tavern gamblers’ tables, in bandit camps, and in ruined houses near the river road or in some taverns.",
        "MapFragment", "Map Fragment", 2),

    Q(
        "Rope. Good rope.\n" +
        "If it snaps, someone dies. Simple as that.",
        "near dockside rope piles by the river, in stable storage sheds, and on merchant carts.",
        "Rope", "Rope", 3),

    // harder
    Q(
        "A spyglass. One clean piece.\n" +
        "I need to see trouble before it sees me.",
        "at merchant trinket stalls, in noble storage boxes, and inside ship cargo crates near the tavern back room.",
        "Spyglass", "Spyglass", 1),

    Q(
        "A brass compass. Real brass, real needle.\n" +
        "Knows where you are. No toys.",
        "at a high-end market stall, at the wizard tower, or at the hunter’s lodge.",
        "BrassCompass", "Brass Compass", 1),
    };



    private static List<Quest> SmithWarriorPool() => new()
    {
    Q(
        "Iron ingots. Without iron, there is no blade.\n" +
        "Bring enough and I’ll make something that lasts.",
        "in blacksmith shelves, in mine carts, and in forge storage crates.",
        "IronIngot", "Iron Ingots", 3),

    Q(
        "Charcoal. The forge drinks it.\n" +
        "If the coals die, the steel dies with them.",
        "at the woodcutter camp, in the kiln behind the village, and in blacksmith storage sacks.",
        "Charcoal", "Charcoal", 5),

    Q(
        "Nails. Lots of them.\n" +
        "Repairs don’t wait for ‘later’.",
        "on the blacksmith floor, in the carpentry shed, and at construction crates near the village.",
        "Nails", "Nails", 12),

    Q(
        "Quenching oil. One bottle.\n" +
        "A blade needs a proper temper—no shortcuts.",
        "on the blacksmith bench, in merchant supplies, and in the taverns.",
        "QuenchOil", "Quenching Oil", 1),

    // harder
    Q(
        "Copper ingots. Not iron—steel.\n" +
        "I’m forging something for a serious fighter.",
        "in a mine chest, inside guarded merchant crates, and sometimes in bandit weapon stashes.",
        "CopperIngot", "Copper Ingots", 2),
    Q(
        "Brass ingots. Not iron—steel.\n" +
        "I’m forging something for a serious fighter.",
        "in a mine chest, inside guarded merchant crates, and sometimes in bandit weapon stashes.",
        "BrassIngot", "Brass Ingots", 2),
    };


    private static List<Quest> SmallGirlPool() => new()
    {
    Q(
        "Please bring me pretty Christmas ornaments! I want to decorate the little tree near our house.\n" +
        "If they’re shiny, even better—I want it to sparkle when the lanterns are lit!",
        "in the market gift stalls, inside the tavern’s decoration box, and near the chapel’s festive corner or just around the village.",
        "Ornament", "Christmas Ornaments", 5),

    Q(
        "Can you bring me a small wrapped gift? Just one!\n" +
        "I want to surprise someone, but I’m too small to carry big things.",
        "at the market gift stall, in the carpenter’s workshop near small boxes, and in the tavern storage by the shelves.",
        "SmallGift", "Small Wrapped Gift", 1),
    };


    private static List<Quest> SmallBoyPool() => new()
    {

    Q(
        "I need a wooden toy sword… but I want it to look like a REAL knight sword!\n" +
        "It’s for my Christmas present, so make sure it’s a good one.",
        "in the carpenter shed, at the market toy stall, and near training yard scraps where wood is left behind.",
        "WoodenSword", "Wooden Toy Sword", 1),

    Q(
        "Bring me a Christmas bell! Just one bell.\n" +
        "I want to attach it to a present so it jingles when someone shakes it!",
        "at the market trinket stalls, near the tavern counter, and inside the chapel’s decoration box or in the Gnome's Village.",
        "JingleBell", "Jingle Bell", 1),
    };


    private static List<Quest> GnomePool() => new()
    {
    Q(
        "Tiny bells! Very important. Extremely important.\n" +
        "If they don’t ring clean, they’re useless.",
        "at market trinket stalls, on the tavern counter, and in the chapel decoration box.",
        "TinyBell", "Tiny Bells", 2),

    Q(
        "Little keys. Any little keys.\n" +
        "I’m definitely not opening anything I shouldn’t. Definitely.",
        "in the tavern lost-and-found, on the guardhouse desk, and in old chests in ruined houses or at old wells.",
        "SmallKey", "Small Keys", 2),

    // harder-ish but medieval
    Q(
        "Tiny gears. Two. I need them for a… pocket device.\n" +
        "Don’t laugh. It’s science. Or magic. Or both.",
        "in the clockmaker/carpenter area, inside broken cart parts, and in a chest in the tavern storage room or at the broken boat.",
        "TinyGear", "Tiny Gears", 2),
    };


    private static List<Quest> WizardPool() => new()
    {
    Q(
        "Rune scrolls. Intact. Do not crease them.\n" +
        "If the ink line breaks, the spell breaks.",
        "on the mage tower shelves, in the chapel library, and on a noble’s study desk or at the bandits camp.",
        "RuneScroll", "Rune Scrolls", 2),

    Q(
        "Magical Staff. A special one.\n" +
        "A staff that is made of crystals",
        "at the Dragon's Cave or in the Crystal Cave",
        "CrystalStaff", "Crystal Staff", 1),

    // harder
    Q(
        "Special gears. Just two—for a magical mechanism.\n" +
        "If you bring me rusty ones, I will know.",
        "in rare merchant stock, in the Gnome Village workshop, and sometimes as a trophy in a bandit leader’s loot.",
        "SpecialGears", "Special Gears", 2),

    Q(
        "Gold ingots. I need them for alchemy.\n" +
        "Bring enough, and I’ll grant you a water-walking charm to reach the sea island.\n" +
        "To use it, face the island from the mountain shore and walk straight toward it.",
        "in rare merchant stock, in crates near the wrecked boat, and deep inside the Crystal Cave.",
        "GoldIngot", "Gold Ingots", 7),
    };


    private static List<Quest> CommonPool(string who) => new()
    {
        Q("Bring me candles.",
          "in the chapel, on the tavern counter, and at market stalls.",
          "Candle", "Candles", 1),

        Q("Bring me bread.",
          "in the tavern kitchen, at the bakery stall, and in market crates.",
          "Bread", "Bread", 1),

        Q("Bring me cloth.",
          "in the tailor shop, on laundry lines behind houses, and on merchant wagons.",
          "Cloth", "Cloth", 1),
    };
}
