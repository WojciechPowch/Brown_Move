/**
 * Author: Wojciech Powch
 * About (PL): Klasa generuje tablicę wartości współbieżnych [x, y] symulujący ruchy Brown'a.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownElement
{
    public enum FunctionType
    {
        SIN,
        COS
    }

    class BrownMovements
    {
        private int movementsCount;
        private Coordinate initialCoordinates;
        private List<Coordinate> bufor;

        private double randomNumber;

        private Random random;

        public BrownMovements(int movementsCount)
        {
            this.movementsCount = movementsCount;
        }

        public void MakeSimulation()
        {
            this.initialCoordinates = GetInitialPosition();
            BuildBrownElementWay();
        }

        private Coordinate GetInitialPosition()
        {
            double x = 0;
            double y = 0;
            return new Coordinate(x, y);
        }

        private void BuildBrownElementWay()
        {
            bufor = new List<Coordinate>();

            for (int i = 0; i < movementsCount; i++)
            {
                randomNumber = GetRandomNumber();

                if (bufor.Count == 0)
                {
                    ProvideCalculateAction(this.initialCoordinates);
                }
                else
                {
                    Coordinate lastCoordinates = GetLastBuforElement();
                    ProvideCalculateAction(lastCoordinates);
                }
            }
        }

        private void ProvideCalculateAction(Coordinate lastCoordinates)
        {
            double effectiveX = lastCoordinates.X;
            double effectiveY = lastCoordinates.Y;

            CalculateNextCoordinate(ref effectiveX, randomNumber, FunctionType.COS);
            CalculateNextCoordinate(ref effectiveY, randomNumber, FunctionType.SIN);

            bufor.Add(new Coordinate(effectiveX, effectiveY));
        }

        private void CalculateNextCoordinate(ref double effectiveValue, double randomNumber, FunctionType functionType)
        {
            switch (functionType)
            {
                case FunctionType.SIN:
                    effectiveValue += Math.Sin(randomNumber);
                    break;
                case FunctionType.COS:
                    effectiveValue += Math.Cos(randomNumber);
                    break;
            }
        }

        private Coordinate GetLastBuforElement()
        {
            return bufor[GetLastBuforIndex()];
        }

        private int GetLastBuforIndex()
        {
            return bufor.Count - 1;
        }

        private double GetRandomNumber()
        {
            random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(0, Int32.MaxValue);
        }

        public List<Coordinate> GetElementWay()
        {
            return this.bufor;
        }
    }
}
