using System.Collections.Generic;

using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Tests.CustomExceptions;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests.Mocks
{
    public class PackageRepositoryMock : PackageRepository
    {
        public PackageRepositoryMock(ILogger logger, ICollection<IPackage> packages = null) 
            : base(logger, packages)
        {
        }

        public override bool Update(IPackage package)
        {
            throw new UpdateMethodCalledException("The update method is called");
        }
    }
}
