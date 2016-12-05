using System;
using System.Collections.Generic;
using System.Drawing;

namespace Itsho.AoC2016.Solutions
{
    public static class Day01Solution
    {
        private enum DirectionEnum
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }

        private static readonly HashSet<Point> _lstVistedPoints = new HashSet<Point>();

        public static int GetPart1DistanceFromStartingPoint(string p_strRiddleSource)
        {
            return Solve(p_strRiddleSource, false);
        }

        public static int GetPart2DistanceFromAlreadyVisit(string p_strRiddleSource)
        {
            return Solve(p_strRiddleSource, true);
        }

        private static int Solve(string p_strRiddleSource, bool p_blnIsPart2)
        {
            _lstVistedPoints.Clear();
            int intDistanceFromAlreadyVisitResult = 0;
            var pntCurrentLoc = new Point();
            var enmCurrCompassDirection = DirectionEnum.North;

            _lstVistedPoints.Add(pntCurrentLoc);
            var arrCommands = p_strRiddleSource.Split(' ');
            bool blnAlreadyVisitFound = false;

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
                    enmCurrCompassDirection = (DirectionEnum)((int)(enmCurrCompassDirection + 3) % 4);
                }

                // get destination
                var pntDestination = GetNewLocation(pntCurrentLoc, enmCurrCompassDirection, intDistance);

                if (p_blnIsPart2 && !blnAlreadyVisitFound)
                {
                    // add visits for all steps in-between
                    var intDistanceFromAlreadyVisit = AddVisits(pntCurrentLoc, intDistance, enmCurrCompassDirection);
                    if (intDistanceFromAlreadyVisit != null)
                    {
                        blnAlreadyVisitFound = true;
                        intDistanceFromAlreadyVisitResult = intDistanceFromAlreadyVisit.Value;
                    }
                }

                // go to destination
                pntCurrentLoc = pntDestination;
            }

            if (p_blnIsPart2)
            {
                return intDistanceFromAlreadyVisitResult;
            }
            // part1 - get distance from
            return Math.Abs(pntCurrentLoc.X) + Math.Abs(pntCurrentLoc.Y);
        }

        private static Point GetNewLocation(Point p_pntLoc, DirectionEnum p_enmCurrCompassDirection, int p_intDistance)
        {
            var pntResult = new Point(p_pntLoc.X, p_pntLoc.Y);

            switch (p_enmCurrCompassDirection)
            {
                // 0
                case DirectionEnum.North:
                    pntResult.X += p_intDistance;
                    break;

                // 1
                case DirectionEnum.East:
                    pntResult.Y += p_intDistance;
                    break;

                //2
                case DirectionEnum.South:
                    pntResult.X -= p_intDistance;
                    break;

                //3
                case DirectionEnum.West:
                    pntResult.Y -= p_intDistance;
                    break;
            }
            return pntResult;
        }

        private static int? AddVisits(Point p_pntSource, int p_intSteps, DirectionEnum p_enmCurrCompassDirection)
        {
            // we SKIP the FIRST location but INCLUDE LAST step
            // the single first location is added manually
            for (int intCurrVisit = 1; intCurrVisit <= p_intSteps; intCurrVisit++)
            {
                var pntVisitDuringJurney = GetNewLocation(p_pntSource, p_enmCurrCompassDirection, intCurrVisit);

                // if found location already visited
                if (_lstVistedPoints.Contains(pntVisitDuringJurney))
                {
                    return Math.Abs(pntVisitDuringJurney.X) + Math.Abs(pntVisitDuringJurney.Y);
                }

                // otherwise, add to list
                _lstVistedPoints.Add(pntVisitDuringJurney);
            }
            return null;
        }
    }
}