Imports IOOperations.Components
Imports IOOperations

Module MainModule
    Friend TheProject As RmosProject
    Friend TheReservoir As RmosEngine.HydComponents.Reservoir

    'Friend List_InflowQSeries As List(Of DataSerie1D)
    'Friend List_DemandsSeries As List(Of DataSerie1D)

    Friend GSA_Engine As RmosEngine.GravitationalSearchAlgorithm.GSAEngine
    Friend GA_Engine As RmosEngine.GeneticAlgorithm.GAEngine
    Friend GWO_Engine As RmosEngine.GreyWolfOptimizer.GWOEngine
    Friend HPSOGWO_Engine As RmosEngine.GreyWolfOptimizer.HybridPSOGWOEngine

    Friend Enum FileFormatEnum
        CSV
        DS1
        DS2
        DS3
        DS4
        DS5
        DST
    End Enum

#Region "IO Operation"
    <Obsolete("Complete this to ")> Friend FileDirectory As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"

    Friend Function Import_Data(ByRef dataserie As DataSerie1D) As Boolean
        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV|DS2|*.DS2|CSV|*.CSV"
                    .ShowDialog()
                    fileName = .FileName
                    .RestoreDirectory = False
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim extention As String = IO.Path.GetExtension(fileName)

            If extention.ToLower() = ".csv" Then
                Dim reader As New IOOperations.CsvFileIO(fileName)
                dataserie = reader.Read_DS1()
            ElseIf extention.ToLower() = ".ds2" Then
                Dim reader As New IOOperations.FileManager(fileName)
                dataserie = reader.Read_DS1()
            End If

            dataserie.FileName = fileName

            result = True

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Friend Function Import_Data(ByRef dataserie As DataSerie1D, ByRef fileName As String) As Boolean
        Dim result As Boolean = False
        Try

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            If IO.File.Exists(fileName) Then
                Dim extention As String = IO.Path.GetExtension(fileName)

                If extention.ToLower() = ".csv" Then
                    Dim reader As New IOOperations.CsvFileIO(fileName)
                    dataserie = reader.Read_DS1()
                ElseIf extention.ToLower() = ".ds2" Then
                    Dim reader As New IOOperations.FileManager(fileName)
                    dataserie = reader.Read_DS1()
                End If

                dataserie.FileName = fileName

                result = True

            End If

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Friend Function Import_Data(ByRef dataserie As DataSerie2D) As Boolean
        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim extention As String = IO.Path.GetExtension(fileName)

            If extention.ToLower() = ".csv" Then
                Dim reader As New IOOperations.CsvFileIO(fileName)
                dataserie = reader.Read_DS2()
            ElseIf extention.ToLower() = ".ds2" Then
                Dim reader As New IOOperations.FileManager(fileName)
                dataserie = reader.Read_DS2()
            End If

            dataserie.FileName = fileName

            result = True

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Friend Function Import_Data(ByRef dataserie As DataSerie2D, ByRef fileName As String) As Boolean
        Dim result As Boolean = False
        Try

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            If IO.File.Exists(fileName) Then

                Dim extention As String = IO.Path.GetExtension(fileName)

                If extention.ToLower() = ".csv" Then
                    Dim reader As New IOOperations.CsvFileIO(fileName)
                    dataserie = reader.Read_DS2()
                ElseIf extention.ToLower() = ".ds2" Then
                    Dim reader As New IOOperations.FileManager(fileName)
                    dataserie = reader.Read_DS2()
                End If
                dataserie.FileName = fileName
                result = True

            End If

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Friend Function Export_Data(ByRef dataserie As DataSerie2D) As Boolean
        Dim result As Boolean = False
        If IsNothing(dataserie) Then Return result

        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    '.Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV"
                    .Filter = "DS2|*.DS2|CSV|*.CSV"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim extention As String = IO.Path.GetExtension(fileName)

            If extention.ToLower() = ".csv" Then
                Dim dataWriter As New IOOperations.CsvFileIO(fileName)
                result = dataWriter.Write(dataserie)
            ElseIf extention.ToLower() = ".ds2" Then
                Dim dataWriter As New IOOperations.FileManager(fileName)
                result = dataWriter.Write(dataserie)
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return result
    End Function

    Friend Function Export_Data(ByRef dataserie As DataSerie1D) As Boolean
        Dim result As Boolean = False
        If IsNothing(dataserie) Then Return result

        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    '.Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV"
                    .Filter = "DS2|*.DS2|CSV|*.CSV"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim extention As String = IO.Path.GetExtension(fileName)

            If extention.ToLower() = ".csv" Then
                Dim dataWriter As New IOOperations.CsvFileIO(fileName)
                result = dataWriter.Write(dataserie)
            ElseIf extention.ToLower() = ".ds2" Then
                Dim dataWriter As New IOOperations.FileManager(fileName)
                result = dataWriter.Write(dataserie)
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return result
    End Function

    Friend Function Export_Data(ByRef ds1 As DataSerie1D, ByRef ds2 As DataSerie1D) As Boolean
        Dim result As Boolean = False
        If IsNothing(ds1) AndAlso IsNothing(ds2) Then Return result
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    '.Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV"
                    .Filter = "DS2|*.DS2|CSV|*.CSV"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim extention As String = IO.Path.GetExtension(fileName)

            Dim dataserie As New DataSerie2D()
            Dim ds1_isNull, ds2_isNull As Boolean
            Dim ds1Count, ds2Count As Integer

            If Not Equals(ds1, Nothing) Then
                If Not Equals(ds1.Data, Nothing) Then
                    ds1_isNull = False
                    ds1Count = ds1.Count
                End If
            End If

            If Not Equals(ds2, Nothing) Then
                If Not Equals(ds2.Data, Nothing) Then
                    ds2_isNull = False
                    ds2Count = ds2.Count
                End If
            End If

            If (Not ds1_isNull) AndAlso (Not ds2_isNull) Then
                dataserie.Name = ds1.Name & "-" & ds2.Name
                dataserie.Description = ds1.Description & "-" & ds2.Description

                Dim itemsCount As Integer = Math.Min(ds1Count, ds2Count)
                For i = 0 To (itemsCount - 1)
                    dataserie.Add(String.Format("{0}-{1}", ds1.Data(i).Title, ds2.Data(i).Title), ds1.Data(i).X_Value, ds2.Data(i).X_Value)
                Next
            End If

            If extention.ToLower() = ".csv" Then
                Dim dataWriter As New IOOperations.CsvFileIO(fileName)
                result = dataWriter.Write(dataserie)
            ElseIf extention.ToLower() = ".ds2" Then
                Dim dataWriter As New IOOperations.FileManager(fileName)
                result = dataWriter.Write(dataserie)
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return result
    End Function

    Friend Function Export_Data(ByRef dataserie As DataSerieTD) As Boolean
        Dim result As Boolean = False
        If IsNothing(dataserie) Then Return result

        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .FileName = dataserie.Title
                    '.Filter = "Data Files (*.DS2, *.CSV)|*.DS2;*.CSV"
                    .Filter = "DST|*.DST|CSV|*.CSV"
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim extention As String = IO.Path.GetExtension(fileName)

            If extention.ToLower() = ".csv" Then
                Dim dataWriter As New IOOperations.CsvFileIO(fileName)
                result = dataWriter.Write(dataserie)
            ElseIf extention.ToLower() = ".ds2" Then
                'Dim dataWriter As New IOOperations.FileManager(fileName)
                'result = dataWriter.Write(dataserie)
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return result
    End Function

    Friend Function ImportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerieTD) As Boolean
        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim reader As New CsvFileIO(fileName)
            dataserie = reader.Read_DST()
            result = True

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Friend Function ImportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerie1D) As Boolean
        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim reader As New CsvFileIO(fileName)
            dataserie = reader.Read_DS1()
            result = True

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function
    Friend Function ImportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerie2D) As Boolean
        Dim result As Boolean = False
        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using openFileDlg As New OpenFileDialog
                With openFileDlg
                    .InitialDirectory = fileName
                    .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False
            Dim reader As New CsvFileIO(fileName)
            dataserie = reader.Read_DS2()
            result = True

            If IsNothing(dataserie.Data) Then Return False

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Friend Function ExportData(ByVal fileFormat As FileFormatEnum, ByRef dataserie As DataSerie1D) As Boolean
        Dim result As Boolean = False
        If IsNothing(dataserie) Then Return result

        Try
            Dim fileName As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RMOS2 Projects"
            If My.Computer.FileSystem.DirectoryExists(fileName) = False Then
                fileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            End If
            Using saveFileDlg As New SaveFileDialog
                With saveFileDlg
                    .InitialDirectory = fileName
                    .Filter = String.Format("{0} files (*.{0})|*.{0}", fileFormat.ToString())
                    .ShowDialog()
                    fileName = .FileName
                End With
            End Using

            If IsNothing(fileName) OrElse fileName = String.Empty Then Return False

            Dim dataWriter As New CsvFileIO(fileName)

            result = dataWriter.Write(dataserie)

        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

#End Region

End Module
