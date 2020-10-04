using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public static class Riddles
{

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// Easy Riddles
    /// /////////////////////////////////////////////////////////////////
    /// </summary>
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
                "actor",
                "actors",
                "actress",
                "actresses"
            },
            new List<string>()
            {
                "you see them in movies",
                "some get paid a lot of money",
                "they play make believe for a living"
            }),
        new Riddle(0,
            new List<string>()
            {
                "february",
            },
            new List<string>()
            {
                "it's a month",
                "sometimes gets and extra day",
                "something about a silent letter"
            }),
        new Riddle(0,
            new List<string>()
            {
                "skateboard",
                "skateboards"
            },
            new List<string>()
            {
                "piece of wood with four wheels",
                "you can kickflip it",
                "something about tony..."
            }),
        new Riddle(0,
            new List<string>()
            {
                "charity"
            },
            new List<string>()
            {
                "give them money for a good cause",
                "helps those in need",
                "philanthropy"
            }),
        new Riddle(0,
            new List<string>()
            {
                "sock",
                "socks"
            },
            new List<string>()
            {
                "put it on my foot",
                "keeps my toesies warm",
                "goes in my shoe"
            }),
        new Riddle(0,
            new List<string>()
            {
                "math",
                "maths",
                "mathematics"
            },
            new List<string>()
            {
                "my favorite subject in school",
                "two plus two",
                "four times four"
            }),
        new Riddle(0,
            new List<string>()
            {
                "ladder",
                "ladders"
            },
            new List<string>()
            {
                "mine is made of wood",
                "has rungs",
                "helps me climb things"
            }),
        new Riddle(0,
            new List<string>()
            {
                "salad",
                "salads"
            },
            new List<string>()
            {
                "a bunch of green veggies",
                "in a bowl",
                "smothered in ranch"
            }),
        new Riddle(0,
            new List<string>()
            {
                "lake",
                "lakes"
            },
            new List<string>()
            {
                "lots of water",
                "usually large, usually circular",
                "some of them are great"
            }),
        new Riddle(0,
            new List<string>()
            {
                "oven",
                "ovens"
            },
            new List<string>()
            {
                "big box",
                "gets real hot",
                "makes my frozen pizza really good"
            }),
        new Riddle(0,
            new List<string>()
            {
                "bread",
                "breads"
            },
            new List<string>()
            {
                "flour, yeast, water, salt",
                "kneaded into a dough",
                "great for sandwiches"
            }),
        new Riddle(0,
            new List<string>()
            {
                "herb",
                "herbs"
            },
            new List<string>()
            {
                "basil",
                "thyme",
                "rosemary",
                "parsley",
                "cilantro",
                "dill",
                "oregano",
                "what are these things"
            }),



    };


    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// Medium Riddles
    /// /////////////////////////////////////////////////////////////////
    /// </summary>
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
        new Riddle(1,
            new List<string>()
            {
                "celebrate",
                "celebration",
                "celebrations"
            },
            new List<string>()
            {
                "party",
                "good times",
                "laughter",
                "come on!"
            }),
        new Riddle(1,
            new List<string>()
            {
                "needle",
                "needles"
            },
            new List<string>()
            {
                "has one eye",
                "can poke yours out"
            }),
         new Riddle(1,
            new List<string>()
            {
                "mood",
                "moods"
            },
            new List<string>()
            {
                "state of mind",
                "it can be good or bad",
                "i'm not in a great one today"
            }),
         new Riddle(1,
            new List<string>()
            {
                "friendship",
                "friend",
                "friends"
            },
            new List<string>()
            {
                "when you like someone",
                "and they like you too",
                "but, like, platonically"
            }),
         new Riddle(1,
            new List<string>()
            {
                "poet",
                "poets"
            },
            new List<string>()
            {
                "person that rhymes",
                "does it with paper, line by line",
                "doesn't even need a beat"
            }),
         new Riddle(1,
            new List<string>()
            {
                "director",
                "directors"
            },
            new List<string>()
            {
                "the dude that's in charge on a movie set",
                "bosses actors around",
            }),
         new Riddle(1,
            new List<string>()
            {
                "argument",
                "arguments",
                "debate",
                "debates"
            },
            new List<string>()
            {
                "when two people are fighting with words",
                "heated",
                "trying to persuade, usually in vain"
            }),
         new Riddle(1,
            new List<string>()
            {
                "grandmother",
                "grandmothers",
                "grandma",
                "grandmas"
            },
            new List<string>()
            {
                "your mother's brother's mom",
                "your brother's cousin's mom's mom",
                "your great-grandpa's son's wife"
            }),
         new Riddle(1,
            new List<string>()
            {
                "history",
                "histories"
            },
            new List<string>()
            {
                "the events that have happened",
                "you're making it right now"
            }),
         new Riddle(1,
            new List<string>()
            {
                "elevator",
                "elevators",
                "escalator",
                "escalators"
            },
            new List<string>()
            {
                "going upward",
                "standing still",
                "without leaving the building"
            }),
         new Riddle(1,
            new List<string>()
            {
                "thing",
                "things"
            },
            new List<string>()
            {
                "it's... like... an object",
                "like, any object...",
                "we all have many of them"
            }),
         new Riddle(1,
            new List<string>()
            {
                "amazon"
            },
            new List<string>()
            {
                "a rainforest",
                "a corporation",
                "a female warrior"
            }),
         new Riddle(1,
            new List<string>()
            {
                "textbook",
                "textbooks"
            },
            new List<string>()
            {
                "the book that you read, but not for fun",
                "educational",
                "why did mine cost four hundred dollars"
            }),
         new Riddle(1,
            new List<string>()
            {
                "count",
                "counting"
            },
            new List<string>()
            {
                "keep track of how many things there are, one by one",
                "learned very early in life"
            }),
         new Riddle(1,
            new List<string>()
            {
                "pew"
            },
            new List<string>()
            {
                "the sound of a deadly laser",
                "where churchgoers sit"
            }),
         new Riddle(1,
            new List<string>()
            {
                "cursor",
                "cursors"
            },
            new List<string>()
            {
                "the mouse pointer on a computer",
                "or is it someone who swears a lot..."
            }),
         new Riddle(1,
            new List<string>()
            {
                "vacuum",
                "vacuums"
            },
            new List<string>()
            {
                "a great way to clean a carpet",
                "a great way to clear a spaceship"
            }),
         new Riddle(1,
            new List<string>()
            {
                "stool",
                "stools"
            },
            new List<string>()
            {
                "a handy wooden chair to sit on",
                "a really smelly gathering of waste"
            }),
         new Riddle(1,
            new List<string>()
            {
                "frost"
            },
            new List<string>()
            {
                "it has to be really cold outside",
                "when the morning dew freezes",
                "layered on car windows"
            }),
         new Riddle(1,
            new List<string>()
            {
                "typewriter"
            },
            new List<string>()
            {
                "the grandfather of keyboards",
                "ding!",
                "really hard to erase..."
            }),
         new Riddle(1,
            new List<string>()
            {
                "ludumdare",
                "ld47",
                "ludumdare47"
            },
            new List<string>()
            {
                "it took me three hours to decide on this game idea",
                "my game turned out pretty close to how i planned it in my head, that's pretty cool",
                "i've been up for over 26 hours... rookie numbers, i know...",
                "answer hint: the best game jam",
                "this is the last riddle i typed",
                "wish i had more time to add more art",
                "I would have liked to fill out the town a bit more",
                "I'm not totally in love with the music I made",
                "i hope your game turned out well!",
                "i wish i had more time to add more riddles!!!",
                "i'm really happy with how much i was able to accomplish this jam",
                "have a nice day! thanks for playing my game!",
            }),


    };

    /// <summary>
    /// /////////////////////////////////////////////////////////////////
    /// Hard Riddles
    /// /////////////////////////////////////////////////////////////////
    /// </summary>
    private readonly static List<Riddle> HardRiddles = new List<Riddle>()
    {
        new Riddle(2,
            new List<string>()
            {
                "assumption",
                "assumptions"
            },
            new List<string>()
            {
                "prejudice",
                "true without proof",
                "you think you know"
            }),
        new Riddle(2,
            new List<string>()
            {
                "success"
            },
            new List<string>()
            {
                "accomplishment",
                "achieving desired aims",
                "attaining prosperity",
                "attaining goals"
            }),
        new Riddle(2,
            new List<string>()
            {
                "equipment"
            },
            new List<string>()
            {
                "all my gear",
                "necessary items",
                "probably some unnecessary items too"
            }),
        new Riddle(2,
            new List<string>()
            {
                "perspective"
            },
            new List<string>()
            {
                "the way you look at things",
                "a type of drawing",
                "can be distorted"
            }),
        new Riddle(2,
            new List<string>()
            {
                "advertising",
                "advertisement",
                "advertisements",
                "advertise",
                "advertises"
            },
            new List<string>()
            {
                "on my tv all the time",
                "not a commercial, it's the thing that commercials do",
                "they're so annoying"
            }),
        new Riddle(2,
            new List<string>()
            {
                "responsible",
                "responsibility",
                "responsibilities"
            },
            new List<string>()
            {
                "the things you have to do even when you don't want to",
                "duty",
                "accountable",
                "accepting fault when you're to blame"
            }),
         new Riddle(2,
            new List<string>()
            {
                "cabinet",
                "cabinets"
            },
            new List<string>()
            {
                "or a wooden storage box",
                "or a group of politicians",
            }),
         new Riddle(2,
            new List<string>()
            {
                "revolution",
                "revolutions"
            },
            new List<string>()
            {
                "360 degrees",
                "or a social uprising",
            }),
         new Riddle(2,
            new List<string>()
            {
                "explanation",
                "explanations"
            },
            new List<string>()
            {
                "i'm trying to make one right now",
                "using my words to tell you the facts",
            }),
         new Riddle(2,
            new List<string>()
            {
                "opportunity",
                "opportunities"
            },
            new List<string>()
            {
                "you only get one shot, do not miss your chance",
                "circumstances make it possible to do something",
                "lose yourself in the music... err... forget that"
            }),
         new Riddle(2,
            new List<string>()
            {
                "transition",
                "transitions"
            },
            new List<string>()
            {
                "refocusing your life",
                "fade out and fade in"
            }),
         new Riddle(2,
            new List<string>()
            {
                "harmony",
                "harmonies"
            },
            new List<string>()
            {
                "why a chord sounds really nice",
                "when they all sing together"
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


