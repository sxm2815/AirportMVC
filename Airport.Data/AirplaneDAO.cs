using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public class AirplaneDAO : IAirplaneDAO {

        private string connString = "Data Source=DESKTOP-G2FMHO8;Initial Catalog=Airport;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddAirplane(Airplane airplane)
        {
            string query = "INSERT INTO dbo.Airplanes(Model, FlightNumber, Destination, TimeDepart, Capacity)" +
                           "VALUES (@Model, @FlightNumber, @Destination, @TimeDepart, @Capacity)";
            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Model", airplane.Model);
                cmd.Parameters.AddWithValue("@FlightNumber",airplane.FlightNumber);
                cmd.Parameters.AddWithValue("@Destination", airplane.Destination);
                cmd.Parameters.AddWithValue("@TimeDepart", airplane.TimeDepart);
                cmd.Parameters.AddWithValue("@Capacity", airplane.Capacity);

                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                } catch(SqlException ex) {
                    Console.WriteLine("Could not add Airplane!\n{0}", ex.Message);
                } finally {
                    conn.Close();
                }
            }
        }

        public Airplane GetAirplane(int Id)
        {
            Airplane airplane = new Airplane();

            string query = "SELECT * FROM dbo.Airplanes WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id",Id);

                try {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        airplane = new Airplane(
                            reader["Model"].ToString(),
                            Int32.Parse(reader["FlightNumber"].ToString()),
                            reader["Destination"].ToString(),
                            (TimeSpan)reader["TimeDepart"],
                            Int32.Parse(reader["Capacity"].ToString()));
                        airplane.Id = Convert.ToInt32(reader["Id"]);
                    }

                } catch( SqlException ex) {
                    Console.WriteLine("Could not get Airplane!\n {0}",ex.Message);
                } finally {
                    conn.Close();
                }
            }
                return airplane;
        }

        public IEnumerable<Airplane> GetAirplanes()
        {
            List<Airplane> airplaneList = new List<Airplane>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Airplanes", conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Airplane temp = new Airplane(
                            reader["Model"].ToString(),
                            Int32.Parse(reader["FlightNumber"].ToString()),
                            reader["Destination"].ToString(),
                            (TimeSpan)reader["TimeDepart"],
                            Int32.Parse(reader["Capacity"].ToString()));
                        temp.Id = Convert.ToInt32(reader["Id"]);

                        airplaneList.Add(temp);
                    }


                } catch( SqlException ex)
                {
                    Console.WriteLine("Could not get all Airplanes!\n{0}", ex.Message);
                } finally
                {
                    conn.Close();
                }
            }
            return airplaneList;
        }

        public IEnumerable<Passenger> GetPassengers(int flightNumber) 
        {
            string query = "SELECT * FROM dbo.Passengers WHERE FlightNumber = @FlightNumber";
            List<Passenger> passengers = new List<Passenger>();

            using(SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FlightNumber", flightNumber);

                try {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        Passenger temp = new Passenger(
                            reader["FullName"].ToString(),
                            Int32.Parse(reader["Age"].ToString()),
                            reader["Email"].ToString(),
                            reader["PhoneNumber"].ToString()
                        );
                        passengers.Add(temp);
                    }

                } catch(SqlException ex) {
                    Console.WriteLine("Could not get Passengers from flight!\n {0}", ex.Message);
                } finally {
                    conn.Close();
                }

            }
            return passengers;
        }

        public void RemoveAirplane(int Id)
        {
            string query = "DELETE FROM dbo.Airplanes WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                } catch (SqlException ex) {
                    Console.WriteLine("Could not Delete Airplane!\n {0}", ex.Message);
                } finally {
                    conn.Close();
                }
            }
        }

        public void UpdateAirplane(int id, Airplane airplane)
        {
            string query = "UPDATE dbo.Airplanes SET Model = @Model, FlightNumber = @FlightNumber, Destination = @Destination, TimeDepart = @TimeDepart, Capacity = @Capacity WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Model", airplane.Model);
                cmd.Parameters.AddWithValue("@FlightNumber", airplane.FlightNumber);
                cmd.Parameters.AddWithValue("@Destination", airplane.Destination);
                cmd.Parameters.AddWithValue("@TimeDepart", airplane.TimeDepart);
                cmd.Parameters.AddWithValue("@Capacity", airplane.Capacity);
                cmd.Parameters.AddWithValue("@Id", id);

                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                } catch (SqlException ex) {
                    Console.WriteLine("Could not add Airplane!\n{0}", ex.Message);
                } finally {
                    conn.Close();
                }
            }
        }
    }
}
