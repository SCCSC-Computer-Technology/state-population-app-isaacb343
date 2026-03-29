using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateLibrary
{
    public class StateRepository
    {
        private string _connectionString;
        public StateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<StateInfo> GetAllStates()
        {
            var list = new List<StateInfo>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                //Load all states from the database and return them as a list of StateInfo objects
                var cmd = new SQLiteCommand("SELECT * FROM State ORDER BY Name", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new StateInfo
                    {
                        Id = Convert.ToInt32(reader["StateID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Population = Convert.ToInt64(reader["Population"]),
                        MedianIncome = Convert.ToDecimal(reader["MedianIncome"]),
                        ComputerJobPercentage = Convert.ToDouble(reader["ComputerJobsPercent"]) / 100,
                        FlagDescription = Convert.ToString(reader["FlagDescription"]),
                        Flower = Convert.ToString(reader["StateFlower"]),
                        Bird = Convert.ToString(reader["StateBird"]),
                        Colors = Convert.ToString(reader["StateColors"]),
                        Capital = Convert.ToString(reader["CapitalCity"]),
                    });
                }
                reader.Close();
                //Load the largest cities for each state and add them to the corresponding StateInfo object
                var cityCmd = new SQLiteCommand("SELECT StateID, CityName, Rank FROM StateLargestCity ORDER BY StateID, Rank", conn);
                var cityReader = cityCmd.ExecuteReader();

                while (cityReader.Read())
                {
                    int stateID = Convert.ToInt32(cityReader["StateID"]);
                    string cityName = Convert.ToString(cityReader["CityName"]);
                    var state = list.FirstOrDefault(s => s.Id == stateID);
                    if (state != null)
                    {
                        state.LargestCities.Add(cityName);
                    }
                }
            }
            return list;

        }
        public void UpdateState(StateInfo state)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("UPDATE State SET Name=@Name, Population=@Population, MedianIncome=@MedianIncome, ComputerJobsPercent=@ComputerJobsPercent, FlagDescription=@FlagDescription, StateFlower=@StateFlower, StateBird=@StateBird, StateColors=@StateColors, CapitalCity=@CapitalCity WHERE StateID=@StateID", conn);
                cmd.Parameters.AddWithValue("@Name", state.Name);
                cmd.Parameters.AddWithValue("@Population", state.Population);
                cmd.Parameters.AddWithValue("@MedianIncome", state.MedianIncome);
                cmd.Parameters.AddWithValue("@ComputerJobsPercent", state.ComputerJobPercentage * 100);
                cmd.Parameters.AddWithValue("@FlagDescription", state.FlagDescription);
                cmd.Parameters.AddWithValue("@StateFlower", state.Flower);
                cmd.Parameters.AddWithValue("@StateBird", state.Bird);
                cmd.Parameters.AddWithValue("@StateColors", state.Colors);
                cmd.Parameters.AddWithValue("@CapitalCity", state.Capital);
                cmd.Parameters.AddWithValue("@StateID", state.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}