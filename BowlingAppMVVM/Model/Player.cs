﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class Player : INotifyPropertyChanged
    {
        #region Members definition
        private string _name;
        private FrameBase[] _frames;

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChangedMembers;
        #endregion Members definition

        #region Properties definition
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.SetProperty<string>(ref this._name, value);
            }
        }
        public FrameBase[] Frames
        {
            get
            {
                return this._frames;
            }
            private set
            {
                this.SetProperty<FrameBase[]>(ref this._frames, value);
            }
        }
        public int Score
        {
            get { return this.CalculateScore(); }
        }
        #endregion Properties definition

        #region Constructors definition
        public Player(string name = "")
        {
            this.Name = name;
            this.Frames = new FrameBase[10]
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
            int total = 0;

            // TODO: Is this LINQ necessary?
            (int score, Game.SCORE_STATE state)[] scores = this.Frames.Select((frame) => frame.Score).ToArray();
            Game.SHOT_VALUE[] shots = this.Frames.SelectMany<FrameBase, Game.SHOT_VALUE>((frame) => frame.Shots).ToArray();

            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i].score;

                if (this.Frames[i] is OneShotFrame)
                {
                    // Final frame.
                    break;
                }

                int shotNumber = GetShotIndex(i, 1);
                if (scores[i].state == Game.SCORE_STATE.Spare)
                {
                    // TODO: Access shot one ahead.
                    // How to go from an indexed score tuple (frame) to the current shot?
                    shotNumber++;
                    total += GetNextScore(shots, ref shotNumber);
                }
                else if (shots[shotNumber] == Game.SHOT_VALUE.Strike)
                {
                    // First shot was a strike.
                    total += GetNextScore(shots, ref shotNumber);
                    total += GetNextScore(shots, ref shotNumber);
                }
                else if (shots[shotNumber + 1] == Game.SHOT_VALUE.Strike)
                {
                    // Second shot was a strike.
                    shotNumber++;
                    total += GetNextScore(shots, ref shotNumber);
                    total += GetNextScore(shots, ref shotNumber);
                }
            }

            return total;
        }

        // TODO: This method isn't great. Could probably be cleaner. ref keyword... eugh.
        private int GetNextScore(Game.SHOT_VALUE[] shots, ref int shotNumber)
        {
            int nextScore = -1;
            do
            {
                shotNumber++;
                if (!(shots[shotNumber] == Game.SHOT_VALUE.Undefined || shots[shotNumber] == Game.SHOT_VALUE.Spare || shots[shotNumber] == Game.SHOT_VALUE.Strike))
                {
                    nextScore = Game.ShotScores[shots[shotNumber]];
                }
            } while (nextScore == -1);
            return nextScore;
        }

        private static int GetShotIndex(int frameNumber, int shotNumber)
        {
            // sn(f,s) = 2(f - 1) + s
            return (2 * (frameNumber - 1)) + shotNumber;
        }

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Methods definition
    }
}
