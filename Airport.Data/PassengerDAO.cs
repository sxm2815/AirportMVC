using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data {
    public class PassengerDAO : IPassengerDAO 
    {
        private string connString = "Data Source=DESKTOP-G2FMHO8;Initial Catalog=Airport;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public void AddPassenger(Passenger passenger) {
            string query = "INSERT INTO dbo.Passengers(FullName, Age, Email, PhoneNumber)" +
                           "VALUES (@FullName, @Age, @Email, @PhoneNumber)";
            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", passenger.Name);
                cmd.Parameters.AddWithValue("@Age", passenger.Age);
                cmd.Parameters.AddWithValue("@Email", passenger.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", passenger.PhoneNumber);

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

        public Passenger GetPassenger(int Id) {
            Passenger passenger = new Passenger();

            string query = "SELECT * FROM dbo.Passengers WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                try {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        passenger = new Passenger(
                            reader["FullName"].ToString(),
                            Int32.Parse(reader["Age"].ToString()),
                            reader["Email"].ToString(),
                            reader["PhoneNumber"].ToString()
                        );
                        int resIndex = reader.GetOrdinal("ReservationNumber");
                        int flightIndex = reader.GetOrdinal("FlightNumber");

                        if (!reader.IsDBNull(resIndex)) {
                            passenger.ReservationNumber = Int32.Parse(reader["ReservationNumber"].ToString());
                        }
                        if (!reader.IsDBNull(flightIndex)) {
                            passenger.FlightNumber = Int32.Parse(reader["FlightNumber"].ToString());
                        }
                    }

                } catch (SqlException ex) {
                    Console.WriteLine("Could not get Airplane!\n {0}", ex.Message);
                } finally {
                    conn.Close();
                }
            }
            return passenger;
        }

        public IEnumerable<Passenger> GetPassengers() {
            List<Passenger> passengerList = new List<Passenger>();

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Passengers", conn);
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
                        temp.Id = Int32.Parse(reader["Id"].ToString());
                        int resIndex = reader.GetOrdinal("ReservationNumber");
                        int flightIndex = reader.GetOrdinal("FlightNumber");

                        if (!reader.IsDBNull(resIndex)) {
                            temp.ReservationNumber = Int32.Parse(reader["ReservationNumber"].ToString());
                        }
                        if (!reader.IsDBNull(flightIndex)) {
                            temp.FlightNumber = Int32.Parse(reader["FlightNumber"].ToString());
                        }
                        passengerList.Add(temp);
                    }


                } catch (SqlException ex) {
                    Console.WriteLine("Could not get all Passengers!\n{0}", ex.Message);
                } finally {
                    conn.Close();
                }
            }


            return passengerList;
        }

        public void RemovePassenger(int Id) {
            string query = "DELETE FROM dbo.Passengers WHERE Id = @Id";

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

        public void UpdatePassenger(int id, Passenger passenger) {
            string query = "UPDATE dbo.Passengers SET FullName = @FullName, Age = @Age, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", passenger.Name);
                cmd.Parameters.AddWithValue("@Age", passenger.Age);
                cmd.Parameters.AddWithValue("@Email", passenger.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", passenger.PhoneNumber);
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

        public void AssignFlight(int id, int flightNumber) {
            string query = "UPDATE dbo.Passengers SET ReservationNumber = @ReservationNumber, FlightNumber = @FlightNumber WHERE Id = @Id";
            
            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(query, conn);

                Random generator = new Random();
                int resNumber = generator.Next(100000, 1000000);

                cmd.Parameters.AddWithValue("@ReservationNumber",resNumber);
                cmd.Parameters.AddWithValue("@FlightNumber",flightNumber);
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
