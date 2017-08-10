using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class Player
    {
        #region Members definition
        public string Name { get; set; }
        public IFrame[] Frames { get; private set; }
        public int Score
        {
            get { return this.CalculateScore(); }
        }
        #endregion Members definition

        #region Constructors definition
        public Player(string name = "")
        {
            this.Name = name;
            this.Frames = new IFrame[10]
            {
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new OneShotFrame(),
            };
        }
        #endregion Constructors definition

        #region Methods definition
        public int CalculateScore()
        {
            throw new NotImplementedException();
        }
        #endregion Methods definition
    }
}
