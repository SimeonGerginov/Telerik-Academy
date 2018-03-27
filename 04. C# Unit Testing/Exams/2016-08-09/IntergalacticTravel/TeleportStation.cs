using System;
using System.Collections.Generic;
using System.Linq;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Extensions;

namespace IntergalacticTravel
{
    public class TeleportStation : ITeleportStation
    {
        protected readonly IResources ResourcesOfStation;
        protected readonly IBusinessOwner OwnerOfStation;
        protected readonly ILocation LocationOfStation;
        protected readonly IEnumerable<IPath> GalacticMapOfStation;

        public TeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
        {
            this.OwnerOfStation = owner;
            this.GalacticMapOfStation = galacticMap;
            this.LocationOfStation = location;
            this.ResourcesOfStation = new Resources();
        }

        public void TeleportUnit(IUnit unitToTeleport, ILocation targetLocation)
        {
            IPath pathToTheTargetPlanet;

            this.ValidateThatTeleportationServiceIsApplicable(unitToTeleport, targetLocation, out pathToTheTargetPlanet);

            this.GetPayment(pathToTheTargetPlanet, unitToTeleport);

            this.ChangeUnitLocation(pathToTheTargetPlanet, unitToTeleport, targetLocation);
        }

        public IResources PayProfits(IBusinessOwner owner)
        {
            if (this.OwnerOfStation.IdentificationNumber != owner.IdentificationNumber)
            {
                throw new UnauthorizedAccessException("Payments are allowed only to the owner");
            }

            var payment = this.ResourcesOfStation.Clone();
            this.ResourcesOfStation.Clear();

            return payment;
        }

        private void ChangeUnitLocation(IPath pathToTheTargetPlanet, IUnit unitToTeleport, ILocation targetLocation)
        {
            pathToTheTargetPlanet.TargetLocation.Planet.Units.Add(unitToTeleport);
            unitToTeleport.CurrentLocation.Planet.Units.Remove(unitToTeleport);
            unitToTeleport.PreviousLocation = unitToTeleport.CurrentLocation;
            unitToTeleport.CurrentLocation = targetLocation;
        }

        private void GetPayment(IPath pathToTheTargetPlanet, IUnit unitToTeleport)
        {
            var cost = pathToTheTargetPlanet.Cost;
            var payment = unitToTeleport.Pay(cost);
            this.ResourcesOfStation.Add(payment);
        }

        private bool LocationsMatch(ILocation firstLocation, ILocation secondLocation)
        {
            return firstLocation.Planet.Galaxy.Name == secondLocation.Planet.Galaxy.Name &&
                firstLocation.Planet.Name == secondLocation.Planet.Name;
        }

        private bool LocationsAndCoordinatesMatch(ILocation firstLocation, ILocation secondLocation)
        {
            return firstLocation.Coordinates.Latitude == secondLocation.Coordinates.Latitude &&
                firstLocation.Coordinates.Longtitude == secondLocation.Coordinates.Longtitude &&
                this.LocationsMatch(firstLocation, secondLocation);
        }

        private void ValidateThatTeleportationServiceIsApplicable(IUnit unitToTeleport, ILocation targetLocation, out IPath pathToTheTargetPlanet)
        {
            if (unitToTeleport.IsNull())
            {
                throw new ArgumentNullException("unitToTeleport");
            }

            if (targetLocation.IsNull())
            {
                throw new ArgumentNullException("destination");
            }

            if (!this.LocationsMatch(this.LocationOfStation, unitToTeleport.CurrentLocation))
            {
                throw new TeleportOutOfRangeException("unitToTeleport.CurrentLocation");
            }

            var pathsToTheTargetGalaxy = this.GalacticMapOfStation
                .Where(path => path.TargetLocation.Planet.Galaxy.Name == targetLocation.Planet.Galaxy.Name)
                .ToList();
            if (pathsToTheTargetGalaxy.IsNullOrEmpty())
            {
                throw new LocationNotFoundException("A path to a Galaxy with the provided name cannot be found in the TeleportStation's galactic map.");
            }

            pathToTheTargetPlanet = pathsToTheTargetGalaxy.FirstOrDefault(path => path.TargetLocation.Planet.Name == targetLocation.Planet.Name);
            if (pathToTheTargetPlanet.IsNull())
            {
                throw new LocationNotFoundException("A path to a Planet with the provided name cannot be found in the TeleportStation's galactic map.");
            }

            foreach (var unitInCity in pathToTheTargetPlanet.TargetLocation.Planet.Units)
            {
                if (this.LocationsAndCoordinatesMatch(targetLocation, unitInCity.CurrentLocation))
                {
                    throw new InvalidTeleportationLocationException("There is already a unit placed on the desired location. Cannot activate the teleportation service because the units will overlap.");
                }
            }

            if (!unitToTeleport.CanPay(pathToTheTargetPlanet.Cost))
            {
                throw new InsufficientResourcesException("The unit cannot be teleported, because THERE AIN'T NO SUCH THING AS A FREE LUNCH.");
            }
        }
    }
}
