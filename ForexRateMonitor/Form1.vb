Imports System.Net.Http
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form1
    Private apiUrl As String = "https://api.frankfurter.app/latest?from=USD&to=EUR"
    Private connectionString As String = "server=localhost;user id=root;password=;database=forexdb;"
    Private backupFilePath As String = "C:\backups\forex_backup.sql"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 60000 ' Refresh every minute
        Timer1.Start()
        If lblStatus IsNot Nothing Then
            lblStatus.Text = "Monitoring started."
        End If
    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Await FetchExchangeRate()
    End Sub

    Private Async Function FetchExchangeRate() As Task
        Try
            Using client As New HttpClient()
                Dim response = Await client.GetStringAsync(apiUrl)
                MessageBox.Show(response) ' Shows API result for debugging

                Dim rates = Newtonsoft.Json.JsonConvert.DeserializeObject(Of FrankfurterResponse)(response)

                If rates IsNot Nothing AndAlso rates.rates.ContainsKey("EUR") Then
                    Dim exchangeRate = rates.rates("EUR")

                    If lblRate IsNot Nothing Then
                        lblRate.Text = String.Format("USD/EUR: {0:F4}", exchangeRate)
                    End If

                    If exchangeRate > 1.2D Then
                        MessageBox.Show("Rate is above threshold!")
                    End If

                    LogRateToDatabase("USD", "EUR", exchangeRate)

                    If lblStatus IsNot Nothing Then
                        lblStatus.Text = "Last updated: " & DateTime.Now.ToString()
                    End If
                Else
                    MessageBox.Show("Error: EUR rate not found in response.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Function

    Private Sub LogRateToDatabase(currency1 As String, currency2 As String, rate As Decimal)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim command As New MySqlCommand("INSERT INTO rates (currency1, currency2, rate, timestamp) VALUES (@currency1, @currency2, @rate, @timestamp)", connection)
                command.Parameters.AddWithValue("@currency1", currency1)
                command.Parameters.AddWithValue("@currency2", currency2)
                command.Parameters.AddWithValue("@rate", rate)
                command.Parameters.AddWithValue("@timestamp", DateTime.Now)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
        End Try
    End Sub

    Private Sub BackupDatabase()
        Try
            If Not Directory.Exists("C:\backups") Then
                Directory.CreateDirectory("C:\backups")
            End If
            Dim backupCommand As String = "mysqldump -u root -pyourpassword forexdb > """ & backupFilePath & """"
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.Arguments = "/C " & backupCommand
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = True
            process.Start()
            process.WaitForExit()
            MessageBox.Show("Database backup completed successfully.")
        Catch ex As Exception
            MessageBox.Show("Backup error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        BackupDatabase()
    End Sub

    Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Await FetchExchangeRate()
    End Sub

    Private Sub lblRate_Click(sender As Object, e As EventArgs)
        ' Do nothing
    End Sub
End Class

Public Class FrankfurterResponse
    Public Property rates As Dictionary(Of String, Decimal)
End Class
