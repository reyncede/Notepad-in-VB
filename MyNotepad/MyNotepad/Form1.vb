Imports System.IO
Public Class Form1
    Private ReadOnly FILE_FILTER = "Text Files (*.txt)|*.txt"

    'File Menu
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = FILE_FILTER
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtBody.Text = File.ReadAllText(OpenFileDialog1.FileName)
        Dim filename As String = OpenFileDialog1.SafeFileName
        Me.Text = filename.Substring(0, filename.Length - 4) & " - Notepad"
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Filter = FILE_FILTER
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtBody.Text, False)
        Text = SaveFileDialog1.FileName & " - Notepad"
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    'Format Menu
    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        If txtBody.WordWrap = True Then
            WordWrapToolStripMenuItem.Text = "✕ Word Wrap"
            txtBody.WordWrap = False
        Else
            WordWrapToolStripMenuItem.Text = "✔ Word Wrap"
            txtBody.WordWrap = True
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim fs As String = InputBox("Enter Font Size", "Font Size")
        If IsNumeric(fs) Then
            txtBody.Font = New Font("Verdana", Integer.Parse(fs), FontStyle.Regular)
        Else
            MessageBox.Show("Invalid Input")
        End If
    End Sub

    Private Sub txtBody_TextChanged(sender As Object, e As EventArgs) Handles txtBody.TextChanged
        lblLines.Text = "Lines: " & txtBody.Lines.Length
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        txtBody.Width = Me.Width - 16
        txtBody.Height = Me.Height - 80
        lblLines.Top = txtBody.Height + 25
    End Sub
End Class
