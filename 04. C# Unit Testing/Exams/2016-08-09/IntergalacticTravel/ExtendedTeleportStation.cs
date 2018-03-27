using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel
{
    public class ExtendedTeleportStation : TeleportStation
    {
        public ExtendedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) 
            : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return this.OwnerOfStation;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return this.GalacticMapOfStation;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.LocationOfStation;
            }
        }

        public IResources Resources
        {
            get
            {
                return this.ResourcesOfStation;
            }
        }
    }
}
