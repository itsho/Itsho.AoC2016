using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Itsho.AoC2016.Solutions
{
    public static class Day01Solution
    {
        private enum DirectionEnum
        {
            North = 0,
            West = 1,
            South = 2,
            East = 3
        }

        public static int GetDistanceFromStartingPoint(string p_strRiddleSource, out int? p_intDistanceFromTwiceVisit)
        {
            p_intDistanceFromTwiceVisit = null;
            //string[] arrDirections = { "north", "west", "south", "east" };
            var pntCurrentLoc = new VisitLocation(0, 0, 0);
            var enmCurrCompassDirection = DirectionEnum.North;

            var lstVists = new List<VisitLocation>();
            lstVists.Add(pntCurrentLoc);
            var arrCommands = p_strRiddleSource.Split(' ');
            foreach (var strCommand in arrCommands)
            {
                var strDirection = strCommand[0];
                var intDistance = int.Parse(strCommand.TrimStart(strDirection).TrimEnd(','));
                if (strDirection == 'R')
                {
                    // North(0) + 1 == West(1)
                    // East(3) +1 == North(0)
                    enmCurrCompassDirection = (DirectionEnum)(((int)enmCurrCompassDirection + 1) % 4);
                }
                else
                {
                    // North(0) - 1 == East(3)
                    // East(3) -1 == South(2)
                    enmCurrCompassDirection = (DirectionEnum)(((int)enmCurrCompassDirection + 3) % 4);
                }

                // get destination
                var pntDestination = GetNewLocation(pntCurrentLoc, enmCurrCompassDirection, intDistance, lstVists);

                // add visits in all points in-between
                var intTempDistanceFromTwiceVisit = AddVisits(pntCurrentLoc, intDistance, enmCurrCompassDirection, lstVists);
                if (intTempDistanceFromTwiceVisit != null)
                {
                    p_intDistanceFromTwiceVisit = intTempDistanceFromTwiceVisit;
                }

                // go to destination
                pntCurrentLoc = pntDestination;
            }

            return Math.Abs(pntCurrentLoc.X) + Math.Abs(pntCurrentLoc.Y);
        }

        private static VisitLocation GetNewLocation(VisitLocation p_pntLoc, DirectionEnum p_enmCurrCompassDirection, int p_intDistance, List<VisitLocation> p_lstPreviousVisits)
        {
            var pntResult = new VisitLocation(p_lstPreviousVisits.Count, p_pntLoc.X, p_pntLoc.Y);

            switch (p_enmCurrCompassDirection)
            {
                case DirectionEnum.North:
                    pntResult.X += p_intDistance;
                    break;

                case DirectionEnum.West:
                    pntResult.Y += p_intDistance;
                    break;

                case DirectionEnum.South:
                    pntResult.X -= p_intDistance;
                    break;

                case DirectionEnum.East:
                    pntResult.Y -= p_intDistance;
                    break;
            }
            return pntResult;
        }

        private static int? AddVisits(VisitLocation p_pntSource, int p_intSteps, DirectionEnum p_enmCurrCompassDirection, List<VisitLocation> p_lstPreviousVisits)
        {
            int? intInnerDistanceFromTwiceVisit = null;

            // we skip first location and include LAST step
            // the single first location is added manually
            for (int intCurrVisit = 1; intCurrVisit <= p_intSteps; intCurrVisit++)
            {
                var pntVisitDuringJurney = GetNewLocation(p_pntSource, p_enmCurrCompassDirection, intCurrVisit, p_lstPreviousVisits);
                p_lstPreviousVisits.Add(pntVisitDuringJurney);

                // no need to add destination as visit point since we already did it as part of AddVisit
                if (intInnerDistanceFromTwiceVisit == null)
                {
                    foreach (var pntVisit in p_lstPreviousVisits)
                    {
                        if (p_lstPreviousVisits.Any(p => p.ID != pntVisit.ID && 
                                                            p.X == pntVisit.X && 
                                                            p.Y == pntVisit.Y))
                        {
                            intInnerDistanceFromTwiceVisit = Math.Abs(pntVisit.X) + Math.Abs(pntVisit.Y);
                            break;
                        }
                    }
                }
            }
            return intInnerDistanceFromTwiceVisit;
        }

        [DebuggerDisplay("{ID} {X} {Y}")]
        private class VisitLocation
        {
            public VisitLocation(int p_id, int p_x, int p_y)
            {
                ID = p_id;
                X = p_x;
                Y = p_y;
            }

            public int ID { get; private set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}