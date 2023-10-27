using System;
using Rpg.Core.Domain;
using Rpg.Core.WpfLibrary.Base;

namespace Rpg.Core.WpfLibrary
{
    public class SpriteViewModel : BaseViewModel
    {
        private Sprite _Sprite;

        public SpriteViewModel() : this(0, 0) { }

        public SpriteViewModel(int x, int y)
        {
            _Sprite = new Sprite(x, y);
        }

        public int X { get => _Sprite.X; set => OnPropertyChanged(() => _Sprite.X = value); }

        public int Y { get => _Sprite.Y; set => OnPropertyChanged(() => _Sprite.Y = value); }
    }
}
