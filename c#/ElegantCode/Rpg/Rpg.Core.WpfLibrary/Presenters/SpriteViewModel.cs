using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.Presenter;
using Rpg.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rpg.Core.WpfLibrary
{
    public class WorldPresenter : IPresenter<World, IEnumerable<SpriteViewModel>>
    {
        public void PresentData(World data)
        {
            throw new NotImplementedException();
        }

        public void PresentError(Error error)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<SpriteViewModel> Entity, Error Error)> View(CancellationToken cancelToken = default)
        {
            throw new NotImplementedException();
        }
    }
}