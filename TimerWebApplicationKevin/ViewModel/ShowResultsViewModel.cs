using OfficeOpenXml;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using TimerWebApplicationKevin.Misc;
using TimerWebApplicationKevin.Model;

namespace TimerWebApplicationKevin.ViewModel
{
    public class ShowResultsViewModel : BaseViewModel
    {
        private bool started = false;
        public string _startTime { get; set; }
        public string _totalTime { get; set; }
        public string _endTime { get; set; }
        public string currentName { get; set; }
        public string _startTimer { get; private set; }
        public string _timeData { get; set; }
        public ICommand ConnectCommand { get; private set; }
        public ICommand SubmitButton { get; private set; }
        public ICommand ExitButton { get; private set; }
        public ICommand StartTime { get; private set; }
        public ICommand Interval { get; private set; }
        public ICommand NavigateLoginCommand { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand ButtonCommand { get; set; }
        public ICommand startCommand { get; set; }
        public ICommand StartAllCommand { get; set; }
        public ICommand clearAllCommand { get; set; }
        public ICommand exportCommand { get; set; }
        private ObservableCollection<TimerModelLogic> timeCollection;
        private ObservableCollection<Users> userCollection;
        private int _Id;
        string connectionString = "Data Source=localhost;Initial Catalog=MyStore;Integrated Security=True";
        public ShowResultsViewModel(NavigationStore navi)
        {
            _startTimer = "Start Timer";
            OnPropertyChanged(nameof(_startTimer));
            ExitButton = new DelegateCommand(exitButton);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navi, () => new LoginViewModel(navi));
            timeCollection = new ObservableCollection<TimerModelLogic>();
            userCollection = new ObservableCollection<Users>();
            AddUserCommand = new DelegateCommand(AddUser);
            ConnectCommand = new DelegateCommand(ConnectionCommand);
            clearAllCommand = new DelegateCommand(ClearTable);
            StartAllCommand = new DelegateCommand(startAllCommand);
            exportCommand = new DelegateCommand(ExportButtonCommand);
            _Id = 0;
            ConnectionCommand();
        }
        private void ButtonAction(int? index)
        {
            MessageBox.Show($"{index}");
        }
        public ObservableCollection<Users> UserCollection
        {
            get
            {
                return userCollection;
            }
            set
            {
                userCollection = value;
                OnPropertyChanged(nameof(userCollection));
            }
        }
        public ObservableCollection<TimerModelLogic> timerModels
        {
            get
            {
                return timeCollection;
            }

            set
            {
                timeCollection = value;
                OnPropertyChanged(nameof(timerModels));
            }
        }
        
        private void ExportButtonCommand()
        {
            string Query = "SELECT * FROM TimeTable";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            var worksheet = excelPackage.Workbook.Worksheets.Add("Time Trials Results");
                            worksheet.Cells["A1"].LoadFromDataReader(reader, true);
                            using (var memoryStream = new MemoryStream())
                            {
                                excelPackage.SaveAs(memoryStream);
                            }
                        }
                    }
                }
            }
        }
        private void startAllCommand()
        {
            foreach(Users u in userCollection)
            {
                u.startCommand.Execute(this);
            }
        }
        private void ClearTable()
        {
            userCollection.Clear();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server");
                    string Query = "TRUNCATE TABLE TimeTable";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to the SQL Server: " + ex.Message);
                }
            }
        }
        private void ConnectionCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=MyStore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server");
                    string Query = "SELECT * FROM TimeTable";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the reader and do something with it
                            int id = reader.GetInt32(0);  // Assuming the first column is of type INT
                            string name = reader.GetString(1);  // Assuming the second column is of type VARCHAR
                            string startTime ="";
                            string endTime = "";
                            string totalTime = "";
                            bool isRunning = false;
                            if (reader.GetString(2) != null)
                            {
                                startTime = reader.GetString(2);
                            }
                            if (reader.GetString(3) != null)
                            {
                                endTime = reader.GetString(2);
                            }
                            isRunning = (reader.GetInt32(4) != 0);
                            if (reader.GetString(5) != null)
                            {
                                totalTime = reader.GetString(2);
                            }
                            Users user = new Users { Id = id, _currentName = name, startTime = startTime, endTime = endTime, totalTime = totalTime, isStarted = isRunning };
                            user.LoadUser();
                            // Perform your desired operations with the retrieved data
                            userCollection.Add(user);
                            id++;
                            OnPropertyChanged(nameof(userCollection));
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to the SQL Server: " + ex.Message);
                }
            }

        }
        private void AddUser()
        {
            if (currentName == String.Empty)
            {
                return;
            }
            userCollection.Add(new Users { Id = _Id, _currentName = this.currentName });
            string connectionString = "Data Source=localhost;Initial Catalog=MyStore;Integrated Security=True";
            string insertQuery = "INSERT INTO TimeTable (Id, _Name) VALUES (@Id, @Name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server");

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@Id", _Id);
                    cmd.Parameters.AddWithValue("@Name", currentName);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to the SQL Server: " + ex.Message);
                }
            }

            _Id++;
            currentName = string.Empty;
            OnPropertyChanged(nameof(userCollection));
        }
        private void exitButton()
        {
            MessageBox.Show("GoodBye");
            Environment.Exit(0);
        }
    }
}
