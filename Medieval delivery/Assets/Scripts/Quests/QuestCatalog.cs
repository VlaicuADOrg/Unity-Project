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

    // ---------- UI text builders ----------

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

    // ---------- Random subset ----------

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

    // Helper that keeps hint separate and always prints as "You can find those ..."
    private static Quest Q(string request, string hint, string tag, string name, int count)
        => new Quest { text = request, findHint = hint, itemTag = tag, itemName = name, itemCount = count };

    // ---------- POOLS (examples for all your characters) ----------

    private static List<Quest> AlienPool() => new()
    {
        Q("⟊⟒⟟⟟… vruu’keth… ⟟⟟⟟",
          "in the tavern floor corners, under loose planks near the village well, and inside abandoned carts by the road.",
          "AncientCoin", "Old Coins", 4),

        Q("⟒⟟⟟⟊… sha’nair… ⟊⟊⟊ ϞϞϞ",
          "along the riverbank gravel, on rocky paths outside the village, and near cliff edges beyond the farms.",
          "PrettyStone", "Shiny Stones", 3),

        Q("⟟⟊⟟… kesh’kesh… ⟒⟒⟒",
          "around dead trees near the forest, behind the graveyard fence, and beside bandit camp leftovers.",
          "BlackFeather", "Black Feathers", 5),

        Q("⟊⟊⟊… druu’mor… ⟟⟟⟟",
          "near old battlefields, at the entrance of dark caves, and close to predator dens in the woods.",
          "Bone", "Large Bones", 3),

        Q("⟒⟒⟒… ul’vra… ⟊⟊⟊",
          "by hunting trails, beside campfires outside the village, and near the butcher’s shed.",
          "Hide", "Animal Hides", 2),

        Q("Ϟ… Ϟ… ⟟⟟⟟…",
          "in stable storage, near the blacksmith’s work area, and inside small chests behind the tavern.",
          "LeatherStrap", "Leather Straps", 3),
    };

    private static List<Quest> PriestessPool() => new()
    {
        Q("The shrine must not go dark. Bring me clean candles for tonight’s prayers.",
          "in the chapel storage, on the tavern counter, and at market stalls near the town square.",
          "Candle", "Candles", 4),

        Q("Incense is required for the morning rite. Do not return empty-handed.",
          "in the chapel, at the apothecary shelves, and in a noble quarter shop.",
          "Incense", "Incense", 3),

        Q("Royal parchments need proper seal wax. Bring me two blocks.",
          "in the scribe’s hut, on courthouse shelves, and inside a chest in the tavern back room.",
          "SealWax", "Seal Wax", 2),
    };

    private static List<Quest> WitchStarPool() => new()
    {
        Q("Bring me forest mushrooms—ones that grow in shadow. I need them for a bubbling brew.",
          "under fallen logs in the forest, in damp cave mouths near the village, and behind the old mill.",
          "Mushroom", "Forest Mushrooms", 3),

        Q("Spider silk. Without it, my potion won’t bind.",
          "inside abandoned huts, in cellar corners under the tavern, and near cave entrances under cliffs.",
          "SpiderSilk", "Spider Silk", 3),

        Q("Empty vials. Magic doesn’t travel in your hands.",
          "on apothecary shelves, in tavern storage crates, and inside chests in ruined houses.",
          "EmptyVial", "Empty Vials", 2),
    };

    private static List<Quest> WitchDiamandoPool() => new()
    {
        Q("I need rare herbs for a careful ritual. Don’t bruise them.",
          "along the forest edge near the village, near the old stone circle, and behind the apothecary.",
          "HerbBundle", "Rare Herbs", 4),

        Q("Nightshade leaves. Touch your eyes and you’ll regret it.",
          "near swampy patches, around graveyard outskirts, and in shaded woods behind the chapel.",
          "Nightshade", "Nightshade", 2),

        Q("Two black candles. The circle won’t draw itself.",
          "at a shady market stall, in witch hut shelves, and in the tavern cellar under the stairs.",
          "BlackCandle", "Black Candles", 2),
    };

    private static List<Quest> CavemanPool() => new()
    {
        Q("HIDES! Thick hides! Make strong armor!",
          "by hunting trails, near the butcher shed, and around wolf territory in the forest.",
          "Hide", "Animal Hides", 3),

        Q("WOLF TEETH! Look scary! Look strong!",
          "inside wolf dens, near hunter cabins, and at carcass sites in the woods.",
          "WolfTooth", "Wolf Teeth", 2),

        Q("CHEST KEY! Key for treasure!",
          "in bandit camp crates, behind the tavern counter, and on the guardhouse desk.",
          "ChestKey", "Rusty Keys", 1),
    };

    private static List<Quest> FarmerManPool() => new()
    {
        Q("Someone stole our best pumpkin… bring me the biggest one you can find.",
          "in farm fields, inside barns behind houses, and along wagon routes near the village.",
          "Pumpkin", "Big Pumpkin", 1),

        Q("We lost horseshoes on the road. Bring three.",
          "at the stables, in the blacksmith area, and on the muddy road outside the village gate.",
          "Horseshoe", "Horseshoes", 3),

        Q("Eggs for the fair—careful not to crack them.",
          "in chicken coops, in farm yards, and in baskets near the tavern kitchen.",
          "Egg", "Eggs", 6),
    };

    private static List<Quest> FarmerWomanPool() => new()
    {
        Q("Bring fresh milk—children are hungry.",
          "near cow pens, inside farmhouses, and on a merchant cart near the gate.",
          "Milk", "Milk Jars", 2),

        Q("Hay bales for the stable.",
          "inside barns, along field edges, and stacked on carts near the farm road.",
          "HayBale", "Hay Bales", 2),

        Q("Apples for pies—good ones.",
          "in orchards near the village, in market crates, and on carts near the entrance road.",
          "Apple", "Apples", 4),
    };

    private static List<Quest> PeasantWomanPool() => new()
    {
        Q("Please… bring bread. Just a little.",
          "in the tavern kitchen, at a bakery stall, and in crates near the market square.",
          "Bread", "Bread", 2),

        Q("Soap… we need soap.",
          "by the river wash area, on apothecary shelves, and in market baskets.",
          "Soap", "Soap", 2),

        Q("Cloth for clothing repairs. Winter is coming.",
          "in the tailor hut, on laundry lines behind houses, and on merchant wagons.",
          "Cloth", "Cloth", 3),
    };

    private static List<Quest> SilkJadePool() => new()
    {
        Q("Bring fine silk for embroidery—no rough fabric.",
          "in noble quarter shops, on merchant caravans, and in the tailor’s hidden stock.",
          "Silk", "Silk Roll", 2),

        Q("Tea leaves for honored guests.",
          "at market spice stalls, in noble pantry boxes, and on trader wagons.",
          "TeaLeaves", "Tea Leaves", 3),

        Q("Lantern oil. The nights are long.",
          "in the tavern cellar, in blacksmith storage, and on merchant carts by the road.",
          "LanternOil", "Lantern Oil", 1),
    };

    private static List<Quest> RangerHunterPool() => new()
    {
        Q("Arrowheads. I won’t hunt with dull points.",
          "at the blacksmith, in the guardhouse supply rack, and in bandit camp leftovers.",
          "Arrowhead", "Arrowheads", 6),

        Q("Feathers for fletching. Plenty.",
          "in chicken coops, near forest nests, and around the hunting lodge.",
          "Feather", "Feathers", 6),

        Q("Bandages. Even a scratch can kill.",
          "at the apothecary, in the guardhouse, and near the tavern’s healer corner.",
          "Bandage", "Bandages", 4),
    };

    private static List<Quest> AssassinPool() => new()
    {
        Q("A sealed letter. Don’t open it.",
          "on the courthouse desk, inside a noble mailbox, and in a guard post satchel.",
          "SealedLetter", "Sealed Letter", 1),

        Q("Smoke powder. Don’t light it.",
          "on alchemist shelves, in bandit camp barrels, and in hidden crates behind the tavern.",
          "SmokePowder", "Smoke Powder", 2),

        Q("Black cloth. No bright stitches.",
          "in the tailor back room, at a shady market stall, and in the tavern cellar.",
          "BlackCloth", "Black Cloth", 3),
    };

    private static List<Quest> Assassin2Pool() => new()
    {
        Q("A lockpick set. Quiet hands need quiet tools.",
          "in thief hideouts, inside the tavern upstairs chest, and at the market alley vendor.",
          "Lockpick", "Lockpick Set", 1),

        Q("A small poison vial.",
          "in witch huts, at the apothecary, and in a hidden cave stash near the village.",
          "PoisonVial", "Poison Vial", 1),

        Q("Leather straps for sheaths.",
          "in the blacksmith yard, at the stables, and in bandit camp crates.",
          "LeatherStrap", "Leather Straps", 2),
    };

    private static List<Quest> SoldierPool() => new()
    {
        Q("Arrow bundles for the watch.",
          "on the guardhouse rack, in blacksmith supplies, and at the training yard.",
          "ArrowBundle", "Arrow Bundles", 3),

        Q("Armor rivets. A fistful.",
          "near the forge scrap bins, on the blacksmith floor, and in training yard crates.",
          "Rivet", "Armor Rivets", 8),

        Q("Horseshoes for the garrison horses.",
          "at the stables, in the blacksmith area, and on the muddy road outside the gate.",
          "Horseshoe", "Horseshoes", 3),
    };

    private static List<Quest> Soldier2Pool() => new()
    {
        Q("Spearheads. We’re short.",
          "on the blacksmith bench, in barracks storage, and in caravan weapon crates.",
          "Spearhead", "Spearheads", 2),

        Q("Shield straps. They snap too easily.",
          "at the leatherworker stall, in barracks gear piles, and in the blacksmith yard.",
          "ShieldStrap", "Shield Straps", 2),

        Q("Bandages for the wounded. Lots.",
          "at the apothecary, in the guardhouse, and near the tavern’s first-aid box.",
          "Bandage", "Bandages", 5),
    };

    private static List<Quest> PiratePool() => new()
    {
        Q("Map fragments. Treasure doesn’t find itself.",
          "on tavern gamblers’ tables, in bandit camps, and in ruined houses near the river road.",
          "MapFragment", "Map Fragment", 2),

        Q("A rusty chest key.",
          "in bandit camp crates, in the tavern back room, and on the guardhouse desk.",
          "ChestKey", "Rusty Key", 1),

        Q("Old coins. Always useful.",
          "in tavern floor corners, in abandoned carts, and around graveyard rubble.",
          "AncientCoin", "Old Coins", 4),
    };

    private static List<Quest> SmithWarriorPool() => new()
    {
        Q("Iron ingots. Without iron, there is no blade.",
          "in blacksmith shelves, in mine carts, and in forge storage crates.",
          "IronIngot", "Iron Ingots", 3),

        Q("Charcoal. The forge drinks it.",
          "at the woodcutter camp, in the kiln behind the village, and in blacksmith storage sacks.",
          "Charcoal", "Charcoal", 4),

        Q("Nails. Lots of them.",
          "on the blacksmith floor, in the carpentry shed, and at construction crates near the village.",
          "Nails", "Nails", 10),
    };

    private static List<Quest> SmallGirlPool() => new()
    {
        Q("Please bring me pretty wildflowers!",
          "in meadows near the village, along the forest edge, and beside riverbank paths.",
          "Wildflower", "Wildflowers", 5),

        Q("I lost my ribbon… if you find it…",
          "on tavern benches, in the market alley, and near the village well.",
          "Ribbon", "Ribbon", 1),

        Q("Honey cookies… if anyone sells them.",
          "in the tavern kitchen, at the bakery stall, and on the market sweets cart.",
          "HoneyCookie", "Honey Cookies", 2),
    };

    private static List<Quest> SmallBoyPool() => new()
    {
        Q("Pine cones! I’m collecting them!",
          "on the forest floor, near tall pines, and behind the village lumber pile.",
          "PineCone", "Pine Cones", 4),

        Q("A wooden sword! A real one!",
          "in the carpenter shed, at the market toy stall, and in training yard scraps.",
          "WoodenSword", "Wooden Sword", 1),

        Q("Flat stones for skipping!",
          "on the riverbank, beside shallow creeks, and near lakeside paths outside the village.",
          "FlatStone", "Flat Stones", 5),
    };

    private static List<Quest> GnomePool() => new()
    {
        Q("Tiny bells! Very important. Extremely important.",
          "at market trinket stalls, on the tavern counter, and in the chapel decoration box.",
          "TinyBell", "Tiny Bells", 2),

        Q("Small nails. Not big nails. SMALL nails.",
          "in the carpenter shed, on the blacksmith floor, and in construction crates.",
          "SmallNails", "Small Nails", 12),

        Q("Little keys. Any little keys.",
          "in the tavern lost-and-found, on the guardhouse desk, and in old chests in ruined houses.",
          "SmallKey", "Small Keys", 2),
    };

    private static List<Quest> WizardPool() => new()
    {
        Q("Rune scrolls. Intact. Do not crease them.",
          "in the mage tower shelves, in the chapel library, and on the noble study desk.",
          "RuneScroll", "Rune Scrolls", 2),

        Q("Spell ink. One bottle.",
          "at the apothecary, in the scribe hut, and on the wizard’s study table.",
          "SpellInk", "Spell Ink", 1),

        Q("Empty vials for elixirs.",
          "on apothecary shelves, in tavern storage crates, and in ruined house chests.",
          "EmptyVial", "Empty Vials", 3),
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
