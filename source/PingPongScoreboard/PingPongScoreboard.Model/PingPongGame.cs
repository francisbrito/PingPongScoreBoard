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
            if (_state == PingPongGameState.Started)
            {
                throw new InvalidOperationException("'GenerateSets' should be called before starting game.");
            }

            if (numberOfSets <= 0)
            {
                throw new ArgumentException();
            }

            _sets.Clear();

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
            if (_currentSetIndex == _sets.Count - 1)
            {
                throw new InvalidOperationException("Cannot move past last set.");
            }

            _currentSetIndex++;
        }

        public void GoToPreviousSet()
        {
            if (_currentSetIndex == 0)
            {
                throw new InvalidOperationException("Cannot move before first set.");
            }

            _currentSetIndex--;
        }

        public void GoToSet(int setNumber)
        {
            if (setNumber <= 0 || setNumber > _sets.Count)
            {
                throw new ArgumentOutOfRangeException("Cannot move outside of bounds of sets.");
            }

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

            WriteToFile(filePath, sb.ToString());
        }

        private void WriteToFile(string filePath, string text)
        {
            using (var writer = File.CreateText(filePath))
            {
                writer.Write(text);
            }
        }

        private void SaveJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(_sets);

            WriteToFile(filePath, json);
        }

        public void LoadFile(string filePath, AllowedFileFormat format)
        {
            _sets.Clear();

            switch (format)
            {
                case AllowedFileFormat.Json:
                    LoadJsonFile(filePath);
                    break;
                case AllowedFileFormat.Text:
                    LoadTextFile(filePath);
                    break;
                default:
                    break;
            }
        }

        private void LoadTextFile(string filePath)
        {
            var text = ReadFromFile(filePath);

            var lines = text.Split('\n');

            foreach (var line in lines)
            {
                var parts = line.Split(' ');

                var number = Convert.ToInt32(parts[0]);
                var team = Convert.ToInt32(parts[1]);

                var outcome = SetOutcome.NotSet;

                switch (parts[0])
                {
                    case "P":
                        outcome = SetOutcome.Point;
                        break;
                    case "F":
                        outcome = SetOutcome.Fault;
                        break;
                    case "I":
                        outcome = SetOutcome.Invalid;
                        break;
                    default:
                        break;
                }

                var set = new Set(number);
                set.MarkAsOutcomeFor(outcome, team);

                _sets.Add(set);
            }
        }

        private string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private void LoadJsonFile(string filePath)
        {
            var json = ReadFromFile(filePath);

            var sets = JsonConvert.DeserializeObject<List<Set>>(json);

            _sets.AddRange(sets);
        }

        public void MarkSetAsPointForTeam(int teamNumber)
        {
            if (teamNumber <= 0 || teamNumber > 2)
            {
                throw new ArgumentOutOfRangeException("'teamNumber' can only be one or two.");
            }

            _sets[_currentSetIndex].MarkAsOutcomeFor(SetOutcome.Point, teamNumber);
        }

        public void MarkSetAsFaultForTeam(int teamNumber)
        {
            if (teamNumber <= 0 || teamNumber > 2)
            {
                throw new ArgumentOutOfRangeException("'teamNumber' can only be one or two.");
            }

            _sets[_currentSetIndex].MarkAsOutcomeFor(SetOutcome.Fault, teamNumber);
        }

        public void MarkSetAsInvalid()
        {
            _sets[_currentSetIndex].MarkAsOutcomeFor(SetOutcome.Invalid, 0);
        }

        public void MarkSetAsFault()
        {
            _sets[_currentSetIndex].MarkAsFault();
        }

        public void SetForTeam(int teamNumber)
        {
            _sets[_currentSetIndex].SetForTeam(teamNumber);
        }

        public void MarkSetAsPoint()
        {
            _sets[_currentSetIndex].MarkAsPoint();
        }
    }

    public enum PingPongGameState
    {
        NotSet,
        Started,
        Finished
    }

    public enum AllowedFileFormat
    {
        Json,
        Text
    }
}
