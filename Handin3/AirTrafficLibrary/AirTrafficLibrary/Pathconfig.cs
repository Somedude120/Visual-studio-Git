using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficLibrary.Interface;
using TransponderReceiver;

namespace AirTrafficLibrary
{
    public class Pathconfig : IPathconfig
    {
        private List<Path> _paths = new List<Path>();

        private readonly IPathCreator _pathCreator;

        public event EventHandler<PathEvent> PathsUpdated;

        public Pathconfig(ITransponderReceiver transponderReceiver, IPathCreator pathCreator)
        {
            _pathCreator = pathCreator;
            transponderReceiver.TransponderDataReady += AddPath;
        }

        private void AddPath(object o, RawTransponderDataEventArgs args)
        {
            var newPaths = new List<Path>();

            foreach (var info in args.TransponderData)
            {
                var newPath = _pathCreator.CreatePath(info);
                newPaths.Add(newPath);
            }

            _paths.AddRange(newPaths);

            OnPathsUpdated(new PathsUpdatedEventArgs { Paths = newPaths });


        }

        private void OnPathsUpdated(PathsUpdatedEventArgs args)
        {
            var handler = PathsUpdated;
            handler?.Invoke(this, args);
        }
    }
}
