<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        btnBaca = New Button()
        btnCekStok = New Button()
        btnKelola = New Button()
        ListBox1 = New ListBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnBaca
        ' 
        btnBaca.Location = New Point(398, 75)
        btnBaca.Name = "btnBaca"
        btnBaca.Size = New Size(94, 52)
        btnBaca.TabIndex = 0
        btnBaca.Text = "Baca File"
        btnBaca.UseVisualStyleBackColor = True
        ' 
        ' btnCekStok
        ' 
        btnCekStok.Location = New Point(398, 149)
        btnCekStok.Name = "btnCekStok"
        btnCekStok.Size = New Size(94, 29)
        btnCekStok.TabIndex = 1
        btnCekStok.Text = "Cek Stok"
        btnCekStok.UseVisualStyleBackColor = True
        ' 
        ' btnKelola
        ' 
        btnKelola.Location = New Point(398, 201)
        btnKelola.Name = "btnKelola"
        btnKelola.Size = New Size(94, 29)
        btnKelola.TabIndex = 2
        btnKelola.Text = "Kelola"
        btnKelola.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.Location = New Point(12, 75)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(368, 264)
        ListBox1.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(12, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(292, 28)
        Label1.TabIndex = 4
        Label1.Text = "Aplikasi Inventaris Sederhana"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(517, 383)
        Controls.Add(Label1)
        Controls.Add(ListBox1)
        Controls.Add(btnKelola)
        Controls.Add(btnCekStok)
        Controls.Add(btnBaca)
        Name = "Form1"
        Text = "Aplikasi Inventaris Sederhana"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBaca As Button
    Friend WithEvents btnCekStok As Button
    Friend WithEvents btnKelola As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label

End Class
