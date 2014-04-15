using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PingPongScoreboard.Model
{
    public class PingPongGame
    {
        private PingPongGameState _state;
        private List<Set> _sets;

        private int _currentSetIndex;

        public PingPongGameState State
        {
            get
            {
                return _state;
            }
        }

        public Set CurrentSet
        {
            get
            {
                return _sets[_currentSetIndex];
            }
        }

        public PingPongGame()
        {
            _state = PingPongGameState.NotSet;
            _sets = new List<Set>();
        }

        public void Start()
        {
            _state = PingPongGameState.Started;
        }

        public void End()
        {
            _state = PingPongGameState.Finished;
        }

        public void GenerateSets(int numberOfSets)
        {
            // Fills list of sets.
            for (int i = 1; i <= numberOfSets; i++)
            {
                _sets.Add(new Set(i));
            }
        }

        public int CalculatePointsForTeam(int teamNumber)
        {
            // Count sets where outcome is a point for `teamNumber` or outcome is a fault for the other team.
            var points = (from set in _sets
                          where (set.ForTeam == teamNumber && set.Outcome == SetOutcome.Point)
                          || (set.ForTeam != teamNumber && set.Outcome == SetOutcome.Fault)
                          select set).Count();

            return points;
        }

        public int CalculateFaultsForTeam(int teamNumber)
        {
            // Count sets where outcome is fault for `teamNumber`.
            var faults = (from set in _sets where set.ForTeam == teamNumber && set.Outcome == SetOutcome.Fault
                          select set).Count();

            return faults;
        }

        public void GoToNextSet() 
        {
            _currentSetIndex++;
        }

        public void GoToPreviousSet()
        {
            _currentSetIndex--;
        }

        public void GoToSet(int setNumber)
        {
            var index = setNumber - 1;

            _currentSetIndex = index;
        }

        public void SaveFile(string filePath, AllowedFileFormat format)
        {
            switch (format)
            {
                case AllowedFileFormat.Json:
                    SaveJsonFile(filePath);
                    break;
                case AllowedFileFormat.Text:
                    SaveTextFile(filePath);
                    break;
                default:
                    break;
            }
        }

        private void SaveTextFile(string filePath)
        {
            // Format is: # T O\n
            //           Where # = set number
            //           T = team number
            //           O = outcome
            var sb = new StringBuilder();

            foreach (var set in _sets)
            {
                int number = set.Number;
                int forTeam = set.ForTeam;

                // `.` means not set.
                char outCome = '.';

                // If an outcome is set.
                if (set.Outcome != SetOutcome.NotSet)
                {
                    switch (set.Outcome)
                    {
                        case SetOutcome.Point:
                            outCome = 'P';
                            break;
                        case SetOutcome.Fault:
                            outCome = 'F';
                            break;
                        case SetOutcome.Invalid:
                            outCome = 'I';
                            break;
                        default:
                            break;
                    }
                }

                sb.AppendFormat("{0} {1} {2}\n", number, forTeam, outCome);
            }

            using (var writer = File.CreateText(filePath))
            {
                writer.Write(sb.ToString());
            }
        }

        private void SaveJsonFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void LoadFile(string filePath, AllowedFileFormat format)
        {
            throw new System.NotImplementedException();
        }

        public void MarkSetAsPointForTeam(int teamNumber)
        {
            throw new System.NotImplementedException();
        }

        public void MarkSetAsFaultForTeam(int teamNumber)
        {
            throw new System.NotImplementedException();
        }
    }

    public enum PingPongGameState
    {
        NotSet,
        Started,
        InSession,
        Finished
    }

    public enum AllowedFileFormat
    {
        Json,
        Text
    }
}
