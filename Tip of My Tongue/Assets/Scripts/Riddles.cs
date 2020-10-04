using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public static class Riddles
{
    private readonly static List<Riddle> EasyRiddles = new List<Riddle>()
    {
        new Riddle(0,
            new List<string>()
            { 
                "red"
            }, 
            new List<string>()
            { 
                "the top of the rainbow",
                "firetrucks",
                "anger, anger, anger!",
                "love"
            }),
        new Riddle(0,
            new List<string>()
            {
                "blue",
            },
            new List<string>()
            {
                "color of the sky",
                "coldness",
                "the ocean",
                "sadness"
                
            }),
        new Riddle(0,
            new List<string>()
            {
                "shirt",
                "shirts",
                "tshirt",
                "tshirts",
                "teeshirt",
                "teeshirts"
            },
            new List<string>()
            {
                "piece of clothing",
                "on my torso",
                "short sleeves",
                "long sleeves",
            }),
        new Riddle(0,
            new List<string>()
            {
                "riddle3easy",
                "riddlethreeeasy"
            },
            new List<string>()
            {
                "test hint riddle 3 easy",
                "test hint 2 riddle 3 easy"
            }),
        new Riddle(0,
            new List<string>()
            {
                "riddle4easy",
                "riddlefoureasy"
            },
            new List<string>()
            {
                "test hint ridde 4 easy",
                "test hint 2 riddle 4 easy"
            }),
    };

    private readonly static List<Riddle> MediumRiddles = new List<Riddle>()
    {
        new Riddle(1,
            new List<string>()
            {
                "height",
                "heights"
            },
            new List<string>()
            {
                "the measurement I use for myself",
                "tallness",
                "feet and inches",
                "top of the mountain"
            }),
        new Riddle(1,
            new List<string>()
            {
                "confusion",
                "confused", 
                "confuse"
            },
            new List<string>()
            {
                "i'm feeling it right now",
                "can't remember anything",
                "who are you",
                "who am i",
                "where am i",
                "what am i"
            }),
        new Riddle(1,
            new List<string>()
            {
                "bath",
                "baths",
            },
            new List<string>()
            {
                "where i clean myself",
                "not a shower",
                "a giant bucket of water i climb into",
                "soap and bubbles",
            }),
        
        new Riddle(1,
            new List<string>()
            {
                "river",
                "rivers",
            },
            new List<string>()
            {
                "rushing water",
                "rapids or gentle",
                "a creek all grown up",
                "i went tubin' last week",
            }),
        new Riddle(1,
            new List<string>()
            {
                "government",
                "governments",
            },
            new List<string>()
            {
                "the organization in charge",
                "they're watching us",
                "power",
                "corruption",
                "authority",
                "legislation"
            }),
        new Riddle(1,
            new List<string>()
            {
                "language",
                "languages",
            },
            new List<string>()
            {
                "what we use to speak",
                "the collection of all words",
                "I've read the entire dictionary",
                "Differs in many places",
            }),
        new Riddle(1,
            new List<string>()
            {
                "menu",
                "menus",
            },
            new List<string>()
            {
                "whatcha gonna eat",
                "list of all dishes",
                "food and prices",
                "dang, that's expensive",
                "lets try something new",
            }),
        new Riddle(1,
            new List<string>()
            {
                "thought",
                "thoughts",
            },
            new List<string>()
            {
                "i have a million in my mind",
                "a sudden idea",
                "sit deep in one",
                "does my brain make them or do they come from somewhere else"
            }),
    };

    private readonly static List<Riddle> HardRiddles = new List<Riddle>()
    {
        new Riddle(2,
            new List<string>()
            {
                "riddle1hard",
                "riddleonehard"
            },
            new List<string>()
            {
                "test hint riddle 1 hard",
                "test hint 2 riddle 1 hard"
            }),
        new Riddle(2,
            new List<string>()
            {
                "riddle2hard",
                "riddletwohard"
            },
            new List<string>()
            {
                "test hint ridde 2 hard",
                "test hint 2 riddle 2 hard"
            }),
    };

    public static List<Riddle> GetEasyRiddles()
    {
        return EasyRiddles.ToList();
    }

    public static List<Riddle> GetMediumRiddles()
    {
        return MediumRiddles.ToList();
    }

    public static List<Riddle> GetHardRiddles()
    {
        return HardRiddles.ToList();
    }
}


