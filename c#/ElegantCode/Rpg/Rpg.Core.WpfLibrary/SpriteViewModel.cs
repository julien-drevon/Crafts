using System;
using ElegantCode.Fundamental.Core.Entities;
using Rpg.Core.Domain;
using Rpg.Core.WpfLibrary.Base;

namespace Rpg.Core.WpfLibrary
{
    public class SpriteViewModel : BaseViewModel, IGotId<Guid>
    {
        private Sprite _Sprite;

        public SpriteViewModel(int x = 0, int y = 0, int width = 0, int height = 0)
        {
            _Sprite = new Sprite(x, y, width, height, Guid.NewGuid());
        }

        public int X { get => _Sprite.X; set => OnPropertyChanged(() => _Sprite.X = value); }
        public int Y { get => _Sprite.Y; set => OnPropertyChanged(() => _Sprite.Y = value); }
        public int Width { get => _Sprite.Width; set => OnPropertyChanged(() => _Sprite.Width = value); }
        public int Height { get => _Sprite.Height; set => OnPropertyChanged(() => _Sprite.Height = value); }

        public Guid Id { get => _Sprite.Id; }
    }
}
