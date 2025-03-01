﻿using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace RimBees
{
    public class PlaceWorker_NextToBeeHouse : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
        {
            for (int i = 0; i < 4; i++)
            {
                //IntVec3 c = loc;
                IntVec3 c = loc + GenAdj.CardinalDirections[i];
                 if (i == 0)
                 {
                     c = loc;
                 }
                 else if (i == 1)
                 {
                    c = loc;

                 }
                 else if (i == 2)
                 {
                     c = loc;
                 }
                 else if (i == 3)
                 {
                    c = loc + GenAdj.CardinalDirections[3]; 
                }
                if (c.InBounds(map))
                {
                    List<Thing> thingList = c.GetThingList(map);
                    for (int j = 0; j < thingList.Count; j++)
                    {
                        Thing thing = thingList[j];
                        ThingDef thingDef = GenConstruct.BuiltDefOf(thing.def) as ThingDef;

                        if (thingDef != null && thingDef.building != null)
                        {
                            if (thingDef.building.wantsHopperAdjacent && thing.TryGetComp<CompBeeHouse>().GetIsBeehouse)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return "GU_PlaceNextToBeeHouse".Translate();
        }
    }
}
