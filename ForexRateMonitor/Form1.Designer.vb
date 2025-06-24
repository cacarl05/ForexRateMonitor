<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblRate = New Label()
        lblStatus = New Label()
        btnRefresh = New Button()
        btnBackup = New Button()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' lblRate
        ' 
        lblRate.AutoSize = True
        lblRate.Location = New Point(58, 97)
        lblRate.Name = "lblRate"
        lblRate.Size = New Size(55, 15)
        lblRate.TabIndex = 0
        lblRate.Text = "USD/EUR"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(58, 139)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(48, 15)
        lblStatus.TabIndex = 1
        lblStatus.Text = "Status..."
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(58, 245)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(128, 23)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh Rate"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnBackup
        ' 
        btnBackup.Location = New Point(227, 245)
        btnBackup.Name = "btnBackup"
        btnBackup.Size = New Size(152, 23)
        btnBackup.TabIndex = 3
        btnBackup.Text = "Backup Database"
        btnBackup.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnBackup)
        Controls.Add(btnRefresh)
        Controls.Add(lblStatus)
        Controls.Add(lblRate)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRate As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents Timer1 As Timer

End Class
