using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public static class Riddles
{
    public readonly static List<Riddle> EasyRiddles = new List<Riddle>()
    {
        new Riddle(
            new List<string>()
            { 
                "riddle1easy", 
                "riddleoneeasy"
            }, 
            new List<string>()
            { 
                "test hint riddle 1 easy",
                "test hint 2 riddle 1 easy"
            }),
        new Riddle(
            new List<string>()
            {
                "riddle2easy",
                "riddletwoeasy"
            },
            new List<string>()
            {
                "test hint ridde 2 easy",
                "test hint 2 riddle 2 easy"
            }),
    };

    public readonly static List<Riddle> MediumRiddles = new List<Riddle>()
    {
        new Riddle(
            new List<string>()
            {
                "riddle1medium",
                "riddleonemedium"
            },
            new List<string>()
            {
                "test hint riddle 1",
                "test hint 2 riddle 1"
            }),
        new Riddle(
            new List<string>()
            {
                "riddle2medium",
                "riddletwomedium"
            },
            new List<string>()
            {
                "test hint ridde 2 medium",
                "test hint 2 riddle 2 medium"
            }),
    };

    public readonly static List<Riddle> HardRiddles = new List<Riddle>()
    {
        new Riddle(
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
        new Riddle(
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
}


