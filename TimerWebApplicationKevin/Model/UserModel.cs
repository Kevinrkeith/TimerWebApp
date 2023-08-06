using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Input;
using System.Timers;
using TimerWebApplicationKevin.Misc;
using System.Globalization;

namespace TimerWebApplicationKevin.Model
{
    public class UserModel { }
    public class Users : BaseViewModel
    {
        public Users()
        {
            startCommand = new DelegateCommand(StartCommand);
            startButton = "Start";
        }
        public int Id { get; set; }
        public string _currentName { get; set; }
        public string startTime { get; set; }
        private DateTime EndTime { get; set; }
        public string endTime { get; set; }
        private TimeSpan TotalTime { get; set; }
        public string totalTime { get; set; }
        private DateTime StartTime { get; set; }
        public bool isStarted = false;
        public string startButton { get; set; }
        public ICommand startCommand { get; set; }
        Timer myTimer = new Timer(1);
        private void UpdateEndTime(Object source, ElapsedEventArgs e)
        {
            EndTime = DateTime.Now;
            TotalTime = EndTime.Subtract(StartTime);

            endTime = EndTime.ToString("HH:mm:ss:fff");
            totalTime = TotalTime.ToString();
            string connectionString = "Data Source=localhost;Initial Catalog=MyStore;Integrated Security=True";
            string updateQuery = "UPDATE TimeTable SET endTime = @endTime, totalTime = @totalTime WHERE Id = @RowId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server");

                    SqlCommand cmd = new SqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@totalTime", totalTime);
                    cmd.Parameters.AddWithValue("@RowId", Id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Row updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows were updated.");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to the SQL Server: " + ex.Message);
                }
            }
            OnPropertyChanged(nameof(endTime));
            OnPropertyChanged(nameof(totalTime));
        }
        private void StartCommand()
        {
            isStarted = !isStarted;
            if (isStarted)
            {
                startButton = "Stop";
                startTime = DateTime.Now.ToString("HH:mm:ss:fff");
                StartTime = DateTime.Now;
            }
            else
            {
                startButton = "Start";
                EndTime = DateTime.Now;
                TotalTime = EndTime.Subtract(StartTime);

                endTime = EndTime.ToString("HH:mm:ss:fff");
                totalTime = TotalTime.ToString();
            }
            string connectionString = "Data Source=localhost;Initial Catalog=MyStore;Integrated Security=True";
            string updateQuery = "UPDATE TimeTable SET startTime = @startTime, running = @running WHERE Id = @RowId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server");

                    SqlCommand cmd = new SqlCommand(updateQuery, connection);
                    int intValue = isStarted ? 1 : 0;
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@running", intValue);
                    cmd.Parameters.AddWithValue("@RowId", Id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Row updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows were updated.");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to the SQL Server: " + ex.Message);
                }
            }
            Form_Load();
            OnPropertyChanged(nameof(startButton));
            OnPropertyChanged(nameof(endTime));
            OnPropertyChanged(nameof(startTime));
            OnPropertyChanged(nameof(totalTime));
        }
        public void LoadUser()
        {
            if (isStarted)
            {
                Form_Load();
                startButton = "Stop";
            }
            string format = "HH:mm:ss:fff";
            StartTime = DateTime.ParseExact(startTime, format, CultureInfo.InvariantCulture);
            OnPropertyChanged(nameof(startButton));
            OnPropertyChanged(nameof(endTime));
        }
        private void Form_Load()
        {
            myTimer.Elapsed += UpdateEndTime;
            myTimer.Start();
            myTimer.Enabled = isStarted;
        }
    }
}
