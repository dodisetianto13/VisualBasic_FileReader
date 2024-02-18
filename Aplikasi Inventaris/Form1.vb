Imports System.IO

Public Class Form1
    Private Sub btnBaca_Click(sender As Object, e As EventArgs) Handles btnBaca.Click
        BacaFile()
    End Sub

    Private Sub BacaFile()
        Dim path As String = "inventaris.txt"

        If File.Exists(path) Then
            ' Bersihkan ListBox sebelum menambahkan item baru
            ListBox1.Items.Clear()

            ' Gunakan StreamReader untuk membaca file
            Using reader As New StreamReader(path)
                Dim line As String
                While Not reader.EndOfStream
                    ' Baca setiap baris dalam file
                    line = reader.ReadLine()
                    ' Cetak baris yang dibaca ke konsol
                    Console.WriteLine($"Baris yang dibaca: {line}")
                    ' Pisahkan data menjadi nama barang dan stoknya
                    Dim data As String() = line.Split(","c)
                    ' Periksa apakah array data memiliki dua elemen
                    If data.Length = 2 Then
                        Dim namaBarang As String = data(0)
                        Dim jumlahBarang As Integer
                        ' Coba untuk mengonversi jumlah barang ke tipe integer
                        If Integer.TryParse(data(1), jumlahBarang) Then
                            ' Tambahkan informasi barang ke dalam ListBox
                            ListBox1.Items.Add($"{namaBarang} - Stok: {jumlahBarang}")
                        Else
                            ' Tangani kesalahan jika tidak dapat mengonversi jumlah barang ke tipe integer
                            MessageBox.Show($"Error parsing jumlah barang for '{namaBarang}'.")
                        End If
                    Else
                        ' Tangani kasus di mana data memiliki format yang tidak valid
                        MessageBox.Show($"Invalid data format: {line}")
                    End If
                End While
            End Using
        Else
            MessageBox.Show("File inventaris.txt tidak ditemukan.")
        End If
    End Sub

    Private Sub btnCekStok_Click(sender As Object, e As EventArgs) Handles btnCekStok.Click
        CekStok()
    End Sub

    Private Sub CekStok()
        Dim barangDicari As String = InputBox("Masukkan nama barang yang ingin dicek stoknya:", "Cek Stok")
        Dim stok As Integer = 0
        Dim path As String = "inventaris.txt"

        If File.Exists(path) Then
            Using reader As New StreamReader(path)
                Dim line As String
                While Not reader.EndOfStream
                    line = reader.ReadLine()
                    Dim data As String() = line.Split(","c)
                    If data.Length = 2 AndAlso data(0) = barangDicari Then
                        ' Mengonversi jumlah stok ke tipe integer dengan penanganan kesalahan
                        If Integer.TryParse(data(1), stok) Then
                            Exit While
                        Else
                            ' Tangani kesalahan jika tidak dapat mengonversi jumlah stok ke tipe integer
                            MessageBox.Show($"Error parsing jumlah stok for '{barangDicari}'.")
                            Exit Sub
                        End If
                    End If
                End While
            End Using

            If stok > 0 Then
                MessageBox.Show($"Stok {barangDicari} saat ini adalah {stok}.")
            Else
                MessageBox.Show($"Barang {barangDicari} tidak ditemukan dalam inventaris.")
            End If
        Else
            MessageBox.Show("File inventaris.txt tidak ditemukan.")
        End If
    End Sub

    Private Sub btnKelola_Click(sender As Object, e As EventArgs) Handles btnKelola.Click
        KelolaInventaris()
    End Sub

    Private Sub KelolaInventaris()
        ' Meminta pengguna untuk memilih aksi pengelolaan inventaris
        Dim pilihan As String = InputBox("Pilih aksi pengelolaan inventaris:" & vbCrLf &
                                          "1. Tambah stok barang" & vbCrLf &
                                          "2. Kurangi stok barang" & vbCrLf &
                                          "3. Tambah item inventaris baru", "Kelola Inventaris")

        ' Mengambil lokasi file inventaris.txt
        Dim path As String = "inventaris.txt"

        ' Memeriksa apakah file inventaris.txt ada
        If File.Exists(path) Then
            ' Memeriksa pilihan pengguna dan melakukan tindakan yang sesuai
            Select Case pilihan
                Case "1" ' Tambah stok barang
                    TambahStok(path)
                Case "2" ' Kurangi stok barang
                    KurangiStok(path)
                Case "3" ' Tambah item inventaris baru
                    TambahItemBaru(path)
                Case Else
                    MessageBox.Show("Pilihan tidak valid.")
            End Select
        Else
            MessageBox.Show("File inventaris.txt tidak ditemukan.")
        End If
    End Sub

    Private Sub TambahStok(ByVal path As String)
        ' Meminta pengguna untuk memasukkan nama barang dan jumlah stok yang akan ditambahkan
        Dim namaBarang As String = InputBox("Masukkan nama barang yang akan ditambahkan stoknya:", "Tambah Stok")
        Dim tambahanStok As Integer = InputBox("Masukkan jumlah stok yang akan ditambahkan:", "Tambah Stok")

        ' Membaca data inventaris dari file
        Dim lines As List(Of String) = File.ReadAllLines(path).ToList()

        ' Menemukan dan memperbarui stok barang yang sesuai
        Dim found As Boolean = False
        For i As Integer = 0 To lines.Count - 1
            Dim data As String() = lines(i).Split(","c)
            If data.Length = 2 AndAlso data(0) = namaBarang Then
                Dim stok As Integer
                ' Mengonversi jumlah stok ke tipe integer dengan penanganan kesalahan
                If Integer.TryParse(data(1), stok) Then
                    stok += tambahanStok
                    lines(i) = $"{namaBarang},{stok}"
                    found = True
                    Exit For
                Else
                    ' Tangani kesalahan jika tidak dapat mengonversi jumlah stok ke tipe integer
                    MessageBox.Show($"Error parsing jumlah stok for '{namaBarang}'.")
                    Exit Sub
                End If
            End If
        Next

        ' Jika barang ditemukan dan stok berhasil diperbarui, tulis kembali ke file
        If found Then
            File.WriteAllLines(path, lines)
            MessageBox.Show($"Stok barang {namaBarang} berhasil ditambahkan sebanyak {tambahanStok}.")
            ' Memperbarui daftar item inventaris setelah menambah stok
            BacaFile()
        Else
            MessageBox.Show($"Barang {namaBarang} tidak ditemukan dalam inventaris.")
        End If
    End Sub

    Private Sub KurangiStok(ByVal path As String)
        ' Meminta pengguna untuk memasukkan nama barang dan jumlah stok yang akan dikurangi
        Dim namaBarang As String = InputBox("Masukkan nama barang yang akan dikurangi stoknya:", "Kurangi Stok")
        Dim kurangiStok As Integer = InputBox("Masukkan jumlah stok yang akan dikurangi:", "Kurangi Stok")

        ' Membaca data inventaris dari file
        Dim lines As List(Of String) = File.ReadAllLines(path).ToList()

        ' Menemukan dan memperbarui stok barang yang sesuai
        Dim found As Boolean = False
        For i As Integer = 0 To lines.Count - 1
            Dim data As String() = lines(i).Split(","c)
            If data.Length = 2 AndAlso data(0) = namaBarang Then
                Dim stok As Integer
                ' Mengonversi jumlah stok ke tipe integer dengan penanganan kesalahan
                If Integer.TryParse(data(1), stok) Then
                    If stok >= kurangiStok Then
                        stok -= kurangiStok
                        lines(i) = $"{namaBarang},{stok}"
                        found = True
                        Exit For
                    Else
                        MessageBox.Show("Stok barang tidak mencukupi untuk dikurangi sebanyak yang diminta.")
                        Exit Sub
                    End If
                Else
                    ' Tangani kesalahan jika tidak dapat mengonversi jumlah stok ke tipe integer
                    MessageBox.Show($"Error parsing jumlah stok for '{namaBarang}'.")
                    Exit Sub
                End If
            End If
        Next

        ' Jika barang ditemukan dan stok berhasil diperbarui, tulis kembali ke file
        If found Then
            File.WriteAllLines(path, lines)
            MessageBox.Show($"Stok barang {namaBarang} berhasil dikurangi sebanyak {kurangiStok}.")
            ' Memperbarui daftar item inventaris setelah mengurangi stok
            BacaFile()
        Else
            MessageBox.Show($"Barang {namaBarang} tidak ditemukan dalam inventaris.")
        End If
    End Sub

    Private Sub TambahItemBaru(ByVal path As String)
        ' Meminta pengguna untuk memasukkan nama barang dan stok baru
        Dim namaBarang As String = InputBox("Masukkan nama barang baru:", "Tambah Item Baru")
        Dim stokBaruStr As String = InputBox("Masukkan stok barang baru:", "Tambah Item Baru")

        Dim stokBaru As Integer
        ' Validasi apakah stok yang dimasukkan adalah bilangan bulat
        If Not Integer.TryParse(stokBaruStr, stokBaru) Then
            MessageBox.Show("Stok harus berupa bilangan bulat.")
            Exit Sub
        End If

        Try
            ' Menambahkan data baru ke dalam list inventaris
            Dim newItem As String = $"{namaBarang},{stokBaru}"
            ListBox1.Items.Add($"{namaBarang} - Stok: {stokBaru}")

            ' Menulis seluruh daftar inventaris kembali ke file
            Using writer As New StreamWriter(path)
                For Each item As String In ListBox1.Items
                    writer.WriteLine(item)
                Next
            End Using

            ' Menampilkan pesan bahwa item inventaris baru telah ditambahkan
            MessageBox.Show($"Item inventaris baru '{namaBarang}' dengan stok {stokBaru} berhasil ditambahkan.")
        Catch ex As Exception
            ' Tangani kesalahan jika terjadi kesalahan saat menulis ke file
            MessageBox.Show($"Error adding new item to inventory: {ex.Message}")
        End Try
    End Sub
End Class
